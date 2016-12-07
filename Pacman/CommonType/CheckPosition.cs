using System;

namespace CommonType
{
    public class CheckPosition : IEquatable<CheckPosition>
    {
        public int[] Position { get; set; }


        public  bool Equals(CheckPosition obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return (this.Position[0].Equals(obj.Position[0]) &&  this.Position[1].Equals(obj.Position[1]));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;
            return Equals((CheckPosition) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}