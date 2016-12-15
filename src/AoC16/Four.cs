using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC16
{
    public class Four : AdventSetup
    {
        List<Room> rooms = new List<Room>();
        int SumOfIds = 0;
        int North = 0;
        public override string[] GetInput(string day)
        {
            return base.GetInput(day);
        }


        public override string RunFirst()
        {
            foreach(string s in Input)
            {
                var room = new Room(s);
                if (room.CountLetters().IsReal())
                {
                    rooms.Add(room);
                    SumOfIds += room.SectorId;
                }
            }
            return SumOfIds.ToString();
        }

        public override string RunSecond()
        {
            foreach (var room in rooms)
            {
                if (room.Decrypt().Contains("north"))
                {
                    North = room.SectorId;
                }
            }
            return North.ToString();
        }
    }


    class Room
    {
        public List<string> Name { get; set; }
        public int SectorId { get; set; }
        public string Checksum { get; set; }
        public Dictionary<char, int> letterCounter { get; set; } = new Dictionary<char, int>();

        public Room(string unparsed)
        {
            Name = GetRoomName(unparsed);
            Checksum = GetChecksum(unparsed);
            SectorId = GetSectorId(unparsed);
        }

        private List<string> GetRoomName(string unparsed)
        {
            var parsed = unparsed.Split('-');
            List<string> withoutSectorAndChecksum = new List<string>();
            for (int i = 0; i < (parsed.Count() - 1); i++)
            {
                withoutSectorAndChecksum.Add(parsed[i]);
            }
            return withoutSectorAndChecksum;
        }

        private string GetChecksum(string unparsed)
        {
            var parsed = unparsed.Split('-');
            string last = parsed[parsed.Count() - 1];
            return Regex.Match(last, @"\[\w+]").Value.Trim(new char[] { '[', ']' });
        }

        private int GetSectorId(string unparsed)
        {
            var parsed = unparsed.Split('-');
            string last = parsed[parsed.Count() - 1];
            var result = Regex.Match(last, @"\d+").Value;
            return int.Parse(result);
        }

        public Room CountLetters()
        {
            foreach (var s in Name)
            {
                var chars = s.ToCharArray();
                foreach (char c in chars)
                {
                    if (letterCounter.ContainsKey(c))
                    {
                        letterCounter[c] += 1;
                    }
                    else
                    {
                        letterCounter.Add(c, 1);
                    }
                }
            }
            return this;
        }

        public bool IsReal()
        {
            var ordered = letterCounter.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key);
            string final = "";
            foreach (var c in ordered)
            {
                final += c.ToString();
            }

            return final.StartsWith(Checksum);
        }

        public string Decrypt()
        {
            string value = string.Join(" ", Name);
            int shift = SectorId;
            char[] buffer = value.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                int ascii;
                if (letter == 32)
                {
                    ascii = 32;
                } else
                {
                    ascii = 97 + (letter - 97 + shift) % 26;
                }
                buffer[i] = (char) ascii;
            }
            return new string(buffer);
        }
    }
}
