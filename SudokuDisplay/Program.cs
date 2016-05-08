using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDisplay
{
    class Program
    {
        const int MaxIterationNumber = 1000;
        static void Main(string[] args)
        {
            var sudoku = SudokuTest.CreateSquareCollection();
            int iterationCounter = 0;
            while (sudoku.EmptyFieldsExistsInSudoku || iterationCounter > MaxIterationNumber)
            {
                for (int i = 1; i <= 9; i++)
                {
                    sudoku.DeleteRowsAndColumns(i);
                    sudoku.DeleteNonEmptyElements();
                    var squares = sudoku.GetSquaresToAddValue();
                    if (squares.Any())
                    {
                        var square = squares.First();
                        sudoku.SetValuesInSquare(square.RowId, square.ColumnId, i);
                    }

                    sudoku.ResetAllDeletion();
                }

                iterationCounter++;
            }
            sudoku.Display();
            Console.ReadKey();
        }
    }
}
