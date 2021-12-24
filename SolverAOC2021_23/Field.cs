using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_23
{
  public class Field
  {
    public char Value;
    public bool IsFinal;
    public bool Locked = false;
    public char Target;

    public Dictionary<Field, ConnectData> Neighbours = new Dictionary<Field, ConnectData>();
    
    public Field(char c, bool isFinal, char target)
    {
      Value = c;
      IsFinal = isFinal;
      Target = target;
    }

    public void Join(Field f, List<Field> goOverFields, int length, List<Field> mustBeLocked)
    {
      f.Neighbours.Add(this, new ConnectData() { Fields = goOverFields, Value = length});
      this.Neighbours.Add(f, new ConnectData() { Fields = goOverFields, Value = length, MustBeCorrect = mustBeLocked });
    }

    internal int Move(Field neighbour)
    {
      neighbour.Value = Value;
      Value = '.';

      switch (neighbour.Value) 
      {
        case 'A':
          return 1 * Neighbours[neighbour].Value;
        case 'B':
          return 10 * Neighbours[neighbour].Value;
        case 'C':
          return 100 * Neighbours[neighbour].Value;
        case 'D':
          return 1000 * Neighbours[neighbour].Value;
        default:
          throw new Exception($"Invalid Move {neighbour.Value}");

      }      
    }

    public override string ToString()
    {
      return Value.ToString();
    }

    internal bool CanMove(Field neighbour)
    {
      if (neighbour.Locked) return false;
      if (neighbour.Target != '.') 
      {
        if (neighbour.Target != this.Value) return false;
      }
      if (neighbour.Value != '.') return false;
      ConnectData cd = Neighbours[neighbour];
      if (!cd.MustBeCorrect.All(x => x.Value == x.Target))
      {
        return false;
      }
      return cd.Fields.All(x => x.Value == '.');
    }
  }

  public class ConnectData
  {
    public List<Field> Fields = new List<Field>();
    public int Value;
    public List<Field> MustBeCorrect = new List<Field>();
  }
}
