using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SolverAOC2021_20
{
  public class Image
  {


    public List<List<char>> Array = new List<List<char>>();

    public Image(StringReader sr)
    {
      string line;
      while((line = sr.ReadLine()) != null) 
      {
        List<char> lTmp = new List<char>();
        lTmp.AddRange(line);
        Array.Add(lTmp);
      }

      AddBorder('.');
      AddBorder('.');
      AddBorder('.');

    }

    public void AddBorder(char c)
    {

      foreach(var line in Array)
      {
        line.Insert(0, c);
        line.Add(c);
      }
      int lineLen = Array[0].Count;

      Array.Insert(0, new List<char>());
      Array.Add(new List<char>());

      for(int i = 0; i < lineLen; i++)
      {
        Array[0].Add(c);
        Array[Array.Count - 1].Add(c);
      }
    }

    internal int GetLitCount()
    {
      return Array.Sum(x => x.Count(y => y == '#'));
    }

    public void SolveNext(string algorithm)
    {
      var arr = CreateCopyArray();
      for (int i = 1; i < Array.Count - 1; i++)
      {
        for(int j = 1; j < Array[i].Count - 1; j++)
        {
          int num = GetNumber(j, i);
          arr[i][j] = algorithm[num];
        }
      }
      Array = arr;

      AddBorder(Array[1][1]);
      ChangeSubBorder(Array[0][0]);
    }

    private void ChangeSubBorder(char c)
    {
      for(int i = 1; i < Array[i].Count - 1; i++)
      {
        Array[1][i] = c;
        Array[Array.Count - 2][i] = c;
        Array[i][1] = c;
        Array[i][Array[i].Count - 2] = c;
      }
    }

    private List<List<char>> CreateCopyArray()
    {
      List<List<char>> TmpArray = new List<List<char>>();
      for(int i = 0; i < Array.Count; i++)
      {
        TmpArray.Add(new List<char>());
        for(int j = 0; j < Array[i].Count; j++)
        {
          TmpArray[i].Add(Array[i][j]);
        }
      }
      return TmpArray;
    }

    public int GetNumber(int x, int y)
    {
      StringBuilder sb = new StringBuilder();
      for(int i = y - 1; i <= y + 1; i++)
      {
        for(int j = x - 1; j <= x + 1; j++)
        {
          sb.Append(Array[i][j] == '#' ? 1 : 0);
        }
      }
      return Convert.ToInt32(sb.ToString(), 2);
    }


    public string Print()
    {
      StringBuilder sb = new StringBuilder();
      foreach(var line in Array)
      {
        foreach(char c in line)
        {
          sb.Append(c);
        }
        sb.AppendLine();
      }
      return sb.ToString();
    }
  }
}