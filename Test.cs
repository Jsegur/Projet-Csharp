using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


enum PlayerState
{
    IDLE = 0,
    WALK = 1,
    RUN = 2,
    SWIM = 3,
}

namespace ProjetCsharp
{
    internal class test
    {
        void main()
        {

            Console.WriteLine("Hello, World!");

            int a;
            string aa;
            float aaa;
            double aaaa;

            var _age = 15; //champ

            var age = 12;
            (string, int, float, double, bool) b = ("", 12, 2.5f, 2.5, true);
            var bb = ("", 12, 2.5f, 2.5, true);

            string name = "hello";

            Console.WriteLine(age < 18 ? "mineur" : "majeur");

            PlayerState monState = PlayerState.IDLE;
            switch (monState)
            {
                case PlayerState.IDLE:
                    break;
                case PlayerState.WALK:
                    Console.WriteLine("1");
                    break;
                case PlayerState.RUN:
                    Console.WriteLine("2");
                    break;
                case PlayerState.SWIM:
                    break;
                default:
                    break;
            }

            dynamic yo = 12;
            yo = "cc";
            yo = false;

            dynamic CoUcOu(dynamic para)
            {
                return 0;
            }

            foreach (var val in new[] { 12, 13, 14, 15 })
            {
                foreach (var val2 in new[] { 12, 13, 14, 15 })
                {

                }
                if (val % 2 == 0) break;
                Console.WriteLine(val);
            }
        }
    }
}

