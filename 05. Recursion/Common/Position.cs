namespace Common
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }

        public static bool operator ==(Position a, Position b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Position a, Position b)
        {
            return !(a == b);
        }
    }
}
