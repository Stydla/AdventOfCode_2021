using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2021_17
{
  class TargetArea
  {

    public int X1, X2;
    public int Y1, Y2;

    public TargetArea(string input)
    {
      //target area: x=155..215, y=-132..-72
      Match m = Regex.Match(input, @"target area: x=(\d*)\.\.(\d*), y=-(\d*)\.\.-(\d*)");

      X1 = int.Parse(m.Groups[1].Value);
      X2 = int.Parse(m.Groups[2].Value);
      Y1 = - int.Parse(m.Groups[3].Value);
      Y2 = - int.Parse(m.Groups[4].Value);
    }

    internal bool TestHit(Probe p)
    {
      return
        p.Coords.X >= X1 &&
        p.Coords.X <= X2 &&
        p.Coords.Y >= Y1 &&
        p.Coords.Y <= Y2;
        
    }
  }
}
