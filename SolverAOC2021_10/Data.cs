using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_10
{
  class Data
  {

    public List<string> Inputs = new List<string>();

    public Data(string input)
    {

      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine())!= null)
        {
          Inputs.Add(line);
        }
      }

    }

    private void RemovePars()
    {
      for(int i = 0; i < Inputs.Count; i++)
      {
        string tmp = Inputs[i];
        string tmp2 = Inputs[i];
        while(true)
        {
          tmp2 = tmp.Replace("()", "").Replace("{}","").Replace("[]", "").Replace("<>", "");
          if(tmp2.Length == tmp.Length)
          {
            break;
          }
          tmp = tmp2;
        }

        Inputs[i] = tmp.ToString();
      }
      
    }

    public int Solve1()
    {
      RemovePars();

      int res = 0;
      for(int i = 0; i < Inputs.Count; i++)
      {
        int tmpRes = 0;
        foreach(char c in Inputs[i])
        {
          switch(c)
          {
            case ')': {
                tmpRes = 3;
                break;
              }
            case ']':
              {
                tmpRes = 57;
                break;
              }
            case '}':
              {
                tmpRes = 1197;
                break;
              }
            case '>':
              {
                tmpRes = 25137;
                break;
              }
            default:
              break;
          }
          if(tmpRes != 0)
          {
            break;
          }
        }
        res += tmpRes;
      }

      return res;
    }

    public long Solve2()
    {
      RemovePars();
      var invalid = Inputs.Where(x => x.Contains(")") || x.Contains("]") || x.Contains("}") || x.Contains(">"));
      Inputs = Inputs.Except(invalid).ToList();

      List<long> scoreList = new List<long>();


      foreach(string input in Inputs)
      {
        long points = 0;
        string pars = input;
        pars = new string(pars.Reverse().ToArray());

        foreach(char c in pars)
        {
          int val = 0;
          if (c == '(') 
          {
            val = 1;
          } else if(c == '[')
          {
            val = 2;
          }
          else if (c == '{')
          {
            val = 3;
          }
          else if (c == '<')
          {
            val = 4;
          } else
          {
            throw new Exception($"invalid par {c}");
          }

          points = (points * 5) + val;
        }
        scoreList.Add(points);
      }

      scoreList.Sort();

      return scoreList[(scoreList.Count - 1) / 2];

    }
  }
}
