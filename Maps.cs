class Map {
    string[] _legend = { "P : Player", "S : Start", "X : Point of interest", "D : Door", "E : Exit", "A : Enemy", "B : Strong enemy", "C : Boss" };
    static string[] _tempmap = File.ReadAllLines("../../../Map.txt");
    static char[,] _map = ExtractMap(_tempmap);
    static int _mapLength = _map.GetLength(1);
    static int _mapWidth = _map.GetLength(0);
    static int _playerX = 2;
    static int _playerY = 9;
    static char _underPlayer = _map[_playerX, _playerY];
    static char[] _walls = { '─', '│', '┌', '┐', '└', '┘', '┤', '┬', '┴' };
    static char[] _events = { 'X', 'D', 'E', 'A', 'B', 'C' }; // X1 : 8 ; 9 / X2 : 21 ; 25

    public int MapWidth { get { return _mapWidth; } }
    public int MapLength { get { return _mapLength;} }

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
        Console.WriteLine("Kill enemies and strong enemies to get the keys that will unlock the doors to get to the boss and defeat him.");
        Console.WriteLine($"\nMap width : {_mapWidth}\nMap length : {_mapLength}");
        Console.WriteLine("\nLegend : ");
        foreach (string i in _legend) Console.WriteLine(i);
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
            _map[_playerX, _playerY] = _underPlayer;
            _playerY--;
            _underPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void GoRight() {
        if (!_walls.Contains(_map[_playerX, _playerY + 1])) {
            _map[_playerX, _playerY] = _underPlayer;
            _playerY++;
            _underPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void GoUp() {
        if (!_walls.Contains(_map[_playerX - 1, _playerY])) {
            _map[_playerX, _playerY] = _underPlayer;
            _playerX--;
            _underPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }

    public void GoDown() {
        if (!_walls.Contains(_map[_playerX + 1, _playerY])){
            _map[_playerX, _playerY] = _underPlayer;
            _playerX++;
            _underPlayer = _map[_playerX, _playerY];
            _map[_playerX, _playerY] = 'P';
            PrintMap();
        }
    }
}

public class Maps { 
    static void Main(string[] args) {
        Map map = new Map();
        Console.SetWindowSize(map.MapLength, map.MapWidth + 15);
        
        map.PrintMap();
        bool game = true;

        while (game) {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape) {
                game = false;
            }
            if (key.Key == ConsoleKey.DownArrow) {
                map.GoDown();
            }
            if (key.Key == ConsoleKey.UpArrow) {
                map.GoUp();
            }
            if (key.Key == ConsoleKey.RightArrow) {
                map.GoRight();
            }
            if (key.Key == ConsoleKey.LeftArrow) {
                map.GoLeft();
            }
        }
    }
}
