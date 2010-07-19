using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Gaddzeit.Kata.Domain;
using NUnit.Framework;

namespace Gaddzeit.Kata.Tests.Unit
{
    [TestFixture]
    public class AddressTests
    {
        [Test]
        [Ignore("Unexpected behavior from System.Reflection.Type.GetConstructors()")]
        public void Constructor_StreetCityProvinceInputParams_HasNoPrivateParameterlessConstructor()
        {
            var constructorCount = typeof(Address).GetConstructors().Where(constructorInfo => constructorInfo.IsPrivate).Count();
            Assert.AreEqual(1, constructorCount);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "You must provide a non-null address.")]
        public void Constructor_StreetNullWithCityAndProvince_ThrowsException()
        {
            const string street = "";
            const string city = "Winnipeg";
            const string province = "MB";

            var sut = new Address(street, city, province);

        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "You must provide a non-null city.")]
        public void Constructor_StreetWithNullCityAndProvince_ThrowsException()
        {
            const string street = "1234 Happy St";
            const string city = "";
            const string province = "MB";

            var sut = new Address(street, city, province);

        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "You must provide a non-null province.")]
        public void Constructor_StreetWithCityAndNullProvince_ThrowsException()
        {
            const string street = "1234 Happy St";
            const string city = "Winnipeg";
            const string province = "";

            var sut = new Address(street, city, province);

        }

        [Test]
        public void TwoInstances_SameConstructorInputs_AreEqual()
        {
            const string street = "1234 Happy St";
            const string city = "Winnipeg";
            const string province = "MB";

            var sut1 = new Address(street, city, province);
            var sut2 = new Address(street, city, province);
            Assert.AreEqual(sut1, sut2);
        }
    }
}
