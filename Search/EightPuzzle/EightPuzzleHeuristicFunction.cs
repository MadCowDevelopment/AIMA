using System;

using Search.Framework;

namespace Search.EightPuzzle
{
    public class EightPuzzleHeuristicFunction : HeuristicFunction<EightPuzzleState>
    {
        private readonly EightPuzzleState _goalState;

        public EightPuzzleHeuristicFunction(EightPuzzleState goalState)
        {
            _goalState = goalState;
        }

        public override double Cost(EightPuzzleState state)
        {
            double cost = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var goalNumberLocation = _goalState.FindLocationOfNumber(state.Fields[i, j]);
                    var xdifference = Math.Abs(i - goalNumberLocation.X);
                    var ydifference = Math.Abs(i - goalNumberLocation.Y);
                    cost += xdifference;
                    cost += ydifference;
                }
            }

            return cost;
        }
    }
}
