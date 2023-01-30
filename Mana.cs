using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCsharp.Combat
{
    class Mana
    {
        int _maxMana;
        int _mana;
        public int Mana_ { get => _mana; set => _mana = value; }
        public int Shortmana { get; set; }
        public int GetMana()
        {
            return _mana;
        }
        public void SetMana(int value)
        {
            _mana = value;
        }

        public void Regen(int amount)
        {
            _mana = Math.Min(_maxMana, _mana + amount);

        }
    }
}
