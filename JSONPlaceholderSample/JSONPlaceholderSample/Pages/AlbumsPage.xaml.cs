using JSONPlaceholderSample.Models;
using JSONPlaceholderSample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumsPage
    {
        private AlbumsViewModel _viewModel;

        public AlbumsPage()
        {
            _viewModel = new AlbumsViewModel();

            BindingContext = _viewModel;

            InitializeComponent();
        }

        public AlbumsPage(User user)
        {
            _viewModel = new AlbumsViewModel(user);

            BindingContext = _viewModel;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.InitData();
        }

        private async void AlbumsListView_OnItemSelected_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AlbumDetailPage((Album) e.SelectedItem));
        }
    }
}