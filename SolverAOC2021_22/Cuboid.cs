using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2021_22
{
  public class Cuboid
  {

    public int X_Min, X_Max;
    public int Y_Min, Y_Max;
    public int Z_Min, Z_Max;

    public bool On;

    public List<Cuboid> SubCuboids = new List<Cuboid>();

    public Cuboid(string line)
    {
      //on x=30018..52561,y=6820..20726,z=63544..81739

      Match m = Regex.Match(line, @"(on|off) x=([-]?\d*)\.\.([-]?\d*),y=([-]?\d*)\.\.([-]?\d*),z=([-]?\d*)\.\.([-]?\d*)");
      On = m.Groups[1].Value == "on";
      X_Min = int.Parse(m.Groups[2].Value);
      X_Max = int.Parse(m.Groups[3].Value);
      Y_Min = int.Parse(m.Groups[4].Value);
      Y_Max = int.Parse(m.Groups[5].Value);
      Z_Min = int.Parse(m.Groups[6].Value);
      Z_Max = int.Parse(m.Groups[7].Value);
    }

    internal bool IsInRegion(int size)
    {
      return
        X_Min >= -size &&
        X_Max <= size &&
        Y_Min >= -size &&
        Y_Max <= size &&
        Y_Min >= -size &&
        Y_Max <= size;
    }

    internal void Join(Cuboid joinedCuboid)
    {
      if (!IsColide(joinedCuboid)) return;

      if(SubCuboids.Count > 0)
      {
        foreach(Cuboid subC in SubCuboids)
        {
          subC.Join(joinedCuboid);
        }
        return;
      }

      CuboidMergeResult mergeResult = Merge(joinedCuboid);
      this.SubCuboids.AddRange(mergeResult.FromFirst);
      this.SubCuboids.AddRange(mergeResult.FromBoth);
    }

    private bool IsColide(Cuboid c)
    {
      List<Interval> intX = Interval.CreateIntervals(X_Min, X_Max, c.X_Min, c.X_Max);
      List<Interval> intY = Interval.CreateIntervals(Y_Min, Y_Max, c.Y_Min, c.Y_Max);
      List<Interval> intZ = Interval.CreateIntervals(Z_Min, Z_Max, c.Z_Min, c.Z_Max);

      if (
      !(intX.Any(x => x.Type == EIntervalType.Both) &&
      intY.Any(x => x.Type == EIntervalType.Both) &&
      intZ.Any(x => x.Type == EIntervalType.Both))
      )
      {
        return false;
      }
      return true;
    }

    internal long GetOnCountV2()
    {
      
      if(SubCuboids.Count > 0)
      {
        long res = 0;
        foreach(Cuboid c in SubCuboids)
        {
          res += c.GetOnCountV2();
        }
        return res;
      }

      long onCount = GetOnCount();
      return onCount;
    }


    private List<Cuboid> GetEndCuboids()
    {
      if(SubCuboids.Count == 0)
      {
        return new List<Cuboid>() { this };
      }
      List<Cuboid> res = new List<Cuboid>();
      foreach(Cuboid c in SubCuboids)
      {
        res.AddRange(c.GetEndCuboids());
      }
      return res;
    }

    private CuboidMergeResult Merge(Cuboid c)
    {
      CuboidMergeResult res = new CuboidMergeResult();

      List<Interval> intX = Interval.CreateIntervals(X_Min, X_Max, c.X_Min, c.X_Max);
      List<Interval> intY = Interval.CreateIntervals(Y_Min, Y_Max, c.Y_Min, c.Y_Max);
      List<Interval> intZ = Interval.CreateIntervals(Z_Min, Z_Max, c.Z_Min, c.Z_Max);

      foreach(var i1 in intX)
      {
        foreach(var i2 in intY)
        {
          foreach(var i3 in intZ)
          {
            if(i1.Type == EIntervalType.Both &&
              i2.Type == EIntervalType.Both &&
              i3.Type == EIntervalType.Both)
            {
              Cuboid cTmp = new Cuboid(i1.A, i1.B, i2.A, i2.B, i3.A, i3.B, c.On);
              res.FromBoth.Add(cTmp);
              continue;
            }
            //i1
            if(i1.Type == EIntervalType.First &&
              (i2.Type == EIntervalType.First || i2.Type == EIntervalType.Both) &&
              (i3.Type == EIntervalType.First || i3.Type == EIntervalType.Both))
            {
              Cuboid cTmp = new Cuboid(i1.A, i1.B, i2.A, i2.B, i3.A, i3.B, On);
              res.FromFirst.Add(cTmp);
              continue;
            }
            if (i1.Type == EIntervalType.Second &&
              (i2.Type == EIntervalType.Second || i2.Type == EIntervalType.Both) &&
              (i3.Type == EIntervalType.Second || i3.Type == EIntervalType.Both))
            {
              Cuboid cTmp = new Cuboid(i1.A, i1.B, i2.A, i2.B, i3.A, i3.B, On);
              res.FromSecond.Add(cTmp);
              continue;
            }

            //i2
            if (i2.Type == EIntervalType.First &&
              (i1.Type == EIntervalType.First || i1.Type == EIntervalType.Both) &&
              (i3.Type == EIntervalType.First || i3.Type == EIntervalType.Both))
            {
              Cuboid cTmp = new Cuboid(i1.A, i1.B, i2.A, i2.B, i3.A, i3.B, On);
              res.FromFirst.Add(cTmp);
              continue;
            }
            if (i2.Type == EIntervalType.Second &&
              (i1.Type == EIntervalType.Second || i1.Type == EIntervalType.Both) &&
              (i3.Type == EIntervalType.Second || i3.Type == EIntervalType.Both))
            {
              Cuboid cTmp = new Cuboid(i1.A, i1.B, i2.A, i2.B, i3.A, i3.B, On);
              res.FromSecond.Add(cTmp);
              continue;
            }

            //i3
            if (i3.Type == EIntervalType.First &&
              (i1.Type == EIntervalType.First || i1.Type == EIntervalType.Both) &&
              (i2.Type == EIntervalType.First || i2.Type == EIntervalType.Both))
            {
              Cuboid cTmp = new Cuboid(i1.A, i1.B, i2.A, i2.B, i3.A, i3.B, On);
              res.FromFirst.Add(cTmp);
              continue;
            }
            if (i3.Type == EIntervalType.Second &&
              (i1.Type == EIntervalType.Second || i1.Type == EIntervalType.Both) &&
              (i2.Type == EIntervalType.Second || i2.Type == EIntervalType.Both))
            {
              Cuboid cTmp = new Cuboid(i1.A, i1.B, i2.A, i2.B, i3.A, i3.B, On);
              res.FromSecond.Add(cTmp);
              continue;
            }

          }
        }
      }

      return res;
    }

    public Cuboid(Cuboid c) : this(c.X_Min, c.X_Max, c.Y_Min, c.Y_Max, c.Z_Min, c.Z_Max, c.On)
    {
    }

    public Cuboid(int xMin, int xMax, int yMin, int yMax, int zMin, int zMax, bool on)
    {
      X_Min = xMin;
      X_Max = xMax;
      Y_Min = yMin;
      Y_Max = yMax;
      Z_Min = zMin;
      Z_Max = zMax;
      On = on;
    }


    public long GetOnCount()
    {
      if(On)
      {
        return Volume();
      }
      return 0;
      
    }

    public override string ToString()
    {
      return $"[{X_Min},{X_Max}][{Y_Min},{Y_Max}][{Z_Min},{Z_Max}]";
    }

    public long Volume()
    {
      return (long)(X_Max - X_Min + 1) * (long)(Y_Max - Y_Min + 1) * (long)(Z_Max - Z_Min + 1);
    }

    public override bool Equals(object obj)
    {
      if(obj is Cuboid c)
      {
        return
          c.X_Min == X_Min &&
          c.X_Max == X_Max &&
          c.Y_Min == Y_Min &&
          c.Y_Max == Y_Max &&
          c.Z_Min == Z_Min &&
          c.Z_Max == Z_Max;
      }
      return false;
    }

    public override int GetHashCode()
    {
      int hash = X_Min;
      hash = hash * 7 + X_Max;
      hash = hash * 7 + Y_Min;
      hash = hash * 7 + Y_Max;
      hash = hash * 7 + Z_Min;
      hash = hash * 7 + Z_Max;
      return base.GetHashCode();
    }

  }
}
