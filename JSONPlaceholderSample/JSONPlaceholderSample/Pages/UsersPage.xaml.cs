using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONPlaceholderSample.Services;
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
	}
}