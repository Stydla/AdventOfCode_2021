using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_06
{
  public class Data
  {

    public List<int> Input;
    public FishPool FishPoolInitial;

    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        string line = sr.ReadLine();
        var arr = line.Split(',');
        Input = new List<int>();

        foreach (string num in arr)
        {
          int val = int.Parse(num);
          Input.Add(val);
        }
      }

      FishPoolInitial = new FishPool(Input);

    }


    public long Solve1()
    {
      FishPool fpTmp = FishPoolInitial;
      for(int i = 0; i < 80; i++)
      {
        fpTmp = new FishPool(fpTmp);
      }

      return fpTmp.GetFishCount();
    }

    internal long Solve2()
    {
      FishPool fpTmp = FishPoolInitial;
      for (int i = 0; i < 256; i++)
      {
        fpTmp = new FishPool(fpTmp);
      }

      return fpTmp.GetFishCount();
    }
  }
}
