using System;
using System.Collections.Generic;

using Search.Framework;

namespace Search.Sudoku
{
    public class SudokuGoalTest : GoalTest<SudokuState>
    {
        public override bool IsGoal(SudokuState state)
        {
            for (int i = 0; i < 9; i++)
            {
                if (!RowIsValid(state, i) || !ColumnIsValid(state, i))
                {
                    return false;
                }
            }

            return PartsAreValid(state);
        }

        public bool RowIsValid(SudokuState state, int row)
        {
            var numbers = new List<int>();
            for (int j = 0; j < 9; j++)
            {
                if (numbers.Contains(state.Fields[row, j]))
                {
                    return false;
                }

                if (state.Fields[row, j] != 0)
                {
                    numbers.Add(state.Fields[row, j]);
                }
            }

            for (int i = 1; i <= 9; i++)
            {
                if (!numbers.Contains(i))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ColumnIsValid(SudokuState state, int column)
        {
            var numbers = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (numbers.Contains(state.Fields[i, column]))
                {
                    return false;
                }

                if (state.Fields[i, column] != 0)
                {
                    numbers.Add(state.Fields[i, column]);
                }
            }

            for (int i = 1; i <= 9; i++)
            {
                if (!numbers.Contains(i))
                {
                    return false;
                }
            }

            return true;
        }

        public bool PartsAreValid(SudokuState state)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var result = PartIsValid(state, i, j);
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool PartIsValid(SudokuState state, int x, int y)
        {
            var numbers = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (numbers.Contains(state.Fields[i + 3 * x, j + 3 * y]))
                    {
                        return false;
                    }

                    if (state.Fields[i + 3 * x, j + 3 * y] != 0)
                    {
                        numbers.Add(state.Fields[i + 3 * x, j + 3 * y]);
                    }
                }
            }

            for (int i = 1; i <= 9; i++)
            {
                if (!numbers.Contains(i))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
