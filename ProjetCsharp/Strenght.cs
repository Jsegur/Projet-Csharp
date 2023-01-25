using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCsharp.Combat
{
    internal class Strenght
    {
        int _strenght;
        int _modifStrenght;

        public int Strenght_ { get => _strenght; set => _strenght = value; }
        public int GetStrenght()
        {
            return _strenght;
        }
        public void SetStrenght(int value)
        {
            _strenght = value;
        }
        public void Level.LevelUp(int addStrenght)
        {
            if (LevelUp = true)
            {
                _strenght += addStrenght;
            }
        }
        public void TotalStrenght()
        {
            _strenght= Math.Abs(_strenght + _modifStrenght);
            
        }

    }
}
