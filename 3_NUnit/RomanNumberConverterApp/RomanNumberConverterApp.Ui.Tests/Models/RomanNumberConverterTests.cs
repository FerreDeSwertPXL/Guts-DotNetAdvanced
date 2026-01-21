using RomanNumberConverterApp.Ui.Models;
using NUnit.Framework;

namespace RomanNumberConverterApp.Ui.Tests.Models
{
    public class RomanNumberConverterTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(4000)]
        public void Convert_ValueIsNotBetweenOneAnd3999_ShouldThrowArgumentException(int value)
        {
            var converter = new RomanNumberConverter();

            var exception = Assert.Throws<ArgumentException>(() =>
                converter.Convert(value));

            Assert.That(exception!.Message, Contains.Substring("1 and 3999"));
        }

        [TestCase(1, "I")]
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        [TestCase(58, "LVIII")]
        [TestCase(1994, "MCMXCIV")]
        public void Convert_ValidValue_ShouldReturnRomanNumberEquivalent(int value, string expectedRoman)
        {
            var converter = new RomanNumberConverter();
            var result = converter.Convert(value);

            Assert.That(result, Is.EqualTo(expectedRoman));
        }
    }
}