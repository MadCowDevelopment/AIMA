using Search.Framework;

namespace Search.Sudoku
{
    public class SudokuResultFunction : ResultFunction<SudokuState, SudokuAction>
    {
        public override SudokuState Result(SudokuState state, SudokuAction action)
        {
            var result = new SudokuState(state.Fields);
            result.Fields[(int)action.Location.X, (int)action.Location.Y] = action.Number;
            return result;
        }
    }
}
