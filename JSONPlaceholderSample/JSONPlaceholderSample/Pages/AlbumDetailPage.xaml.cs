using JSONPlaceholderSample.Models;
using JSONPlaceholderSample.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlbumDetailPage
    {
        private readonly Album _album;
        private readonly AlbumDetailPageViewModel _viewModel;

		public AlbumDetailPage (Album album)
		{
		    _album = album;
            _viewModel = new AlbumDetailPageViewModel(album);

		    BindingContext = _viewModel;

		    InitializeComponent();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.InitData();
            FillPhotosLayout();
        }

        private void FillPhotosLayout()
        {
            var photos = _viewModel.Photos;
            foreach (var photo in photos)
            {
                PhotosLayout.Children.Add(new Image
                {
                    Margin = 5,
                    HeightRequest = 75,
                    WidthRequest = 75,
                    Source = ImageSource.FromUri(new Uri(photo.ThumbnailUrl))
                });
            }
        }
    }
}