using System;
using System.Collections.Generic;

namespace Gaddzeit.Kata.Domain
{
    public class Gym : EntityBase
    {
        private readonly IList<MonthlyPackage> _monthlyPackages;

        public Gym()
        {
            _monthlyPackages = new List<MonthlyPackage>();
        }

        public IEnumerable<MonthlyPackage> MonthlyPackages
        {
            get { return _monthlyPackages; }
        }

        public void AddMonthlyPackage(MonthlyPackage monthlyPackage)
        {
            RejectDuplicateMonthlyPackage(monthlyPackage);

            _monthlyPackages.Add(monthlyPackage);
        }

        private void RejectDuplicateMonthlyPackage(MonthlyPackage monthlyPackage)
        {
            if(_monthlyPackages.Contains(monthlyPackage))
                throw new ArgumentException("You cannot add a duplicate MonthlyPackage.");
        }

        public Batch ManuallyGenerateMonthlyCharge(Customer customer, DateTime dateTime)
        {
            DisallowManualChargesForOntarioCustomers(customer);
            var transaction = new Transaction {Id = 3945, Amount = customer.PackagePrice};
            var batch = new Batch { Id = 35 };
            batch.AddTransaction(transaction);
            return batch;
        }

        private static void DisallowManualChargesForOntarioCustomers(Customer customer)
        {
            if(customer.Address != null
               && !string.IsNullOrEmpty(customer.Address.Province)
               && customer.Address.Province.Equals("Ontario"))
                throw new Exception("A manual charge cannot be run for Ontario customers.");
        }
    }
}