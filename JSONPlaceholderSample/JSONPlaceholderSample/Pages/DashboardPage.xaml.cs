using System;
using Xamarin.Forms;

namespace JSONPlaceholderSample.Pages
{
    public partial class DashboardPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage(), true);
        }
    }
}
