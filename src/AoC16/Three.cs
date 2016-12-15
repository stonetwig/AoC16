using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC16
{
    public class Three : AdventSetup
    {
        int Triangles = 0;

        public override string[] GetInput(string day)
        {
           return base.GetInput(day);
        }

        public override string RunFirst()
        {
            foreach (string s in Input)
            {
                string[] parsed = s.Split(new[] { "  " }, StringSplitOptions.None);
                parsed = FixPotentialParseErrors(parsed);
                int[] numbers; 
                if (IsValidInts(parsed, out numbers))
                {
                    if (IsTriangle(numbers)) {
                        Triangles++;
                    }
                }

            }
            return Triangles.ToString();
        }

        public override string RunSecond()
        {
            Triangles = 0; // Reset triangles
            for (int i = 0; i < Input.Length; i += 3)
            {
                string row1 = Input[i], row2 = Input[i + 1], row3 = Input[i + 2];
                string[] p1 = row1.Split(new[] { "  "}, StringSplitOptions.None), p2 = row2.Split(new[] { "  " }, StringSplitOptions.None),
                    p3 = row3.Split(new[] { "  " }, StringSplitOptions.None);

                p1 = FixPotentialParseErrors(p1);
                p2 = FixPotentialParseErrors(p2);
                p3 = FixPotentialParseErrors(p3);

                int[] nums1, nums2, nums3;
                if (IsValidInts(p1, out nums1) && IsValidInts(p2, out nums2) && IsValidInts(p3, out nums3))
                {
                    for(int c = 0; c < 3; c++)
                    {
                        int[] column = new int[] { nums1[c], nums2[c], nums3[c] };
                        if (IsTriangle(column))
                        {
                            Triangles++;
                        }
                    }
                }
            }
            return Triangles.ToString();
        }

        private bool IsValidInts(string[] s, out int[] numbers)
        {
            int side1, side2, side3;
            bool didParseFirst = int.TryParse(s[0], out side1);
            bool didParseSecond = int.TryParse(s[1], out side2);
            bool didParseThird = int.TryParse(s[2], out side3);

            if (didParseFirst && didParseSecond && didParseThird)
            {
                numbers = new int[] { side1, side2, side3 };
                return true;
            }
            else
            {
                Console.WriteLine("WARNING: COULD NOT PROCESS LINE CORRECTLY" + string.Join(", ", s));
                numbers = new int[] { };
                return false;
            }
        }

        private string[] FixPotentialParseErrors(string[] parsed)
        {
            List<string> correctlyParsedStrings = new List<string>();
            foreach (string s in parsed)
            {
                if (!string.IsNullOrEmpty(s.Trim())) {
                    correctlyParsedStrings.Add(s.Trim());
                }
            }
            return correctlyParsedStrings.ToArray();
        }

        private bool IsTriangle(int[] n) 
        {
            int a = n[0], b = n[1], c = n[2];
            return a < (b + c) && b < (a + c) && c < (a + b);
        }



    }
}
