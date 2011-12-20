// -----------------------------------------------------------------------
// <copyright file="MissionariesActionFunction.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Search.Framework;

namespace Search.Missionaries
{
    public class MissionariesActionFunction : ActionFunction<MissionariesState, MissionariesAction>
    {
        private readonly MissionariesState _goalState;

        public MissionariesActionFunction(MissionariesState goalState)
        {
            _goalState = goalState;
        }

        public override List<MissionariesAction> Actions(MissionariesState state)
        {
            var result = new List<MissionariesAction>();

            if (state.BoatDirection == Direction.Left)
            {
                if (state.CannibalsLeft + state.CannibalsBoat > 0)
                {
                    if (state.MissionariesLeft + state.MissionariesBoat > 0)
                    {
                        if (state.MissionariesLeft + state.MissionariesBoat >= state.CannibalsLeft + state.CannibalsBoat - 1)
                        {
                            result.Add(new MissionariesAction(Direction.Right, 0, 1));
                        }
                    }
                    else
                    {
                        result.Add(new MissionariesAction(Direction.Right, 0, 1));
                    }
                }

                if (state.CannibalsLeft + state.CannibalsBoat > 1)
                {
                    result.Add(new MissionariesAction(Direction.Right, 0, 2));
                }

                if (state.MissionariesLeft + state.MissionariesBoat > state.CannibalsLeft + state.CannibalsBoat)
                {
                    result.Add(new MissionariesAction(Direction.Right, 1, 0));
                }

                if (state.MissionariesLeft + state.MissionariesBoat > state.CannibalsLeft + state.CannibalsBoat + 1)
                {
                    result.Add(new MissionariesAction(Direction.Right, 2, 0));
                }

                if (state.MissionariesLeft + state.MissionariesBoat > 0 && state.CannibalsLeft + state.CannibalsBoat > 0 &&
                    state.MissionariesLeft + state.MissionariesBoat >= state.CannibalsLeft + state.CannibalsBoat)
                {
                    result.Add(new MissionariesAction(Direction.Right, 1, 1));
                }
            }
            else
            {
                if ((state.MissionariesBoat == 0 && state.CannibalsBoat == 1 && state.MissionariesRight == _goalState.MissionariesRight && state.CannibalsRight == _goalState.CannibalsRight - 1) ||
                    (state.MissionariesBoat == 0 && state.CannibalsBoat == 2 && state.MissionariesRight == _goalState.MissionariesRight && state.CannibalsRight == _goalState.CannibalsRight - 2) ||
                    (state.MissionariesBoat == 1 && state.CannibalsBoat == 1 && state.MissionariesRight == _goalState.MissionariesRight - 1 && state.CannibalsRight == _goalState.CannibalsRight - 1))
                {
                    result.Add(new MissionariesAction(Direction.Left, 0, 0));
                }

                if (state.CannibalsRight + state.CannibalsBoat > 0)
                {
                    if (state.MissionariesRight + state.MissionariesBoat > 0)
                    {
                        if (state.MissionariesRight + state.MissionariesBoat >= state.CannibalsRight + state.CannibalsBoat - 1)
                        {
                            result.Add(new MissionariesAction(Direction.Left, 0, 1));
                        }
                    }
                    else
                    {
                        result.Add(new MissionariesAction(Direction.Left, 0, 1));
                    }
                }

                if (state.CannibalsRight + state.CannibalsBoat > 1)
                {
                    result.Add(new MissionariesAction(Direction.Left, 0, 2));
                }

                if (state.MissionariesRight + state.MissionariesBoat > state.CannibalsRight + state.CannibalsBoat)
                {
                    result.Add(new MissionariesAction(Direction.Left, 1, 0));
                }

                if (state.MissionariesRight + state.MissionariesBoat > state.CannibalsRight + state.CannibalsBoat + 1)
                {
                    result.Add(new MissionariesAction(Direction.Left, 2, 0));
                }

                if (state.MissionariesRight + state.MissionariesBoat > 0 && state.CannibalsRight + state.CannibalsBoat > 0 &&
                    state.MissionariesRight + state.MissionariesBoat >= state.CannibalsRight + state.CannibalsBoat)
                {
                    result.Add(new MissionariesAction(Direction.Left, 1, 1));
                }
            }

            return result;
        }
    }
}
