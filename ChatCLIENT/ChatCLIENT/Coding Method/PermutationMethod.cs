using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCLIENT.Coding_Method
{
    public class PermutationMethod : MessageHandler
    {
        public string EncryptMessage(string message)
        {
            int pNumber = Configuration.permutationNumber;

            char[] chars = message.ToCharArray();
            int length = chars.Length;

            for (int i = 0; i < length; i++)
            {
                int nextIndex = (i + pNumber) % length;
                char temp = chars[i];
                chars[i] = chars[nextIndex];
                chars[nextIndex] = temp;
            }

            return new string(chars);
        }

        public string DMessage(string message)
        {
            int pNumber = Configuration.permutationNumber;

            char[] chars = message.ToCharArray();
            int length = chars.Length;

            
            for (int i = length - 1; i >= 0; i--)
            {
                int nextIndex = (i + pNumber) % length;
                char temp = chars[i];
                chars[i] = chars[nextIndex];
                chars[nextIndex] = temp;
            }

            return new string(chars);
        }


    }
}
