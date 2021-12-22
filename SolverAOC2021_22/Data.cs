using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_22
{
  class Data
  {

    public List<Cuboid> Cuboids = new List<Cuboid>();

    

    public Data(string input)
    {
      using (StringReader sr = new StringReader(input))
      {
        string line;
        while((line =sr.ReadLine()) != null)
        {
          Cuboid c = new Cuboid(line);
          Cuboids.Add(c);
        }
      }
    }

    internal long Solve1()
    {
      Cuboid masterCuboid = new Cuboid(int.MinValue, int.MaxValue, int.MinValue, int.MaxValue, int.MinValue, int.MaxValue, false);
      
      List<Cuboid> CuboidsForJoin = Cuboids.Where(x => x.IsInRegion(50)).ToList();

      for (int i = 0; i < CuboidsForJoin.Count; i++)
      {
        masterCuboid.Join(CuboidsForJoin[i]);
      }
     
      return masterCuboid.GetOnCountV2();
    }

    internal long Solve2()
    {
      Cuboid masterCuboid = new Cuboid(int.MinValue, int.MaxValue, int.MinValue, int.MaxValue, int.MinValue, int.MaxValue, false);

      
      for (int i = 0; i < Cuboids.Count; i++)
      {
        masterCuboid.Join(Cuboids[i]);
      }

      return masterCuboid.GetOnCountV2();
    }
  }
}
