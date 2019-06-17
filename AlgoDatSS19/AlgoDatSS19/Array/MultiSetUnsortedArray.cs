using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
  class MultiSetUnsortedArray : SupportArray, IMultiSet
  {
    public MultiSetUnsortedArray(int size) : base(size) { }

    public bool Search(int x)
    {
      //Suche Element x in Array
      for (int i = 0; i < array.Length - 1; i++)
      {
        if (array[i] == x)
        {
          return true;
        }
      }

      return false;
    }

    public bool Insert(int x)
    {
      //Element x wird an erste freie Stelle eingefügt 
      for (int i = 0; i < array.Length; i++)
      {
        if (array[i] == 0)
        {
          array[i] = x;
          return true;
        }
      }
      return false;
    }

    public bool Delete(int x)
    {
      //Suchfunktion kann Element x nicht finden
      if (Search(x) == false)
      {
        return false;
      }

      //Element x wird nach Finden gelöscht 
      for (int i = 0; i < array.Length; i++)
      {
        if (array[i] == x)
        {
          for (int pos = i; pos < array.Length -1; pos++)
          {
            //Wert x an Position i wird gelöscht 
            array[i] = 0;

            //Positionen rechts von Element x werden um eins nach links verschoben
            array[pos + 1] = array[pos];
          }

          return true;
        }
      }
      return false;
    }

    //Print Funktion implementiert in SupportArray

  }
}

