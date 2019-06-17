using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
  class SetUnsortedArray : MultiSetUnsortedArray, ISet
  {
    public SetUnsortedArray(int size) : base(size) { }

    public new bool Insert(int x)
    {
      //Prüfen ob Element x schon vorhanden ist, Menge -> nicht doppelt vorhanden
      if (Search(x) == true)
      {
        return false;
      }

      //Einfügen des Elements x 
      for (int i = 0; i < array.Length; i++)
      {
        //suche nach 1.freiem Feld
        if (array[i] == 0)
        {
          array[i] = x;
          return true;
        }
      }
      return false;
    }
  }
}
