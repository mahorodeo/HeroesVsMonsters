using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters
{
    public class Dragonnet : Monster, IOr, ICuir
    {
        private int _Or;

        public int Or
        {
            get { return _Or; }
            private set { _Or = value; }
        }

        private int _Cuir;

        public int Cuir
        {
            get { return _Cuir; }
            private set { _Cuir = value; }
        }

        public override int End
        {
            get
            {
                return base.End + 1;
            }
        }

        public Dragonnet()
        {
            //Cuir = De4.Lance();
            //Or = De6.Lance();
        }
    }
}
