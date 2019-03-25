using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderSample.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewWithTitle
    {
        #region Title property

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(ViewWithTitle), "");

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        #endregion

        #region ChildView property

        public static readonly BindableProperty ChildViewProperty =
            BindableProperty.Create(nameof(ChildView), typeof(View), typeof(ViewWithTitle));

        public View ChildView
        {
            get => (View) GetValue(ChildViewProperty);
            set => SetValue(ChildViewProperty, value);
        }

        #endregion

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(ChildView))
            {
                if (!ChildViewPlace.Children.Any())
                    ChildViewPlace.Children.Add(ChildView);
            }
        }

        public ViewWithTitle()
        {
            InitializeComponent();
        }
    }
}