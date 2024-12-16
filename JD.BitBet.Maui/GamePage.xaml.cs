using JD.BitBet.BL.Models;
using JD.Utility;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace JD.BitBet.Maui
{
    public partial class GamePage : ContentPage
    {
        private readonly ApiClient _client;
        public ObservableCollection<GameState> GameStates { get; set; }
        public Game CurrentGame { get; set; }

        public ICommand HitCommand { get; set; }
        public ICommand StandCommand { get; set; }
        public ICommand DoubleCommand { get; set; }

        public GamePage(Guid gameId)
        {
            InitializeComponent();
            var apiBaseUrl = "https://localhost:7061/api/";
            _client = new ApiClient(apiBaseUrl);
            GameStates = new ObservableCollection<GameState>();
            BindingContext = this;

            HitCommand = new Command<GameState>(PerformHit);
            StandCommand = new Command<GameState>(PerformStand);
            DoubleCommand = new Command<GameState>(PerformDouble);

            LoadGameState(gameId);
        }

        private async void PerformHit(GameState gameState)
        {
            await PerformActionAsync("hit", gameState);
            if (CurrentGame.isGameOver)
            { 
                var response2 = await _client.GetAsync($"GameState/{gameState.Id}");
                if (response2.IsSuccessStatusCode)
                {
                    var responseContent2 = await response2.Content.ReadAsStringAsync();
                    var gameStates = JsonConvert.DeserializeObject<GameState>(responseContent2);
                    await DisplayAlert("Finished Game", $"The Game is over {gameStates.message}", "OK");
                }
            }
        }

        private async void PerformStand(GameState gameState)
        {
            await PerformActionAsync("stand", gameState);
            if (CurrentGame.isGameOver)
            {
                var response1 = await _client.PostAsync($"Game/dealerTurn/{gameState.dealerHandId}", null);
                var responseContent1 = await response1.Content.ReadAsStringAsync();

                var response = await _client.GetAsync($"GameState/{gameState.Id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var gameStates = JsonConvert.DeserializeObject<GameState>(responseContent);
                    await DisplayAlert("Finished Game", $"The Game is over {gameStates.message}", "OK");
                }
            }
        }

        private async void PerformDouble(GameState gameState)
        {
            await PerformActionAsync("double", gameState);
            if (CurrentGame.isGameOver)
            {
                var response = await _client.GetAsync($"GameState/{gameState.Id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var gameStates = JsonConvert.DeserializeObject<GameState>(responseContent);
                    await DisplayAlert("Finished Game", $"The Game is over {gameStates.message}", "OK");
                }
            }
        }

        private async Task PerformActionAsync(string action, GameState gameState)
        {
            if (gameState == null)
            {
                await DisplayAlert("Error", "gamestate null", "Ok");
                return;
            }

            try
            {
                var userId = Preferences.Get("UserId", null);
                if (string.IsNullOrEmpty(userId))
                {
                    await DisplayAlert("Error", "Please log in first", "OK");
                    return;
                }

                var endpoint = $"Game/{action}/{userId}";

                var response = await _client.PostAsync(endpoint, null);

                if (response.IsSuccessStatusCode)
                {
                    await LoadGameState(CurrentGame.Id);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Error", $"Failed to perform '{action}': {errorContent}", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private async Task LoadGameState(Guid gameId)
        {
            try
            {
                var response = await _client.GetAsync($"Game/loadstate/{gameId}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var gameStates = JsonConvert.DeserializeObject<List<GameState>>(responseContent);
                    GameStates.Clear();
                    foreach (var state in gameStates)
                    {
                        if (!state.isGameOver)
                        {
                            GameStates.Add(state);
                        }
                    }

                    var gameResponse = await _client.GetAsync($"Game/{gameId}");
                    if (gameResponse.IsSuccessStatusCode)
                    {
                        var gameContent = await gameResponse.Content.ReadAsStringAsync();
                        CurrentGame = JsonConvert.DeserializeObject<Game>(gameContent);
                        if (GameStates.Count == 0)
                        {
                            CurrentGame.isGameOver = true;
                        }
                        if (CurrentGame.isGameOver)
                        {
                            btnStartGame.IsVisible = true;
                        }
                    }
                }
                else
                {
                    ShowError("Unable to fetch game state.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }

        private async void OnActionClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string action)
            {
                var userId = Preferences.Get("UserId", null);
                if (string.IsNullOrEmpty(userId))
                {
                    await DisplayAlert("Error", "Please log in first", "OK");
                    return;
                }

                if (action == "start" && CurrentGame != null && !CurrentGame.isGameOver)
                {
                    await DisplayAlert("Error", "You are already in a game cannot start another one sorry. Finish this game", "OK");
                    return;
                }

                try
                {
                    var endpoint = action == "start"
                        ? $"Game/{action}/{CurrentGame.Id}"
                        : $"Game/{action}/{CurrentGame.Id}/{userId}";

                    var response = await _client.PostAsync(endpoint, null);

                    if (response.IsSuccessStatusCode)
                    {
                        await LoadGameState(CurrentGame.Id);
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        await DisplayAlert("Error", $"Unable to perform action '{action}': {errorContent}", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                }
            }
        }

        private void ShowError(string message)
        {
            ErrorMessage.Text = message;
            ErrorMessage.IsVisible = true;
        }
    }
}
