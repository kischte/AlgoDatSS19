using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
  interface IDictionary
  {
    bool Search(int x);
    bool Insert(int x);
    bool Delete(int x);
    void Print();
  }
}
