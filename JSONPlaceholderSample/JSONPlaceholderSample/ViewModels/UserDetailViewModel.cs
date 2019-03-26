using Acr.UserDialogs;
using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Models;
using Plugin.Connectivity;
using System.Threading.Tasks;

namespace JSONPlaceholderSample.ViewModels
{
    public class UserDetailViewModel : BaseViewModel
    {
        public User User { get; set; }
        public int PostsCount { get; set; }
        public int AlbumsCount { get; set; }
        public int TodosCount { get; set; }

        private bool _isInit;

        public UserDetailViewModel(User user)
        {
            User = user;
        }

        public async Task InitData()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                UserDialog.ShowLoading(ConstantHelper.Loading);
                AlbumsCount = await ApiService.GetAlbumsCountForCurrentUser(User.Id);
                TodosCount = await ApiService.GetTodosCountForCurrentUser(User.Id);
                PostsCount = await ApiService.GetPostsCountForCurrentUser(User.Id);
                UserDialog.HideLoading();

                _isInit = true;
            }
            else
            {
                await UserDialog.AlertAsync(new AlertConfig
                {
                    Title = ConstantHelper.Error,
                    Message = ConnectivityHelper.ConnectionErrorMessage,
                    OkText = ConstantHelper.Ok,
                });

                CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
                {
                    if (CrossConnectivity.Current.IsConnected && !_isInit)
                        await InitData();
                };
            }
        }
    }
}