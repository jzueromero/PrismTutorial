using Prism.Navigation;
using Xamarin.Forms;

namespace PrismTuto.Views
{
    public partial class CustomMasterDetailPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public CustomMasterDetailPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation
        {
            get { return false; }
        }
    }
}
