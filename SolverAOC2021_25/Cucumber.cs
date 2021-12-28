using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_25
{
  public class Cucumber
  {
    public ECucumberType Type;

    public Field Field;
    public Cucumber(char input, Field field)
    {
      switch(input)
      {
        case '>':
          {
            Type = ECucumberType.East;
            break;
          }
        case 'v':
          {
            Type = ECucumberType.South;
            break;
          }
        default:
          throw new Exception($"Cucumber type not found: {input}");
      }

      Field = field;
    } 

    public void Move()
    {
      switch(Type)
      {
        case ECucumberType.East:
          {
            Field tmp = Field.GetNeighbour(EDirection.RIGHT);
            tmp.Cucumber = this;
            this.Field.Cucumber = null;
            this.Field = tmp;
            break;
          }
        case ECucumberType.South:
          {
            Field tmp = Field.GetNeighbour(EDirection.DOWN);
            tmp.Cucumber = this;
            this.Field.Cucumber = null;
            this.Field = tmp;
            break;
          }
      }
    }

    internal char Print()
    {
      switch(Type)
      {
        case ECucumberType.East:
          return '>';
        case ECucumberType.South:
          return 'v';
        default:
          throw new Exception();
      }
      
    }

    public bool CanMove()
    {
      switch (Type)
      {
        case ECucumberType.East:
          {
            Field rightNeighbour = Field.GetNeighbour(EDirection.RIGHT);
            if (rightNeighbour.Cucumber == null)
            {
              return true;
            }
            else
            {
              return false;
            }          }
        case ECucumberType.South:
          {
            Field downNeighbour = Field.GetNeighbour(EDirection.DOWN);
            Field downLeftNeighbour = downNeighbour.GetNeighbour(EDirection.LEFT);
            if (downNeighbour.Cucumber == null)
            {
              if(downLeftNeighbour.Cucumber == null || downLeftNeighbour.Cucumber.Type == ECucumberType.South)
              {
                return true;
              } else
              {
                return false;
              }
            } else
            {
              Field downRightNeighbour = downNeighbour.GetNeighbour(EDirection.RIGHT);
              if (downNeighbour.Cucumber.Type == ECucumberType.East && downRightNeighbour.Cucumber == null)
              {
                return true;
              }
              return false;
            }
          }
        default:
          throw new Exception($"Invalid cucumber type: {Type}");
      }
      throw new Exception("Invalid can move");
    }
  }
}
