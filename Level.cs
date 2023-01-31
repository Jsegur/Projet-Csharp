using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCsharp
{
    internal class Level
    {
        public int level;
        private float exp;
        private float expMax;

        void Start()
        {
            level = 1;
            _health = 100;
            _mana = 100;
            _strenght = 10;
            exp = 0;
            expMax = 100;
        }
        
        void Up() 
        {
            Exp();
            if(Monster._health <= 0) 
            {
                exp += 100;
            }
        }
        void LevelUp()
        {
            level += 1;
            exp = 0;

            switch (level) 
            {
                case 2:
                    _health = 200;
                    _mana = 200;
                    _strenght += 20;
                    expMax = 200;
                    break;
                case 3:
                    _health = 300;
                    _mana = 300;
                    _strenght += 30;
                    expMax = 300;
                    break;
            }
        }
        void Exp()
        { 
            if(exp >= expMax) 
            {
                LevelUp();
            }
        }
    }
}