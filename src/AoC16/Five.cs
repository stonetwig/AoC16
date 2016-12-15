using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AoC16
{
    public class Five : AdventSetup
    {
        public override string[] GetInput(string day)
        {
            return base.GetInput(day);
        }

        public override string RunFirst()
        {
            var input = Input[0];
            int index = 0, counter = 0;
            List<char> password = new List<char>();
            do
            {
                string hash = Hash(input + counter);
                if (hash.StartsWith("00000"))
                {
                    var chars = hash.ToCharArray();
                    password.Add(chars[5]);
                    Console.WriteLine("Found hash " + hash + " at counter " + counter + " the password is now " + new string(password.ToArray()));
                    index += 1;
                }
                counter += 1;
            } while (index < 8);

            return new string(password.ToArray());
        }

        public string Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string 
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
