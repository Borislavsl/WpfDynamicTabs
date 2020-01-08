using System.Collections.Generic;

namespace Models
{
    public class ItemsDictionary<T>
    {
        public Dictionary<string, IEnumerable<T>> Dictionary { get; set; }      
    }
}
