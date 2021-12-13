using System.Text.RegularExpressions;

namespace SolverAOC2021_13
{
  public class Fold
  {


    public FoldType FoldType;
    public int value;

   
    public Fold(string input)
    {
      Match m = Regex.Match(input, @"fold along ([xy])=(\d*)");
      if (m.Groups[1].Value == "x")
      {
        FoldType = FoldType.AlongX;
      } else
      {
        FoldType = FoldType.AlongY;
      }
      value = int.Parse(m.Groups[2].Value);
    }
  }

  public enum FoldType
  {
    AlongX,
    AlongY
  }
}