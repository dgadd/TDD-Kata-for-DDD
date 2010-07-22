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

        public Batch BillForMonthlyCharge(DateTime today)
        {
            DisallowManualChargesForOntarioCustomers(this);
            var transaction = new Transaction { Id = 3945, Amount = this.PackagePrice };
            var batch = new Batch();
            batch.AddTransaction(transaction);
            return batch;
        }

        private static void DisallowManualChargesForOntarioCustomers(Customer customer)
        {
            if (customer.Address != null
               && !string.IsNullOrEmpty(customer.Address.Province)
               && customer.Address.Province.Equals("Ontario"))
                throw new Exception("A manual charge cannot be run for Ontario customers.");
        }

    }
}