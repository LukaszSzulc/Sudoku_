using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Tests
{
    public class SquareBuilder
    {
        private int[,] square;

        private SquareBuilder()
        {
            square = new int[3,3];
        }

        public static SquareBuilder Create()
        {
            return new SquareBuilder();
        }

        public SquareBuilder Add(int x, int y, int value)
        {
            square[x, y] = value;
            return this;
        }

        public int[,] Build()
        {
            return square;
        }
    }
}
