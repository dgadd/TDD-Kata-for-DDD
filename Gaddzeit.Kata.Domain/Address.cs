using System;

namespace Gaddzeit.Kata.Domain
{
    public class Address
    {
        private readonly string _street;
        private readonly string _city;
        private readonly string _province;

        // disallow parameterless constructor
        private Address()
        {
        }


        public Address(string street, string city, string province)
        {
            PerformConstructorNullChecks(street, city, province);

            _street = street;
            _city = city;
            _province = province;
        }

        public string Province
        {
            get { return _province; }
        }

        public string City
        {
            get { return _city; }
        }

        public string Street
        {
            get { return _street; }
        }

        private static void PerformConstructorNullChecks(string street, string city, string province)
        {
            if (string.IsNullOrEmpty(street))
                throw new ArgumentException("You must provide a non-null address.");
            if (string.IsNullOrEmpty(city))
                throw new ArgumentException("You must provide a non-null city.");
            if (string.IsNullOrEmpty(province))
                throw new ArgumentException("You must provide a non-null province.");
        }

        public override bool Equals(object obj)
        {
            var other = (Address) obj;
            return other.Street.Equals(this.Street)
                   && other.City.Equals(this.City)
                   && other.Province.Equals(this.Province);
        }

        public override int GetHashCode()
        {
            return this.Street.GetHashCode() + this.City.GetHashCode() + this.Province.GetHashCode();
        }
    }
}