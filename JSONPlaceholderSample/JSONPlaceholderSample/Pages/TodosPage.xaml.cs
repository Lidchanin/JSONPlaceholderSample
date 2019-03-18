using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodosPage : ContentPage
	{
		public TodosPage ()
		{
			InitializeComponent ();
		}

	    public TodosPage(int userId)
	    {
            InitializeComponent();
	    }
	}
}