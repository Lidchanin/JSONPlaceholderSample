using JSONPlaceholderSample.Models;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostsPage
    {
		public PostsPage ()
		{
			InitializeComponent ();
		}

	    public PostsPage(User user)
	    {
            InitializeComponent();
	    }
	}
}