﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters
{
    public class Nain : Hero
    {
        public override int End
        {
            get
            {
                return base.End + 2;
            }
        }
    }
}
