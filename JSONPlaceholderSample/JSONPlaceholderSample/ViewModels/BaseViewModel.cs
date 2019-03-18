using Acr.UserDialogs;
using JSONPlaceholderSample.Services;
using System.ComponentModel;

namespace JSONPlaceholderSample.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly IUserDialogs UserDialog = UserDialogs.Instance;
        protected readonly IServiceClient ApiService = ServiceClient.Instance;

        protected BaseViewModel()
        {

        }
    }
}