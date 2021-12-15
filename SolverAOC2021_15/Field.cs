using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_15
{
  public class Field
  {

    public int X, Y, RiskLevel;

    public int TotalRiskLevel = int.MaxValue;

    public EState State;
    public Field(int x, int y, int riskLevel)
    {
      X = x;
      Y = y;
      RiskLevel = riskLevel;
      State = EState.Fresh;
    }

    public void Solve(List<List<Field>> fields)
    {
      State = EState.Closed;
      foreach(Field f in GetNeighbours(fields))
      {
        if (f.State == EState.Fresh) continue;

        int tmpRiskLevel = f.TotalRiskLevel + RiskLevel;
        if (TotalRiskLevel > tmpRiskLevel)
        {
          TotalRiskLevel = tmpRiskLevel;
          State = EState.Changed;
        }
      }
    }

    public List<Field> GetNeighbours(List<List<Field>> fields)
    {
      List<Field> res = new List<Field>();
      for (int i = -1; i <= 1; i ++)
      {
        for (int j = -1; j <= 1; j ++)
        {
          if (Math.Abs(i) == Math.Abs(j)) continue;
          int j2 = X + j;
          int i2 = Y + i;
          if (i2 < 0 || i2 >= fields.Count) continue;
          if (j2 < 0 || j2 >= fields[i2].Count) continue;
          
          res.Add(fields[i2][j2]);
        }
      }
      return res;
    }

    public override string ToString()
    {
      return $"[{X},{Y}]";
    }

    internal void Init()
    {
      TotalRiskLevel = RiskLevel;
      State = EState.Changed;
    }
  }

  public enum EState
  {
    Fresh,
    Changed,
    Closed
  }
}
