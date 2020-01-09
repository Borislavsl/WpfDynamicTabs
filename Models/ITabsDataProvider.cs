using System.Collections.Generic;

namespace Models
{
    public interface ITabsDataProvider<T>
    {
        IEnumerable<T> GetTabItems(string tabKey);
        IEnumerable<string> GetListItems();

        void Initialize();
    }
}
