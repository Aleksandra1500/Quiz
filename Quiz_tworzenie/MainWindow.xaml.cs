using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_tworzenie
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Zamknięcie całego programu
        private void Exit_Click(object sender, RoutedEventArgs e) => Close();

        //Wejście do trybu kreatora quizu
        private void CreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Tworzenie T = new Tworzenie();
            T.ShowDialog();
            this.Show();
        }

        //Wejście do trybu rozwiązywania quizu
        private void LoadQuiz_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            //Rozwiazywanie W = new Rozwiazywanie();
            //W.Show();
        }
    }
}
