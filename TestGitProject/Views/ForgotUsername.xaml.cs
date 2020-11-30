using TestGitProject.DataService;
using Xamarin.Forms;

namespace TestGitProject.Views
{
    public partial class ForgotUsername : ContentPage
    {
        AuthenticationService authService;

        public ForgotUsername()
        {
            InitializeComponent();

            authService = new AuthenticationService();
        }

        async void RequestUsername(object sender, System.EventArgs e)
        {
        
            await DisplayAlert("Alert", "Not Implemented yet..", "OK");
            await Navigation.PushAsync(new landingPage());
        }

    }
}
