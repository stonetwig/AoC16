using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC16
{
    public class Program
    {
        int[] Directions = new int[] { 0, 0, 0, 0 };
        static string raw = @"R4, R1, L2, R1, L1, L1, R1, L5, R1, R5, L2, R3, L3, L4, R4, R4, R3, L5, L1, R5, R3, L4, R1, R5, L1, R3, L2, R3, R1, L4, L1, R1, L1, L5, R1, L2, R2, L3, L5, R1, R5, L1, R188, L3, R2, R52, R5, L3, R79, L1, R5, R186, R2, R1, L3, L5, L2, R2, R4, R5, R5, L5, L4, R5, R3, L4, R4, L4, L4, R5, L4, L3, L1, L4, R1, R2, L5, R3, L4, R3, L3, L5, R1, R1, L3, R2, R1, R2, R2, L4, R5, R1, R3, R2, L2, L2, L1, R2, L1, L3, R5, R1, R4, R5, R2, R2, R4, R4, R1, L3, R4, L2, R2, R1, R3, L5, R5, R2, R5, L1, R2, R4, L1, R5, L3, L3, R1, L4, R2, L2, R1, L1, R4, R3, L2, L3, R3, L2, R1, L4, R5, L1, R5, L2, L1, L5, L2, L5, L2, L4, L2, R3";
        int CurrentDirection = 0; // 0 north, 1 east, 2 south, 3 west
        string[] Input = raw.Split(new[] { ", " }, StringSplitOptions.None);
        int Distance = 0;
        List<int[]> visited = new List<int[]>();
        int[] lastCoord = new int[] { 0, 0 };
        bool hasOccurred = false;
        public static void Main(string[] args)
        {
            var p = new Program();
            foreach (string s in p.Input)
            {
                p.TakeStep(s);
            }
            //System.Console.WriteLine("Part one: " + p.Distance);
            //System.Console.WriteLine("Part two collided at points: " + p.lastCoord[0] + ", " +  p.lastCoord[1] + ". Of a total of " + p.visited.Count() + " it is " + p.CalculateDistance() + " blocks away");
            var day2 = new Two();
            System.Console.WriteLine(day2.run());
        }

        public void TakeStep(string step)
        {
            var chars = step.ToCharArray();
            var n = Int32.Parse(step.Trim().Remove(0, 1));
            CurrentDirection = chars[0] == 'R' ? CurrentDirection += 1 : CurrentDirection -= 1;
            CurrentDirection = CurrentDirection > 3 ? 0 : (CurrentDirection < 0 ? 3 : CurrentDirection);

            Directions[CurrentDirection] += n;
            for (int i = 0; i < n; i++)
            {
                var coord = new int[] { lastCoord[0], lastCoord[1] };
                switch (CurrentDirection)
                {
                    case 0:
                        coord[0] += 1;
                        break;
                    case 2:
                        coord[1] -= 1;
                        break;
                    case 1:
                        coord[0] += 1;
                        break;
                    case 3:
                        coord[0] -= 1;
                        break;
                }

                if (!hasOccurred)
                {
                    visited.Add(coord);
                    lastCoord = coord;
                }

                if (visited.Contains(coord))
                {
                    hasOccurred = true;
                }

            }
            Distance = UpdateDistance();
        }

        public int UpdateDistance()
        {
            var northsouth = Math.Abs(Directions[0] - Directions[2]);
            var eastwest = Math.Abs(Directions[1] - Directions[3]);

            return northsouth + eastwest;
        }

        public int CalculateDistance()
        {
            var coord = lastCoord;
            return Math.Abs(coord[0]) + Math.Abs(coord[1]);
        }
    }
}
