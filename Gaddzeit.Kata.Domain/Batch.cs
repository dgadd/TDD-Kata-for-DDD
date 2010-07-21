using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaddzeit.Kata.Domain
{
    public class Batch : EntityBase
    {
        private readonly IList<Transaction> _transactions;

        public Batch()
        {
            _transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Transactions
        {
            get { return _transactions; }
        }

        public decimal TotalAmount
        {
            get
            {
                return _transactions.Sum(transaction => transaction.Amount);
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            if(transaction.Amount < 10.00M)
                throw new ArgumentException("A transaction charge must be at least $10.");
            RejectDuplicateTransaction(transaction);

            _transactions.Add(transaction);
        }

        private void RejectDuplicateTransaction(Transaction transaction)
        {
            if(_transactions.Contains(transaction))
                throw new ArgumentException("You cannot add duplicate transactions.");
        }

        public void ManuallyGenerateMonthlyChargeFor(Customer customer, DateTime today)
        {
            DisallowManualChargesForOntarioCustomers(customer);
            var transaction = new Transaction { Id = 3945, Amount = customer.PackagePrice };
            this.AddTransaction(transaction);
        }

        private static void DisallowManualChargesForOntarioCustomers(Customer customer)
        {
            if (customer.Address != null
               && !string.IsNullOrEmpty(customer.Address.Province)
               && customer.Address.Province.Equals("Ontario"))
                throw new Exception("A manual charge cannot be run for Ontario customers.");
        }

        public bool TransactionsContainsChargeOf(decimal price)
        {
            foreach(var transaction in _transactions)
            {
                if(transaction.Amount.Equals(price))
                    return true;
            }
            return false;
        }
    }
}