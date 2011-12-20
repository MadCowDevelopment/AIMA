using System.Collections.Generic;

namespace Search.Sudoku
{
    public class SudokuState
    {
        public int[,] Fields { get; private set; }

        public SudokuState(int[,] fields)
        {
            Fields = new int[9, 9];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Fields[i, j] = fields[i, j];
                }
            }
        }

        public bool IsValid()
        {
            for (int i = 0; i < 9; i++)
            {
                if (!RowIsValid(i) || !ColumnIsValid(i))
                {
                    return false;
                }
            }

            if (!PartsAreValid())
            {
                return false;
            }

            return true;
        }

        public bool RowIsValid(int row)
        {
            var numbers = new List<int>();
            for (int j = 0; j < 9; j++)
            {
                if (numbers.Contains(Fields[row, j]))
                {
                    return false;
                }

                if (Fields[row, j] != 0)
                {
                    numbers.Add(Fields[row, j]);
                }
            }

            return true;
        }

        public bool ColumnIsValid(int column)
        {
            var numbers = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (numbers.Contains(Fields[i, column]))
                {
                    return false;
                }

                if (Fields[i, column] != 0)
                {
                    numbers.Add(Fields[i, column]);
                }
            }

            return true;
        }

        public bool Equals(SudokuState other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (other.Fields[i, j] != Fields[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(SudokuState))
            {
                return false;
            }
            return Equals((SudokuState)obj);
        }

        public override int GetHashCode()
        {
            return (Fields != null ? Fields.GetHashCode() : 0);
        }

        public bool PartsAreValid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var result = PartIsValid(i, j);
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool PartIsValid(int x, int y)
        {
            var numbers = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (numbers.Contains(Fields[i + 3 * x, j + 3 * y]))
                    {
                        return false;
                    }

                    if (Fields[i + 3 * x, j + 3 * y] != 0)
                    {
                        numbers.Add(Fields[i + 3 * x, j + 3 * y]);
                    }
                }
            }

            return true;
        }
    }
}
