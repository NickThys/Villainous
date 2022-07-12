
using Villainous.Client;
using Villainous.WinForm.Enums;
using Villainous.Contracts;
using Microsoft.AspNetCore.SignalR.Client;

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
        private readonly Random _random = new ();
        private bool _closing;
        private HubConnection _connection;
        public LobbyGameState LobbyGameState { get; set; }
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
            JoinPnl.Visible = _lobbyState == LobbyState.NewGame||_lobbyState==LobbyState.JoinGame;
            CreateGameBTN.Enabled= joinGameBtn.Enabled = _lobbyState == LobbyState.MainMenu;
            CreateGameBTN.Visible=joinGameBtn.Visible=_lobbyState!=LobbyState.Lobby;
            playersListBx.Visible=gameCodeTextLbl.Visible=gameCodeLbl.Visible=_lobbyState==LobbyState.Lobby;
            gameCodePanelLBL.Visible=gameCodeTxtBx.Visible=_lobbyState==LobbyState.JoinGame;
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
            JoinBtn.Enabled = playerNameTxtBX.Enabled= false;
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

        private async void MainMenu_Load(object sender, EventArgs e)
        {
            LobbyState=LobbyState.MainMenu;
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
                        playersListBx.Items.Add($"{player.Name}  ({(player.IsHost ? "Host" : "")})");
                    };
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

    }
}