using Search.Types;

namespace Search.EightPuzzle
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    public class EightPuzzleAction
    {
        public EightPuzzleAction(Direction direction)
        {
            Direction = direction;
        }

        public Direction Direction { get; private set; }
    }
}
