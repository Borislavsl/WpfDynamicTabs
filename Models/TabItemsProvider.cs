using System.Collections.Generic;

namespace Models
{
    public class TabItemsProvider : ITabsDataProvider<TabItem>
    {       
        public Dictionary<string, IEnumerable<TabItem>> DictionaryItems;

        public TabItemsProvider()
        {            
            DictionaryItems = new Dictionary<string, IEnumerable<TabItem>>();
        }

        public IEnumerable<string> GetListItems()
        {            
            return new List<string>(this.DictionaryItems.Keys);
        }

        public IEnumerable<TabItem> GetTabItems(string tabKey)
        {
            return DictionaryItems[tabKey];
        }

        public void Initialize()
        {
            int listItemsLength = 3;
            var tabItemsLength = new int[] { 3, 2, 3 };
           
            for (int i = 0; i < listItemsLength; i++)
            {
                var tabItems = new List<TabItem>();
                for (int j = 0; j < tabItemsLength[i]; j++)
                {
                    string header = $"List{i+1}Tab{j+1}";
                    tabItems.Add(new TabItem(header, $"This is {header} content"));
                }

                DictionaryItems.Add($"ListItem{i+1}", tabItems);
            }
        }
    }
}
