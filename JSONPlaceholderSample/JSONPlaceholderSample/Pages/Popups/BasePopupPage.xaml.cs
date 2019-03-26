using Acr.UserDialogs;
using JSONPlaceholderSample.Services;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasePopupPage
	{
	    public readonly IServiceClient ApiService = ServiceClient.Instance;
	    public readonly IUserDialogs UserDialog = UserDialogs.Instance;

        public BasePopupPage ()
		{
			InitializeComponent ();
		}
	}
}