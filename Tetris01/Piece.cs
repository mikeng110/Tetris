using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris01
{
    public enum Direction {UP, DOWN, LEFT, RIGHT };

    public class Piece
    {

        public Piece()
        {
            content = new List<Square>();


        }
        public List<Square> content;
        public int pos;
        private Square GenarateRandomPiece()
        {
            return new Square(0,0);
        }
        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.UP:
                    break;
                case Direction.DOWN:
                    break;
                case Direction.LEFT:
                    break;
                case Direction.RIGHT:
                    break;
            }
        }
    }
}
