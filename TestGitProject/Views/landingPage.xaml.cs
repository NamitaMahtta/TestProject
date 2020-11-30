using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestGitProject.DataService;
using TestGitProject.Interfaces;

namespace TestGitProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class landingPage : ContentPage
    {
        AuthenticationService authService;

        public landingPage()
        {
            InitializeComponent();

            authService = new AuthenticationService();
        }

        private bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(usernameEntry.Text)) return false;
            if (string.IsNullOrWhiteSpace(passwordEntry.Text)) return false;
            return true;
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (!validateForm()) { await DisplayAlert("Validation", "Please fill missing field(s)", "OK"); return; };

            bool loginSuccess = false;

            var isSuccess = await authService.AuthorizeUser(usernameEntry.Text.Trim(), passwordEntry.Text.Trim());

            loginSuccess = (isSuccess == System.Net.HttpStatusCode.OK) ? true : false;
            var mobileOS = string.Empty;
#if __IOS__
            mobileOS = "iOS";
#endif
#if __ANDROID__
            mobileOS = "Android";
#endif

            string ipStr = DependencyService.Get<IIPAddressManager>().GetIPAddress();

            var  paramsBody = new Dictionary<string, string>()
                {
                    {"uname", usernameEntry.Text.Trim()},
                    {"success", loginSuccess.ToString()},
                    {"ipAdd", ipStr},
                    {"mobileDevice", "true"},
                    {"mobileOS", mobileOS},
                };

            await authService.SubmitLoginInfo(paramsBody);

            if (isSuccess == System.Net.HttpStatusCode.OK)
            {
                App.IsUserLoggedIn = true;
                loginSuccess = true;
                await Navigation.PushModalAsync(new TestGitProject.Views.DashboardPatient.FormPage("snowy"));
            }
            else {
                await DisplayAlert("Error", "Invalid Login", "OK");
            }
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            //Go to terms and conditions page
            await Navigation.PushAsync(new TermsConditions());
        }

        async void OnForgotUsernameButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotUsername());
        }

        async void OnForgotPwdButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }

        async void OnTermConditionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermsConditions());
        }

        void OnContactUsButtonClicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.countryliving.com/life/news/g5015/positive-quotes-about-life/l"));
        }
    }
}