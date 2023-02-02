using ProjetCsharp.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Index
{
    START,
    ACTIONS,
    ATTACKS,
    ITEMS,
    FLEE,
    USE_ATTACK,
    RESULT_ATTACK,
    USE_ITEM,
    RESULT_ITEM,
    ENEMY_ATTACK,
}

namespace ProjetCsharp
{
    internal class Fight : Stat
    {
        private Index index = Index.ACTIONS;
        private bool phase1 = true;

        public  Fight()
        {
            // Replace later with appropriate actions
            // Make a "Choice with back option" class

            Choices ActionChoice = new Choices(new List<string> { "Attack", "Item", "Fuir" });
            Choices AttackChoice = new Choices(Attacks);
            Choices ItemChoice = new Choices(Items);


            Console.WriteLine("You stumble on a Slime !");

            ConsoleKey e;
            e = Console.ReadKey().Key;
            bool loop = true;
            while (loop)
            {
                Console.Clear();

                Console.WriteLine(PName + "\nHP : " + PHealth_ + " / " + MaxPHealth_ + "\n");
                Console.WriteLine(MName + "\nHP : " + MHealth_ + " / " + MaxMHealth_ + "\n");

                switch (index)
                {
                    case Index.ACTIONS:
                        if (PHealth_ < 1)
                        {
                            Console.WriteLine("You died !");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("What will you do ?");
                            ActionChoice.Event(e);
                            ActionChoice.Write();
                            e = Console.ReadKey().Key;
                            if (e == ConsoleKey.Enter)
                            {
                                switch (ActionChoice.State)
                                {
                                    case 0:
                                        index = Index.ATTACKS;
                                        break;
                                    case 1:
                                        index = Index.ITEMS;
                                        break;
                                    case 2:
                                        index = Index.FLEE;
                                        break;
                                }
                            }
                        }
                        
                        break;

                    case Index.ATTACKS:
                        Console.WriteLine("Attacks :");
                        AttackChoice.Event(e);
                        AttackChoice.Write();
                        e = Console.ReadKey().Key;
                        if (e == ConsoleKey.Enter) { index = Index.USE_ATTACK; }
                        else if (e == ConsoleKey.Backspace) { index = Index.ACTIONS; }
                        break;

                    case Index.ITEMS: // Peut être faire une page classe spéciale
                        Console.WriteLine("Items :");
                        ItemChoice.Event(e);
                        ItemChoice.Write();
                        e = Console.ReadKey().Key;
                        if (e == ConsoleKey.Enter) { index = Index.USE_ITEM; }
                        else if (e == ConsoleKey.Backspace) { index = Index.ACTIONS; }
                        break;

                    case Index.FLEE:
                        Console.WriteLine("You flee !");
                        loop = false;
                        break;

                    case Index.USE_ATTACK:
                        Console.WriteLine("You use " + Attacks[AttackChoice.State]);
                        e = Console.ReadKey().Key;
                        if (e == ConsoleKey.Enter)
                        {
                            int damage = PStrenght_;
                            MHealth_ -= damage;
                            Console.WriteLine("It deals " + damage + " damage !");
                            e = Console.ReadKey().Key;
                            if (e == ConsoleKey.Enter) { index = Index.ENEMY_ATTACK; }
                        }
                        break;
                    //case Index.RESULT_ATTACK:

                    case Index.USE_ITEM:
                        Console.WriteLine("You use " + Items[ItemChoice.State]);
                        e = Console.ReadKey().Key;
                        if (e == ConsoleKey.Enter)
                        {
                            int lifeMissing = MaxPHealth_ - PHealth_;
                            int heal = 5;
                            if (heal > lifeMissing) { heal = lifeMissing; }
                            PHealth_ += heal;
                            Console.WriteLine("You healed " + heal + " HP !");
                            e = Console.ReadKey().Key;
                            if (e == ConsoleKey.Enter) { index = Index.ENEMY_ATTACK; }
                        }
                        break;

                    case Index.ENEMY_ATTACK:
                        if (MHealth_ < 0)
                        {
                            Console.WriteLine("You win !");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine(MName + " attacks " + PName);
                            e = Console.ReadKey().Key;
                            if (e == ConsoleKey.Enter)
                            {
                                int damage = MStrenght_;
                                PHealth_ -= damage;
                                Console.WriteLine("It deals " + PName + " " + damage + " damage !");
                                e = Console.ReadKey().Key;
                                if (e == ConsoleKey.Enter) { index = Index.ACTIONS; }
                            }
                        }
                        break;

                    default:
                        loop = false;
                        break;
                }


            }
        }
    }
}
