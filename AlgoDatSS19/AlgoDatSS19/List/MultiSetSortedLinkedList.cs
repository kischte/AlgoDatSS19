using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
    class MultiSetSortedLinkedList : SupportList, IMultiSet
    {
        public override bool Insert(int node)
        {
            AddSorted(node);
            return true;
        }
    }
}
