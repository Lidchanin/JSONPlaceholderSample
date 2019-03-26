using JSONPlaceholderSample.Models;
using JSONPlaceholderSample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UsersPage
	{
	    private readonly UsersViewModel _viewModel;

		public UsersPage ()
		{
            _viewModel = new UsersViewModel();

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