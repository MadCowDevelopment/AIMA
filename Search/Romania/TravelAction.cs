
namespace Search.Romania
{
    public class TravelAction
    {
        public TravelAction(TravelState destination)
        {
            Destination = destination;
        }

        public TravelState Destination { get; set; }
    }
}
