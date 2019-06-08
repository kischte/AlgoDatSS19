using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
  class SetSortedArray : MultiSetSortedArray, ISetSorted
  {
    public SetSortedArray(int size) : base(size) { }

    public new bool Insert(int x)
    {
      //leeres Element x wird nicht eingefügt
      if (x == 0) 
      {
        return false;
      }

      //Wenn Element x schon vorhanden, wird es nicht neu hinzugefügt
      if (Search(x)) 
      {
        return false;
      }


      for (int i = 0; i < array.Length; i++) 
      {
        if (array[i] > x)
        {
        //Sortiertes Einfügen von Element x an entprechender Stelle 
          for (int pos = array.Length - 1; pos >= i + 1; pos--)
          {
          //Alle Elemente rechts von x um eins nach rechts verschieben
            array[pos] = array[pos - 1];
          }
          array[i] = x;
          return true;
        }
        else if (array[i] == 0)
        {
          array[i] = x;
          return true;
        }

      }

      return false;
    }

    //Print Funktion implementiert in SupportArray
  }
}
