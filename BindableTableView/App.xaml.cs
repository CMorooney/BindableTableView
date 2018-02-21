using Xamarin.Forms;

namespace BindableTableView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TableViewPage();
        }
    }
}
