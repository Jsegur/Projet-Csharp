﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCsharp.Combat
{
    class Health
    {
        public StringBuilder _sb;
        int _maxHealth;
        int _health;
        public int Health_ { get => _health; set => _health = value; }
        public int ShortHealth { get; set; }
        public int GetHealth()
        {
            return _health;
        }
        public void SetHealth(int value)
        {
            _health = value;
        }
        public void Domage(int amount)
        {
            if (_health == 0)
            {

            }

            _health -= amount;
            _health = Math.Max(0, _health - amount);
        }
        public void Regen(int amount)
        {
            _health = Math.Min(_maxHealth, _health + amount);

        }
    }
}