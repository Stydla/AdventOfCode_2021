using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_23
{
  public class Data
  {

    public Map InitialMap;

    public Dictionary<string, int> Maps = new Dictionary<string, int>();

    public Data(string input)
    {
      InitialMap = new Map(input);
    }


    public int Solve1()
    {
      int res = InitialMap.Solve1(Maps);
      return res;
    }

    public int Solve2()
    {
      int res = InitialMap.Solve2(Maps);
      return res;
    }
  }
}
