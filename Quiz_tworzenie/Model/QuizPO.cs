using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_tworzenie.Model
{
    public class QuizPO
    {
        public string ID { get; set; }
        public string Pytanie { get; set; }
        public string Odp1 { get; set; }
        public string Odp2 { get; set; }
        public string Odp3 { get; set; }
        public string Odp4 { get; set; }
        public int[] PopOdp { get; set; }


        public QuizPO(string pytanie, string odp1, string odp2, string odp3, string odp4, int[] popodp)
        {
            Pytanie = pytanie;
            Odp1 = odp1;
            Odp2 = odp2;
            Odp3 = odp3;
            Odp4 = odp4;
            PopOdp = popodp;
        }

        public override string ToString()
        {
            return $"{Pytanie},{Odp1},{Odp2},{Odp3},{Odp4}";
        }
    }
}
