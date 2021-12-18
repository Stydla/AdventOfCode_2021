using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_18
{
  internal class Data
  {

    public List<Snailfish> SnailfishList = new List<Snailfish>();

    public List<string> Inputs = new List<string>();

    public Data (string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          Inputs.Add(line);
          Snailfish sf = CreateSnailfish(line);
          SnailfishList.Add(sf);
        }
      }
    }

    private Snailfish CreateSnailfish(string line)
    {
      int pos = 0;
      Snailfish sf = new Snailfish(line, ref pos, null);
      return sf;
    }

    internal int Solve1()
    {
      Snailfish tmp = SnailfishList[0];
      for(int i = 1; i < SnailfishList.Count; i++)
      {
        tmp = tmp.Add(SnailfishList[i]);
        tmp.Reduce();
      }

      return tmp.GetMagnitude();
    }

    internal int Solve2()
    {

      int max = int.MinValue;

      for(int i = 0; i < Inputs.Count; i++)
      {
        for(int j = 0; j < Inputs.Count; j++)
        {
          if (i == j) continue;
          Snailfish sf1 = CreateSnailfish(Inputs[i]);
          Snailfish sf2 = CreateSnailfish(Inputs[j]);
          
          Snailfish res = sf1.Add(sf2);
          res.Reduce();
          int mag = res.GetMagnitude();
          if(res.GetMagnitude() > max)
          {
            max = mag;
          }

        }
      }
      return max;

    }
  }
}
