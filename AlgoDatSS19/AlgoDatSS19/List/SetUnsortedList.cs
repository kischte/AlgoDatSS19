using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
    class SetUnsortedList : SupportList, ISet
    {
        public override bool Insert(int x)
        {
            if (!Search(x))
            {
                Enque(x);
                return true;
            }
            return false;
        }
    }
}
