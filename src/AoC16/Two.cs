using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC16
{
    public class Two : AdventSetup 
    {
        //int[,] keypad = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        List<List<char>> keypad = new List<List<char>>
        {
            new List<char> { '1', '2', '3' },
            new List<char> { '4', '5', '6' },
            new List<char> { '7', '8', '9' },
        };
        List<List<char>> overEngineeredKeyPad = new List<List<char>>
        {
            new List<char> { ' ', ' ', '1' },
            new List<char> { ' ', '2', '3', '4' },
            new List<char> { '5', '6', '7', '8', '9' },
            new List<char> { ' ', 'A', 'B', 'C' },
            new List<char> { ' ', ' ', 'D' },
        };
        string code = "";
        List<string> instructions = new List<string>
        {
            "DDDURLURURUDLDURRURULLRRDULRRLRLRURDLRRDUDRUDLRDUUDRRUDLLLURLUURLRURURLRLUDDURUULDURDRUUDLLDDDRLDUULLUDURRLUULUULDLDDULRLDLURURUULRURDULLLURLDRDULLULRRRLRLRULLULRULUUULRLLURURDLLRURRUUUDURRDLURUURDDLRRLUURLRRULURRDDRDULLLDRDDDDURURLLULDDULLRLDRLRRDLLURLRRUDDDRDLLRUDLLLLRLLRUDDLUUDRLRRRDRLRDLRRULRUUDUUDULLRLUDLLDDLLDLUDRURLULDLRDDLDRUDLDDLDDDRLLDUURRUUDLLULLRLDLUURRLLDRDLRRRRUUUURLUUUULRRUDDUDDRLDDURLRLRLLRRUDRDLRLDRRRRRRUDDURUUUUDDUDUDU",
            "RLULUULRDDRLULRDDLRDUURLRUDDDUULUUUDDRDRRRLDUURDURDRLLLRDDRLURLDRRDLRLUURULUURDRRULRULDULDLRRDDRLDRUDUDDUDDRULURLULUDRDUDDDULRRRURLRRDLRDLDLLRLUULURLDRURRRLLURRRRRLLULRRRDDLRLDDUULDLLRDDRLLUUDRURLRULULRLRUULUUUUUDRURLURLDDUDDLRDDLDRRLDLURULUUDRDLULLURDLLLRRDRURUDDURRLURRDURURDLRUDRULUULLDRLRRDRLDDUDRDLLRURURLUDUURUULDURUDULRLRDLDURRLLDRDUDRUDDRLRURUDDLRRDLLLDULRRDRDRRRLURLDLURRDULDURUUUDURLDLRURRDRULLDDLLLRUULLLLURRRLLLDRRUDDDLURLRRRDRLRDLUUUDDRULLUULDURLDUUURUDRURUDRDLRRLDRURRLRDDLLLULUDDUULDURLRUDRDDD",
            "RDDRUDLRLDDDRLRRLRRLUULDRLRUUURULRRLUURLLLRLULDDLDLRLULULUUDDDRLLLUDLLRUDURUDDLLDUDLURRULLRDLDURULRLDRLDLDRDDRUDRUULLLLRULULLLDDDULUUDUUDDLDRLRRDLRLURRLLDRLDLDLULRLRDLDLRLUULLDLULRRRDDRUULDUDLUUUUDUDRLUURDURRULLDRURUDURDUULRRULUULULRLDRLRLLRRRLULURLUDULLDRLDRDRULLUUUDLDUUUDLRDULRDDDDDDDDLLRDULLUDRDDRURUDDLURRUULUURURDUDLLRRRRDUDLURLLURURLRDLDUUDRURULRDURDLDRUDLRRLDLDULRRUDRDUUDRLURUURLDLUDLLRDDRDU",
            "LLDDDDLUDLLDUDURRURLLLLRLRRLDULLURULDULDLDLLDRRDLUDRULLRUUURDRLLURDDLLUDDLRLLRDDLULRLDDRURLUDRDULLRUDDLUURULUUURURLRULRLDLDDLRDLDLLRUURDLUDRRRDDRDRLLUDDRLDRLLLRULRDLLRLRRDDLDRDDDUDUDLUULDLDUDDLRLDUULRULDLDULDDRRLUUURUUUDLRDRULDRRLLURRRDUDULDUDUDULLULLULULURLLRRLDULDULDLRDDRRLRDRLDRLUDLLLUULLRLLRLDRDDRUDDRLLDDLRULLLULRDDDLLLDRDLRULDDDLULURDULRLDRLULDDLRUDDUDLDDDUDRDRULULDDLDLRRDURLLRLLDDURRLRRULLURLRUDDLUURULULURLRUDLLLUDDURRLURLLRLLRRLDULRRUDURLLDDRLDLRRLULUULRRUURRRDULRLRLRDDRDULULUUDULLLLURULURRUDRLL",
            "UULLULRUULUUUUDDRULLRLDDLRLDDLULURDDLULURDRULUURDLLUDDLDRLUDLLRUURRUDRLDRDDRRLLRULDLLRUUULLLDLDDULDRLRURLDRDUURLURDRUURUULURLRLRRURLDDDLLDDLDDDULRUDLURULLDDRLDLUDURLLLLLRULRRLLUDRUURLLURRLLRDRLLLRRDDDRRRDLRDRDUDDRLLRRDRLRLDDDLURUUUUULDULDRRRRLUDRLRDRUDUDDRULDULULDRUUDUULLUDULRLRRURDLDDUDDRDULLUURLDRDLDDUURULRDLUDDLDURUDRRRDUDRRDRLRLULDRDRLRLRRUDLLLDDDRURDRLRUDRRDDLDRRLRRDLUURLRDRRUDRRDLDDDLRDDLRDUUURRRUULLDDDLLRLDRRLLDDRLRRRLUDLRURULLDULLLUDLDLRLLDDRDRUDLRRDDLUU"
        };
        List<string> sample = new List<string>
        {
            "ULL",
            "RRDDD",
            "LURDL",
            "UUUUD"
        };
        Tuple<int, int> levels = new Tuple<int, int>(1, 1);

        public override string RunFirst()
        {
            code = "";
            return run(keypad);
        }

        public override string RunSecond()
        {
            code = "";
            levels = new Tuple<int, int>(2, 0);
            return run(overEngineeredKeyPad);
        }

        private string run(List<List<char>> pad)
        {
            foreach (string instruction in instructions)
            {
                var directions = instruction.ToCharArray();
                foreach (char d in directions)
                {
                    var nextNumber = GetNextNumber(d, pad);
                    if (!nextNumber.Equals(levels))
                    {
                        levels = nextNumber;
                    }
                }
                code += pad[levels.Item1][levels.Item2].ToString();
            }
            return code;
        }

        private Tuple<int, int> GetNextNumber(char direction, List<List<char>> pad)
        {
            int item1 = levels.Item1;
            int item2 = levels.Item2;

            switch (direction) {
                case 'U':
                    var down1 = levels.Item1 - 1;
                    if (down1 >= 0)
                    {
                        if (levels.Item2 < pad[down1].Count && pad[down1][levels.Item2] != ' ')
                        {
                            item1 -= 1;
                        }
                    }
                    break;
                case 'R':
                    if (levels.Item2 < (pad[levels.Item1].Count - 1))
                    {
                        item2 += 1;
                    }
                    break;
                case 'D':
                    var up1 = levels.Item1 + 1;
                    if (up1 < pad.Count)
                    {
                        if (levels.Item2 < pad[up1].Count && pad[up1][levels.Item2] != ' ')
                        {
                            item1 += 1;
                        }
                    }
                    break;
                case 'L':
                    if (levels.Item2 > 0 && pad[levels.Item1][levels.Item2 - 1] != ' ')
                    {
                        item2 -= 1;
                    }
                    break;
                default:
                    break;
            }
            return new Tuple<int, int>(item1, item2);
        }

        public override string[] GetInput(string day)
        {
            return null;
        }
    }
}
