using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCsharp.Combat
{
    internal class Level
    {
        int _level;
        bool levelUp = false;
        int _exp = 0;
        int _addExp = 100;
        int _expMax = 100;
        int _point;

        public int Level_ { get => _level; set => _level = value; }
        public int GetLevel()
        {
            return _level;
        }
        public void SetLevel(int value)
        {
            _level = value;
        }

        private void LevelUp()
        {
            while (kill = true)
            {
                if (_exp = _expMax)

            }

        }
    }
}