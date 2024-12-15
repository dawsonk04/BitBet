using JD.BitBet.BL.Models;
using JD.Utility;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace JD.BitBet.Maui
{
    public partial class GameListPage : ContentPage
    {
        private readonly ApiClient _client;
        public ObservableCollection<Game> Games { get; set; }

        public GameListPage()
        {
            InitializeComponent();
            var apiBaseUrl = "https://localhost:7061/api/";
            _client = new ApiClient(apiBaseUrl);
            Games = new ObservableCollection<Game>();
            BindingContext = this;
            LoadGames();
        }

        private async void LoadGames()
        {
            try
            {
                var response = await _client.GetAsync("Game/");

                if (response.IsSuccessStatusCode)
                {
                    var gamesJson = await response.Content.ReadAsStringAsync();
                    var gamesList = JsonConvert.DeserializeObject<List<Game>>(gamesJson);

                    foreach (var game in gamesList)
                    {
                        Games.Add(game);
                    }

                    GamesCollectionView.ItemsSource = Games;
                }
                else
                {
                    ErrorMessage.Text = "Unable to fetch games.";
                    ErrorMessage.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = $"Error: {ex.Message}";
                ErrorMessage.IsVisible = true;
            }
        }

        private async void OnJoinGameClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Guid gameId)
            {
                var userId = Preferences.Get("UserId", null);
                if (string.IsNullOrEmpty(userId))
                {
                    await DisplayAlert("Error", "Please log in first", "OK");
                    return;
                }

                try
                {
                    var joinResponse = await _client.PostAsync($"Game/join/{gameId}/{userId}", null);

                    if (joinResponse.IsSuccessStatusCode)
                    {
                        if (Guid.TryParse(gameId.ToString(), out Guid parsedGameId))
                        {
                            await Navigation.PushAsync(new GamePage(parsedGameId));
                        }
                    }
                    else
                    {
                        var errorContent = await joinResponse.Content.ReadAsStringAsync();
                        await DisplayAlert("Error", $"Unable to join game: {errorContent}", "OK");
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