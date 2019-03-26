using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JSONPlaceholderSample.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public UsersViewModel()
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