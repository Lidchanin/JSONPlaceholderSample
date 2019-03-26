using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Models;
using Plugin.Connectivity;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JSONPlaceholderSample.ViewModels
{
    public class AlbumsViewModel : BaseViewModel
    {
        public string PageTitle { get; set; }
        public ObservableCollection<Album> Albums { get; set; }

        private bool _isInit;
        private readonly User _user;

        public AlbumsViewModel()
        {
            _user = null;
            PageTitle = ConstantHelper.AllAlbums;
        }

        public AlbumsViewModel(User user)
        {
            _user = user;
            PageTitle = $"{_user.Username}'s albums";
        }

        public async Task InitData()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                UserDialog.ShowLoading(ConstantHelper.Loading);

                Albums = _user == null
                    ? new ObservableCollection<Album>(await ApiService.GetAlbums())
                    : new ObservableCollection<Album>(await ApiService.GetAlbums(_user.Id));

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
