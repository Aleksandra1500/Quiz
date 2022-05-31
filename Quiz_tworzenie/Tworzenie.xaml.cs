using Microsoft.Win32;
using Quiz_tworzenie.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Quiz_tworzenie
{
    public partial class Tworzenie : Window
    {
        Obsluga_plikow pliki;
        public Tworzenie()
        {
            InitializeComponent();
            //this.Closing += new System.ComponentModel.CancelEventHandler(MyWindow_Closing); //odpowiada za działanie metody odnoszącej się do "krzyżyka" zamykającego okno
            CZYSZCZENIE.IsEnabled = false;
            ZAPIS_QUIZU.IsEnabled = false;
            MODYFIKACJA.IsEnabled = false;
            USUŃ.IsEnabled = false;
            pliki = new Obsluga_plikow();
        }

        // Zapobiega zamknięciu okienka, ale chyba nie będziemy jednak tego używać
        void MyWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;

            //string messageBoxText = "Zapisywanie aktualnego quizu";
            //string caption = "Zapisywanie!";
            //MessageBoxButton button = MessageBoxButton.OK;
            //MessageBoxImage icon = MessageBoxImage.Hand;
            //MessageBoxResult result;
            //result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            //if (result == MessageBoxResult.OK)
            //{
            //    this.Close();
            //}

            //string messageBoxText = "Czy na pewno chcesz zamknąć aplikację?";
            //string caption = "Uwaga!";
            //MessageBoxButton button = MessageBoxButton.YesNo;
            //MessageBoxImage icon = MessageBoxImage.Exclamation;
            //MessageBoxResult result;

            //result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            //switch (result)
            //{
            //    case MessageBoxResult.Yes:
            //Application.Current.Shutdown();
            //            break;
            //        case MessageBoxResult.No:
            //            // User pressed No
            //            break;
            //    }
        }

        //Modyfikacja istniejącego pytania
        private void MODYFIKACJA_Click(object sender, RoutedEventArgs e)
        {
            if (LISTA.SelectedItem != null)
            {
                string p = this.PYTANIE.Text;
                string o1 = this.ODP1.Text;
                string o2 = this.ODP2.Text;
                string o3 = this.ODP3.Text;
                string o4 = this.ODP4.Text;
                int[] po = { 0, 0, 0, 0 };

                if (PIERWSZY.IsChecked == true)
                {
                    po[0] = 1;
                    PIERWSZY.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                if (DRUGI.IsChecked == true)
                {
                    po[1] = 1;
                    DRUGI.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                if (TRZECI.IsChecked == true)
                {
                    po[2] = 1;
                    TRZECI.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                if (CZWARTY.IsChecked == true)
                {
                    po[3] = 1;
                    CZWARTY.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }

                QuizPO quiz1 = new QuizPO(p, o1, o2, o3, o4, po);
                int currentIndex = LISTA.Items.IndexOf(LISTA.SelectedItem);
                LISTA.Items.Remove(LISTA.SelectedItem);
                LISTA.Items.Insert(currentIndex, quiz1);
            }
        }

        //Wgranie istniejącego quizu
        private void WGRANIE_Click(object sender, RoutedEventArgs e)
        {
            ZAPIS_QUIZU.IsEnabled = true;
            pliki.Odczyt(LISTA, NAZWA);
        }

        //Zaznaczenie elementu (danego pytania) w listboxie
        private void LISTA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PIERWSZY.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            DRUGI.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            TRZECI.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            CZWARTY.SetCurrentValue(CheckBox.IsCheckedProperty, false);

            MODYFIKACJA.IsEnabled = true;
            CZYSZCZENIE.IsEnabled = true;
            USUŃ.IsEnabled = true;

            if ((sender as ListBox).SelectedItem is QuizPO currentItem)
            {
                PYTANIE.Text = currentItem.Pytanie;
                ODP1.Text = currentItem.Odp1;
                ODP2.Text = currentItem.Odp2;
                ODP3.Text = currentItem.Odp3;
                ODP4.Text = currentItem.Odp4;

                if (currentItem.PopOdp[0] == 1)
                {
                    PIERWSZY.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                if (currentItem.PopOdp[1] == 1)
                {
                    DRUGI.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                if (currentItem.PopOdp[2] == 1)
                {
                    TRZECI.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                if (currentItem.PopOdp[3] == 1)
                {
                    CZWARTY.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
            }
        }

        //Zapis nowego pytania
        private void ZAPIS_PYTANIA_Click(object sender, RoutedEventArgs e)
        {
            if (this.PYTANIE.Text != "" && this.PYTANIE.Text != "...")
            {
                string p = this.PYTANIE.Text;
                string o1 = this.ODP1.Text;
                string o2 = this.ODP2.Text;
                string o3 = this.ODP3.Text;
                string o4 = this.ODP4.Text;
                int[] po = { 0, 0, 0, 0 };

                if (PIERWSZY.IsChecked == true)
                {
                    po[0] = 1;
                    PIERWSZY.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                if (DRUGI.IsChecked == true)
                {
                    po[1] = 1;
                    DRUGI.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                if (TRZECI.IsChecked == true)
                {
                    po[2] = 1;
                    TRZECI.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                if (CZWARTY.IsChecked == true)
                {
                    po[3] = 1;
                    CZWARTY.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }

                QuizPO quiz1 = new QuizPO(p, o1, o2, o3, o4, po);
                LISTA.Items.Add(quiz1);
                ZAPIS_QUIZU.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Nie utworzono pytania!");
            }
        }

        //Zapis całego quizu
        private async void ZAPIS_QUIZU_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pliki.Zapis(LISTA, NAZWA);
                MessageBox.Show("Udało się zapisać quiz!");
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udało się zapisać quizu!");
            }
        }

        //Czyszczenie zawartości textboxów, texblocków i checkboxów
        private void CZYSZCZENIE_Click(object sender, RoutedEventArgs e)
        {
            LISTA.UnselectAll();
            this.PYTANIE.Text = "...";
            this.ODP1.Text = "...";
            this.ODP2.Text = "...";
            this.ODP3.Text = "...";
            this.ODP4.Text = "...";
        }

        //Usuwanie danego elementu (pytania) z listboxa
        private void USUŃ_Click(object sender, RoutedEventArgs e)
        {
            LISTA.Items.Remove(LISTA.SelectedItem);
            this.PYTANIE.Text = "...";
            this.ODP1.Text = "...";
            this.ODP2.Text = "...";
            this.ODP3.Text = "...";
            this.ODP4.Text = "...";
            PIERWSZY.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            DRUGI.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            TRZECI.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            CZWARTY.SetCurrentValue(CheckBox.IsCheckedProperty, false);
        }

        //Metody odpowiadające za wyczyszczenie texboxów po podwójnym kliknięciu
        private void NAZWA_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.NAZWA.Text = "";
        }

        private void PYTANIE_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.PYTANIE.Text = "";
        }

        private void ODP1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ODP1.Text = "";
        }

        private void ODP2_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ODP2.Text = "";
        }

        private void ODP3_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ODP3.Text = "";
        }

        private void ODP4_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ODP4.Text = "";
        }
    }
}
