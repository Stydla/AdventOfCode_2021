using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_21
{
  public class Player
  {
    public int Score;
    public int Position;

    public Player(int position, int score)
    {
      Score = score;
      Position = position;
    }

    public Player(Player player) : this(player.Position, player.Score)
    {
    }

    internal bool IsWinner()
    {
      return Score >= 21;
    }

    public override string ToString()
    {
      return $"[{Position,2},{Score,2}]";

    }
  }
}
