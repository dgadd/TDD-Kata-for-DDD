using System;
using System.Collections.Generic;

namespace Gaddzeit.Kata.Domain
{
    public class Gym : EntityBase
    {
        private List<MonthlyPackage> _monthlyPackages;

        public Gym()
        {
            _monthlyPackages = new List<MonthlyPackage>();
        }

        public List<MonthlyPackage> MonthlyPackages
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
            var transaction = new Transaction {Id = 3945, Amount = customer.PackagePrice};
            var batch = new Batch { Id = 35 };
            batch.AddTransaction(transaction);
            return batch;
        }
    }
}