using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2021_19
{
  public class Vector
  {
    public int X, Y, Z;
   
    public Vector(string input)
    {
      Match m = Regex.Match(input, @"([-]{0,1}\d*),([-]{0,1}\d*),([-]{0,1}\d*)");
      X = int.Parse(m.Groups[1].Value);
      Y = int.Parse(m.Groups[2].Value);
      Z = int.Parse(m.Groups[3].Value);
    }

    public Vector(int x, int y, int z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    internal int Distance(Vector v)
    {
      return Math.Abs(X - v.X) + Math.Abs(Y - v.Y) + Math.Abs(Z - v.Z);
    }

    public Vector Copy()
    {
      return new Vector(X, Y, Z);
    }

    internal Vector RotateX()
    {
      return new Vector(X, -Z, Y);
      
    }

    internal Vector RotateY()
    {
      return new Vector(Z, Y, -X);
    }

    internal Vector RotateZ()
    {
      return new Vector(-Y, X, Z);
    }

    public override bool Equals(object obj)
    {
      if(obj is Vector v)
      {
        return
          v.X == this.X &&
          v.Y == this.Y &&
          v.Z == this.Z;
      }
      return false;
      
    }

    public override int GetHashCode()
    {
      int hc = X.GetHashCode();
      hc = 13 * hc + Y.GetHashCode();
      hc = 13 * hc + Z.GetHashCode();
      return hc;
    }

    internal Vector Move(Vector v)
    {
      return new Vector(X + v.X, Y + v.Y, Z + v.Z);
    }

    public static Vector operator- (Vector v1, Vector v2) 
    {
      return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public override string ToString()
    {
      return $"[{X,3},{Y,3},{Z,3}]";
    }
  }
}
