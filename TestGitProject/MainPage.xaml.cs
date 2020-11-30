using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestGitProject
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            SizeChanged += MainPageSizeChanged;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void MainPageSizeChanged(object sender, EventArgs e)
        {
        }
    }
}
