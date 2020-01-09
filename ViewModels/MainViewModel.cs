using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Models;

namespace DynamicTabs.ViewModels
{    
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ITabsDataProvider<TabItem> tabItemsProvider;

        public List<string> ListItems { get; set; }

        private string selectedListItem;
        public string SelectedListItem
        {
            get { return selectedListItem; }
            set
            {
                if (selectedListItem == value)
                    return;

                selectedListItem = value;

                AddItemsToTab(value);

                OnPropertyChanged(nameof(SelectedListItem));                           
            }
        }

        public ObservableCollection<TabItemDetail> TabItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(ITabsDataProvider<TabItem> provider)
        {
            tabItemsProvider = provider;
            tabItemsProvider.Initialize();

            TabItems = new ObservableCollection<TabItemDetail>();
            ListItems = GetListItems();
            SelectedListItem = ListItems[0];
        }      

        private void AddItemsToTab(string selectedItem)
        {
            TabItems.Clear();

            var tabItems = tabItemsProvider.GetTabItems(selectedItem);
            foreach (TabItem item in tabItems)            
                TabItems.Add(new TabItemDetail(item));            
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<string> GetListItems()
        {
            return tabItemsProvider.GetListItems() as List<string>;
        }        
    }
}
