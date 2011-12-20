
namespace Search.Missionaries
{
    public enum Direction
    {
        Left,
        Right
    }

    public class MissionariesAction
    {
        public MissionariesAction(Direction direction, int missionaries, int cannibals)
        {
            Direction = direction;
            Missionaries = missionaries;
            Cannibals = cannibals;
        }

        public Direction Direction { get; private set; }

        public int Missionaries { get; private set; }

        public int Cannibals { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", Missionaries, Cannibals);
        }
    }
}
