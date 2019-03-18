using Acr.UserDialogs;
using JSONPlaceholderSample.Services;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasePage
    {
        public readonly IServiceClient ApiService = ServiceClient.Instance;
        public readonly IUserDialogs UserDialog = UserDialogs.Instance;

		public BasePage ()
		{
			InitializeComponent ();
		}
	}
}