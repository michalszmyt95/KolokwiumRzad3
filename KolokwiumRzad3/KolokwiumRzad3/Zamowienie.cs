using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumRzad3
{
    abstract class Zamowienie
    {
        protected DateTime czasDostawy;
        virtual public bool PoprawnyCzas()
        {
            if (czasDostawy > DateTime.Now)
                return true;
            return false;
        }
        public void UstawCzasDostawy(DateTime czasDostawy)
        {
            this.czasDostawy = czasDostawy;
        }
    }
}
