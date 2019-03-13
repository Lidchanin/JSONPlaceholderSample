using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Models;

namespace JSONPlaceholderSample.ViewModels
{
    public class UsersPageViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public UsersPageViewModel()
        {
            Users = new ObservableCollection<User>();
        }

        public async Task InitData()
        {
            Users = new ObservableCollection<User>();
            UserDialog.ShowLoading(ConstantHelper.Loading);
            Users = new ObservableCollection<User>(await ApiService.GetUsers());
            UserDialog.HideLoading();
        }
    }
}