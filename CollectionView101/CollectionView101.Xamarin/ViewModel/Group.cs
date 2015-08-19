using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionView101
{
    public class Group : ObservableCollection<Item>
    {
        public Group(string groupName, IEnumerable<Item> items)
            : base(items)
        {
            GroupName = groupName;
        }
        public string GroupName { get; set; }
    }
}
