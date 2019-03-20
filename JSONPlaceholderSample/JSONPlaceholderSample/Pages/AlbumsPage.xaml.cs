using JSONPlaceholderSample.Models;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlbumsPage
    {
        public AlbumsPage ()
		{
			InitializeComponent ();
		}

	    public AlbumsPage(User user)
	    {
            InitializeComponent();
	    }
	}
}