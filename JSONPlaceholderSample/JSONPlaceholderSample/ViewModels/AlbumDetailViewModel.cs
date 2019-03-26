using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Models;
using JSONPlaceholderSample.Pages.Popups;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JSONPlaceholderSample.ViewModels
{
    public class AlbumDetailViewModel : BaseViewModel
    {
        public string PageTitle { get; set; }

        public ObservableCollection<Photo> Photos { get; set; }
        public Album Album { get; set; }

        //public ICommand PhotoEnlargingCommand { get; set; }

        private bool _isInit;

        public AlbumDetailViewModel(Album album)
        {
            Album = album;
            PageTitle = album.Title;

            //PhotoEnlargingCommand = new Command<Photo>(async (photo) => await PhotoEnlarging(photo));
        }

        public async Task InitData()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                UserDialog.ShowLoading(ConstantHelper.Loading);

                Photos = new ObservableCollection<Photo>(await ApiService.GetPhotos(Album.Id));

                UserDialog.HideLoading();
                
                _isInit = true;
            }
            else
            {
                await UserDialog.AlertAsync(ConstantHelper.Error, ConnectivityHelper.ConnectionErrorMessage,
                    ConstantHelper.Ok);

                CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
                {
                    if (CrossConnectivity.Current.IsConnected && !_isInit)
                        await InitData();
                };
            }
        }

        /*private async Task PhotoEnlarging(Photo photo)
        {
            await PopupNavigation.Instance.PushAsync(new PhotoDetailPage(photo, Photos));
        }*/
    }
}