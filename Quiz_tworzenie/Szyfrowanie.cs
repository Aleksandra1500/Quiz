using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_tworzenie
{
    internal interface ISzyfrowanie
    {
        String Encrypt(String txt);
        String Decrypt(String txt);
    }
}
