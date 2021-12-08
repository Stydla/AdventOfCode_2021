using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_08
{
  class DataItem
  {
    public List<string> Input;
    public List<string> Output;
    public List<Digit> Digits;

    public Dictionary<char, char> SegmentMap;
    

    public DataItem(string input)
    {
      var arr = input.Split('|');

      Input = arr[0].Trim().Split(' ').ToList();
      Output = arr[1].Trim().Split(' ').ToList();

      Digits = new List<Digit>();
      for(int i = 0; i < 10; i++)
      {
        Digits.Add(new Digit(i));
      }

      SegmentMap = new Dictionary<char, char>();
      for(char c = 'a'; c<='g'; c++)
      {
        SegmentMap.Add(c, '?');
      }
    }

    public override string ToString()
    {
      return string.Join(" ", Input) + " | " + string.Join(" ", Output);
    }

    internal void Prepare()
    {
      Input.Sort((x,y)=>x.Length - y.Length);
      Output.Sort((x, y) => x.Length - y.Length);
      
    }

    internal int Get1478Count()
    {
      return Output.Where(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7).Count(); 
    }

    internal void Solve()
    {
      Solve1();
      Solve7();
      Solve4();
      Solve8();
      Solve9();
      Solve6();
      Solve0();
      Solve2();
      Solve3();
      Solve5();
    }

    private void Solve0()
    {
      var segments = Input.Where(
       x => x.Length == 6 &&
       x.Intersect(Digits[9].Segments).Count() != 6 &&
       x.Intersect(Digits[6].Segments).Count() != 6);
      if (segments.Count() != 1)
      {
        throw new Exception("Number 0 failed");
      }
      foreach (char s in segments.First())
      {
        Digits[0].Segments.Add(s);
      }
    }

    private void Solve1()
    {
      var segments = Input.Where(x => x.Length == 2).First();
      foreach (char s in segments)
      {
        Digits[1].Segments.Add(s);
      }
    }
    private void Solve2()
    {
      var segments = Input.Where(
       x => x.Length == 5 &&
       x.Intersect(Digits[1].Segments).Count() == 1 &&
       x.Intersect(Digits[7].Segments).Count() == 2 &&
       x.Intersect(Digits[4].Segments).Count() == 2);
      if (segments.Count() != 1)
      {
        throw new Exception("Number 2 failed");
      }
      foreach (char s in segments.First())
      {
        Digits[2].Segments.Add(s);
      }
    }
    private void Solve3()
    {
      var segments = Input.Where(
       x => x.Length == 5 &&
       x.Intersect(Digits[1].Segments).Count() == 2 &&
       x.Intersect(Digits[7].Segments).Count() == 3 &&
       x.Intersect(Digits[4].Segments).Count() == 3);
      if (segments.Count() != 1)
      {
        throw new Exception("Number 3 failed");
      }
      foreach (char s in segments.First())
      {
        Digits[3].Segments.Add(s);
      }
    }
    private void Solve4()
    {
      var segments = Input.Where(x => x.Length == 4).First();
      foreach (char s in segments)
      {
        Digits[4].Segments.Add(s);
      }
    }
    private void Solve5()
    {
      var segments = Input.Where(
      x => x.Length == 5 &&
      x.Intersect(Digits[1].Segments).Count() == 1 &&
      x.Intersect(Digits[7].Segments).Count() == 2 &&
      x.Intersect(Digits[4].Segments).Count() == 3);
      if (segments.Count() != 1)
      {
        throw new Exception("Number 5 failed");
      }
      foreach (char s in segments.First())
      {
        Digits[5].Segments.Add(s);
      }
    }
    private void Solve6()
    {
      var segments = Input.Where(
        x => x.Length == 6 && 
        x.Intersect(Digits[9].Segments).Count() != 6 &&
        x.Intersect(Digits[7].Segments).Count() == 2);
      if (segments.Count() != 1)
      {
        throw new Exception("Number 6 failed");
      }
      foreach (char s in segments.First())
      {
        Digits[6].Segments.Add(s);
      }
    }
    private void Solve7()
    {
      var segments = Input.Where(x => x.Length == 3).First();
      foreach (char s in segments)
      {
        Digits[7].Segments.Add(s);
      }
      var aSegment = Digits[7].Segments.Except(Digits[1].Segments).First();
      SegmentMap['a'] = aSegment;
    }
    private void Solve8()
    {
      var segments = Input.Where(x => x.Length == 7).First();
      foreach (char s in segments)
      {
        Digits[8].Segments.Add(s);
      }
    }
    private void Solve9()
    {
      var segments = Input.Where(
        x => x.Length == 6 && 
        x.Intersect(Digits[1].Segments).Count() == 2 &&
        x.Intersect(Digits[4].Segments).Count() == 4);
      if(segments.Count() != 1)
      {
        throw new Exception("Number 9 failed");
      }
      foreach (char s in segments.First())
      {
        Digits[9].Segments.Add(s);
      }
    }

    internal int GetOutputValue()
    {
      StringBuilder number = new StringBuilder();
      foreach (string output in Output)
      {
        
        foreach(Digit d in Digits)
        {
          var intersect = output.Intersect(d.Segments);
          if (intersect.Count() == d.Segments.Count && intersect.Count() == output.Count())
          {
            number.Append(d.Number);
          }
        }
        
      }
      
      return int.Parse(number.ToString());

    }
  }
}
