using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FontSizeConverter = Xamarin.Forms.FontSizeConverter;

namespace JSONPlaceholderSample.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoSectionWithImage
    {
        #region SummaryText property

        public static readonly BindableProperty SummaryTextProperty = BindableProperty.Create(nameof(SummaryText),
            typeof(string), typeof(InfoSectionWithImage), string.Empty, BindingMode.Default);

        public string SummaryText
        {
            get => (string) GetValue(SummaryTextProperty);
            set => SetValue(SummaryTextProperty, value);
        }

        #endregion

        #region DetailsText property

        public static readonly BindableProperty DetailsTextProperty = BindableProperty.Create(nameof(DetailsText),
            typeof(string), typeof(InfoSectionWithImage), string.Empty, BindingMode.Default);

        public string DetailsText
        {
            get => (string) GetValue(DetailsTextProperty);
            set => SetValue(DetailsTextProperty, value);
        }

        #endregion

        #region DetailsFormattedText property

        public static readonly BindableProperty DetailsFormattedTextProperty = BindableProperty.Create(
            nameof(DetailsFormattedText), typeof(FormattedString), typeof(Label), null,
            BindingMode.Default);

        public FormattedString DetailsFormattedText
        {
            get => (FormattedString) GetValue(DetailsFormattedTextProperty);
            set => SetValue(DetailsFormattedTextProperty, value);
        }

        #endregion

        #region SummaryTextColor property

        public static readonly BindableProperty SummaryTextColorProperty =
            BindableProperty.Create(nameof(SummaryTextColor), typeof(Color), typeof(InfoSectionWithImage), Color.Black,
                BindingMode.Default);

        public Color SummaryTextColor
        {
            get => (Color) GetValue(SummaryTextColorProperty);
            set => SetValue(SummaryTextColorProperty, value);
        }

        #endregion

        #region DetailsTextColor property

        public static readonly BindableProperty DetailsTextColorProperty =
            BindableProperty.Create(nameof(DetailsTextColor), typeof(Color), typeof(InfoSectionWithImage), Color.Black,
                BindingMode.Default);

        public Color DetailsTextColor
        {
            get => (Color) GetValue(DetailsTextColorProperty);
            set => SetValue(DetailsTextColorProperty, value);
        }

        #endregion

        #region ImageSource property

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource),
            typeof(string), typeof(InfoSectionWithImage), null, BindingMode.Default);

        public string ImageSource
        {
            get => (string) GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        #endregion

        #region SummaryTextFontSize property

        public static readonly BindableProperty SummaryTextFontSizeProperty =
            BindableProperty.Create(nameof(SummaryTextFontSize), typeof(double), typeof(InfoSectionWithImage),
                Device.GetNamedSize(NamedSize.Small, typeof(Label)));

        [TypeConverter(typeof(FontSizeConverter))]
        public double SummaryTextFontSize
        {
            get => (double) GetValue(SummaryTextFontSizeProperty);
            set => SetValue(SummaryTextFontSizeProperty, value);
        }

        #endregion

        #region DetailsTextFontSize property

        public static readonly BindableProperty DetailsTextFontSizeProperty =
            BindableProperty.Create(nameof(DetailsTextFontSize), typeof(double), typeof(InfoSectionWithImage),
                Device.GetNamedSize(NamedSize.Small, typeof(Label)), BindingMode.Default);

        [TypeConverter(typeof(FontSizeConverter))]
        public double DetailsTextFontSize
        {
            get => (double) GetValue(DetailsTextFontSizeProperty);
            set => SetValue(DetailsTextFontSizeProperty, value);
        }

        #endregion

        #region CornerRadius property

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius),
            typeof(float), defaultValue: 0f, declaringType: typeof(InfoSectionWithImage),
            defaultBindingMode: BindingMode.Default);

        public float CornerRadius
        {
            get => (float) GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        #endregion

        #region HasShadow property

        public static readonly BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(Frame),
                false, BindingMode.Default);

        public bool HasShadow
        {
            get => (bool) GetValue(HasShadowProperty);
            set => SetValue(HasShadowProperty, value);
        }

        #endregion

        #region BackgroundColor property

        public new static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(Frame),
                Color.Transparent, BindingMode.Default);

        public new Color BackgroundColor
        {
            get => (Color) GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        #endregion

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(SummaryText):
                    SummaryLabel.Text = SummaryText;
                    break;
                case nameof(DetailsText):
                    DetailsLabel.Text = DetailsText;
                    break;
                case nameof(DetailsFormattedText):
                    DetailsLabel.FormattedText = DetailsFormattedText;
                    break;
                case nameof(SummaryTextColor):
                    SummaryLabel.TextColor = SummaryTextColor;
                    break;
                case nameof(DetailsTextColor):
                    DetailsLabel.TextColor = DetailsTextColor;
                    break;
                case nameof(ImageSource):
                    Image.Source = ImageSource;
                    break;
                case nameof(SummaryTextFontSize):
                    SummaryLabel.FontSize = SummaryTextFontSize;
                    break;
                case nameof(DetailsTextFontSize):
                    DetailsLabel.FontSize = DetailsTextFontSize;
                    break;
                case nameof(CornerRadius):
                    MainFrame.CornerRadius = CornerRadius;
                    break;
                case nameof(HasShadow):
                    MainFrame.HasShadow = HasShadow;
                    break;
                case nameof(BackgroundColor):
                    MainFrame.BackgroundColor = BackgroundColor;
                    break;
            }
        }

        public InfoSectionWithImage()
        {
            InitializeComponent();
        }
    }
}