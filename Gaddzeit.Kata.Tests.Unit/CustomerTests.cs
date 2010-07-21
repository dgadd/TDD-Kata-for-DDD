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
    }
}
