namespace SolverAOC2021_13
{
  public class Dot
  {
    public int X, Y;

    public Dot(string input)
    {
      string[] arr = input.Split(',');
      X = int.Parse(arr[0]);
      Y = int.Parse(arr[1]);
    }


    public override bool Equals(object obj)
    {
      if(obj is Dot dot)
      {
        return X == dot.X && Y == dot.Y;
      }
      return false;
    }

    public override int GetHashCode()
    {
      return 1;
    }

  }

  
}