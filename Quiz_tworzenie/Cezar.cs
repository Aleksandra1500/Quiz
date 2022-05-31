using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_tworzenie
{
    public class Cezar : ISzyfrowanie
    {
        //Szyfrowanie
        public String Encrypt(String txt)
        {
            String encrypted = "";
            int key = 3;

            for (int i = 0; i < txt.Length; i++)
            {
                if (Char.IsUpper(txt[i]))
                {
                    int characterIndex = txt[i] - (char)('A');
                    int characterShifted = (characterIndex + key) % 26 + (char)'A';
                    encrypted += (char)(characterShifted);
                }
                else if (Char.IsLower(txt[i]))
                {
                    int characterIndex = txt[i] - (char)('a');
                    int characterShifted = (characterIndex + key) % 26 + (char)'a';
                    encrypted += (char)(characterShifted);
                }
                else if (Char.IsDigit(txt[i]))
                {
                    if (txt[i] == '7')
                    {
                        encrypted += (char)('0');
                    }
                    else if (txt[i] == '8')
                    {
                        encrypted += (char)('1');
                    }
                    else if (txt[i] == '9')
                    {
                        encrypted += (char)('2');
                    }
                    else
                    {
                        int characterNew = (int)(txt[i] + key) % 10 + 50;
                        encrypted += (char)(characterNew);
                    }
                }
                else
                {
                    encrypted += txt[i];
                }
            }
            return encrypted;
        }

        //Deszyfrowanie
        public String Decrypt(String txt)
        {
            String decrypted = "";
            int key = 3;
            key %= 26;

            for (int i = 0; i < txt.Length; i++)
            {
                if (Char.IsUpper(txt[i]))
                {
                    if (txt[i] == 'A')
                    {
                        decrypted += 'X';
                    }
                    else if (txt[i] == 'B')
                    {
                        decrypted += 'Y';
                    }
                    else if (txt[i] == 'C')
                    {
                        decrypted += 'Z';
                    }
                    else
                    {
                        int characterIndex = txt[i] - (char)('A');
                        int characterOrgPos = (characterIndex - key) % 26 + (char)('A');
                        decrypted += (char)(characterOrgPos);
                    }
                }
                else if (Char.IsLower(txt[i]))
                {
                    if (txt[i] == 'a')
                    {
                        decrypted += 'x';
                    }
                    else if (txt[i] == 'b')
                    {
                        decrypted += 'y';
                    }
                    else if (txt[i] == 'c')
                    {
                        decrypted += 'z';
                    }
                    else
                    {
                        int characterIndex = txt[i] - (char)('a');
                        int characterOrgPos = (characterIndex - key) % 26 + (char)('a');
                        decrypted += (char)(characterOrgPos);
                    }
                }
                else if (Char.IsDigit(txt[i]))
                {
                    if (txt[i] == '3')
                    {
                        decrypted += '0';
                    }
                    else if (txt[i] == '4')
                    {
                        decrypted += '1';
                    }
                    else
                    {
                        int characterOrgPos = (txt[i] - key) % 10 + 50;
                        decrypted += (char)(characterOrgPos);
                    }
                }
                else
                {
                    decrypted += txt[i];
                }
            }
            return decrypted;
        }
    }
}
