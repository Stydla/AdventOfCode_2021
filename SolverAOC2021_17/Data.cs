using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_17
{
  class Data
  {
    public TargetArea TargetArea;

    public Data(string input)
    {
      TargetArea = new TargetArea(input);
    }

    internal int Solve1()
    {

      List<Probe> ProbesWithHit = new List<Probe>();

      for(int i = 0; i < TargetArea.X2; i++)
      {
        for(int j = 0; j < 20; j++)
        {
          Velocity v = new Velocity(j, i);
          Coords c = new Coords(0, 0);

          Probe p = new Probe(c, v);
          if(SimulateProble(p, 10000))
          {
            ProbesWithHit.Add(p);
          }
        }
      }
      return ProbesWithHit.Max(x => x.MaxY);
    }


    internal int Solve2()
    {

      List<Probe> ProbesWithHit = new List<Probe>();

      for (int i = TargetArea.Y1; i < TargetArea.X2; i++)
      {
        for (int j = 0; j <= TargetArea.X2; j++)
        {
          Velocity v = new Velocity(j, i);
          Coords c = new Coords(0, 0);

          Probe p = new Probe(c, v);
          if (SimulateProble(p, 10000))
          {
            ProbesWithHit.Add(p);
          }

        }
      }

      return ProbesWithHit.Count;
    }

    private bool SimulateProble(Probe p, int steps)
    {
      for(int i = 0; i < steps; i++)
      {
        p.Move();
        if(TargetArea.TestHit(p))
        {
          return true;
        }
        if(TargetArea.IsOut(p))
        {
          return false;
        }
      }
      return false;
    }

  }
}
