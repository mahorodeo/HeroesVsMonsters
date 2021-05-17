using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters
{
    public abstract class Personnage
    {
        public event Action<Personnage> Meurt;

        private int _End, _For, _PV;
        private readonly De _De4, _De6;

        protected De De4
        {
            get { return _De4; }
        } 

        protected De De6
        {
            get { return _De6; }
        } 

        public virtual int End
        {
            get { return _End; }
            private set { _End = value; }
        }

        public virtual int For
        {
            get { return _For; }
            private set { _For = value; }
        }

        private int PV
        {
            get { return _PV; }
            set 
            {
                _PV = value; 
                if(_PV <= 0 && Meurt != null)
                {
                    Meurt(this);
                }
            }
        }

        public Personnage()
        {
            _De4 = new De(4);
            _De6 = new De(6);

            For = De.GetNouvelleCaracteristique();
            End = De.GetNouvelleCaracteristique();
            ResetPV();
        }

        public void Frappe(Personnage Personnage)
        {
            //Calcule des Dégâts
            int Degat = De4.Lance() + GetModificateur(For);

            Console.WriteLine("{0} Frappe {1} et lui inflige {2} Point(s) de dégat", this.GetType().Name, Personnage.GetType().Name, Degat);
            //Retrait des dégâts des points de vie de la cible
            Personnage.PV -= Degat;
        }

        private int GetModificateur(int Caracteristique)
        {
            return (Caracteristique < 5) ? -1 :
                (Caracteristique < 10) ? 0 :
                (Caracteristique < 15) ? 1 : 2;
        }

        protected void ResetPV()
        {
            PV = End + GetModificateur(End);
        }
    }
}
