using JSONPlaceholderSample.Models;
using JSONPlaceholderSample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UsersPage
	{
	    private readonly UsersPageViewModel _viewModel;

		public UsersPage ()
		{
            _viewModel = new UsersPageViewModel();

		    BindingContext = _viewModel;

			InitializeComponent ();
		}

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();
	        await _viewModel.InitData();
	    }

	    private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        await Navigation.PushAsync(new UserDetailPage((User) e.SelectedItem), true);
        }
    }
}