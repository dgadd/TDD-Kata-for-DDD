using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.Kata.Domain;
using NUnit.Framework;

namespace Gaddzeit.Kata.Tests.Unit
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void Constructor_NoInputParams_IsInstanceOfEntityBase()
        {
            var sut = new Customer();
            Assert.IsInstanceOfType(typeof(EntityBase), sut);
        }

        [Test]
        public void AddressProperty_Set_AddressEqualsCustomerAddress()
        {
            const string street = "1234 Happy St";
            const string city = "Winnipeg";
            const string province = "MB";

            var address = new Address(street, city, province);

            var sut = new Customer {Address = address};

            Assert.AreEqual(address, sut.Address);
        }

        [Test]
        public void MonthlyPackageProperty_Set_PackageEqualsCustomerMonthlyPackage()
        {
            var monthlyPackage = new MonthlyPackage { Id = 91351 };

            var sut = new Customer {MonthlyPackage = monthlyPackage};

            Assert.AreEqual(monthlyPackage, sut.MonthlyPackage);
        }

        [Test]
        public void PackageNameAndPriceProperties_Getters_WrapMonthlyPackageProperties()
        {
            var monthlyPackage = new MonthlyPackage { Id = 91351, Name = "Top Fit", Price = 35.00M };

            var sut = new Customer {MonthlyPackage = monthlyPackage};

            Assert.AreEqual(sut.PackageName, monthlyPackage.Name);
            Assert.AreEqual(sut.PackagePrice, monthlyPackage.Price);
        }

        [Test]
        public void BillForMonthlyChargeMethod_CustomerPackageInput_GeneratesBatchWithTransaction()
        {
            const decimal price = 12.20M;
            var monthlyPackage = new MonthlyPackage { Id = 1235, Name = "Top Fit", Price = price };
            var sut = new Customer { Id = 91352, MonthlyPackage = monthlyPackage };
            var batch = sut.BillForMonthlyCharge(DateTime.Today);
            Assert.IsTrue(batch.TransactionsContainsChargeOf(price));
        }


        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "A transaction charge must be at least $10.")]
        public void BillForMonthlyChargeMethod_CustomerPackagePriceLessThanTenDollars_ThrowsException()
        {
            var monthlyPackage = new MonthlyPackage { Id = 1235, Name = "Top Fit", Price = 9.20M };
            var sut = new Customer { Id = 91352, MonthlyPackage = monthlyPackage };
            sut.BillForMonthlyCharge(DateTime.Today);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "A manual charge cannot be run for Ontario customers.")]
        public void BillForMonthlyChargeMethod_CustomerIsFromOntario_ThrowsException()
        {
            var monthlyPackage = new MonthlyPackage { Id = 1235, Name = "Top Fit", Price = 9.20M };
            var address = new Address("1234 Happy St", "Toronto", "Ontario");
            var sut = new Customer { Id = 91352, MonthlyPackage = monthlyPackage, Address = address };
            sut.BillForMonthlyCharge(DateTime.Today);
        }
    }
}
