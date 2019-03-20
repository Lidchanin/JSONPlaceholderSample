using JSONPlaceholderSample.Models;
using JSONPlaceholderSample.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodosPage
    {
        private readonly TodosPageViewModel _viewModel;

		public TodosPage ()
		{
            _viewModel = new TodosPageViewModel();

		    BindingContext = _viewModel;

			InitializeComponent ();
		}

	    public TodosPage(User user)
	    {
            _viewModel = new TodosPageViewModel(user);

	        BindingContext = _viewModel;

            InitializeComponent();
	    }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.InitData();
        }

        private async void AddButton_OnTapped(object sender, EventArgs e)
        {
            await _viewModel.AddTodo();
        }

        private async void MenuDelete_OnClicked(object sender, EventArgs e)
        {
            var todo = ((MenuItem) sender).BindingContext as Todo;
            await _viewModel.DeleteTodo(todo);
        }

        private async void Todo_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await _viewModel.UpdateTodo((Todo) e.SelectedItem);
        }
    }
}