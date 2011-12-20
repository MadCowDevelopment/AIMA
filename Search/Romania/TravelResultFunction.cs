using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Search.Framework;

namespace Search.Romania
{
    public class TravelResultFunction : ResultFunction<TravelState, TravelAction>
    {
        public override TravelState Result(TravelState state, TravelAction action)
        {
            return action.Destination;
        }
    }
}
