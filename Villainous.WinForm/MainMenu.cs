using Villainous.Client;
using Villainous.WinForm.Enums;
using Villainous.Contracts;
using Microsoft.AspNetCore.SignalR.Client;
using Villainous.Domain;

namespace Villainous.WinForm
{
    public partial class MainMenu : Form
    {
        //TODO: add URL
#if DEBUG
        private static string _signalRHost = "https://localhost:7186/game";
#else
        private static string _signalRHost = "https://villainoussignalr20220711143214.azurewebsites.net/game";
#endif
        private readonly GameClient _client;
        private LobbyState _lobbyState = LobbyState.MainMenu;
        private readonly Random _random = new();
        private bool _closing;
        private HubConnection _connection;
        private Player _player;
        private LobbyGameState _lobbyGameState;

        public LobbyGameState LobbyGameState
        {
            get { return _lobbyGameState; }
            set
            {
                _lobbyGameState = value;
                _player = _lobbyGameState.Players.Find(p => p.Name == playerNameTxtBX.Text);
            }
        }

        public LobbyState LobbyState
        {
            get { return _lobbyState; }
            set
            {
                _lobbyState = value;
                RefreshMenu();
            }
        }

        public MainMenu(GameClient gameClient)
        {
            _client = gameClient;
            InitializeComponent();
        }
        private void RefreshMenu()
        {
            JoinPnl.Visible = _lobbyState == LobbyState.NewGame || _lobbyState == LobbyState.JoinGame;
            CreateGameBTN.Enabled = joinGameBtn.Enabled = _lobbyState == LobbyState.MainMenu;
            CreateGameBTN.Visible = joinGameBtn.Visible = _lobbyState != LobbyState.Lobby;
            playersListBx.Visible = gameCodeTextLbl.Visible = gameCodeLbl.Visible = playerReadyBtn.Visible = _lobbyState == LobbyState.Lobby;
            gameCodePanelLBL.Visible = gameCodeTxtBx.Visible = _lobbyState == LobbyState.JoinGame;
        }

        private void CreateGameBTN_Click(object sender, EventArgs e)
        {
            LobbyState = LobbyState.NewGame;
        }

        private void joinGameBtn_Click(object sender, EventArgs e)
        {
            LobbyState = LobbyState.JoinGame;
        }
        private async void JoinBtn_Click(object sender, EventArgs e)
        {
            JoinBtn.Enabled = playerNameTxtBX.Enabled = false;
            var gameCode = string.Empty;
            if (_lobbyState == LobbyState.NewGame)
            {
                gameCode = await _client.CreateGame(playerNameTxtBX.Text);
            }
            if (_lobbyState == LobbyState.JoinGame)
            {
                gameCode = await _client.JoinGame(gameCodeTxtBx.Text, playerNameTxtBX.Text);
            }
            await _connection.SendAsync("JoinGame", gameCode);
            LobbyState = LobbyState.Lobby;
            gameCodeLbl.Text = gameCode;
        }
        private async void playerReadyBtn_Click(object sender, EventArgs e)
        {
            playerReadyBtn.Visible = false;
            await _client.PlayerReady(gameCodeLbl.Text, playerNameTxtBX.Text);
            await _connection.SendAsync("PlayerReady", gameCodeLbl.Text);
        }

        private void startGameBtn_Click(object sender, EventArgs e)
        {

        }
        private async void MainMenu_Load(object sender, EventArgs e)
        {
            LobbyState = LobbyState.MainMenu;
            _connection = new HubConnectionBuilder()
                .WithUrl(_signalRHost)
                .Build();

            _connection.Closed += async (error) =>
            {
                if (!_closing)
                {
                    await Task.Delay(_random.Next(0, 5) * 1000);
                    await _connection.StartAsync();
                }
            };

            _connection.On<LobbyGameState>("ReceiveLobbyState", state =>
            {
                Invoke(() =>
                {
                    LobbyGameState = state;
                    playersListBx.Items.Clear();
                    gameCodeLbl.Text = state.GameCode;
                    foreach (var player in state.Players)
                    {
                        playersListBx.Items.Add($"{player.Name}: {(player.IsReady ? "Ready" : "Not ready")}  {(player.IsHost ? "Host" : "")}");
                    };
                    if (_player.IsHost)
                    {
                        startGameBtn.Visible = true;
                        startGameBtn.Enabled = _lobbyGameState.Players.Where(p => !p.IsReady).Count() == 0;
                    }
                });
            });

            try
            {
                while (_connection.State != HubConnectionState.Connected)
                {
                    await Task.Delay(1000);

                    try
                    {
                        await _connection.StartAsync();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Text = ex.Message;
            }
        }

        private async void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_closing)
            {
                _closing = true;
                e.Cancel = true;


                if (!string.IsNullOrWhiteSpace(gameCodeLbl.Text) && !string.IsNullOrWhiteSpace(playerNameTxtBX.Text))
                {
                    await _client.AbandoneGame(gameCodeLbl.Text, playerNameTxtBX.Text);
                    await _connection.SendAsync("JoinGame", gameCodeLbl.Text);
                }
                await _connection.StopAsync();
                Close();
            }
        }
    }
}