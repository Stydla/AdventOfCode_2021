using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_23
{
  public class Map
  {
    public string Input;

    public List<Field> Fields = new List<Field>();

    public int Energy;

    public static string FINAL_ID = ".......ABCDABCD";
    public static string FINAL_ID2 = ".......ABCDABCDABCDABCD";

    public string final;
    public Map (string input)
    {
      Input = input;
    }

    private void Create1()
    {

      for (int i = 0; i < 7; i++)
      {
        Field f = new Field('.', false, '.');
        Fields.Add(f);
      }


      using (StringReader sr = new StringReader(Input))
      {
        sr.ReadLine();
        sr.ReadLine();

        Field f;
        string line = sr.ReadLine();
        string vals = line.Replace("#", "");

        f = new Field(vals[0], true, 'A');
        Fields.Add(f);

        f = new Field(vals[1], true, 'B');
        Fields.Add(f);

        f = new Field(vals[2], true, 'C');
        Fields.Add(f);

        f = new Field(vals[3], true, 'D');
        Fields.Add(f);

        line = sr.ReadLine();
        vals = line.Replace("#", "").Replace(" ", "");

        f = new Field(vals[0], true, 'A');
        Fields.Add(f);

        f = new Field(vals[1], true, 'B');
        Fields.Add(f);

        f = new Field(vals[2], true, 'C');
        Fields.Add(f);

        f = new Field(vals[3], true, 'D');
        Fields.Add(f);
        /*
#############
#01.2.3.4.56#
###7#8#9#a###
  #b#c#d#e#
  #########
 * */
        Fields[0].Join(Fields[7], new List<Field>() { Fields[1] }, 3, new List<Field>() { Fields[11] });
        Fields[0].Join(Fields[8], new List<Field>() { Fields[1], Fields[2] }, 5, new List<Field>() { Fields[12] });
        Fields[0].Join(Fields[9], new List<Field>() { Fields[1], Fields[2], Fields[3] }, 7, new List<Field>() { Fields[13] });
        Fields[0].Join(Fields[10], new List<Field>() { Fields[1], Fields[2], Fields[3], Fields[4] }, 9, new List<Field>() { Fields[14] });

        Fields[0].Join(Fields[11], new List<Field>() { Fields[7], Fields[1] }, 4, new List<Field>());
        Fields[0].Join(Fields[12], new List<Field>() { Fields[8], Fields[1], Fields[2] }, 6, new List<Field>());
        Fields[0].Join(Fields[13], new List<Field>() { Fields[9], Fields[1], Fields[2], Fields[3] }, 8, new List<Field>());
        Fields[0].Join(Fields[14], new List<Field>() { Fields[10], Fields[1], Fields[2], Fields[3], Fields[4] }, 10, new List<Field>());



        Fields[1].Join(Fields[7], new List<Field>() { }, 2, new List<Field>() { Fields[11] });
        Fields[1].Join(Fields[8], new List<Field>() { Fields[2] }, 4, new List<Field>() { Fields[12] });
        Fields[1].Join(Fields[9], new List<Field>() { Fields[2], Fields[3] }, 6, new List<Field>() { Fields[13] });
        Fields[1].Join(Fields[10], new List<Field>() { Fields[2], Fields[3], Fields[4] }, 8, new List<Field>() { Fields[14] });

        Fields[1].Join(Fields[11], new List<Field>() { Fields[7], }, 3, new List<Field>());
        Fields[1].Join(Fields[12], new List<Field>() { Fields[8], Fields[2] }, 5, new List<Field>());
        Fields[1].Join(Fields[13], new List<Field>() { Fields[9], Fields[2], Fields[3] }, 7, new List<Field>());
        Fields[1].Join(Fields[14], new List<Field>() { Fields[10], Fields[2], Fields[3], Fields[4] }, 9, new List<Field>());



        Fields[2].Join(Fields[7], new List<Field>() { }, 2, new List<Field>() { Fields[11] });
        Fields[2].Join(Fields[8], new List<Field>() { }, 2, new List<Field>() { Fields[12] });
        Fields[2].Join(Fields[9], new List<Field>() { Fields[3] }, 4, new List<Field>() { Fields[13] });
        Fields[2].Join(Fields[10], new List<Field>() { Fields[3], Fields[4] }, 6, new List<Field>() { Fields[14] });

        Fields[2].Join(Fields[11], new List<Field>() { Fields[7] }, 3, new List<Field>());
        Fields[2].Join(Fields[12], new List<Field>() { Fields[8] }, 3, new List<Field>());
        Fields[2].Join(Fields[13], new List<Field>() { Fields[9], Fields[3] }, 5, new List<Field>());
        Fields[2].Join(Fields[14], new List<Field>() { Fields[10], Fields[3], Fields[4] }, 7, new List<Field>());



        Fields[3].Join(Fields[7], new List<Field>() { Fields[2] }, 4, new List<Field>() { Fields[11] });
        Fields[3].Join(Fields[8], new List<Field>() { }, 2, new List<Field>() { Fields[12] });
        Fields[3].Join(Fields[9], new List<Field>() { }, 2, new List<Field>() { Fields[13] });
        Fields[3].Join(Fields[10], new List<Field>() { Fields[4] }, 4, new List<Field>() { Fields[14] });

        Fields[3].Join(Fields[11], new List<Field>() { Fields[7], Fields[2] }, 5, new List<Field>());
        Fields[3].Join(Fields[12], new List<Field>() { Fields[8] }, 3, new List<Field>());
        Fields[3].Join(Fields[13], new List<Field>() { Fields[9] }, 3, new List<Field>());
        Fields[3].Join(Fields[14], new List<Field>() { Fields[10], Fields[4] }, 5, new List<Field>());



        Fields[4].Join(Fields[7], new List<Field>() { Fields[3], Fields[2] }, 6, new List<Field>() { Fields[11] });
        Fields[4].Join(Fields[8], new List<Field>() { Fields[3] }, 4, new List<Field>() { Fields[12] });
        Fields[4].Join(Fields[9], new List<Field>() { }, 2, new List<Field>() { Fields[13] });
        Fields[4].Join(Fields[10], new List<Field>() { }, 2, new List<Field>() { Fields[14] });

        Fields[4].Join(Fields[11], new List<Field>() { Fields[7], Fields[3], Fields[2] }, 7, new List<Field>());
        Fields[4].Join(Fields[12], new List<Field>() { Fields[8], Fields[3] }, 5, new List<Field>());
        Fields[4].Join(Fields[13], new List<Field>() { Fields[9] }, 3, new List<Field>());
        Fields[4].Join(Fields[14], new List<Field>() { Fields[10] }, 3, new List<Field>());



        Fields[5].Join(Fields[7], new List<Field>() { Fields[4], Fields[3], Fields[2] }, 8, new List<Field>() { Fields[11] });
        Fields[5].Join(Fields[8], new List<Field>() { Fields[4], Fields[3] }, 6, new List<Field>() { Fields[12] });
        Fields[5].Join(Fields[9], new List<Field>() { Fields[4] }, 4, new List<Field>() { Fields[13] });
        Fields[5].Join(Fields[10], new List<Field>() { }, 2, new List<Field>() { Fields[14] });

        Fields[5].Join(Fields[11], new List<Field>() { Fields[7], Fields[4], Fields[3], Fields[2] }, 9, new List<Field>());
        Fields[5].Join(Fields[12], new List<Field>() { Fields[8], Fields[4], Fields[3] }, 7, new List<Field>());
        Fields[5].Join(Fields[13], new List<Field>() { Fields[9], Fields[4] }, 5, new List<Field>());
        Fields[5].Join(Fields[14], new List<Field>() { Fields[10] }, 3, new List<Field>());



        Fields[6].Join(Fields[7], new List<Field>() { Fields[5], Fields[4], Fields[3], Fields[2] }, 9, new List<Field>() { Fields[11] });
        Fields[6].Join(Fields[8], new List<Field>() { Fields[5], Fields[4], Fields[3] }, 7, new List<Field>() { Fields[12] });
        Fields[6].Join(Fields[9], new List<Field>() { Fields[5], Fields[4] }, 5, new List<Field>() { Fields[13] });
        Fields[6].Join(Fields[10], new List<Field>() { Fields[5] }, 3, new List<Field>() { Fields[14] });

        Fields[6].Join(Fields[11], new List<Field>() { Fields[7], Fields[5], Fields[4], Fields[3], Fields[2] }, 10, new List<Field>());
        Fields[6].Join(Fields[12], new List<Field>() { Fields[8], Fields[5], Fields[4], Fields[3] }, 8, new List<Field>());
        Fields[6].Join(Fields[13], new List<Field>() { Fields[9], Fields[5], Fields[4] }, 6, new List<Field>());
        Fields[6].Join(Fields[14], new List<Field>() { Fields[10], Fields[5] }, 4, new List<Field>());
      }
    }

    private void Create2()
    {

      for (int i = 0; i < 7; i++)
      {
        Field f = new Field('.', false, '.');
        Fields.Add(f);
      }


      using (StringReader sr = new StringReader(Input))
      {
        sr.ReadLine();
        sr.ReadLine();

        Field f;
        string line = sr.ReadLine();
        string vals = line.Replace("#", "");

        f = new Field(vals[0], true, 'A');
        Fields.Add(f);

        f = new Field(vals[1], true, 'B');
        Fields.Add(f);

        f = new Field(vals[2], true, 'C');
        Fields.Add(f);

        f = new Field(vals[3], true, 'D');
        Fields.Add(f);

        /*
#D#C#B#A#
#D#B#A#C#
         * */
        line = "#D#C#B#A#";
        vals = line.Replace("#", "").Replace(" ", "");
        f = new Field(vals[0], true, 'A');
        Fields.Add(f);

        f = new Field(vals[1], true, 'B');
        Fields.Add(f);

        f = new Field(vals[2], true, 'C');
        Fields.Add(f);

        f = new Field(vals[3], true, 'D');
        Fields.Add(f);

        line = "#D#B#A#C#";
        vals = line.Replace("#", "").Replace(" ", "");
        f = new Field(vals[0], true, 'A');
        Fields.Add(f);

        f = new Field(vals[1], true, 'B');
        Fields.Add(f);

        f = new Field(vals[2], true, 'C');
        Fields.Add(f);

        f = new Field(vals[3], true, 'D');
        Fields.Add(f);





        line = sr.ReadLine();
        vals = line.Replace("#", "").Replace(" ", "");
        f = new Field(vals[0], true, 'A');
        Fields.Add(f);

        f = new Field(vals[1], true, 'B');
        Fields.Add(f);

        f = new Field(vals[2], true, 'C');
        Fields.Add(f);

        f = new Field(vals[3], true, 'D');
        Fields.Add(f);
        /*
#############
#01.2.3.4.56#
###7#8#9#a###
  #b#c#d#e#
  #########
 * */
        List<Field> A1 = new List<Field>() { Fields[11], Fields[15], Fields[19] };
        List<Field> A2 = new List<Field>() { Fields[15], Fields[19] };
        List<Field> A3 = new List<Field>() { Fields[19] };
        List<Field> A4 = new List<Field>() { };

        List<Field> B1 = new List<Field>() { Fields[12], Fields[16], Fields[20] };
        List<Field> B2 = new List<Field>() { Fields[16], Fields[20] };
        List<Field> B3 = new List<Field>() { Fields[20] };
        List<Field> B4 = new List<Field>() { };

        List<Field> C1 = new List<Field>() { Fields[13], Fields[17], Fields[21] };
        List<Field> C2 = new List<Field>() { Fields[17], Fields[21] };
        List<Field> C3 = new List<Field>() { Fields[21] };
        List<Field> C4 = new List<Field>() { };

        List<Field> D1 = new List<Field>() { Fields[14], Fields[18], Fields[22] };
        List<Field> D2 = new List<Field>() { Fields[18], Fields[22] };
        List<Field> D3 = new List<Field>() { Fields[22] };
        List<Field> D4 = new List<Field>() { };

        Fields[0].Join(Fields[7], new List<Field>() { Fields[1] }, 3, A1);
        Fields[0].Join(Fields[8], new List<Field>() { Fields[1], Fields[2] }, 5, B1);
        Fields[0].Join(Fields[9], new List<Field>() { Fields[1], Fields[2], Fields[3] }, 7, C1);
        Fields[0].Join(Fields[10], new List<Field>() { Fields[1], Fields[2], Fields[3], Fields[4] }, 9, D1);

        Fields[0].Join(Fields[11], new List<Field>() { Fields[7], Fields[1] }, 4, A2);
        Fields[0].Join(Fields[12], new List<Field>() { Fields[8], Fields[1], Fields[2] }, 6, B2);
        Fields[0].Join(Fields[13], new List<Field>() { Fields[9], Fields[1], Fields[2], Fields[3] }, 8, C2);
        Fields[0].Join(Fields[14], new List<Field>() { Fields[10], Fields[1], Fields[2], Fields[3], Fields[4] }, 10, D2);

        Fields[0].Join(Fields[15], new List<Field>() { Fields[11], Fields[7], Fields[1] }, 5, A3);
        Fields[0].Join(Fields[16], new List<Field>() { Fields[12], Fields[8], Fields[1], Fields[2] }, 7, B3);
        Fields[0].Join(Fields[17], new List<Field>() { Fields[13], Fields[9], Fields[1], Fields[2], Fields[3] }, 9, C3);
        Fields[0].Join(Fields[18], new List<Field>() { Fields[14], Fields[10], Fields[1], Fields[2], Fields[3], Fields[4] }, 11, D3);

        Fields[0].Join(Fields[19], new List<Field>() { Fields[15],Fields[11], Fields[7], Fields[1] }, 6, A4);
        Fields[0].Join(Fields[20], new List<Field>() { Fields[16],Fields[12], Fields[8], Fields[1], Fields[2] }, 8, B4);
        Fields[0].Join(Fields[21], new List<Field>() { Fields[17],Fields[13], Fields[9], Fields[1], Fields[2], Fields[3] }, 10, C4);
        Fields[0].Join(Fields[22], new List<Field>() { Fields[18], Fields[14], Fields[10], Fields[1], Fields[2], Fields[3], Fields[4] }, 12, D4);




        Fields[1].Join(Fields[7], new List<Field>() { }, 2, A1);
        Fields[1].Join(Fields[8], new List<Field>() { Fields[2] }, 4, B1);
        Fields[1].Join(Fields[9], new List<Field>() { Fields[2], Fields[3] }, 6, C1);
        Fields[1].Join(Fields[10], new List<Field>() { Fields[2], Fields[3], Fields[4] }, 8, D1);

        Fields[1].Join(Fields[11], new List<Field>() { Fields[7], }, 3, A2);
        Fields[1].Join(Fields[12], new List<Field>() { Fields[8], Fields[2] }, 5, B2);
        Fields[1].Join(Fields[13], new List<Field>() { Fields[9], Fields[2], Fields[3] }, 7, C2);
        Fields[1].Join(Fields[14], new List<Field>() { Fields[10], Fields[2], Fields[3], Fields[4] }, 9, D2);

        Fields[1].Join(Fields[15], new List<Field>() { Fields[11], Fields[7], }, 4, A3);
        Fields[1].Join(Fields[16], new List<Field>() { Fields[12], Fields[8], Fields[2] }, 6, B3);
        Fields[1].Join(Fields[17], new List<Field>() { Fields[13], Fields[9], Fields[2], Fields[3] }, 8, C3);
        Fields[1].Join(Fields[18], new List<Field>() { Fields[14], Fields[10], Fields[2], Fields[3], Fields[4] }, 10, D3);

        Fields[1].Join(Fields[19], new List<Field>() { Fields[15],Fields[11], Fields[7], }, 5, A4);
        Fields[1].Join(Fields[20], new List<Field>() { Fields[16],Fields[12], Fields[8], Fields[2] }, 7, B4);
        Fields[1].Join(Fields[21], new List<Field>() { Fields[17],Fields[13], Fields[9], Fields[2], Fields[3] }, 9, C4);
        Fields[1].Join(Fields[22], new List<Field>() { Fields[18], Fields[14], Fields[10], Fields[2], Fields[3], Fields[4] }, 11, D4);



        Fields[2].Join(Fields[7], new List<Field>() { }, 2, A1);
        Fields[2].Join(Fields[8], new List<Field>() { }, 2, B1);
        Fields[2].Join(Fields[9], new List<Field>() { Fields[3] }, 4, C1);
        Fields[2].Join(Fields[10], new List<Field>() { Fields[3], Fields[4] }, 6, D1);

        Fields[2].Join(Fields[11], new List<Field>() { Fields[7] }, 3, A2);
        Fields[2].Join(Fields[12], new List<Field>() { Fields[8] }, 3, B2);
        Fields[2].Join(Fields[13], new List<Field>() { Fields[9], Fields[3] }, 5, C2);
        Fields[2].Join(Fields[14], new List<Field>() { Fields[10], Fields[3], Fields[4] }, 7, D2);

        Fields[2].Join(Fields[15], new List<Field>() { Fields[11], Fields[7]  }, 4, A3);
        Fields[2].Join(Fields[16], new List<Field>() { Fields[12], Fields[8]  }, 4, B3);
        Fields[2].Join(Fields[17], new List<Field>() { Fields[13], Fields[9], Fields[3] }, 6, C3);
        Fields[2].Join(Fields[18], new List<Field>() { Fields[14], Fields[10], Fields[3], Fields[4] }, 8, D3);

        Fields[2].Join(Fields[19], new List<Field>() { Fields[15], Fields[11], Fields[7] }, 5, A4);
        Fields[2].Join(Fields[20], new List<Field>() { Fields[16],Fields[12], Fields[8] }, 5, B4);
        Fields[2].Join(Fields[21], new List<Field>() { Fields[17],Fields[13], Fields[9], Fields[3] }, 7, C4);
        Fields[2].Join(Fields[22], new List<Field>() { Fields[18],Fields[14], Fields[10], Fields[3], Fields[4] }, 9, D4);



        Fields[3].Join(Fields[7], new List<Field>() { Fields[2] }, 4, A1);
        Fields[3].Join(Fields[8], new List<Field>() { }, 2, B1);
        Fields[3].Join(Fields[9], new List<Field>() { }, 2, C1);
        Fields[3].Join(Fields[10], new List<Field>() { Fields[4] }, 4, D1);

        Fields[3].Join(Fields[11], new List<Field>() { Fields[7], Fields[2] }, 5, A2);
        Fields[3].Join(Fields[12], new List<Field>() { Fields[8] }, 3, B2);
        Fields[3].Join(Fields[13], new List<Field>() { Fields[9] }, 3, C2);
        Fields[3].Join(Fields[14], new List<Field>() { Fields[10], Fields[4] }, 5, D2);

        Fields[3].Join(Fields[15], new List<Field>() { Fields[11], Fields[7], Fields[2] }, 6, A3);
        Fields[3].Join(Fields[16], new List<Field>() { Fields[12], Fields[8] }, 4, B3);
        Fields[3].Join(Fields[17], new List<Field>() { Fields[13], Fields[9] }, 4, C3);
        Fields[3].Join(Fields[18], new List<Field>() { Fields[14], Fields[10], Fields[4] }, 6, D3);

        Fields[3].Join(Fields[19], new List<Field>() { Fields[15], Fields[11], Fields[7], Fields[2] }, 7, A4);
        Fields[3].Join(Fields[20], new List<Field>() { Fields[16],Fields[12], Fields[8] }, 5, B4);
        Fields[3].Join(Fields[21], new List<Field>() { Fields[17],Fields[13], Fields[9] }, 5, C4);
        Fields[3].Join(Fields[22], new List<Field>() { Fields[18],Fields[14], Fields[10], Fields[4] }, 7, D4);



        Fields[4].Join(Fields[7], new List<Field>() { Fields[3], Fields[2] }, 6, A1);
        Fields[4].Join(Fields[8], new List<Field>() { Fields[3] }, 4, B1);
        Fields[4].Join(Fields[9], new List<Field>() { }, 2, C1);
        Fields[4].Join(Fields[10], new List<Field>() { }, 2, D1);

        Fields[4].Join(Fields[11], new List<Field>() { Fields[7], Fields[3], Fields[2] }, 7, A2);
        Fields[4].Join(Fields[12], new List<Field>() { Fields[8], Fields[3] }, 5, B2);
        Fields[4].Join(Fields[13], new List<Field>() { Fields[9] }, 3, C2);
        Fields[4].Join(Fields[14], new List<Field>() { Fields[10] }, 3, D2);

        Fields[4].Join(Fields[15], new List<Field>() { Fields[11], Fields[7], Fields[3], Fields[2] }, 8, A3);
        Fields[4].Join(Fields[16], new List<Field>() { Fields[12], Fields[8], Fields[3] }, 6, B3);
        Fields[4].Join(Fields[17], new List<Field>() { Fields[13], Fields[9]  }, 4, C3);
        Fields[4].Join(Fields[18], new List<Field>() { Fields[14], Fields[10] }, 4, D3);

        Fields[4].Join(Fields[19], new List<Field>() { Fields[15], Fields[11], Fields[7], Fields[3], Fields[2] }, 9, A4);
        Fields[4].Join(Fields[20], new List<Field>() { Fields[16],Fields[12], Fields[8], Fields[3] }, 7, B4);
        Fields[4].Join(Fields[21], new List<Field>() { Fields[17],Fields[13], Fields[9] }, 5, C4);
        Fields[4].Join(Fields[22], new List<Field>() { Fields[18],Fields[14], Fields[10] }, 5, D4);




        Fields[5].Join(Fields[7], new List<Field>() { Fields[4], Fields[3], Fields[2] }, 8, A1);
        Fields[5].Join(Fields[8], new List<Field>() { Fields[4], Fields[3] }, 6, B1);
        Fields[5].Join(Fields[9], new List<Field>() { Fields[4] }, 4, C1);
        Fields[5].Join(Fields[10], new List<Field>() { }, 2, D1);

        Fields[5].Join(Fields[11], new List<Field>() { Fields[7], Fields[4], Fields[3], Fields[2] }, 9, A2);
        Fields[5].Join(Fields[12], new List<Field>() { Fields[8], Fields[4], Fields[3] }, 7, B2);
        Fields[5].Join(Fields[13], new List<Field>() { Fields[9], Fields[4] }, 5, C2);
        Fields[5].Join(Fields[14], new List<Field>() { Fields[10] }, 3, D2);

        Fields[5].Join(Fields[15], new List<Field>() { Fields[11], Fields[7], Fields[4], Fields[3], Fields[2] }, 10, A3);
        Fields[5].Join(Fields[16], new List<Field>() { Fields[12],Fields[8], Fields[4], Fields[3] }, 8, B3);
        Fields[5].Join(Fields[17], new List<Field>() { Fields[13],Fields[9], Fields[4] }, 6, C3);
        Fields[5].Join(Fields[18], new List<Field>() { Fields[14],Fields[10] }, 4, D3);

        Fields[5].Join(Fields[19], new List<Field>() { Fields[15], Fields[11], Fields[7], Fields[4], Fields[3], Fields[2] }, 11, A4);
        Fields[5].Join(Fields[20], new List<Field>() { Fields[16],Fields[12], Fields[8], Fields[4], Fields[3] }, 9, B4);
        Fields[5].Join(Fields[21], new List<Field>() { Fields[17],Fields[13], Fields[9], Fields[4] }, 7, C4);
        Fields[5].Join(Fields[22], new List<Field>() { Fields[18],Fields[14], Fields[10] }, 5, D4);



        Fields[6].Join(Fields[7], new List<Field>() { Fields[5], Fields[4], Fields[3], Fields[2] }, 9, A1);
        Fields[6].Join(Fields[8], new List<Field>() { Fields[5], Fields[4], Fields[3] }, 7, B1);
        Fields[6].Join(Fields[9], new List<Field>() { Fields[5], Fields[4] }, 5, C1);
        Fields[6].Join(Fields[10], new List<Field>() { Fields[5] }, 3, D1);

        Fields[6].Join(Fields[11], new List<Field>() { Fields[7], Fields[5], Fields[4], Fields[3], Fields[2] }, 10, A2);
        Fields[6].Join(Fields[12], new List<Field>() { Fields[8], Fields[5], Fields[4], Fields[3] }, 8, B2);
        Fields[6].Join(Fields[13], new List<Field>() { Fields[9], Fields[5], Fields[4] }, 6, C2);
        Fields[6].Join(Fields[14], new List<Field>() { Fields[10], Fields[5] }, 4, D2);

        Fields[6].Join(Fields[15], new List<Field>() { Fields[11], Fields[7], Fields[5], Fields[4], Fields[3], Fields[2] }, 11, A3);
        Fields[6].Join(Fields[16], new List<Field>() {  Fields[12], Fields[8], Fields[5], Fields[4], Fields[3] }, 9, B3);
        Fields[6].Join(Fields[17], new List<Field>() {  Fields[13], Fields[9], Fields[5], Fields[4] }, 7, C3);
        Fields[6].Join(Fields[18], new List<Field>() {  Fields[14],Fields[10], Fields[5] }, 5, D3);

        Fields[6].Join(Fields[19], new List<Field>() { Fields[15], Fields[11], Fields[7], Fields[5], Fields[4], Fields[3], Fields[2] }, 12, A4);
        Fields[6].Join(Fields[20], new List<Field>() { Fields[16],Fields[12], Fields[8], Fields[5], Fields[4], Fields[3] }, 10, B4);
        Fields[6].Join(Fields[21], new List<Field>() { Fields[17],Fields[13], Fields[9], Fields[5], Fields[4] }, 8, C4);
        Fields[6].Join(Fields[22], new List<Field>() { Fields[18],Fields[14], Fields[10], Fields[5] }, 6, D4);
      }
    }


    internal int Solve1(Dictionary<string, int> maps)
    {
      Create1();
      final = FINAL_ID;
      SolveRec(maps, 0);
      return maps[final];
    }

    internal int Solve2(Dictionary<string, int> maps)
    {
      Create2();
      final = FINAL_ID2;
      SolveRec(maps, 0);
      return maps[FINAL_ID2];
    }

    private void SolveRec(Dictionary<string, int> maps, int depth)
    {
      
      if (IsFinal())
      {

        if (maps.ContainsKey(final))
        {
          if (maps[final] > Energy)
          {
            maps[final] = Energy;
          }
        } else
        {
          maps.Add(final, Energy);
        }
        return;
      }

      if (maps.ContainsKey(final))
      {
        if (maps[final] <= Energy)
        {
          return;
        }
      }

      string id = GetID();
      if (maps.ContainsKey(id))
      {
        if (maps[id] <= Energy)
        {
          return;
        }
        maps[id] = Energy;
      } else
      {
        maps.Add(id, Energy);
      }



      
      for(int i = 0; i < Fields.Count; i++) 
      {
        Field f = Fields[i];
        if (f.Value != '.')
        {
          foreach (Field neighbour in f.Neighbours.Keys)
          {
            if (f.CanMove(neighbour))
            {
              Energy += f.Move(neighbour);
              if(neighbour.IsFinal)
              {
                neighbour.Locked = true;
              }

              this.SolveRec(maps, depth + 1);
              Energy -= neighbour.Move(f);
              if (neighbour.IsFinal)
              {
                neighbour.Locked = false;
              }

            }
          }
        }
      }
    }


    public bool IsFinal()
    {
   
      return GetID() == final;
    }

    public string GetID()
    {
      StringBuilder sb = new StringBuilder();
      foreach(Field f in Fields)
      {
        sb.Append(f.Value);
      }
      return sb.ToString();
    }

    public override string ToString()
    {
      return GetID();
    }

  }
}
