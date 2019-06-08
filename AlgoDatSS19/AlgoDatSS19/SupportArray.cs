using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
  class SupportArray
  {
    public int[] array;

    public SupportArray(int size)
    {
      this.array = new int[size];
    }

    public void Print()
    {
      for (int i = 0; i < array.Length; i++)
      {
        if (array[i] == 0)
        {
          Console.Write("[ ]" + " ");
        }
        else
        {
          Console.Write("[" + array[i] + "]" + " ");
        }
      }
    }
  }
}
