using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindableTableView
{
    public class TableViewPageViewModel : INotifyPropertyChanged
    {
        public TableViewPageViewModel()
        {
            TableSections = new ObservableCollection<TableSectionViewModel>
            {
                new TableSectionViewModel
                {
                    TableSection = new TableSection("here's one")
                    {
                        new SwitchCell { Text = "Should I?" },
                        new EntryCell { Text = "Why I should" }
                    }
                }
            };

            DoBindingTestForTableView();
        }

        async void DoBindingTestForTableView()
        {
            await Task.Delay(5000);

            TableSections.Add(
                new TableSectionViewModel
                {
                    TableSection = new TableSection("5 seconds later")
                    {
                    new SwitchCell { Text = "I've added another" }
                    }
                }
            );

            await Task.Delay(5000);

            TableSections.RemoveAt(0);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<TableSectionViewModel> _tableSections;
        public ObservableCollection<TableSectionViewModel> TableSections
        {
            get { return _tableSections; }
            set
            {
                _tableSections = value;
                NotifyPropertyChanged();
            }
        }

        void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
