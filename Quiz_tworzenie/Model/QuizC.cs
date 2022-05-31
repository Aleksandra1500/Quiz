using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Quiz_tworzenie.Model
{
    public class QuizC
    {
        public string Nazwa { get; set; }

        public QuizC(string n, string[] lines, ListBox lista_pytan)
        {

            this.Nazwa = n;

            //pętla do przypisania do listy wszystkiego
            for (int i = 1; i < lines.Length - 4; i += 5)
            {
                string o4;
                string o3;
                string o2;
                string o1;
                string p;
                int[] poprawna = { 0, 0, 0, 0 };

                p = lines[i];
                o1 = lines[i + 1];
                o2 = lines[i + 2];
                o3 = lines[i + 3];
                o4 = lines[i + 4];

                if (o1.EndsWith("1"))
                {
                    poprawna[0] = 1;
                }
                else
                {
                    poprawna[0] = 0;
                }

                if (o2.EndsWith("1"))
                {
                    poprawna[1] = 1;
                }
                else
                {
                    poprawna[1] = 0;
                }

                if (o3.EndsWith("1"))
                {
                    poprawna[2] = 1;
                }
                else
                {
                    poprawna[2] = 0;
                }

                if (o4.EndsWith("1"))
                {
                    poprawna[3] = 1;
                }
                else
                {
                    poprawna[3] = 0;
                }

                string o11 = o1.Remove(o1.Length - 2);
                string o22 = o2.Remove(o2.Length - 2);
                string o33 = o3.Remove(o3.Length - 2);
                string o44 = o4.Remove(o4.Length - 2);

                QuizPO Temp = new QuizPO(p, o11, o22, o33, o44, poprawna);
                lista_pytan.Items.Add(Temp);
            }
        }
    }
}