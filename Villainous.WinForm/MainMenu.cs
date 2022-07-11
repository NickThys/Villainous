using Microsoft.AspNetCore.SignalR.Client;
using Villainous.Client;
using Villainous.WinForm.Enums;

namespace Villainous.WinForm
{
    public partial class MainMenu : Form
    {
        //TODO: add URL
#if DEBUG
        private static string _signalRHost = "https://localhost:7186/";
#else
        private static string _signalRHost = "https://villainoussignalr20220711143214.azurewebsites.net/";
#endif
        private readonly GameClient _client;
        private LobbyState _lobbyState = LobbyState.MainMenu;
        private readonly Random _random = new ();
        private bool _closing;
        private HubConnection _connection;

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
            gameCodeTextLbl.Visible=gameCodeLbl.Visible=_lobbyState==LobbyState.Lobby;
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
            var gameCode = string.Empty;
            if (_lobbyState == LobbyState.NewGame)
            {
                gameCode = await _client.CreateGame(playerNameTxtBX.Text);
            }
            if (_lobbyState == LobbyState.JoinGame)
            {
                gameCode = await _client.JoinGame(gameCodeTxtBx.Text, playerNameTxtBX.Text);
            }
            LobbyState = LobbyState.Lobby;
            gameCodeLbl.Text = gameCode;
        }

        private async void MainMenu_Load(object sender, EventArgs e)
        {
            LobbyState=LobbyState.MainMenu;
            _connection = new HubConnectionBuilder().WithUrl(_signalRHost).Build();

            _connection.Closed += async (error) =>
              {
                  if (!_closing)
                  {
                      await Task.Delay(_random.Next(0, 5) * 1000);
                      await _connection.StartAsync();
                  }
              };


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