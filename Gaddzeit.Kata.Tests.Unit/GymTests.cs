using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.Kata.Domain;
using NUnit.Framework;

namespace Gaddzeit.Kata.Tests.Unit
{
    [TestFixture]
    public class GymTests
    {
        [Test]
        public void Constructor_NoInputParams_IsInstanceOfEntityBase()
        {
            var sut = new Gym();
            Assert.IsInstanceOfType(typeof(EntityBase), sut);
        }

        [Test]
        public void MonthlyPackagesProperty_Getter_HasCountOf0()
        {
            var sut = new Gym();
            Assert.AreEqual(0, sut.MonthlyPackages.Count());
        }

        [Test]
        public void AddMonthlyPackageMethod_MonthlyPackageInput_IncrementsMonthlyPackagesCount()
        {
            var sut = new Gym();
            Assert.AreEqual(0, sut.MonthlyPackages.Count());
            sut.AddMonthlyPackage(new MonthlyPackage());
            Assert.AreEqual(1, sut.MonthlyPackages.Count());     
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "You cannot add a duplicate MonthlyPackage.")]
        public void AddMonthlyPackageMethod_DuplicateInput_ThrowsException()
        {
            var sut = new Gym();
            var monthlyPackage1 = new MonthlyPackage {Id = 1535235};
            sut.AddMonthlyPackage(monthlyPackage1);
            sut.AddMonthlyPackage(monthlyPackage1);
        }

        [Test]
        public void ManuallyGenerateMonthlyChargeMethod_CustomerAndDateInputs_ReturnsBatch()
        {
            var monthlyPackage = new MonthlyPackage {Id = 1235, Name = "Top Fit", Price = 35.00M};
            var customer = new Customer {Id = 91352, MonthlyPackage = monthlyPackage};
            var sut = new Gym();
            var batch = sut.ManuallyGenerateMonthlyCharge(customer, DateTime.Today);
            Assert.AreEqual(customer.PackagePrice, batch.TotalAmount);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "A transaction charge must be at least $10.")]
        public void ManuallyGenerateMonthlyChargeMethod_CustomerPackagePriceLessThanTenDollars_ThrowsException()
        {
            var monthlyPackage = new MonthlyPackage { Id = 1235, Name = "Top Fit", Price = 9.20M };
            var customer = new Customer { Id = 91352, MonthlyPackage = monthlyPackage };
            var sut = new Gym();
            var batch = sut.ManuallyGenerateMonthlyCharge(customer, DateTime.Today);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "A manual charge cannot be run for Ontario customers.")]
        public void ManuallyGenerateMonthlyChargeMethod_CustomerIsFromOntario_ThrowsException()
        {
            var monthlyPackage = new MonthlyPackage { Id = 1235, Name = "Top Fit", Price = 9.20M };
            var address = new Address("1234 Happy St", "Toronto", "Ontario");
            var customer = new Customer { Id = 91352, MonthlyPackage = monthlyPackage, Address = address};
            var sut = new Gym();
            var batch = sut.ManuallyGenerateMonthlyCharge(customer, DateTime.Today);
        }

    }
}
