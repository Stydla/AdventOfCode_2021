using System.Collections.Generic;

namespace SolverAOC2021_08
{
  internal class Digit
  {
    public int Number;
    public List<char> Segments = new List<char>();

    public Digit(int number)
    {
      Number = number;
    }
  }
}