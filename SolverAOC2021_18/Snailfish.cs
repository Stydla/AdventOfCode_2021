using System;
using System.Collections.Generic;
using System.Linq;

namespace SolverAOC2021_18
{
  internal class Snailfish
  {

    public int Value;


    public Snailfish Parent;
    public Snailfish Left;
    public Snailfish Right;

    public bool IsValueType
    {
      get
      {
        return Left == null && Right == null;
      }
    }

    
    public Snailfish(string input, ref int pos, Snailfish parent)
    {
      Parent = parent;
      
      char current = input[pos];
      pos++;

      switch (current)
      {
        case char n when (n >= '0' && n <= '9'):
          {
            Value = n - '0';
            break;
          }
        case '[':
          {
            Left = new Snailfish(input, ref pos, this);
            current = input[pos];
            pos++;
            if(current != ',')
            {
              throw new Exception($"Expected ,    found {current}");
            }
            Right = new Snailfish(input, ref pos, this);
            current = input[pos];
            pos++;
            if (current != ']')
            {
              throw new Exception($"Expected ]    found {current}");
            }
            break;
          }
        default:
          throw new Exception($"Invalid character {current}, pos: {pos}");
      }
    }

    public Snailfish(Snailfish left, Snailfish right)
    {
      Parent = null;
      Left = left;
      Right = right;
      left.Parent = this;
      right.Parent = this;
    }

    public Snailfish(Snailfish parent, int value)
    {
      this.Parent = parent;
      Value = value;
    }

    internal int GetMagnitude()
    {
      if(IsValueType)
      {
        return Value;
      } else
      {
        return Left.GetMagnitude() * 3 + Right.GetMagnitude() * 2;
      }
    }

    internal Snailfish Add(Snailfish snailfish)
    {
      return new Snailfish(this, snailfish);
    }

    

    internal void Reduce()
    {
      List<Func<bool>> actions = new List<Func<bool>>();
      actions.Add(ExplodeAction);
      actions.Add(SplitAction);

      bool changed = true;
      while(changed)
      {
        changed = false;

        var currentAction = actions[0];
        if(currentAction())
        {
          changed = true;
          //actions.Remove(currentAction);
          //actions.Add(currentAction);
        } else
        {
          if(actions[1]())
          {
            changed = true;
          }
        }

      }
    }

    public bool ExplodeAction()
    {
      Snailfish sf = FindFirstExplode(0);
      if(sf == null)
      {
        return false;
      }
      List<Snailfish> orderedValues = GetOrderedSnailfish();
      
      int indexL = orderedValues.IndexOf(sf.Left);
      if(indexL > 0)
      {
        orderedValues[indexL - 1].Value += sf.Left.Value;
      }
      int indexR = orderedValues.IndexOf(sf.Right);
      if (indexR < orderedValues.Count - 1)
      {
        orderedValues[indexR + 1].Value += sf.Right.Value; 
      }

      sf.Left = null;
      sf.Right = null;
      sf.Value = 0;
      
      return true;
    }


    private List<Snailfish> GetOrderedSnailfish()
    {
      if (this.IsValueType)
      {
        return new List<Snailfish>() { this };
      } else
      {
        List<Snailfish> res = new List<Snailfish>();
        res.AddRange(Left.GetOrderedSnailfish());
        res.AddRange(Right.GetOrderedSnailfish());
        return res;
      }
    }

    public bool SplitAction()
    {
      List<Snailfish> ordered = this.GetOrderedSnailfish();
      Snailfish forSplit = ordered.FirstOrDefault(x => x.Value > 9);
      if(forSplit == null)
      {
        return false;
      }


      int leftValue = forSplit.Value / 2;
      int rightValue = forSplit.Value - leftValue;
      forSplit.Left = new Snailfish(forSplit, leftValue);
      forSplit.Right = new Snailfish(forSplit, rightValue);

      return true;
    }

    public Snailfish FindFirstExplode(int depth)
    {
      if(depth >= 4 && !this.IsValueType && this.Left.IsValueType && this.Right.IsValueType)
      {
        return this;
      }
      if (IsValueType)
      {
        return null;
      }
      Snailfish res;
      res = Left.FindFirstExplode(depth + 1);

      if (res != null)
      {
        return res;
      }
      else
      {
        return Right.FindFirstExplode(depth + 1);
      }
    }


    public override string ToString()
    {
      if (IsValueType)
        return Value.ToString();

      return $"[{Left},{Right}]";
    }
  }
}