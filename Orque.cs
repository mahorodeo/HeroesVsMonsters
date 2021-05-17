using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters
{
    public class Orque : Monster, IOr
    {
        private int _Or;

        public int Or
        {
            get { return _Or; }
            private set { _Or = value; }
        }

        public override int For
        {
            get
            {
                return base.For + 1;
            }
        }

        public Orque()
        {
            //Or = De6.Lance();
        }
    }
}
