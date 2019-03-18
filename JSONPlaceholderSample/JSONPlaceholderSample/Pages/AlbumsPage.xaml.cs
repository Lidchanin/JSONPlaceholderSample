using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlbumsPage : ContentPage
	{
        public AlbumsPage ()
		{
			InitializeComponent ();
		}

	    public AlbumsPage(int userId)
	    {
            InitializeComponent();
	    }
	}
}