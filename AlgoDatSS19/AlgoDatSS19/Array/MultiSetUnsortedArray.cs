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
      //leeres Element x wird nicht eingefügt
      if (x == 0)
      {
        return false;
      }

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
          for (int pos = i; pos < array.Length - 1; pos++)
          {
            //an Stelle x wird der letzte gefundene Wert eingetragen 
            array[i] = pos - 1;

            //letzte Position wird frei(=0) gesetzt
            array[pos - 1] = 0;
          }

          return true;
        }
      }
      return false;
    }

    //Print Funktion implementiert in SupportArray

  }
}

