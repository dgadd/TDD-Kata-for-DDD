using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.Kata.Domain;
using NUnit.Framework;

namespace Gaddzeit.Kata.Tests.Unit
{
    [TestFixture]
    public class EntityBaseTests
    {
        [Test]
        public void TwoInstances_SameIdProperty_AreEqual()
        {
            const int idToAdd = 9135121;
            var sut1 = new EntityBase { Id = idToAdd };
            var sut2 = new EntityBase { Id = idToAdd };
            Assert.AreEqual(sut1, sut2);
        }

        [Test]
        public void TwoInstances_DifferentIdProperty_AreNotEqual()
        {
            var sut1 = new EntityBase { Id = 3819025 };
            var sut2 = new EntityBase { Id = 82934 };
            Assert.AreNotEqual(sut1, sut2);
        }

        [Test]
        public void TwoInstances_ZeroIdProperty_AreNotEqual()
        {
            const int idToAdd = 0;
            var sut1 = new EntityBase { Id = idToAdd };
            var sut2 = new EntityBase { Id = idToAdd };
            Assert.AreNotEqual(sut1, sut2);
        }

    }
}
