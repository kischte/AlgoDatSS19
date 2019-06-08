using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
  class MultiSetSortedArray : SupportArray, IMultiSetSorted
  {
    public MultiSetSortedArray(int size) : base(size) { }

    public bool Search(int x)
    {
      int l, r, i;
      l = 0;
      r = array.Length - 1;

      do
      {
        i = (l + r) / 2;
        if (array[i] < x)
        {
          l = i + 1;
        }

        else
        {
          r = i - 1;
        }

      } while (array[i] != x && l < r);

      if (array[i] == x)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool Insert(int x)
    {
      //leeres Element x wird nicht eingefügt
      if (x == 0)
      {
        return false;
      }
      //Sortiertes Einfügen von Element x in Array 
      for (int i = 0; i < array.Length; i++)
      {
        if (array[i] >= x)
        {
          for (int pos = array.Length - 1; pos >= i + 1; pos--)
          {
            //Verschiebung aller Elemente > x um eins nach rechts
            array[pos] = array[pos - 1];
          }
          array[i] = x;

          return true;
        }

        //Falls das Array leer ist, füge x an Position 0 ein 
        else if (array[i] == 0)
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

      for (int i = 0; i < array.Length; i++)
      {
        if (array[i] == x)
        {
          for (int pos = i; pos < array.Length - 1; pos++)
          {
            //Verschieben der Elemente ab Position x um eins nach links
            array[pos] = array[pos + 1];
            array[pos + 1] = 0;
          }
          return true;
        }
      }
      return false;
    }
    //Print Funktion implementiert in SupportArray
  }
}
