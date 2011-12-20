using System.Collections.Generic;

using Search.Framework;

namespace Search.EightPuzzle
{
    public class EightPuzzleActionFunction : ActionFunction<EightPuzzleState, EightPuzzleAction>
    {
        public override List<EightPuzzleAction> Actions(EightPuzzleState state)
        {
            var actions = new List<EightPuzzleAction>();

            var locationOfEmptyField = state.FindLocationOfEmptyField();

            if (locationOfEmptyField.X < 2)
            {
                actions.Add(new EightPuzzleAction(Direction.Right));
            }

            if (locationOfEmptyField.X > 0)
            {
                actions.Add(new EightPuzzleAction(Direction.Left));
            }

            if (locationOfEmptyField.Y < 2)
            {
                actions.Add(new EightPuzzleAction(Direction.Down));
            }

            if (locationOfEmptyField.Y > 0)
            {
                actions.Add(new EightPuzzleAction(Direction.Up));
            }

            return actions;
        }
    }
}
