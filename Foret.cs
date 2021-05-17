using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters
{
    public class Foret
    {
        private readonly De _De3;
        private int _NbrDeCombatGagne;

        private bool _FinDePartie;

        private bool FinDePartie
        {
            get { return _FinDePartie; }
            set { _FinDePartie = value; }
        }

        private readonly Hero _Hero;

        private Monster _Monster;

        private Monster Monster
        {
            get { return _Monster; }
            set { _Monster = value; }
        }

        public Hero Hero
        {
            get { return _Hero; }
        }

        protected De De3
        {
            get { return _De3; }
        }

        public Foret(Hero Hero)
        {
            _De3 = new De(3);
            this._Hero = Hero;
            Hero.Meurt += UnPersonnageEstMort;

            Console.WriteLine("Un {0} entre dans la forêt", Hero.GetType().Name);
            Console.WriteLine("Force : {0}", Hero.For);
            Console.WriteLine("Endurance : {0}", Hero.End);
        }

        private void UnPersonnageEstMort(Personnage p)
        {
            p.Meurt -= UnPersonnageEstMort;

            if(p is Hero)
            {
                FinDePartie = true;

                Console.WriteLine();
                Console.WriteLine("Le héro est mort");
                Console.WriteLine("Le héro a gagné {0} combat(s)", _NbrDeCombatGagne);
                Console.WriteLine("Le héro a accumulé {0} pièce(s) d'or", ((Hero)p).Or);
                Console.WriteLine("Le héro a accumulé {0} cuir(s)", ((Hero)p).Cuir);
            }
            else
            {
                Console.WriteLine("Le monstre est mort");
                _NbrDeCombatGagne++;
                Hero.SeReposer();
                Hero.Depouiller((Monster)p);
                Monster = GetNextMonster();
            }
        }

        public void Lance()
        {
            Monster = GetNextMonster();            

            bool IsPlayerTurn = true;

            while (!FinDePartie)
            {
                if (IsPlayerTurn)
                    Hero.Frappe(Monster);
                else
                    Monster.Frappe(Hero);

                IsPlayerTurn = !IsPlayerTurn;
            }
        }

        private Monster GetNextMonster()
        {
            Monster M = null;

            switch(De3.Lance())
            {
                case 1:
                    M = new Loup();
                    break;
                case 2:
                    M = new Orque();
                    break;
                case 3:
                    M = new Dragonnet();
                    break;
            }

            M.Meurt += UnPersonnageEstMort;
            Console.WriteLine();
            Console.WriteLine("Nous rencontrons un monstre");
            Console.WriteLine("Type : {0}", M.GetType().Name);
            Console.WriteLine("Force : {0}", M.For);
            Console.WriteLine("Endurance : {0}", M.End);
            
            return M;
        }
    }
}
