using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_19
{
  public class Beacons
  {

    public List<Vector> BeaconList = new List<Vector>();

    public Beacons(StringReader sr)
    {
      string line = sr.ReadLine();
      while (!string.IsNullOrWhiteSpace(line))
      {
        Vector b = new Vector(line);
        BeaconList.Add(b);

        line = sr.ReadLine();
      }
    }

    private Beacons() 
    {
    }
       
    public Beacons RotateX()
    {
      Beacons res = new Beacons();
      foreach(Vector b in BeaconList)
      {
        res.BeaconList.Add(b.RotateX());
      }
      return res;
    }

    public Beacons RotateY()
    {
      Beacons res = new Beacons();
      foreach (Vector b in BeaconList)
      {
        res.BeaconList.Add(b.RotateY());
      }
      return res;
    }

    public Beacons RotateZ()
    {
      Beacons res = new Beacons();
      foreach (Vector b in BeaconList)
      {
        res.BeaconList.Add(b.RotateZ());
      }
      return res;
    }

    internal Beacons Move(Vector v)
    {
      Beacons res = new Beacons();
      foreach (Vector b in BeaconList)
      {
        res.BeaconList.Add(b.Move(v));
      }
      return res;
      
    }

    public override bool Equals(object obj)
    {
      if(obj is Beacons b)
      {
        if(b.BeaconList.Count != BeaconList.Count)
        {
          return false;
        }

        for(int i = 0; i < BeaconList.Count; i++)
        {
          if(BeaconList[i] != b.BeaconList[i])
          {
            return false;
          }
        }
        return true;
      }
      return false;
    }

    public override int GetHashCode()
    {
      int hc = 0;
      foreach(Vector v in BeaconList)
      {
        hc = (7*hc) ^ v.GetHashCode();
      }
      return base.GetHashCode();
    }

  }
}
