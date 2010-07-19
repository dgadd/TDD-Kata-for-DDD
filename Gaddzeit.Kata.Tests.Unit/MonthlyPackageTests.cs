using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.Kata.Domain;
using NUnit.Framework;

namespace Gaddzeit.Kata.Tests.Unit
{
    [TestFixture]
    public class MonthlyPackageTests
    {
        [Test]
        public void Constructor_NoInputParams_IsInstanceOfEntityBase()
        {
            var sut = new MonthlyPackage();
            Assert.IsInstanceOfType(typeof(EntityBase), sut);
        }
    }
}
