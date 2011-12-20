using System.Collections.Generic;

using Search.Framework;
using Search.Types;

namespace Search.Sudoku
{
    public class SudokuActionFunction : ActionFunction<SudokuState, SudokuAction>
    {
        public override List<SudokuAction> Actions(SudokuState state)
        {
            var result = new List<SudokuAction>();

            var temp = new SudokuState(state.Fields);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (state.Fields[i, j] != 0)
                    {
                        continue;
                    }

                    for (int k = 1; k <= 9; k++)
                    {
                        temp.Fields[i, j] = k;

                        if(temp.RowIsValid(i) && temp.ColumnIsValid(j) && temp.PartsAreValid())
                        {
                            result.Add(new SudokuAction(new Point(i, j), k));
                        }

                        temp.Fields[i, j] = 0;
                    }
                }
            }

            return result;
        }
    }
}
