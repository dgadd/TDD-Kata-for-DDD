using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.Kata.Domain;
using NUnit.Framework;

namespace Gaddzeit.Kata.Tests.Unit
{
    [TestFixture]
    public class BatchTests
    {
        [Test]
        public void Constructor_NoInputParams_IsInstanceOfEntityBase()
        {
            var sut = new Batch();
            Assert.IsInstanceOfType(typeof(EntityBase), sut);
        }

        [Test]
        public void TransactionProperty_Getter_HasCountOf0()
        {
            var sut = new Batch();
            Assert.AreEqual(0, sut.Transactions.Count());
        }

        [Test]
        public void AddTransactionMethod_TransactionInput_IncrementsCount()
        {
            var sut = new Batch();
            Assert.AreEqual(0, sut.Transactions.Count());
            sut.AddTransaction(new Transaction {Id = 91352, Amount = 10.01M});
            Assert.AreEqual(1, sut.Transactions.Count());            
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "You cannot add duplicate transactions.")]
        public void AddTransactionMethod_DuplicateInput_ThrowsException()
        {
            var transaction = new Transaction { Id = 91325125, Amount = 10.01M };

            var sut = new Batch();
            sut.AddTransaction(transaction);
            sut.AddTransaction(transaction);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "A transaction charge must be at least $10.")]
        public void AddTransactionMethod_AmountLessThanTenDollars_ThrowsException()
        {
            var transaction = new Transaction { Id = 91325125, Amount = 9.99M };

            var sut = new Batch();
            sut.AddTransaction(transaction);
        }

    }
}
