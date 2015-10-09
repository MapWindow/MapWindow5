// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnvelopeTests.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the Envelope Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using MW5.Api.Concrete;
using NUnit.Framework;

namespace MW5.API.Test
{
    [TestFixture]
    public class EnvelopeTests
    {
        [Test]
        public void EqualsTo()
        {
            Debug.WriteLine("Envelope().EqualsTo");
            var env1 = new Envelope(10, 20, 10, 20);
            var env2 = new Envelope(10, 20, 10, 20);
            var env3 = new Envelope(11, 20, 10, 20);

            Assert.IsTrue(env1.EqualsTo(env2));
            Debug.WriteLine("env1 equals env2");
            Assert.IsFalse(env1.EqualsTo(env3));
            Debug.WriteLine("env1 not equals env3");
            Assert.IsTrue(env1.EqualsTo(env3, 1));
            Debug.WriteLine("env1 equals env3 within threshold");
        }
    }
}