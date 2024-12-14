using JD.BitBet.BL.Models;
using JD.Utility;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace JD.BitBet.Maui
{
    public partial class GamePage : ContentPage
    {
        private readonly ApiClient _client;
        public ObservableCollection<GameState> GameStates { get; set; }
        public Game CurrentGame { get; set; }

        public GamePage(Guid gameId)
        {
            InitializeComponent();
            var apiBaseUrl = "https://localhost:7061/api/";
            _client = new ApiClient(apiBaseUrl);
            GameStates = new ObservableCollection<GameState>();
            BindingContext = this;
            LoadGameState(gameId);
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
                        GameStates.Add(state);
                    }

                    var gameResponse = await _client.GetAsync($"Game/{gameId}");
                    if (gameResponse.IsSuccessStatusCode)
                    {
                        var gameContent = await gameResponse.Content.ReadAsStringAsync();
                        CurrentGame = JsonConvert.DeserializeObject<Game>(gameContent);
                    }
                }
                else
                {
                    ErrorMessage.Text = "Unable to fetch game state.";
                    ErrorMessage.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = $"Error: {ex.Message}";
                ErrorMessage.IsVisible = true;
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

                try
                {
                    var response = await _client.PostAsync($"Game/{action}/{CurrentGame.Id}/{userId}", null);

                    if (response.IsSuccessStatusCode)
                    {
                        // Refresh the game state after the action
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

    }
}
