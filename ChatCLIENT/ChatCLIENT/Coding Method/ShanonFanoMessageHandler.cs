using ChatCLIENT.Coding_Method.ShannonFano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCLIENT.Coding_Method
{
    public class ShanonFanoMessageHandler : MessageHandler
    {
        public string EncryptMessage(string text )
        {
            char[] chars = text.ToCharArray();
            string respons = "";
            try
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    foreach (var elem in Configuration.letterCodeValues)
                    {
                        if (chars[i] == elem.Key)
                        {
                            respons += elem.Value;
                        }
                    }
                }
            }
            catch ( Exception e) 
            {
                
            }
            return respons;

        }

        public string DMessage(string text)
        {
            Decoding decoding = new Decoding();
            return (decoding.GetResult(text));

        }

    }
}
