using System;
using System.Collections.Generic;

namespace SolverAOC2021_19
{
  public class Map
  {

    public List<Vector> Beacons = new List<Vector>();

    internal void Add(Beacons beacons)
    {
      Add(beacons.BeaconList);
    }

    internal void Add(List<Vector> beacons)
    {
      foreach (var b in beacons)
      {
        Beacons.Add(b.Copy());
      }
    }

  }
}