using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumRzad3
{
    class Skladnik : IComparable<Skladnik>
    {
        private string nazwaSkladnika;
        private double cenaSkladnika;

        public Skladnik(string nazwaSkladnika, double cenaSkladnika)
        {
            this.nazwaSkladnika = nazwaSkladnika;
            this.cenaSkladnika = cenaSkladnika;
        }

        public override string ToString()
        {
            return "Nazwa: " + nazwaSkladnika + ", cena: " + cenaSkladnika + ".";
        }

        public double DajCene()
        {
            return cenaSkladnika;
        }

        public int CompareTo(Skladnik skladnik)
        {
            return String.Compare(this.nazwaSkladnika, skladnik.nazwaSkladnika);
        }

    }
}
