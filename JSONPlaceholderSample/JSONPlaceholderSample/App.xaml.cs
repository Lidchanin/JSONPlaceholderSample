using JSONPlaceholderSample.Helpers;
using JSONPlaceholderSample.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace JSONPlaceholderSample
{
    public partial class App
    {
        public App()
        {
            // Initialize Live Reload.
#if DEBUG
            LiveReload.Init();
#endif

            InitializeComponent();

            MainPage = new NavigationPage(new UsersPage());
        }

        protected override void OnStart()
        {
            ConnectivityHelper.InitConnectionStatus();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
