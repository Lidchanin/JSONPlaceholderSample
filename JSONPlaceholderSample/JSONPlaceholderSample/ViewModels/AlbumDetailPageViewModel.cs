using System.Collections.Generic;
using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Models;
using Plugin.Connectivity;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JSONPlaceholderSample.ViewModels
{
    public class AlbumDetailPageViewModel : BaseViewModel
    {
        public string PageTitle { get; set; }

        public ObservableCollection<Photo> Photos { get; set; }
        public Album Album { get; set; }

        private bool _isInit;

        public AlbumDetailPageViewModel(Album album)
        {
            Album = album;
            PageTitle = album.Title;
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

          
    }
}