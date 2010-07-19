using System;

namespace Gaddzeit.Kata.Domain
{
    public class EntityBase
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            var other = (EntityBase) obj;
            return other.Id > 0 && this.Id > 0
                    && other.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}