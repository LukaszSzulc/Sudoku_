namespace Sudoku.Tests
{
    using System.Collections.Generic;

    public class SudokuTest
    {

        private SquareCollection CreateSquareCollection()
        {
            var squareCollection = new SquareCollection();
            squareCollection.AddSquare(
                new Square(0, 0, SquareBuilder.Create().Add(0, 0, 7).Add(0, 2, 1).Add(1, 0, 4).Add(2, 2, 3).Build()));
            squareCollection.AddSquare(
                new Square(0, 1, SquareBuilder.Create().Add(1, 0, 6).Add(1, 2, 2).Add(2, 2, 1).Build()));
            squareCollection.AddSquare(
                new Square(0, 2, SquareBuilder.Create().Add(0, 0, 6).Add(0, 2, 2).Add(2, 1, 4).Build()));
            squareCollection.AddSquare(
                new Square(1, 0, SquareBuilder.Create().Add(0, 2, 8).Add(1, 1, 6).Add(2, 0, 1).Add(2, 1, 4).Build()));
            squareCollection.AddSquare(
                new Square(1, 1, SquareBuilder.Create().Add(0, 2, 3).Add(1, 2, 4).Add(2, 0, 4).Add(2, 1, 8).Build()));
            squareCollection.AddSquare(new Square(1, 2, SquareBuilder.Create().Build()));
            squareCollection.AddSquare(new Square(2, 0, SquareBuilder.Create().Add(1, 0, 2).Add(2, 2, 5).Build()));
            squareCollection.AddSquare(new Square(2, 1, SquareBuilder.Create().Add(0, 1, 7).Add(2, 1, 3).Build()));
            squareCollection.AddSquare(
                new Square(2, 2, SquareBuilder.Create().Add(0, 2, 4).Add(1, 0, 5).Add(2, 1, 9).Build()));
            return squareCollection;
        }
    }
}
