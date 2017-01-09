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

namespace KolokwiumRzad3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pizza pizza;
        NaWynos naWynos;
        NaMiejscu naMiejscu;
        bool dostawaNaWynos = false;

        public MainWindow()
        {
            InitializeComponent();
            SchowajWszystko();
        }

        private void Odswiez()
        {
            if (pizza != null)
            {
                if (pizza.ToString() != "")
                    ZamowieniaTekstBlock.Text = pizza.ToString();
                else
                    ZamowieniaTekstBlock.Text = "Zamówienia";
            }
            Info.Text = "";
        }

        private void SchowajWszystko()
        {
            DodajSkladniki.Visibility = System.Windows.Visibility.Hidden;
            Dostawa.Visibility = System.Windows.Visibility.Hidden;

            NazwaPizzyTekst.Visibility = System.Windows.Visibility.Hidden;
            NazwaPizzyTekstBlock.Visibility = System.Windows.Visibility.Hidden;
            DodajPizze.Visibility = System.Windows.Visibility.Hidden;

            NazwaSkladnikaTekstBlock.Visibility = System.Windows.Visibility.Hidden;
            NazwaSkladnikaTekst.Visibility = System.Windows.Visibility.Hidden;
            CenaTekstBlock.Visibility = System.Windows.Visibility.Hidden;
            CenaTekst.Visibility = System.Windows.Visibility.Hidden;
            DodajSkladnik.Visibility = System.Windows.Visibility.Hidden;
            SosTekst.Visibility = System.Windows.Visibility.Hidden;
            SosTekstBlock.Visibility = System.Windows.Visibility.Hidden;
            UstawSos.Visibility = System.Windows.Visibility.Hidden;

            NaWynos.Visibility = System.Windows.Visibility.Hidden;
            NaMiejscu.Visibility = System.Windows.Visibility.Hidden;

            GodzinaTekst.Visibility = System.Windows.Visibility.Hidden;
            GodzinaTekstBlock.Visibility = System.Windows.Visibility.Hidden;
            Sprawdz.Visibility = System.Windows.Visibility.Hidden;
        }

        private void NowaPizzaButton(object sender, RoutedEventArgs e)
        {
            pizza = new Pizza();
            SchowajWszystko();
            Odswiez();
            NazwaPizzyTekst.Visibility = System.Windows.Visibility.Visible;
            NazwaPizzyTekstBlock.Visibility = System.Windows.Visibility.Visible;
            DodajPizze.Visibility = System.Windows.Visibility.Visible;
            
        }

        private void DodajSkladnikiButton(object sender, RoutedEventArgs e)
        {
            NazwaSkladnikaTekstBlock.Visibility = System.Windows.Visibility.Visible;
            NazwaSkladnikaTekst.Visibility = System.Windows.Visibility.Visible;
            CenaTekstBlock.Visibility = System.Windows.Visibility.Visible;
            CenaTekst.Visibility = System.Windows.Visibility.Visible;
            DodajSkladnik.Visibility = System.Windows.Visibility.Visible;
            SosTekst.Visibility = System.Windows.Visibility.Visible;
            SosTekstBlock.Visibility = System.Windows.Visibility.Visible;
            UstawSos.Visibility = System.Windows.Visibility.Visible;
        }

        private void DostawaButton(object sender, RoutedEventArgs e)
        {
            SchowajWszystko();
            NaWynos.Visibility = System.Windows.Visibility.Visible;
            NaMiejscu.Visibility = System.Windows.Visibility.Visible;
        }

        private void WyjscieButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DodajPizzeButton(object sender, RoutedEventArgs e)
        {
            if (NazwaPizzyTekst.Text != "")
            {
                pizza.UstawNazwe(NazwaPizzyTekst.Text);
                SchowajWszystko();
                DodajSkladniki.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void DodajSkladnikButton(object sender, RoutedEventArgs e)
        {
            try
            {
                pizza.DodajSkladnik(NazwaSkladnikaTekst.Text, Convert.ToInt32(CenaTekst.Text));
            }
            catch
            {

            }
            Odswiez();
            SprobujPokazacDostawe();
        }

        private void UstawSosButton(object sender, RoutedEventArgs e)
        {
            pizza.DodajSos(SosTekst.Text);
            Odswiez();
            SprobujPokazacDostawe();
        }

        private void SprobujPokazacDostawe()
        {
            if (pizza.IleSkladnikow() > 3)
            {
                if (pizza.CzyPoprawnaPizza())
                    Dostawa.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void SprawdzButton(object sender, RoutedEventArgs e)
        {
            DateTime s = DateTime.Now;
            string czas = "";
            int godzina = 00;
            int minuty = 00;
            czas = GodzinaTekst.Text;
            string godzinaString = "";
            try
            {
                godzinaString += czas[0];
                godzinaString += czas[1];
            }
            catch
            { }
            string minutaString = "";
            try
            {
            minutaString += czas[3];
            minutaString += czas[4];
            }
            catch
            { }
            int.TryParse(godzinaString, out godzina);
            int.TryParse(minutaString, out minuty);
            TimeSpan ts = new TimeSpan(godzina, minuty, 0);
            s = s.Date + ts;
            if(dostawaNaWynos)
                SprawdzNaWynos(s);
            else
                SprawdzNaMiejscu(s);
        }

        private void SprawdzNaWynos(DateTime s)
        {
            naWynos.UstawCzasDostawy(s);
            if (naWynos.PoprawnyCzas())
                Info.Text = Environment.NewLine + "Czas jest poprawny.";
            else
                Info.Text = Environment.NewLine + "Czas nie jest poprawny.";
        }
        private void SprawdzNaMiejscu(DateTime s)
        {
            naMiejscu.UstawCzasDostawy(s);
            if (naMiejscu.PoprawnyCzas())
                Info.Text = Environment.NewLine + "Czas jest poprawny.";
            else
                Info.Text = Environment.NewLine + "Czas nie jest poprawny.";
        }



        private void NaWynosButton(object sender, RoutedEventArgs e)
        {
            dostawaNaWynos = true;
            naWynos = new NaWynos();
            GodzinaTekst.Visibility = System.Windows.Visibility.Visible;
            GodzinaTekstBlock.Visibility = System.Windows.Visibility.Visible;
            Sprawdz.Visibility = System.Windows.Visibility.Visible;
        }

        private void NaMiejscuButton(object sender, RoutedEventArgs e)
        {
            dostawaNaWynos = false;
            naMiejscu = new NaMiejscu();
            GodzinaTekst.Visibility = System.Windows.Visibility.Visible;
            GodzinaTekstBlock.Visibility = System.Windows.Visibility.Visible;
            Sprawdz.Visibility = System.Windows.Visibility.Visible;
        }

    }
}
