using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_08
{
  class Data
  {

    public List<DataItem> Items;

    public Data(string input)
    {
      Items = new List<DataItem>();
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine())!= null)
        {
          DataItem di = new DataItem(line);
          Items.Add(di);
        }
      }
    }

    internal int Solve1()
    {
      int total = 0;
      foreach(DataItem di in Items)
      {
        int cnt = di.Get1478Count();
        total += cnt;
      }
      return total;
    }

    internal void Test()
    {
      foreach(DataItem di in Items)
      {
        di.Prepare();
        Console.WriteLine(di);
      }
    }

    internal int Solve2()
    {
      int total = 0;
      foreach (DataItem di in Items)
      {
        di.Solve();
        int output = di.GetOutputValue();
        total += output;
        
      }
      return total;
    }
  }
}
