using System;
using System.Collections.Generic;

namespace Gaddzeit.Kata.Domain
{
    public class Batch : EntityBase
    {
        private List<Transaction> _transactions;

        public Batch()
        {
            _transactions = new List<Transaction>();
        }

        public List<Transaction> Transactions
        {
            get { return _transactions; }
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