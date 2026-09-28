using System.Data;
using System.Diagnostics;
using System.Numerics;
using System.Runtime;
using System.Runtime.CompilerServices;

namespace beast_in_labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------------
            // LOAD INPUT
            // ------------------

            int width = int.Parse(Console.ReadLine()!);
            int height = int.Parse(Console.ReadLine()!);

            char[,] map = new char[height, width];

            for (int y = 0; y < height; y++)
            {
                string line = Console.ReadLine()!;

                for (int x = 0; x < width; x++)
                {
                    map[y, x] = line[x];
                }
            }

            // ------------------
            // CONSTRUCT MONSTERS
            // ------------------

            List<Monster> monsters = new List<Monster>();

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (directionToChar.Contains(map[row, col]))
                    {
                        monsters.Add(new Monster(map, row, col));
                    }
                }
            }

            // ------------------
            // 20 STEPS
            // ------------------

            for (int i = 0; i < 20; i++)
            {
                foreach (Monster monster in monsters)
                {
                    monster.GameTurn();
                }
                Console.WriteLine();
                Console.WriteLine("{0}. krok", i+1);
                PrintMap(map);
            }
        }

        static void PrintMap(char[,] map)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    Console.Write(map[row, col]);
                }
                Console.WriteLine();
            }
        }

        static List<char> directionToChar = new List<char> { '^', '>', 'v', '<' };
        static List<(int row, int col)> directionToCords = [(-1, 0), (0, 1), (1, 0), (0, -1)];

        class Monster
        {
            public char[,] map;

            public int row;
            public int col;

            public int orientation;

            public Monster(char[,] _map, int _row, int _col)
            {
                row = _row;
                col = _col;
                map = _map;

                this.SetOrientation();
            }

            /// <summary>
            /// From this.row and this.col calculates and sets this.orientation.
            /// </summary>
            public void SetOrientation()
            {
                orientation = directionToChar.IndexOf(map[row, col]);
            }

            public void GameTurn()
            {
                char right = map[row + directionToCords[(orientation + 1) % 4].row, col + directionToCords[(orientation + 1) % 4].col];
                char front = map[row + directionToCords[orientation].row, col + directionToCords[orientation].col];
                char frontright = map[row + directionToCords[orientation].row + directionToCords[(orientation + 1) % 4].row, col + directionToCords[orientation].col + directionToCords[(orientation + 1) % 4].col];

                // cases when 'X' is on the right
                if (right != '.' && front != '.') this.Rotate(-1);
                else if (right != '.') this.StepForwards();
                // cases when '.' is on the right
                else if (front != '.') this.Rotate(1);
                else if (frontright != '.') this.StepForwards();
                else this.Rotate(1);
            }

            public void Rotate(int rotation)
            {
                this.orientation = ((this.orientation + rotation) % 4 + 4) % 4;

                this.map[row, col] = directionToChar[this.orientation];
            }

            public void StepForwards()
            {
                this.map[row, col] = '.';

                this.row += directionToCords[this.orientation].row;
                this.col += directionToCords[this.orientation].col;

                this.map[row, col] = directionToChar[this.orientation];
            }
        }
    }
}
