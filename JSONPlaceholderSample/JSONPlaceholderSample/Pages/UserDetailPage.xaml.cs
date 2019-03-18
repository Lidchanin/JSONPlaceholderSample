using JSONPlaceholderSample.Models;
using JSONPlaceholderSample.ViewModels;
using System;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetailPage
    {
        private readonly UserDetailPageViewModel _viewModel;
        private readonly User _user;

		public UserDetailPage (User user)
		{
            _viewModel = new UserDetailPageViewModel(user);
		    _user = user;

		    BindingContext = _viewModel;

			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.InitData();
        }

        private async void PostsLabel_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostsPage(_user.Id));
        }

        private async void AlbumsLabel_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlbumsPage(_user.Id));
        }

        private async void TodosLabel_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodosPage(_user.Id));
        }
    }
}