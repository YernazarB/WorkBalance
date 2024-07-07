namespace WorkBalance.Domain.Entities
{
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        public int Id { get; set; }

        public bool Equals(BaseEntity? other)
        {
            if (other == null) 
                return false;

            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity other)
                return false;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
