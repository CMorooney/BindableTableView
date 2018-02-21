using Xamarin.Forms;

namespace BindableTableView
{
    public partial class TableViewPage : ContentPage
    {
        public TableViewPage()
        {
            BindingContext = new TableViewPageViewModel();

            InitializeComponent();
        }
    }
}
