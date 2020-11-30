using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestGitProject
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static bool IsFirstLogIn { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
