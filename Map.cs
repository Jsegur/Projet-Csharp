public class Program { 
    static void Main(string[] args) {
        Console.SetWindowSize(145, 39);
        Console.WriteLine("Kill enemies and strong enemies to get the keys that will unlock the doors to get to the boss and defeat him.");
        string[] legend = { "P : Player","S : Start","X : Point of interest","D : Door","E : Exit","A : Enemy","B : Strong enemy","C : Boss" };
        string[] tempmap = File.ReadAllLines("../../../Map.txt"); 

        char[,] map = ExtractMap(tempmap);
        int mapLength = map.GetLength(1);
        int mapWidth = map.GetLength(0);
        int playerX = 2;
        int playerY = 9;

        Console.WriteLine($"Map width : {mapWidth}\nMap length : {mapLength}");
        Console.WriteLine($"\nMap legend :");
        foreach(string i in legend) Console.WriteLine(i);
        Console.WriteLine();
        Console.WriteLine();

        map[playerX, playerY] = 'P';
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapLength; j++)
            {
                Console.Write("{0}", map[i, j]);
            }
            Console.WriteLine();
        }
        
    }

    public static char[,] ExtractMap(string[] input) {
        string[] tempmap = input;
        char[,] result = new char[tempmap.Length, tempmap.Max(i => i.Length)];
        for (int i = 0; i < tempmap.Length; i++)
        {
            for (int j = 0; j < tempmap[i].Length; j++)
            {
                if (tempmap[i].Length <= j) break;

                result[i, j] = tempmap[i][j];
            }
        }
        return result;
    }
}
