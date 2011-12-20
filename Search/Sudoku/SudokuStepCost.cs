using Search.Framework;

namespace Search.Sudoku
{
    public class SudokuStepCost : StepCost<SudokuState, SudokuAction>
    {
        public override double Cost(SudokuState state, SudokuAction action)
        {
            return 1;
        }
    }
}
