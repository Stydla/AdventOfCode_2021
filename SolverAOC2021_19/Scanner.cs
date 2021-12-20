using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2021_19
{
  public class Scanner
  {
    public string Name;
    public Beacons InitialBeacons;

    public List<Beacons> Variants = new List<Beacons>();

    public bool used = false;

    public Vector ResultOffset;
    public int ResultVariant;

    public Scanner(StringReader sr)
    {
      Name = sr.ReadLine();
      InitialBeacons = new Beacons(sr);

      Beacons tmpBeacons = InitialBeacons;
      for(int i = 0; i < 4; i++)
      {
        Variants.Add(tmpBeacons);
        tmpBeacons = tmpBeacons.RotateX();
      }

      tmpBeacons = tmpBeacons.RotateZ();
      for (int i = 0; i < 4; i++)
      {
        Variants.Add(tmpBeacons);
        tmpBeacons = tmpBeacons.RotateY();
      }

      tmpBeacons = tmpBeacons.RotateZ();
      for (int i = 0; i < 4; i++)
      {
        Variants.Add(tmpBeacons);
        tmpBeacons = tmpBeacons.RotateX();
      }

      tmpBeacons = tmpBeacons.RotateZ();
      for (int i = 0; i < 4; i++)
      {
        Variants.Add(tmpBeacons);
        tmpBeacons = tmpBeacons.RotateY();
      }

      tmpBeacons = tmpBeacons.RotateX();
      for (int i = 0; i < 4; i++)
      {
        Variants.Add(tmpBeacons);
        tmpBeacons = tmpBeacons.RotateZ();
      }

      tmpBeacons = tmpBeacons.RotateX();
      tmpBeacons = tmpBeacons.RotateX();
      for (int i = 0; i < 4; i++)
      {
        Variants.Add(tmpBeacons);
        tmpBeacons = tmpBeacons.RotateZ();
      }

      var VariantsCheck = Variants.Distinct().ToList();
      if(VariantsCheck.Count < Variants.Count)
      {
        throw new Exception("Same variant found multiple times");
      }

    }


  }
}
