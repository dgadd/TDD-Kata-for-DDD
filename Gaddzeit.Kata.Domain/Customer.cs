using System;

namespace Gaddzeit.Kata.Domain
{
    public class Customer : EntityBase
    {
        public MonthlyPackage MonthlyPackage { get; set; }
        public Address Address { get; set; }

        public string PackageName
        {
            get { return this.MonthlyPackage.Name; }
        }

        public decimal PackagePrice
        {
            get { return this.MonthlyPackage.Price; }
        }
    }
}