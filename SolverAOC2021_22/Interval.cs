using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_22
{
  class Interval
  {
    public int A;
    public int B;

    public EIntervalType Type;


    private Interval(int a, int b, EIntervalType type)
    {
      A = a;
      B = b;
      Type = type;
    }

    public static List<Interval> CreateIntervals(int A, int B, int C, int D)
    {
      List<Interval> res = new List<Interval>();

      if(B < C)
      {
        res.Add(new Interval(A, B, EIntervalType.First));
        res.Add(new Interval(C, D, EIntervalType.Second));
      }
      if (A < B && A < C && C <= B && B < D)
      {
        res.Add(new Interval(A, C - 1, EIntervalType.First));
        res.Add(new Interval(C, B, EIntervalType.Both));
        res.Add(new Interval(B + 1, D, EIntervalType.Second));
      }
      if(A < C && B == D)
      {
        res.Add(new Interval(A, C - 1, EIntervalType.First));
        res.Add(new Interval(C, D, EIntervalType.Both));
      }
      if(A < C && D < B)
      {
        res.Add(new Interval(A, C - 1, EIntervalType.First));
        res.Add(new Interval(C, D, EIntervalType.Both));
        res.Add(new Interval(D + 1, B, EIntervalType.First));
      }
      if(A == C && D < B)
      {
        res.Add(new Interval(A, D, EIntervalType.Both));
        res.Add(new Interval(D + 1, B, EIntervalType.First));
      }
      if(C < A && B < D)
      {
        res.Add(new Interval(C, A - 1, EIntervalType.Second));
        res.Add(new Interval(A, B, EIntervalType.Both));
        res.Add(new Interval(B + 1, D, EIntervalType.Second));
      }
      if(C < A && B == D)
      {
        res.Add(new Interval(C, A - 1, EIntervalType.Second));
        res.Add(new Interval(A, B, EIntervalType.Both));
      }
      if(C < A && A <= D && D < B)
      {
        res.Add(new Interval(C, A - 1, EIntervalType.Second));
        res.Add(new Interval(A, D, EIntervalType.Both));
        res.Add(new Interval(D + 1, B, EIntervalType.First));
      }
      if(D < A) 
      {
        res.Add(new Interval(C, D, EIntervalType.Second));
        res.Add(new Interval(A, B, EIntervalType.First));
      }
      if(A == C && B == D)
      {
        res.Add(new Interval(A, B, EIntervalType.Both));
      }

      if(A == C && B < D) 
      {
        res.Add(new Interval(A, B, EIntervalType.Both));
        res.Add(new Interval(B + 1, D, EIntervalType.Second));
      }

      if(res.Count == 0)
      {
        throw new Exception($"Interval not found {A},{B},{C},{D}");
      }
      return res;

    }

  }



  public enum EIntervalType
  {
    Both,
    First,
    Second
  }
  
}
