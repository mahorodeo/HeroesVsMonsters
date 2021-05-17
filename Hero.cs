using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters
{
    public abstract class Hero : Personnage, IOr, ICuir
    {
        //God Mode
        //public override int End
        //{
        //    get { return base.End + 150; }
        //}

        private int _Or, _Cuir;

        public int Or
        {
            get { return _Or; }
            private set { _Or = value; }
        }

        public int Cuir
        {
            get { return _Cuir; }
            private set { _Cuir = value; }
        }

        public void SeReposer()
        {
            ResetPV();
        }

        public void Depouiller(Monster Monster)
        {
            if (Monster is IOr)
            {
                this.Or += ((IOr)Monster).Or;
            }

            if (Monster is ICuir)
            {
                this.Cuir += ((ICuir)Monster).Cuir;
            }
        }
    }
}
