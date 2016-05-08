using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public class SquareCollection
    {
        private List<Square> squares;

        public SquareCollection()
        {
            squares = new List<Square>();
        }

        public bool EmptyFieldsExistsInSudoku => CountEmptyFields() > 0;

        public void AddSquare(Square square) => squares.Add(square);

        public void SetAllAsAvailable()
        {
            squares.ForEach(x=>x.Disabled = true);
        }

        public void ResetAllDeletion()
        {
            foreach (var square in squares)
            {
                square.ResetDeletion();
                square.Disabled = false;
            }
        }

        public void DeleteRowsAndColumns(int element)
        {
            foreach (var square in squares)
            {
                var result = square.ContainsElement(element);
                if (result != null)
                {
                    DeleteElementsInRows(square.RowId,result.Item1);
                    DeleteElementsInColumns(square.ColumnId,result.Item2);
                    square.Disabled = true;
                }
            }
        }

        public void Display()
        {
            foreach (var square in squares)
            {
                Console.WriteLine($"Displaying {square.RowId} {square.ColumnId}");
                square.Display();
                Console.WriteLine();
            }
        }

        public void DisplayDeletion()
        {
            foreach (var square in squares)
            {
                Console.WriteLine($"Displaying {square.RowId} {square.ColumnId}");
                square.DisplayDeletion();
                Console.WriteLine();
            }
        }

        public void DeleteNonEmptyElements()
        {
            foreach (var square in squares)
            {
                square.DeleteNonEmptyElements();
            }
        }

        public List<Square> GetSquaresToAddValue()
        {
            var result = new List<Square>();
            var availableSquares = GetNotDisabledSquares();
            if (!availableSquares.Any())
            {
                return result;
            }

            foreach (var availableSquare in availableSquares)
            {
                if (availableSquare.CountNotDeletedIndexes() == 1)
                {
                    result.Add(availableSquare);
                }   
            }

            return result;
        }

        public void SetValuesInSquare(int rowId, int columnId, int value)
        {
            var square = squares.First(x => x.RowId == rowId && x.ColumnId == columnId);
            var index = square.GetNotDeletedIndex();
            square.SetElement(index.Item1,index.Item2,value);
        }
        private List<Square> GetNotDisabledSquares()
        {
            return squares.Where(x => !x.Disabled).ToList();
        }

        private void DeleteElementsInRows(int squareRowId, int row)
        {
            foreach (var square in squares)
            {
                if (square.RowId == squareRowId)
                {
                    square.DeleteElementsInRow(row);
                }
            }
        }

        private void DeleteElementsInColumns(int squareColumnId, int column)
        {
            foreach (var square in squares)
            {
                if (square.ColumnId == squareColumnId)
                {
                    square.DeleteElementsInColumn(column);
                }
            }
        }

        private int CountEmptyFields()
        {
            int sum = 0;
            foreach (var square in squares)
            {
                sum += square.CountEmptyFields();
            }

            return sum;
        }
    }
}
