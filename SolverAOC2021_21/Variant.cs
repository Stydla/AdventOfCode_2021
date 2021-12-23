using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_21
{
  public class Variant
  {

    public List<Player> Players = new List<Player>();
    public int PlayerIndexOnTurn;

    public Dictionary<Variant, int> PrevVariants = new Dictionary<Variant, int>();
    public Dictionary<Variant, int> NextVariants = new Dictionary<Variant, int>();
    public bool Solved = false;

    internal int GetID()
    {
      int res = 0;
      res = res * 100 + Players[0].Position;
      res = res * 100 + Players[0].Score;
      res = res * 100 + Players[1].Position;
      res = res * 100 + Players[1].Score;
      res = res * 100 + PlayerIndexOnTurn;
      return res;
    }

    public Variant(List<Player> players, int playerIndexOnTurn)
    {
      Players.AddRange(players);
      PlayerIndexOnTurn = playerIndexOnTurn;
    }

    internal void Solve(Variants AllVariants)
    {
      if (IsInvalidVariant() || IsWinVariant())
      {
        return;
      }
      if (Solved)
      {
        return;
      }
      Solved = true;

      for (int i = 1; i <= 3; i++)
      {
        for(int j = 1; j <= 3; j++)
        {
          for(int k = 1; k <= 3; k++)
          {
            List<Player> playersForNextTurn = new List<Player>();
            playersForNextTurn.Add(new Player(Players[0]));
            playersForNextTurn.Add(new Player(Players[1]));
            int nextPlayerTurnIndex = (PlayerIndexOnTurn + 1) % 2;

            Player currentPlayer = playersForNextTurn[PlayerIndexOnTurn];

            currentPlayer.Position = (currentPlayer.Position + i + j + k + -1) % 10 + 1;
            currentPlayer.Score = currentPlayer.Score + currentPlayer.Position;

            Variant tmp = new Variant(playersForNextTurn, nextPlayerTurnIndex);
            Variant v = AllVariants.GetOrCreateVariant(tmp);

            if (!NextVariants.ContainsKey(v))
            {
              NextVariants.Add(v, 1);
            } else
            {
              NextVariants[v]++;
            }
            if(!v.PrevVariants.ContainsKey(this))
            {
              v.PrevVariants.Add(this, 1);
            } else
            {
              v.PrevVariants[this]++;
            }

          }
        }
      }

      foreach (Variant v in NextVariants.Keys)
      {
        v.Solve(AllVariants);
      }
    }


    internal long GetCount(long paths)
    {

      if(PrevVariants.Count == 0)
      {
        return paths;
      }
      long res = 0;
      foreach(var kv in PrevVariants)
      {
        Variant v = kv.Key;
        int count = kv.Value;
        res +=  v.GetCount(paths * count);
      }
      return res ;
      
    }


    public bool IsWinVariant()
    {
      return
        (Players[0].IsWinner() && !Players[1].IsWinner()) ||
        (Players[1].IsWinner() && !Players[0].IsWinner());
    }
    private bool IsInvalidVariant()
    {
      return Players[0].IsWinner() && Players[1].IsWinner();
    }

    public override string ToString()
    {
      return $"[{Players[0]},{Players[1]},{PlayerIndexOnTurn}] ";

    }

  }
}
