using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Models;

namespace DynamicTabs.ViewModels
{    
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDataProvider<TabItem> tabItemsProvider;

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

        public ObservableCollection<TabItemDetail> TabItems { get; set; }

        public MainViewModel(IDataProvider<TabItem> provider)
        {
            tabItemsProvider = provider;
            tabItemsProvider.Initialize();

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

            var tabItems = tabItemsProvider.GetTabItems(selectedItem);
            foreach (TabItem item in tabItems)            
                TabItems.Add(new TabItemDetail(item));            
        }

        private List<string> GetListItems()
        {
            return tabItemsProvider.GetListItems() as List<string>;
        }        
    }
}
