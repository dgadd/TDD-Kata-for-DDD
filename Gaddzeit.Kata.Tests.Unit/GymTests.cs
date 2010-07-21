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

    }
}
