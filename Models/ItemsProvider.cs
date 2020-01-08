using System.Collections.Generic;

namespace Models
{
    public class ItemsProvider : IDataProvider<TabItem>
    {
        public ItemsDictionary<TabItem> Items { get; private set; }

        public ItemsProvider()
        {
            Items = new ItemsDictionary<TabItem>();
        }

        public IEnumerable<string> GetListItems()
        {            
            return new List<string>(this.Items.Dictionary.Keys);
        }

        public IEnumerable<TabItem> GetTabItems(string tabKey)
        {
            return Items.Dictionary[tabKey];
        }

        public void Initialize()
        {
            Items.Dictionary = new Dictionary<string, IEnumerable<TabItem>>()
            {
                { "ListItem1", new List<TabItem>() { new TabItem("List1Tab1", "This is List1Tab1 content"), new TabItem("List1Tab2", "This is List1Tab2 content"), new TabItem("List1Tab3", "This is List1Tab3 content") } },
                { "ListItem2", new List<TabItem>() { new TabItem("List2Tab1", "This is List2Tab1 content"), new TabItem("List2Tab2", "This is List2Tab2 content") } },
                { "ListItem3", new List<TabItem>() { new TabItem("List3Tab1", "This is List3Tab1 content"), new TabItem("List3Tab2", "This is List3Tab2 content"), new TabItem("List3Tab3", "This is List3Tab3 content") } }
            };
        }
    }
}
