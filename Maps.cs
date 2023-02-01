class Map {
    string[] _legend = { "P : Player", "S : Start", "X : Point of interest", "D : Door", "E : Exit", "A : Enemy", "B : Strong enemy", "C : Boss" };
    static string[] _tempmap = File.ReadAllLines("../../../Map.txt");
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
    static string[] _items = new string [3];
    static string _inventory = File.ReadAllText("../../../Inventory.json");
    static bool _game = true;

    public int Width { get => _mapWidth; }
    public int Length { get => _mapLength; }
    public bool Game { get => _game; set => _game = value; }

    public static char[,] ExtractMap(string[] input) {
        string[] tempmap = input;
        char[,] result = new char[tempmap.Length, tempmap.Max(i => i.Length)];
        for (int i = 0; i < tempmap.Length; i++) {
            for (int j = 0; j < tempmap[i].Length; j++) {
                if (tempmap[i].Length <= j) break;

                result[i, j] = tempmap[i][j];
            }
        }
        return result;
    }

    public void PrintMap() {
        Console.Clear();
        Console.WriteLine("Kill enemies and stronger enemies to get the keys that will unlock the doors to get to the boss and defeat him.\nMove with the arrow keys and quit game with escape key.");
        Console.WriteLine($"\nMap width : {_mapWidth}\nMap length : {_mapLength}");
        Console.WriteLine("\nLegend :");
        foreach (string i in _legend) Console.WriteLine(i);
        string inv = "\nInventory :";
        foreach (string i in _items) {
            if (i != null) {
                inv += $" {i},";
            }
        }
        if (inv.EndsWith(',')) {
            inv = inv.Remove(inv.Length-1);
        }
        Console.WriteLine(inv);
        Console.WriteLine($"Keys : {_keyNumber}");
        _map[_playerX, _playerY] = 'P';
        for (int i = 0; i < _mapWidth; i++) {
            for (int j = 0; j < _mapLength; j++) {
                Console.Write("{0}", _map[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void GoLeft(){
        if (!_walls.Contains(_map[_playerX, _playerY - 1])) {
            _map[_playerX, _playerY] = _tileUnderPlayer;
            _oldY= _playerY;
            _oldX= _playerX;
            _playerY--;
            _tileUnderPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void GoRight() {
        if (!_walls.Contains(_map[_playerX, _playerY + 1])) {
            _map[_playerX, _playerY] = _tileUnderPlayer;
            _oldY = _playerY;
            _oldX = _playerX;
            _playerY++;
            _tileUnderPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void GoUp() {
        if (!_walls.Contains(_map[_playerX - 1, _playerY])) {
            _map[_playerX, _playerY] = _tileUnderPlayer;
            _oldY = _playerY;
            _oldX = _playerX;
            _playerX--;
            _tileUnderPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void GoDown() {
        if (!_walls.Contains(_map[_playerX + 1, _playerY])){
            _map[_playerX, _playerY] = _tileUnderPlayer;
            _oldY = _playerY;
            _oldX = _playerX;
            _playerX++;
            _tileUnderPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void Encounter() {
        if (_events.Contains(_tileUnderPlayer)) {
            switch (_tileUnderPlayer) {
                case 'X':
                    if (_playerX == 8 && _playerY == 9) {
                        Console.WriteLine("You found a sword !");
                        _items[0] = "Sword";
                        _tileUnderPlayer = ' ';
                    } 
                    if (_playerX == 21 && _playerY == 25) {
                        Console.WriteLine("You found an armor !");
                        _items[1] = "Armor";
                        _tileUnderPlayer = ' ';
                    }
                    if (_playerX == 10 && _playerY == 19)
                    {
                        Console.WriteLine("You found a potion !");
                        _items[2] = "Potion";
                        _tileUnderPlayer = ' ';
                    }

                    break;
                case 'D':
                    Console.WriteLine("You encountered a door !");
                    if (_keyNumber > 0) {
                        _tileUnderPlayer = ' ';
                        _keyNumber--;
                    } else {
                        _map[_playerX, _playerY] = ' ';
                        _playerX = _oldX;
                        _playerY = _oldY;
                        _map[_playerX, _playerY] = 'P';
                    }
                    break;
                case 'E':
                    Console.WriteLine("Congratulations, you found the exit !");
                    Thread.Sleep(2000);
                    _game = false;
                    break;
                case 'A':
                    Console.WriteLine("You encountered an enemy.");
                    _keyNumber++;
                    _tileUnderPlayer = ' ';
                    break;
                case 'B':
                    Console.WriteLine("You encountered an stronger enemy.");
                    _keyNumber++;
                    _tileUnderPlayer = ' ';
                    break;
                case 'C':
                    Console.WriteLine("You encountered the boss.");
                    _keyNumber++;
                    _tileUnderPlayer = ' ';
                    break;
                default:
                    break;
            }
        }
    }
}

public class Maps { 
    static void Main(string[] args) {
        Map map = new Map();
        Console.SetWindowSize(map.Length + 1, map.Width + 20);
        
        map.PrintMap();

        while (map.Game) {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape) {
                map.Game = false;
            }
            if (key.Key == ConsoleKey.DownArrow) {
                map.GoDown();
                map.Encounter();
            }
            if (key.Key == ConsoleKey.UpArrow) {
                map.GoUp();
                map.Encounter();
            }
            if (key.Key == ConsoleKey.RightArrow) {
                map.GoRight();
                map.Encounter();
            }
            if (key.Key == ConsoleKey.LeftArrow) {
                map.GoLeft();
                map.Encounter();
            }
        }
    }
}
