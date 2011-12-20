using Search.Framework;

namespace Search.EightPuzzle
{
    public class EightPuzzleResultFunction : ResultFunction<EightPuzzleState, EightPuzzleAction>
    {
        public override EightPuzzleState Result(EightPuzzleState state, EightPuzzleAction action)
        {
            var locationOfEmptyField = state.FindLocationOfEmptyField();

            var result = new EightPuzzleState(state.Fields);

            switch (action.Direction)
            {
                case Direction.Left:
                    var numberLeftOfEmpty = result.Fields[(int)locationOfEmptyField.X - 1, (int)locationOfEmptyField.Y];
                    result.Fields[(int)locationOfEmptyField.X - 1, (int)locationOfEmptyField.Y] = 0;
                    result.Fields[(int)locationOfEmptyField.X, (int)locationOfEmptyField.Y] = numberLeftOfEmpty;
                    break;
                case Direction.Right:
                    var numberRightOfEmpty = result.Fields[(int)locationOfEmptyField.X + 1, (int)locationOfEmptyField.Y];
                    result.Fields[(int)locationOfEmptyField.X + 1, (int)locationOfEmptyField.Y] = 0;
                    result.Fields[(int)locationOfEmptyField.X, (int)locationOfEmptyField.Y] = numberRightOfEmpty;
                    break;
                case Direction.Up:
                    var numberTopOfEmpty = result.Fields[(int)locationOfEmptyField.X, (int)locationOfEmptyField.Y - 1];
                    result.Fields[(int)locationOfEmptyField.X, (int)locationOfEmptyField.Y - 1] = 0;
                    result.Fields[(int)locationOfEmptyField.X, (int)locationOfEmptyField.Y] = numberTopOfEmpty;
                    break;
                case Direction.Down:
                    var numberBelowOfEmpty = result.Fields[(int)locationOfEmptyField.X, (int)locationOfEmptyField.Y + 1];
                    result.Fields[(int)locationOfEmptyField.X, (int)locationOfEmptyField.Y + 1] = 0;
                    result.Fields[(int)locationOfEmptyField.X, (int)locationOfEmptyField.Y] = numberBelowOfEmpty;
                    break;
            }

            return result;
        }
    }
}
