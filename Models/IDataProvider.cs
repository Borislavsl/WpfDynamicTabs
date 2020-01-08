using System.Collections.Generic;

namespace Models
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetTabItems(string tabKey);
        IEnumerable<string> GetListItems();

        void Initialize();
    }
}
