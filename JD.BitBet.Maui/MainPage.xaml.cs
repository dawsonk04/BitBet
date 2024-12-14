using JD.BitBet.BL.Models;
using JD.Utility;
using Newtonsoft.Json;
using System.Text;

namespace JD.BitBet.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly ApiClient _client;
        public MainPage()
        {
            InitializeComponent();
            var apiBaseUrl = "https://localhost:7061/api/";
            _client = new ApiClient(apiBaseUrl);
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text
            };

            string jsonContent = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("User/Authenticate", httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var authenticatedUser = JsonConvert.DeserializeObject<User>(responseContent);
                if (authenticatedUser != null)
                {
                    Preferences.Set("UserId", authenticatedUser.Id.ToString());

                    await Navigation.PushAsync(new GameListPage());
                    return;
                }
                else
                {
                    ErrorMessage.Text = "Error: Unable to parse user details.";
                    ErrorMessage.IsVisible = true;
                }
            }
            else
            {
                ErrorMessage.Text = $"Login failed. {response.StatusCode}: {responseContent}";
                ErrorMessage.IsVisible = true;
            }


        }

        private void OnForgotPasswordTapped(object sender, TappedEventArgs e)
        {

        }

        private void OnSignUpTapped(object sender, TappedEventArgs e)
        {

        }
    }
}
