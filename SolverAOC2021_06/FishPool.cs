using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_06
{
  public class FishPool
  {

    public List<long> FishCounts = new List<long>();
    public int Round;

    public const int TOTAL_STATES = 9;

    public FishPool(FishPool fp)
    {
      Init();

      for(int i = 0; i < TOTAL_STATES; i++)
      {
        FishCounts[i] = fp.FishCounts[(i + 1) % TOTAL_STATES];
      }

      FishCounts[6] += fp.FishCounts[0];

    }

    public FishPool(List<int> initialFishes)
    {
      Init();
      foreach(int fish in initialFishes)
      {
        FishCounts[fish]++;
      }
    }

    private void Init()
    {
      for (int i = 0; i < TOTAL_STATES; i++) 
      {
        FishCounts.Add(0);
      }
    }

    public long GetFishCount()
    {
      return FishCounts.Sum();
    }

  }
}
