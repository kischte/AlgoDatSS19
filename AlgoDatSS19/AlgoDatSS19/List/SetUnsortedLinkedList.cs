﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
    class SetUnsortedLinkedList : SupportList, ISet
    {
        public override bool Insert(int x)
        {
            if (!Search(x))   //wenn Element nicht gefunden
            {
                Enque(x);     //am Ende der Liste einreihen
                return true;
            }
            return false;     //Element schon vorhanden, nicht speichern
        }
    }
}
