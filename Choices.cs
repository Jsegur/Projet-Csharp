using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCsharp.NewFolder
{
    internal class Choices
    {
        private List<string> choices= new List<string>();
        private int state = 0;
        public int State { get { return state; } }
        public Choices(List<string> choices)
        {
            this.choices = choices;
        }

        public int Event(ConsoleKey e)
        {
            
            switch (e)
            {
                case ConsoleKey.UpArrow:
                    if (state == 0)
                    {
                        state = choices.Count-1;
                    }
                    else
                    {
                        state --;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (state == choices.Count-1)
                    {
                        state = 0;
                    }
                    else
                    {
                        state ++;
                    }
                    break;
            }
            return state;
        }

        public void Write()
        {
            for (int i = 0; i < choices.Count; i++)
            {
                if (state == i) { Console.Write(" ► "); } else { Console.Write("   "); }
                Console.WriteLine(choices[i]);
            }

        }
    }
}
