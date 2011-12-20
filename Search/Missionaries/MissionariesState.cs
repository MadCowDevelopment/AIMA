namespace Search.Missionaries
{
    public class MissionariesState
    {
        public MissionariesState(
            int missionariesLeft,
            int cannibalsLeft, 
            int missionariesBoat, 
            int cannibalsBoat, 
            int missionariesRight,
            int cannibalsRight,
            Direction boatDirection)
        {
            MissionariesLeft = missionariesLeft;
            CannibalsLeft = cannibalsLeft;
            MissionariesBoat = missionariesBoat;
            CannibalsBoat = cannibalsBoat;
            MissionariesRight = missionariesRight;
            CannibalsRight = cannibalsRight;
            BoatDirection = boatDirection;
        }

        public int MissionariesLeft { get; private set; }

        public int CannibalsLeft { get; private set; }

        public int MissionariesBoat { get; private set; }

        public int CannibalsBoat { get; private set; }

        public int MissionariesRight { get; private set; }

        public int CannibalsRight { get; private set; }

        public Direction BoatDirection { get; private set; }

        public override string ToString()
        {
            return string.Format(
                "{0}-{1} {2}-{3} {4}-{5} {6}",
                MissionariesLeft,
                CannibalsLeft,
                MissionariesBoat,
                CannibalsBoat,
                MissionariesRight,
                CannibalsRight,
                BoatDirection);
        }

        public bool Equals(MissionariesState other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.MissionariesLeft == this.MissionariesLeft && other.CannibalsLeft == this.CannibalsLeft
                   && other.MissionariesBoat == this.MissionariesBoat && other.CannibalsBoat == this.CannibalsBoat
                   && other.MissionariesRight == this.MissionariesRight && other.CannibalsRight == this.CannibalsRight;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(MissionariesState))
            {
                return false;
            }
            return Equals((MissionariesState)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = this.MissionariesLeft;
                result = (result * 397) ^ this.CannibalsLeft;
                result = (result * 397) ^ this.MissionariesBoat;
                result = (result * 397) ^ this.CannibalsBoat;
                result = (result * 397) ^ this.MissionariesRight;
                result = (result * 397) ^ this.CannibalsRight;
                return result;
            }
        }
    }
}
