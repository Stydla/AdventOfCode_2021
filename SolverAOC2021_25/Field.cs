using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_25
{
  public class Field
  {

    public int X, Y;
    public Cucumber Cucumber;


    private Dictionary<EDirection, Field> Neighbours = new Dictionary<EDirection, Field>();

    public Field(int x, int y)
    {
      X = x;
      Y = y;
    }

    public Field GetNeighbour(EDirection direction)
    {
      return Neighbours[direction];
    }

    public void SetNeighbour(EDirection direction, Field field)
    {
      if(Neighbours.ContainsKey(direction))
      {
        throw new Exception($"Neighbour already set {direction}");
      }

      Neighbours.Add(direction, field);
    }

    internal char Print()
    {
      if(Cucumber == null)
      {
        return '.';
      } else
      {
        return Cucumber.Print();
      }
    }
  }

  public enum EDirection
  {
    UP,
    DOWN,
    LEFT,
    RIGHT
  }
}
