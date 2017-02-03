using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris01
{
    enum Type {I, J, L, O, S};
    enum Orientation {PUPFP, RRFL}
    class Program
    {
        private static int HEIGHT = 16;
        private static int WIDTH = 10;
        private static bool[,] grid;
        private static Type peiceType; 
        private static Tuple<int,int> peicePos;
        private static Orientation peiceOr;
        static void Main(string[] args)
        {
            //lets program it right here XD
            //grid size 10x16
            grid = new bool[HEIGHT, WIDTH];
            peicePos = new Tuple<int, int>(0,4);
           
            peiceType = Type.I;
            peiceOr = Orientation.PUPFP;
            for (int i = 0; i < HEIGHT; i++)
            {
                for(int j = 0; j < WIDTH; j++)
                {
                    grid[i,j] = false;
                }
            }
            grid[15, 0] = true;
            grid[15, 4] = true;
            grid[15, 5] = true;
           // peicePos = new Tuple<int, int>(peicePos.Item1 + 1, peicePos.Item2);
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();
            peiceOr = Orientation.RRFL;
            Console.Clear();
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();

            Console.Clear();
            peiceType = Type.J;
            peiceOr = Orientation.PUPFP;
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();
            peiceOr = Orientation.RRFL;
            Console.Clear();
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();

            Console.Clear();
            peiceType = Type.L;
            peiceOr = Orientation.PUPFP;
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();
            peiceOr = Orientation.RRFL;
            Console.Clear();
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();

            Console.Clear();
            peiceType = Type.O;
            peiceOr = Orientation.PUPFP;
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();
            peiceOr = Orientation.RRFL;
            Console.Clear();
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();

            Console.Clear();
            peiceType = Type.S;
            peiceOr = Orientation.PUPFP;
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();
            peiceOr = Orientation.RRFL;
            Console.Clear();
            InsertPeice();
            Output();
            Console.ReadKey();
            RomovePeice();
        }
        static void InsertPeice(bool b = true)
        {
            int xi = 4;
            int xj = 2;
            var p = new bool[0, 0];

            switch (peiceType)
            {
                case Type.I:
                    
                    if (peiceOr == Orientation.PUPFP)
                    {
                        xi = 2;
                        xj = 4;
                        p = new bool[xi, xj];
                        p[0, 0] = b;
                        p[0, 1] = b;
                        p[0, 2] = b;
                        p[0, 3] = b;
                    }
                    else if (peiceOr == Orientation.RRFL)
                    {
                        xi = 4;
                        xj = 2;
                        p = new bool[xi, xj];
                        p[0, 1] = b;
                        p[1, 1] = b;
                        p[2, 1] = b;
                        p[3, 1] = b;
                    }
                    break;
                case Type.J:

                    if (peiceOr == Orientation.PUPFP)
                    {
                        xi = 2;
                        xj = 4;
                        p = new bool[xi, xj];
                        p[0, 0] = b;
                        p[1, 0] = b;
                        p[1, 1] = b;
                        p[1, 2] = b;
                    }
                    else if (peiceOr == Orientation.RRFL)
                    {
                        xi = 4;
                        xj = 2;
                        p = new bool[xi, xj];
                        p[0, 0] = b;
                        p[0, 1] = b;
                        p[1, 0] = b;
                        p[2, 0] = b;
                    }
                    break;
                case Type.L:

                    if (peiceOr == Orientation.PUPFP)
                    {
                        xi = 2;
                        xj = 4;
                        p = new bool[xi, xj];
                        p[0, 3] = b;
                        p[1, 1] = b;
                        p[1, 2] = b;
                        p[1, 3] = b;
                    }
                    else if (peiceOr == Orientation.RRFL)
                    {
                        xi = 4;
                        xj = 2;
                        p = new bool[xi, xj];
                        p[0, 0] = b;
                        p[1, 0] = b;
                        p[2, 0] = b;
                        p[2, 1] = b;
                    }
                    break;
                case Type.O:

                    xi = 2;
                    xj = 4;
                    p = new bool[xi, xj];
                    p[0, 0] = b;
                    p[0, 1] = b;
                    p[1, 0] = b;
                    p[1, 1] = b;

                    break;
                case Type.S:

                    if (peiceOr == Orientation.PUPFP)
                    {
                        xi = 2;
                        xj = 4;
                        p = new bool[xi, xj];
                        p[0, 1] = b;
                        p[0, 2] = b;
                        p[1, 0] = b;
                        p[1, 1] = b;
                    }
                    else if (peiceOr == Orientation.RRFL)
                    {
                        xi = 4;
                        xj = 2;
                        p = new bool[xi, xj];
                        p[0, 0] = b;
                        p[1, 0] = b;
                        p[1, 1] = b;
                        p[2, 1] = b;
                    }
                    break;

            }
            int ii, jj;
            ii = peicePos.Item1;
            jj = peicePos.Item2;
            
            for (int i = 0; i < xi; i++)
            {
                for (int j = 0; j < xj; j++)
                {
                    grid[ii, jj++] = p[i,j];
                } 
                jj = peicePos.Item2;
                ii++;
            }

        }
        static void RomovePeice()
        {
            InsertPeice(false);

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
