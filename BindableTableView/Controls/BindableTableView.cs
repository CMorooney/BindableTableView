using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace BindableTableView
{
    public class BindableTableView : TableView
    {
        public BindableTableView ()
        {
            Root = new TableRoot();
            Intent = TableIntent.Settings;
        }

        void AddSectionToTable(IEnumerable<TableSectionViewModel> viewModels)
        {
            if (Root != null)
            {
                foreach (var viewModel in viewModels)
                {
                    Root.Add(viewModel.TableSection);
                }
            }
        }

        void RemoveSectionFromTable(IEnumerable<TableSectionViewModel> viewModels)
        {
            if (Root != null)
            {
                foreach (var viewModel in viewModels)
                {
                    Root.Remove(viewModel.TableSection);
                }
            }
        }

        #region EventHandlers

        void SectionsSet()
        {
            if (Sections != null)
            {
                Sections.CollectionChanged += SectionsChanged;

                if (Sections.Count > 0)
                {
                    var p = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                                                                 new List<TableSectionViewModel>(Sections));
                    SectionsChanged(Sections, p);
                }
            }
        }

        void SectionsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                AddSectionToTable(e.NewItems.Cast<TableSectionViewModel>());
            }

            if (e.OldItems != null)
            {
                RemoveSectionFromTable(e.OldItems.Cast<TableSectionViewModel>());
            }

        }

        #endregion

        #region Properties

        public ObservableCollection<TableSectionViewModel> Sections
        {
            get { return (ObservableCollection<TableSectionViewModel>)GetValue(SectionsProperty); }
            set { SetValue(SectionsProperty, value); }
        }

        #endregion

        #region Bindable properties

        public static BindableProperty SectionsProperty =
            BindableProperty.Create(nameof(Sections), typeof(ObservableCollection<TableSectionViewModel>), typeof(BindableTableView), null, BindingMode.OneWay, null,
                                    (bindable, oldValue, newValue) =>
                                    {
                                        (bindable as BindableTableView).SectionsSet();
                                    });


        #endregion
    }
}