using Acr.UserDialogs;
using JSONPlaceholderSample.Helpers;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using JSONPlaceholderSample.Services;
using Xamarin.Forms;

namespace JSONPlaceholderSample.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly IUserDialogs UserDialog = UserDialogs.Instance;
        protected readonly IServiceClient ApiService = ServiceClient.Instance;

        private bool IsBusy { get; set; }

        protected BaseViewModel()
        {

        }
    }
}