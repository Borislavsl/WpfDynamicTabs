using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DynamicTabs.ViewModels
{
    public class TabItemDetail
    {
        public string Header { get; set; }
        public string Content { get; set; }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        public List<string> ListItems { get; }

        private string _selectedListItem;
        public string SelectedListItem
        {
            get { return _selectedListItem; }
            set
            {
                if (_selectedListItem == value)
                    return;

                _selectedListItem = value;

                AddItemsToTab(value);

                OnPropertyChanged(nameof(SelectedListItem));                           
            }
        }

        public ObservableCollection<TabItemDetail> TabItems { get; }

        public MainViewModel()
        {
            TabItems = new ObservableCollection<TabItemDetail>();
            ListItems = GetListItems();
            SelectedListItem = ListItems[0];
        }       

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }      

        private void AddItemsToTab(string selectedItem)
        {
            TabItems.Clear();
            TabItems.Add(new TabItemDetail { Header = selectedItem + 1, Content = "The tab1  is selected" });        
            TabItems.Add(new TabItemDetail { Header = selectedItem + 2, Content = "The tab2  is selected" });        
            TabItems.Add(new TabItemDetail { Header = selectedItem + 3, Content = "The tab3  is selected" });        
        }

        private List<string> GetListItems()
        {
            var source = new List<string>();

            source.Add("Default tab");
            source.Add("Voltage Tab");

            return source;
        }        
    }
}
