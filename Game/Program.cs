using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            const int height = 21;
            const int width = 21;

            Console.CursorVisible = false;
            Random rng = new Random();
            MapElement[,] field = new MapElement[width, height];

            field[0, height / 2] = new Player('♀');


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    field[rng.Next(width - 1) + 1, rng.Next(height)] = new Rock('O');
                }

                for (int j = 0; j < 7; j++)
                {
                    field[rng.Next(width - 1) + 1, rng.Next(height)] = new Monster('♠');
                }

                for (int j = 0; j < 5; j++)
                {
                    field[rng.Next(width - 1) + 1, rng.Next(height)] = new RockDestroyer('♣');
                }
            }

            bool win = false;
            while (!win)
            {
                MapElement[,] newField = new MapElement[width, height];
                Teken(width, height, field);
                ConsoleKey input = Console.ReadKey(true).Key;
                int xplus = 0;
                int yplus = 0;
                bool skip = false;

                switch (input)
                {
                    case ConsoleKey.LeftArrow: xplus = -1; break;
                    case ConsoleKey.DownArrow: yplus = 1; break;
                    case ConsoleKey.RightArrow: xplus = 1; break;
                    case ConsoleKey.UpArrow: yplus = -1; break;
                    default: skip = true; break;
                }

                if (!skip)
                {
                    for (int row = 0; row < height; row++)
                    {
                        for (int col = 0; col < width; col++)
                        {
                            if (field[col, row] is Player)
                            {
                                int xGoto = col + xplus;
                                int yGoto = row + yplus;
                                xGoto = Clamp(xGoto, 0, width - 1);
                                yGoto = Clamp(yGoto, 0, height - 1);

                                if (xGoto != col || yGoto != row)
                                {
                                    if (field[xGoto, yGoto] == null)
                                    {
                                        newField[xGoto, yGoto] = new Player('♀');
                                        field[col, row] = null;

                                        if (xGoto == width-1)
                                        {
                                            win = true;
                                        }
                                    }
                                    else
                                    {
                                        if (field[xGoto, yGoto] is Monster || field[xGoto, yGoto] is Rock)
                                        {
                                            field[xGoto, yGoto] = null;
                                        }
                                    }
                                }

                            }
                        }
                    }

                    for (int row = 0; row < height; row++)
                    {
                        for (int col = 0; col < width; col++)
                        {
                            if (newField[col, row] != null)
                            {
                                field[col, row] = newField[col, row];
                            }
                        }
                    }

                    Teken(width, height, field);
                    newField = new MapElement[width, height];
                    System.Threading.Thread.Sleep(100);
                    for (int row = 0; row < height; row++)
                    {
                        for (int col = 0; col < width; col++)
                        {
                            if (field[col, row] is Monster)
                            {
                                int xMonsterPlus = 0;
                                int yMonsterPlus = 0;

                                switch (rng.Next(4))
                                {
                                    case 0: xMonsterPlus = -1; break;
                                    case 1: xMonsterPlus = 1; break;
                                    case 2: yMonsterPlus = -1; break;
                                    case 3: yMonsterPlus = 1; break;
                                }

                                int xGoto = xMonsterPlus + col;
                                int yGoto = yMonsterPlus + row;
                                xGoto = Clamp(xGoto, 0, width - 1);
                                yGoto = Clamp(yGoto, 0, height - 1);

                                if (xGoto != col || yGoto != row)
                                {
                                    if (field[xGoto, yGoto] == null)
                                    {
                                        if (field[col, row] is RockDestroyer)
                                            newField[xGoto, yGoto] = new RockDestroyer('♣');
                                        else
                                            newField[xGoto, yGoto] = new Monster('♠');
                                        field[col, row] = null;
                                        field[xGoto, yGoto] = new Empty();
                                    }
                                    else
                                    {
                                        if (field[xGoto, yGoto] is IDestructableByMonster)
                                        {
                                            field[xGoto, yGoto] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    for (int row = 0; row < height; row++)
                    {
                        for (int col = 0; col < width; col++)
                        {
                            if (newField[col, row] != null)
                            {
                                field[col, row] = newField[col, row];
                            }
                        }
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Proficiat!");
            Console.ReadLine();
        }

        static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        static void Teken(int width, int height, MapElement[,] field)
        {
            Console.SetCursorPosition(0, 0);

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (field[col, row] == null)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        if (field[col, row] is Rock)
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        if (field[col, row] is Monster)
                            Console.ForegroundColor = ConsoleColor.Red;
                        if (field[col, row] is RockDestroyer)
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        if (field[col, row] is Player)
                            Console.ForegroundColor = ConsoleColor.Green;

                        field[col, row].Draw();

                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
