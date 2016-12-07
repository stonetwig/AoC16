using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC16
{
    public class Two
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
            new List<char> { '1' },
            new List<char> { '2', '3', '4' },
            new List<char> { '5', '6', '7', '8', '9' },
            new List<char> { 'A', 'B', 'C' },
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
        int currentLevel = 1;
        int currentCharIndex = 5;

        public string runFirst()
        {
            code = "";
            foreach (string instruction in instructions)
            {
                var directions = instruction.ToCharArray();
                foreach (char d in directions)
                {
                    int nextNumber = GetNextNumber(d);
                    if (nextNumber != currentCharIndex)
                    {
                        currentCharIndex = nextNumber;
                    }
                }
                code += currentCharIndex.ToString();
            }
            return code;
        }

        private int GetNextNumber(char direction)
        {
            int nextHop = currentCharIndex;
            foreach (var keys in keypad)
            {
                int level = keypad.FindIndex(pad => pad.Equals(keys));
                if (keys.Contains((char) currentCharIndex))
                {
                    int index = keys.FindIndex(a => a == currentCharIndex);
                    switch (direction)
                    {
                        case 'U':
                            if (level > 0)
                            {
                                nextHop -= 3;
                            }
                            break;
                        case 'R':
                            if (index < (keys.Count - 1))
                            {
                                nextHop += 1;
                            }
                            break;
                        case 'D':
                            if (level < (keypad.Count - 1))
                            {
                                nextHop += 3;
                            }
                            break;
                        case 'L':
                            if (index > 0)
                            {
                                nextHop -= 1;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return nextHop;
        }

        public string runSecond()
        {
            code = "";
            return "123123 I donno";
        }
    }
}
