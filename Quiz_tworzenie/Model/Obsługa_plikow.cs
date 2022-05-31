using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Quiz_tworzenie.Model
{
    public class Obsluga_plikow
    {
        private string NameOfFile;
        private string NameOfQuiz;
        ISzyfrowanie szyfr = new Cezar();

        //Odczytywanie z pliku
        public void Odczyt(ListBox lista_pytan, TextBox nazwa_quizu)
        {

            //czytanie z pliku
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //NameOfFile = "C:\\Users\\Alex_\\OneDrive\\Pulpit\\quiz.txt"; //Ustawienie jakiejś ścieżki na sztywno do testów

            //Wybranie pliku z okna dialogowego
            if (openFileDialog.ShowDialog() == true)
            {
                NameOfFile = openFileDialog.FileName;
            }

            string[] lines = { };
            if (!string.IsNullOrEmpty(NameOfFile))
            {
                lines = File.ReadAllLines(NameOfFile);
            }

            string temp_lines = "";
            for (int i = 0; i < lines.Length; i++)
            {
                temp_lines += lines[i] + ".";
            }

            //Console.WriteLine(temp_lines);
            //temp_lines = szyfr.encrypt(temp_lines); // Do testów szyfrowanie jak nie ma pliku zapisanego szyfrem
            //Console.WriteLine(temp_lines);
            temp_lines = szyfr.Decrypt(temp_lines);
            //Console.WriteLine(temp_lines);
            lines = temp_lines.Split('.');

            QuizC quiz1 = new QuizC(NameOfFile, lines, lista_pytan);
            NameOfQuiz = lines[0];
            nazwa_quizu.Text = NameOfQuiz;
        }

        //Zapisywanie do pliku
        public void Zapis(ListBox lista_pytan, TextBox nazwa_quizu)
        {
            string calosc = "";
            Console.WriteLine(NameOfQuiz);

            if (NameOfQuiz != null)
            {
                calosc += NameOfQuiz + ".";
            }
            else
            {
                NameOfQuiz = nazwa_quizu.Text;
                calosc += nazwa_quizu.Text;
            }

            foreach (var item in lista_pytan.Items)
            {
                QuizPO currentQuestion = item as QuizPO;
                calosc += currentQuestion.Pytanie + ".";

                if (currentQuestion.PopOdp[0] == 1)
                {
                    string temp = currentQuestion.Odp1 + " 1.";
                    calosc += currentQuestion.Odp1 + " 1.";
                }
                else
                {
                    string temp = currentQuestion.Odp1;
                    temp += " 0";
                    calosc += temp + ".";
                }

                if (currentQuestion.PopOdp[1] == 1)
                {
                    string temp = currentQuestion.Odp2 + " 1.";
                    calosc += currentQuestion.Odp2 + " 1.";
                }
                else
                {
                    string temp = currentQuestion.Odp2;
                    temp += " 0";
                    calosc += temp + ".";
                }

                if (currentQuestion.PopOdp[2] == 1)
                {
                    string temp = currentQuestion.Odp3 + " 1.";
                    calosc += currentQuestion.Odp3 + " 1.";
                }
                else
                {
                    string temp = currentQuestion.Odp3;
                    temp += " 0";
                    calosc += temp + ".";
                }

                if (currentQuestion.PopOdp[3] == 1)
                {
                    string temp = currentQuestion.Odp4 + " 1.";
                    calosc += currentQuestion.Odp4 + " 1.";
                }
                else
                {
                    string temp = currentQuestion.Odp4;
                    temp += " 0";
                    calosc += temp + ".";
                }
            }

            calosc = szyfr.Encrypt(calosc);
            string[] all = calosc.Split('.');
            string fileName = NameOfFile;
            if (NameOfFile == null)
            {
                fileName = "Z:\\Studia\\Sem.4\\Programowanie\\Quiz\\Quiz\\bin\\Debug\\" + NameOfQuiz + ".txt";
            }
            Console.WriteLine(fileName);
            FileStream fs = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (string item in all)
                    {
                        sw.Write(item + "\n");
                    }
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }
    }
}
