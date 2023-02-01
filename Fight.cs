using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCsharp
{
    internal class Fight
    {
        int _maxHealth;
        int _phealth =100;
        int _mhealth = 100;
        int _pstrenght;
        int _mstrenght;
        int _modifStrenght;
        int _maxMana;
        int _mana;
        public int level;
        private float exp;
        private float expMax;
        public int PHealth_ { get => _phealth; set => _phealth = value; }
        public int MHealth_ { get => _mhealth; set => _mhealth = value; }
        public int PStrenght_ { get => _pstrenght; set => _pstrenght = value; }
        public int MStrenght_ { get => _mstrenght; set => _mstrenght = value; }
        public int ShortHealth { get; set; }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int GetHpMonster() 
        {
            return _mhealth;
        }
        public int GetHpPlayer()
        {
            return _phealth;
        }
        public void Domage(int amount)
        {
            if (_phealth == 0)
            {

            }

            _phealth -= amount;
            _phealth = Math.Max(0, _phealth - amount);
        }
        public void Regen(int amount)
        {
            _phealth = Math.Min(_maxHealth, _phealth + amount);

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void Start()
        {
            level = 1;
            exp = 0;
            expMax = 100;
        }
        void Up()
        {
            Exp();
            if (_mhealth <= 0)
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
                    _phealth = 200;
                    _mana = 200;
                    _pstrenght += 20;
                    expMax = 200;
                    break;
                case 3:
                    _phealth = 400;
                    _mana = 400;
                    _pstrenght += 40;
                    expMax = 300;
                    break;
                case 4:
                    _phealth = 800;
                    _mana = 800;
                    _pstrenght += 80;
                    expMax = 2000000000000000; 
                    break;
            }
        }
        void Exp()
        {
            if (exp >= expMax)
            {
                LevelUp();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int GetMonsterStrenght()
        {
            return _mstrenght;
        }
        public int GetPlayerStrenght()
        {
            return _pstrenght;
        }
        public void TotalStrenght()
        {
            _pstrenght = Math.Abs(_pstrenght + _modifStrenght);

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
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
        public void Consum(int amount)
        {
            if (_mana == 0)
            {

            }
            _mana -= amount;
            _mana = Math.Max(0, _mana - amount);
        }
        public void Restor(int amount)
        {
            _mana = Math.Min(_maxMana, _mana + amount);

        }
    }
}
