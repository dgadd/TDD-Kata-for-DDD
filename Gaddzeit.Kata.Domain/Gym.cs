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
    }
}