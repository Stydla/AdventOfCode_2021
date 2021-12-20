using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_20
{
  class Data
  {

    public string Algorithm;
    public Image Image;

    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        Algorithm = sr.ReadLine();
        sr.ReadLine();

        Image = new Image(sr);
        

      }
    }

    internal int Solve1()
    {
      for(int i = 0; i < 2; i++)
      {
        Image.SolveNext(Algorithm);
      }
      return Image.GetLitCount();
    }

    internal int Solve2()
    {
      for (int i = 0; i < 50; i++)
      {
        Image.SolveNext(Algorithm);
      }
      return Image.GetLitCount();
    }
  }
}
