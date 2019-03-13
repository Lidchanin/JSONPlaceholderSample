using JSONPlaceholderSample.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasePage
    {
        public readonly IServiceClient ApiService = ServiceClient.Instance;

		public BasePage ()
		{
			InitializeComponent ();
		}
	}
}