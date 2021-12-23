using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2021_21
{
  class Data
  {

    public List<int> PlayersPos = new List<int>();
    public List<int> PlayersScore = new List<int>();
    
    public Data(string input)
    {
      //Player 1 starting position: 6
      //Player 2 starting position: 4

      using(StringReader sr = new StringReader(input))
      {
        Match m = Regex.Match(sr.ReadLine(), @"Player 1 starting position: (\d*)");
        PlayersPos.Add(int.Parse(m.Groups[1].Value));
        m = Regex.Match(sr.ReadLine(), @"Player 2 starting position: (\d*)");
        PlayersPos.Add(int.Parse(m.Groups[1].Value));
      }
      PlayersScore.Add(0);
      PlayersScore.Add(0);
    }

    public long Solve1()
    {
      int playerTurn = 0;

      int diceValue = 1;
      long turn = 0;

      while(PlayersScore.All(x=>x < 1000)) 
      {

        int currentValue = (diceValue*2 + 2) * 3 / 2;

        PlayersPos[playerTurn] = (PlayersPos[playerTurn] - 1 + currentValue) % 10 + 1;
        PlayersScore[playerTurn] += PlayersPos[playerTurn];

        turn++;
        diceValue += 3;
        playerTurn = (playerTurn + 1) % 2;
      }

      return turn * PlayersScore[playerTurn]*3;
    } 


    public long Solve2()
    {
      Player player1 = new Player(PlayersPos[0], PlayersScore[0]);
      Player player2 = new Player(PlayersPos[1], PlayersScore[1]);

      List<Player> players = new List<Player>() { player1, player2 };

      Variants variants = new Variants();
      Variant initialVariant = variants.GetOrCreateVariant(new Variant(players, 0));
      
      initialVariant.Solve(variants);


      var winVariants = variants.VariantDict.Values.Where(c => c.Players[0].IsWinner() && c.IsWinVariant()).ToList();

      long res = 0;
      foreach(Variant v in winVariants)
      {
        long tmp = v.GetCount(1);
        res += tmp;
      }

      return res;
    }
  
  }
}
