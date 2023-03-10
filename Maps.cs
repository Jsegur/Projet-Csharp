using ProjetCsharp;
using System.Text.Json;

internal class Maps// : Fight
{
    string[] _legend = { "P : Player", "S : Start", "X : Point of interest", "D : Door", "E : Exit", "A : Enemy", "B : Strong enemy", "C : Boss" };
    static string[] _tempmap = File.ReadAllLines("Map.txt");
    static char[,] _map = ExtractMap(_tempmap);
    static int _mapLength = _map.GetLength(1);
    static int _mapWidth = _map.GetLength(0);
    static int _playerX = 2;
    static int _oldX = _playerX;
    static int _playerY = 9;
    static int _oldY = _playerY;
    static char _tileUnderPlayer = _map[_playerX, _playerY];
    static char[] _walls = { '─', '│', '┌', '┐', '└', '┘', '┤', '┬', '┴' };
    static char[] _events = { 'X', 'D', 'E', 'A', 'B', 'C' }; // X1 : 8 ; 9 / X2 : 21 ; 25
    static int _keyNumber = 0;
    static Dictionary<string, int> _items;
    static string[] _inventory = File.ReadAllLines("Inventory.json");
    static bool _runGame = true;

    public int Width { get => _mapWidth; }
    public int Length { get => _mapLength; }
    public bool RunGame { get => _runGame; set => _runGame = value; }
    public Dictionary<string, int> Items { get => _items; }

    public static char[,] ExtractMap(string[] input)
    {
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

    public void LoadInventory()
    {
        string file = File.ReadAllText("Inventory.json");
        _items = JsonSerializer.Deserialize<Dictionary<string, int>>(file)!;
    }

    public void SaveInventory()
    {
        JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
        var txt = JsonSerializer.Serialize(_items, options);
        File.WriteAllText("Inventory.json", txt);
    }

    public void PrintMap()
    {
        LoadInventory();
        Console.Clear();
        Console.WriteLine("Kill enemies and stronger enemies to get the keys that will unlock the doors to get to the boss and defeat him.\nMove with the arrow keys and quit game with escape key.");
        Console.WriteLine("\nLegend :");
        foreach (string i in _legend) Console.WriteLine(i);
        string inv = "\nInventory :";
        foreach (var i in _items)
        {
            if (i.Value <= 0)
                continue;
            if (i.Value == 1)
            {
                inv += $" {i.Key},";
            }
            else
            {
                inv += $" {i.Key}({i.Value}),";
            }

        }
        if (inv.EndsWith(','))
        {
            inv = inv.Remove(inv.Length - 1);
        }
        Console.WriteLine(inv);
        Console.WriteLine($"Keys : {_keyNumber}");
        _map[_playerX, _playerY] = 'P';
        for (int i = 0; i < _mapWidth; i++)
        {
            for (int j = 0; j < _mapLength; j++)
            {
                Console.Write("{0}", _map[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void GoLeft()
    {
        if (!_walls.Contains(_map[_playerX, _playerY - 1]))
        {
            _map[_playerX, _playerY] = _tileUnderPlayer;
            _oldY = _playerY;
            _oldX = _playerX;
            _playerY--;
            _tileUnderPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void GoRight()
    {
        if (!_walls.Contains(_map[_playerX, _playerY + 1]))
        {
            _map[_playerX, _playerY] = _tileUnderPlayer;
            _oldY = _playerY;
            _oldX = _playerX;
            _playerY++;
            _tileUnderPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void GoUp()
    {
        if (!_walls.Contains(_map[_playerX - 1, _playerY]))
        {
            _map[_playerX, _playerY] = _tileUnderPlayer;
            _oldY = _playerY;
            _oldX = _playerX;
            _playerX--;
            _tileUnderPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void GoDown()
    {
        if (!_walls.Contains(_map[_playerX + 1, _playerY]))
        {
            _map[_playerX, _playerY] = _tileUnderPlayer;
            _oldY = _playerY;
            _oldX = _playerX;
            _playerX++;
            _tileUnderPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void Encounter()
    {
        if (_events.Contains(_tileUnderPlayer))
        {
            switch (_tileUnderPlayer)
            {
                case 'X':
                    if (_playerX == 8 && _playerY == 9)
                    {
                        Console.WriteLine("You found a sword !");
                        _items["Sword"] += 1;
                        SaveInventory();
                        _tileUnderPlayer = ' ';
                    }
                    if (_playerX == 21 && _playerY == 25)
                    {
                        Console.WriteLine("You found an armor !");
                        _items["Armor"] += 1;
                        SaveInventory();
                        _tileUnderPlayer = ' ';
                    }
                    if (_playerX == 10 && _playerY == 19)
                    {
                        Console.WriteLine("You found a potion !");
                        _items["Potion"] += 1;
                        SaveInventory();
                        _tileUnderPlayer = ' ';
                    }
                    break;
                case 'D':
                    Console.WriteLine("You encountered a door !");
                    if (_keyNumber > 0)
                    {
                        _tileUnderPlayer = ' ';
                        _keyNumber--;
                    }
                    else
                    {
                        _map[_playerX, _playerY] = 'D';
                        _map[_oldX, _oldY] = ' ';
                        _playerX = _oldX;
                        _playerY = _oldY;
                        _map[_playerX, _playerY] = 'P';
                        _tileUnderPlayer = ' ';
                        PrintMap();
                    }
                    break;
                case 'E':
                    Console.WriteLine("Congratulations, you found the exit !");
                    _items["Sword"] = 0;
                    _items["Armor"] = 0;
                    _items["Potion"] = 0;
                    SaveInventory();
                    Thread.Sleep(2000);
                    _runGame = false;
                    break;
                case 'A':
                    Fight fight1 = new Fight();
                    _keyNumber++;
                    _tileUnderPlayer = ' ';
                    break;
                case 'B':
                    Fight fight2 = new Fight();
                    _keyNumber++;
                    _tileUnderPlayer = ' ';
                    break;
                case 'C':
                    Fight fight3 = new Fight();
                    _keyNumber++;
                    _tileUnderPlayer = ' ';
                    break;
                default:
                    break;
            }
        }
    }
}
