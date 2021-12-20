using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_19
{
  public class Data
  {

    public List<Scanner> Scanners = new List<Scanner>();

    public Map Map;

    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        while(sr.Peek() != -1)
        {
          Scanner s = new Scanner(sr);
          Scanners.Add(s);
        }
      }
    }

    internal int Solve1()
    {

      Map = new Map();

      Map.Add(Scanners[0].InitialBeacons);
      Scanners[0].used = true;
      Scanners[0].ResultOffset = new Vector(0, 0, 0);

      bool changed = true;
      while(changed)
      {
        changed = false;
        bool stop = false;

        List<Scanner> unusedScanners = Scanners.Where(x => x.used == false).ToList();
        foreach(Scanner scanner in unusedScanners)
        {
          foreach(Beacons b in scanner.Variants)
          {
            foreach (Vector v1 in Map.Beacons)
            {
              foreach(Vector v2 in b.BeaconList)
              {
                Vector vRes = v1 - v2;
                Beacons bTmp = b.Move(vRes);
                List<Vector> intersect = bTmp.BeaconList.Intersect(Map.Beacons).ToList();
                if (intersect.Count >= 12)
                {
                  changed = true;
                  List<Vector> except = bTmp.BeaconList.Except(Map.Beacons).ToList();
                  Map.Add(except);
                  scanner.ResultOffset = vRes;
                  scanner.used = true;
                  stop = true; 
                }
                if (stop) break;
              }
              if (stop) break;
            }
            if (stop) break;
          }
          if (stop) break;
        }

      }

      return Map.Beacons.Count;

    }

    internal int Solve2()
    {
      Solve1();

      int maxDist = int.MinValue;
      
      foreach (Vector v1 in Scanners.Select(x => x.ResultOffset))
      {
        foreach (Vector v2 in Scanners.Select(x => x.ResultOffset))
        {
          int dist = v1.Distance(v2);
          if (dist > maxDist)
          {
            maxDist = dist;
          }

        }
      }
      return maxDist;
      

    }
  }
}
