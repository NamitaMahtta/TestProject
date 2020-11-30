using System;
using System.Collections.Generic;
using TestGitProject.DataService;
using Xamarin.Forms;

namespace TestGitProject.Views
{
    public partial class aboutPageInfo : ContentPage
    {
        DataOperation dataOperation;
        public aboutPageInfo()
        {
            InitializeComponent();
            dataOperation = new DataOperation();
        }

        void links(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://ut.medicalhomeportal.org"));
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                string location = "test";
                var response = await dataOperation.GetImageFromServer(location);
            }

            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }
    }
}
