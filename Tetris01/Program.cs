using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris01
{
    enum Type {I, J, L, O, S};
    enum Orientation {PUPFP, RRFL}
    enum Mode {INSERT, REMOVE};
    class Program
    {
        private static int HEIGHT = 16;
        private static int WIDTH = 10;
        private static bool[,] grid;
        private static Type peiceType; 
        private static Tuple<int,int> peicePos;
        private static Orientation peiceOr;
        private static Tuple<int, int> pieceBox;

        static void Main(string[] args)
        {
            //lets program it right here XD
            //grid size 10x16
            grid = new bool[HEIGHT, WIDTH];
            
           
           
            for (int i = 0; i < HEIGHT; i++)
            {
                for(int j = 0; j < WIDTH; j++)
                {
                    grid[i,j] = false;
                }
            }
            grid[15, 0] = true;
            grid[15, 4] = true;
            grid[14, 4] = true;
            grid[13, 4] = true;
            grid[12, 4] = true;
            grid[11, 4] = true;
            grid[15, 5] = true;
            // peicePos = new Tuple<int, int>(peicePos.Item1 + 1, peicePos.Item2);
            peicePos = new Tuple<int, int>(0, 5);
            peiceType = Type.I;
           // peiceOr = Orientation.PUPFP;
            peiceOr = Orientation.RRFL;
            InsertPeice();
            Output();
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        MoveDown();
                        Console.Clear();
                        Output();
                        break;
                    case ConsoleKey.UpArrow:
                        MoveUp();
                        Console.Clear();
                        Output();
                        break;
                }
            }
        }
        static bool MoveDown()
        {
            RemovePeice();
            peicePos = new Tuple<int, int>(peicePos.Item1+1, peicePos.Item2);
            if (InsertPeice())
            {
                return true;
            }
            peicePos = new Tuple<int, int>(peicePos.Item1-1, peicePos.Item2);
            InsertPeice();
            return false;
        }
        static bool MoveUp()
        {
            RemovePeice();
            peicePos = new Tuple<int, int>(peicePos.Item1 - 1, peicePos.Item2);
            if (InsertPeice())
            {
                return true;
            }
            peicePos = new Tuple<int, int>(peicePos.Item1 + 1, peicePos.Item2);
            InsertPeice();
            return false;
        }
        static bool InsertPeice(Mode mode = Mode.INSERT)
        {
            int xi = 4;
            int xj = 2;
            var p = new bool[0, 0];
            var tempGrid = grid;
            int ii, jj;
            
            GenPeice(out p, peiceType, peiceOr);
            ii = peicePos.Item1;
            jj = peicePos.Item2;

            for (int i = 0; i < xi; i++)
            {
                for (int j = 0; j < xj; j++)
                {
                    if (!p[i, j]) continue; //Empty square has no effect on filled square.

                    if (grid[ii, jj] && p[i, j]) //New position already contains a filled square.
                    {
                        if (mode == Mode.INSERT)
                            return false;
                        if (mode == Mode.REMOVE)
                            tempGrid[ii, jj++] = false;
                    }
                    else
                    {
                        tempGrid[ii, jj++] = p[i, j];
                    }
                } 
                jj = peicePos.Item2;
                ii++;
            }
            grid = tempGrid;
            
            return true;
        }

        static void GenPeice(out bool [,] peice, Type type, Orientation orientation)
        {
            int xi, xj;
            var p = new bool[0, 0];
            switch (peiceType)
            {
                case Type.I:

                    if (peiceOr == Orientation.PUPFP)
                    {
                        xi = 2;
                        xj = 4;
                        p = new bool[xi, xj];
                        p[0, 0] = true;
                        p[0, 1] = true;
                        p[0, 2] = true;
                        p[0, 3] = true;
                    }
                    else if (peiceOr == Orientation.RRFL)
                    {
                        xi = 4;
                        xj = 2;
                        p = new bool[xi, xj];
                        p[0, 1] = true;
                        p[1, 1] = true;
                        p[2, 1] = true;
                        p[3, 1] = true;
                    }
                    break;
                case Type.J:

                    if (peiceOr == Orientation.PUPFP)
                    {
                        xi = 2;
                        xj = 4;
                        p = new bool[xi, xj];
                        p[0, 0] = true;
                        p[1, 0] = true;
                        p[1, 1] = true;
                        p[1, 2] = true;
                    }
                    else if (peiceOr == Orientation.RRFL)
                    {
                        xi = 4;
                        xj = 2;
                        p = new bool[xi, xj];
                        p[0, 0] = true;
                        p[0, 1] = true;
                        p[1, 0] = true;
                        p[2, 0] = true;
                    }
                    break;
                case Type.L:

                    if (peiceOr == Orientation.PUPFP)
                    {
                        xi = 2;
                        xj = 4;
                        p = new bool[xi, xj];
                        p[0, 3] = true;
                        p[1, 1] = true;
                        p[1, 2] = true;
                        p[1, 3] = true;
                    }
                    else if (peiceOr == Orientation.RRFL)
                    {
                        xi = 4;
                        xj = 2;
                        p = new bool[xi, xj];
                        p[0, 0] = true;
                        p[1, 0] = true;
                        p[2, 0] = true;
                        p[2, 1] = true;
                    }
                    break;
                case Type.O:

                    xi = 2;
                    xj = 4;
                    p = new bool[xi, xj];
                    p[0, 0] = true;
                    p[0, 1] = true;
                    p[1, 0] = true;
                    p[1, 1] = true;

                    break;
                case Type.S:

                    if (peiceOr == Orientation.PUPFP)
                    {
                        xi = 2;
                        xj = 4;
                        p = new bool[xi, xj];
                        p[0, 1] = true;
                        p[0, 2] = true;
                        p[1, 0] = true;
                        p[1, 1] = true;
                    }
                    else if (peiceOr == Orientation.RRFL)
                    {
                        xi = 4;
                        xj = 2;
                        p = new bool[xi, xj];
                        p[0, 0] = true;
                        p[1, 0] = true;
                        p[1, 1] = true;
                        p[2, 1] = true;
                    }
                    break;
            }
            peice = p;
        }  
        static void RemovePeice()
        {
            InsertPeice(Mode.REMOVE);

        }
        static bool IsRowFilled(int r)
        {
            for (int i = 0; i < WIDTH; i++)
            {
                if (!grid[r, i])
                {
                    return false;
                }     
            }
            return true;
        }
        static void Output()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < WIDTH; j++)
                {
                    if (grid[i, j])
                    {
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine(" |");
            }
            Console.WriteLine("==================================");
        }
    }
}
