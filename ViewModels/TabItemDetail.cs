using Models;

namespace DynamicTabs.ViewModels
{
    public class TabItemDetail
    {
        public string Header { get; set; }
        public string Content { get; set; }

        public TabItemDetail()
        {
        }

        public TabItemDetail(TabItem tabitem)
        {
            Header = tabitem.Header;
            Content = tabitem.Content;
        }
    }
}
