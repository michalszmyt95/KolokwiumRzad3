using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumRzad3
{
    class Pizza
    {
        private string nazwa;
        private decimal suma = 15;
        private List<Skladnik> skladniki = new List<Skladnik>();
        private string sos;

        public void DodajSkladnik(string nazwaSkladnika, double cenaSkladnika)
        {
            skladniki.Add(new Skladnik(nazwaSkladnika, cenaSkladnika));
            suma += (decimal) cenaSkladnika;
        }

        public void DodajSos(string sos)
        {
            this.sos = sos;
        }

        public void UstawNazwe(string nazwaPizzy)
        {
            this.nazwa = nazwaPizzy;
        }

        public override string ToString()
        {
            if (skladniki.Count == 0)
                return "";
            string wynik = "Pizza " + nazwa + ":" + Environment.NewLine;
            skladniki.Sort();
            foreach(var skladnik in skladniki)
            {
                wynik += skladnik.ToString() + Environment.NewLine;
            }
            wynik += "Sos: " + sos + Environment.NewLine;
            wynik += "Suma: " + suma;
            return wynik;
        }

        public int IleSkladnikow()
        {
            return skladniki.Count();
        }

        public bool CzyNazwa()
        {
            if (nazwa == null)
                return false;
            return true;
        }

        public bool CzyPoprawnaPizza()
        {
            if (skladniki.Count > 0)
            {
                if (sos == null)
                    return false;
                if (sos == "")
                    return false;
                return true;
            }
            return false;
        }

    }
}
