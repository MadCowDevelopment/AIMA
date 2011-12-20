// -----------------------------------------------------------------------
// <copyright file="MissionariesResultFunction.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Search.Framework;

namespace Search.Missionaries
{
    public class MissionariesResultFunction : ResultFunction<MissionariesState, MissionariesAction>
    {
        public override MissionariesState Result(MissionariesState state, MissionariesAction action)
        {
            if (action.Direction == Direction.Left)
            {
                var result = new MissionariesState(
                    state.MissionariesLeft,
                    state.CannibalsLeft,
                    action.Missionaries,
                    action.Cannibals,
                    state.MissionariesRight + state.MissionariesBoat - action.Missionaries,
                    state.CannibalsRight + state.CannibalsBoat - action.Cannibals,
                    Direction.Left);

                return result;
            }
            else
            {
                var result = new MissionariesState(
                    state.MissionariesLeft + state.MissionariesBoat - action.Missionaries,
                    state.CannibalsLeft + state.CannibalsBoat - action.Cannibals,
                    action.Missionaries,
                    action.Cannibals,
                    state.MissionariesRight,
                    state.CannibalsRight,
                    Direction.Right);

                return result;
            }
        }
    }
}
