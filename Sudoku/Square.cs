namespace Sudoku
{
    using System;

    public class Square
    {
        public int[,] SudokuSquare { get; }

        private readonly bool[,] deletion;

        private Square()
        {
            
        }

        public Square(int rowId, int columnId, int[,] sudokuSquare)
        {
            this.SudokuSquare = sudokuSquare;
            RowId = rowId;
            ColumnId = columnId;
            Disabled = false;
            deletion = new bool[sudokuSquare.GetLength(0),sudokuSquare.GetLength(1)];
        }

        public bool Disabled { get; set; }

        public int RowId { get; set; }

        public int ColumnId { get; set; }

        public void DeleteElementsInRow(int row)
        {
            for (int i = 0; i < SudokuSquare.GetLength(1); i++)
            {
                deletion[row, i] = true;
            }
        }

        public void DeleteElementsInColumn(int column)
        {
            for (int i = 0; i < SudokuSquare.GetLength(0); i++)
            {
                deletion[i, column] = true;
            }
        }

        public void ResetDeletion()
        {
            for (int i = 0; i < deletion.GetLength(0); i++)
            {
                for (int j = 0; j < deletion.GetLength(1); j++)
                {
                    this.deletion[i, j] = false;
                }
            }
        }

        public Tuple<int,int> ContainsElement(int value)
        {
            for (int i = 0; i < SudokuSquare.GetLength(0); i++)
            {
                for (int j = 0; j < SudokuSquare.GetLength(1); j++)
                {
                    if (SudokuSquare[i, j] == value)
                    {
                        return new Tuple<int, int>(i,j);
                    }
                }
            }

            return null;
        }

        public void SetElement(int x, int y, int value)
        {
            SudokuSquare[x, y] = value;
        }

        public int CountNotDeletedIndexes()
        {
            int counter = 0;
            for (var i = 0; i < deletion.GetLength(0); i++)
            {
                for (int j = 0; j < deletion.GetLength(1); j++)
                {
                    if (!deletion[i, j])
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public void Display()
        {
            for (int i = 0; i < SudokuSquare.GetLength(0); i++)
            {
                for (int j = 0; j < SudokuSquare.GetLength(1); j++)
                {
                    Console.Write($"{SudokuSquare[i,j]}  ");
                }

                Console.WriteLine();
            }
        }

        public void DeleteNonEmptyElements()
        {
            for (var i = 0; i < SudokuSquare.GetLength(0); i++)
            {
                for (var j = 0; j < SudokuSquare.GetLength(1); j++)
                {
                    if (SudokuSquare[i, j] != 0)
                    {
                        deletion[i, j] = true;
                    }
                }
            }
        }

        public void DisplayDeletion()
        {
            for (int i = 0; i < deletion.GetLength(0); i++)
            {
                for (int j = 0; j < deletion.GetLength(1); j++)
                {
                    Console.Write($"{deletion[i, j]}  ");
                }

                Console.WriteLine();
            }
        }

        public int CountEmptyFields()
        {
            int count = 0;
            for (int i = 0; i < SudokuSquare.GetLength(0); i++)
            {
                for (int j = 0; j < SudokuSquare.GetLength(1); j++)
                {
                    if (SudokuSquare[i, j] == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        public Tuple<int, int> GetNotDeletedIndex()
        {
            int counter = 0;
            for (var i = 0; i < deletion.GetLength(0); i++)
            {
                for (int j = 0; j < deletion.GetLength(1); j++)
                {
                    if (!deletion[i, j])
                    {
                        return new Tuple<int, int>(i,j);
                    }
                }
            }

            return new Tuple<int, int>(-1, -1);
        }
    }
}