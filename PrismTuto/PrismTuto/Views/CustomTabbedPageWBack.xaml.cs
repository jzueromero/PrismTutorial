using Xamarin.Forms;

namespace PrismTuto.Views
{
    public partial class CustomTabbedPageWBack : TabbedPage
    {
        private bool _isTabPageVisible;


        public static readonly BindableProperty SelectedTabIndexProperty =
    BindableProperty.Create(
        nameof(SelectedTabIndex),
        typeof(int),
        typeof(CustomTabbedPageWBack), 0,
        BindingMode.TwoWay, null,
        propertyChanged: OnSelectedTabIndexChanged);
        static void OnSelectedTabIndexChanged
            (BindableObject bindable, object oldValue, object newValue)
        {
            if (((CustomTabbedPageWBack)bindable)._isTabPageVisible)
            {
                // update the Selected Child-Tab page 
                // only if Tabbed Page is visible..
                ((CustomTabbedPageWBack)bindable).CurrentPage
                = ((CustomTabbedPageWBack)bindable).Children[(int)newValue];
            }
        }
        public int SelectedTabIndex
        {
            get { return (int)GetValue(SelectedTabIndexProperty); }
            set { SetValue(SelectedTabIndexProperty, value); }
        }



        public CustomTabbedPageWBack()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _isTabPageVisible = true;
            this.CurrentPage = this.Children[SelectedTabIndex];
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _isTabPageVisible = false;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            SelectedTabIndex = this.Children.IndexOf(this.CurrentPage);
        }
    }
}
