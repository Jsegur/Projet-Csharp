using System;

public class Health {
    int _health;
    int _maxHealth;
    bool isKo;

    public int Health_ { get => _health;  set => _health = value; }
    public int MaxHealth_ { get => _maxHealth; set => _maxHealth = value; }
    public bool IsKo { get => isKo; }

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _health = _maxHealth;
    }
    public Health(int maxHealth, int currentHealth)
    {
        _maxHealth = maxHealth;
        _health = currentHealth;
    }

    public void Damage(int amount) {
        if (amount > 0) {
            _health = Math.Max(0, _health - amount);
        }
        Console.WriteLine($"{amount} HP lost");
        if (_health ==0) {
            isKo= true;
        } else {
            isKo= false;
        }
    }

    public void Regen (int amount) {
        if (amount > 0) { 
            _health = Math.Min(_maxHealth, _health + amount); 
        }
        Console.WriteLine($"{amount} HP regenerated");
        if (_health == 0) {
            isKo = true;
        } else {
            isKo = false;
        }
    }

    public void KoOrNot() {
        if (IsKo) {
            Console.WriteLine("KO !");
        } else {
            Console.WriteLine("Not KO");
        }
    }

}

public class Program { 
    static void Main(string[] args) {
        Console.SetWindowSize(145, 39);
        Health health = new Health(1000);
        Console.WriteLine($"Health : {health.Health_}");
        health.Health_ = 100;
        Console.WriteLine($"Health : {health.Health_}");
        health.Regen(400);
        Console.WriteLine($"Health : {health.Health_}");
        health.Regen(300);
        Console.WriteLine($"Health : {health.Health_}");
        health.Regen(600);
        Console.WriteLine($"Health : {health.Health_}");
        health.Damage(600);
        Console.WriteLine($"Health : {health.Health_}");
        health.Damage(300);
        Console.WriteLine($"Health : {health.Health_}");
        health.Damage(400);
        Console.WriteLine($"Health : {health.Health_}");
        Console.WriteLine();
        health.KoOrNot();
        Console.WriteLine("Kill enemies and strong enemies to get the keys that will unlock the doors to get to the boss and defeat him.");
        string[] legend = { "S : Start","X : Point of interest","D : Door","E : Exit","A : Enemy","B : Strong enemy","C : Boss" };
        string[] tempmap = File.ReadAllLines("../../../Map.txt"); 

        char[,] map = ExtractMap(tempmap);
        int mapLength = map.GetLength(1);
        int mapWidth = map.GetLength(0);

        Console.WriteLine($"\nMap width : {mapWidth}\nMap length : {mapLength}");
        Console.WriteLine($"\nMap legend :");
        foreach(string i in legend) Console.WriteLine(i);

        Console.WriteLine();
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