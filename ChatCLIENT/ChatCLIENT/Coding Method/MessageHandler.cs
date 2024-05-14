using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCLIENT.Coding_Method
{
    public interface MessageHandler
    {

        string EncryptMessage(string message);
        string DMessage(string encryptMessage);

    }
}
