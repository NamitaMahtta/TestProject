using System;
using System.Collections.Generic;
using TestGitProject.DataService;
using Xamarin.Forms;

namespace TestGitProject.Views
{
    public partial class ForgotPassword : ContentPage
    {
        AuthenticationService authService;
        public ForgotPassword()
        {
            InitializeComponent();
            authService = new AuthenticationService();
        }

        async void RequestPassword(object sender, System.EventArgs e)
        {
            await DisplayAlert("Alert", "Not Implemented yet..", "OK");
            await Navigation.PushAsync(new landingPage());
        }
    }
}
