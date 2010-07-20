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
    }
}