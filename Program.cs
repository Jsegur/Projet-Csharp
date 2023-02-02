// See https://aka.ms/new-console-template for more information
using ProjetCsharp;
using System.Diagnostics;
using System.Text;

internal class Game : Maps
{
    static void Main(string[] args)
    {
        Maps map = new Maps();
        Console.SetWindowSize(map.Length + 1, map.Width + 17);

        map.PrintMap();
        map.LoadInventory();

        while (map.RunGame)
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                map.Items["Sword"] = 0;
                map.Items["Armor"] = 0;
                map.Items["Potion"] = 0;
                map.SaveInventory();
                map.RunGame = false;
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                map.GoDown();
                map.Encounter();
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                map.GoUp();
                map.Encounter();
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                map.GoRight();
                map.Encounter();
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                map.GoLeft();
                map.Encounter();
            }
        }
    }
}