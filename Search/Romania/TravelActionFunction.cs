using System.Collections.Generic;
using Search.Framework;

namespace Search.Romania
{
    public class TravelActionFunction : ActionFunction<TravelState, TravelAction>
    {
        public override List<TravelAction> Actions(TravelState state)
        {
            switch (state)
            {
                case TravelState.Arad:
                    return new List<TravelAction> { new TravelAction(TravelState.Zerind), new TravelAction(TravelState.Timisoara) };
                case TravelState.Lugoj:
                    return new List<TravelAction> { new TravelAction(TravelState.Timisoara) };
                case TravelState.Oradea:       
                    return new List<TravelAction> { new TravelAction(TravelState.Zerind) };
                case TravelState.Timisoara:      
                    return new List<TravelAction> { new TravelAction(TravelState.Arad), new TravelAction(TravelState.Lugoj) };
                case TravelState.Zerind:           
                    return new List<TravelAction> { new TravelAction(TravelState.Arad), new TravelAction(TravelState.Oradea) };
                default:
                    return null;
            }
        }
    }
}
