using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_07
{
  class Data
  {

    List<int> Input;

    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        string line = sr.ReadLine();
        var arr = line.Split(',');
        Input = new List<int>(arr.Select(x=>int.Parse(x)));
      }

    }

    public int Solve1()
    {
      int res = int.MaxValue;
      
      for (int i = Input.Min(); i <= Input.Max(); i++)
      {
        int resTmp = 0;
        foreach (int val in Input)
        {
          resTmp += Math.Abs(i - val);
        }

        if (resTmp < res)
        {
          res = resTmp;
        }
      }
      return res;
    }


    public int Solve2()
    {
      int res = int.MaxValue;

      for (int i = Input.Min(); i <= Input.Max(); i++)
      {
        int resTmp = 0;
        foreach (int val in Input)
        {
          int dist = Math.Abs(i - val);
          int fuel = ((1 + dist) * dist) / 2;
          resTmp += fuel;
        }

        if (resTmp < res)
        {
          res = resTmp;
        }
      }
      return res;
    }

  }
}
