using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostsPage : ContentPage
	{
		public PostsPage ()
		{
			InitializeComponent ();
		}

	    public PostsPage(int userId)
	    {
            InitializeComponent();
	    }
	}
}