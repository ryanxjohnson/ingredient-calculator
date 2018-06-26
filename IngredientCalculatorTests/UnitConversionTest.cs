using IngredientCalculator.Business;
using NUnit.Framework;

namespace IngredientCalculatorTests
{
    [TestFixture]
    public class UnitConversionTest
    {
        [TestCase(3, 1)]
        [TestCase(6, 2)]
        public void Should_Convert_TeaSpoonToTableSpoon(double input, double expected)
        {
            Assert.AreEqual(expected, Converters.TeaSpoonToTableSpoon(input));
        }

        [TestCase(1.0, .0625)]
        [TestCase(2.0, .125)]
        public void Should_Convert_TableSpoonToCup(double input, double expected)
        {
            Assert.AreEqual(expected, Converters.TableSpoonToCup(input));
        }

        [TestCase(1.0, .5)]
        [TestCase(5.33, 2.665)]
        public void Should_Convert_TableSpoonToOunce(double input, double expected)
        {
            Assert.AreEqual(expected, Converters.TableSpoonToOunce(input));
        }

        [TestCase(1.0, .125)]
        [TestCase(2.6, .325)]
        public void Should_Convert_OunceToCup(double input, double expected)
        {
            Assert.AreEqual(expected, Converters.OunceToCup(input));
        }

        [TestCase(1.0, 2.0)]
        [TestCase(2.6, 5.2)]
        public void Should_Convert_OunceToTableSpoon(double input, double expected)
        {
            Assert.AreEqual(expected, Converters.OunceToTableSpoon(input));
        }

        [TestCase(1.0, 8.0)]
        [TestCase(.75, 6.0)]
        public void Should_Convert_CupToOunce(double input, double expected)
        {
            Assert.AreEqual(expected, Converters.CupToOunce(input));
        }

        [TestCase(1.0, 16.0)]
        [TestCase(.75, 12.0)]
        [TestCase(.33, 5.28)]
        public void Should_Convert_CupToTableSpoon(double input, double expected)
        {
            Assert.AreEqual(expected, Converters.CupToTableSpoon(input));
        }
    }
}

