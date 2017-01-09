using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumRzad3
{
    class NaWynos : Zamowienie
    {
        public override bool PoprawnyCzas()
        {
            if (base.PoprawnyCzas())
            {
                if (this.czasDostawy.Hour > DateTime.Now.Hour)
                    return true;
            }
            return false;
        }
    }
}
