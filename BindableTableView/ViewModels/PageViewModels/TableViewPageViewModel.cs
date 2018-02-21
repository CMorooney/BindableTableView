using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindableTableView
{
    public class TableViewPageViewModel : INotifyPropertyChanged
    {
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
