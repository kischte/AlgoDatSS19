using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDSPraktikum
{
    class SetUnsortedList : BaseLinkedList, ISet
    {
        public override bool Insert(int element)
        {
            if (!Search(element))
            {
                Enque(element);
                return true;
            }
            return false;
        }
    }
}
