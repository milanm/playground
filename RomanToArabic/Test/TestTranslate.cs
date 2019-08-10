using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanToArabic;

namespace Test
{
    [TestClass]
    public class TestTranslate
    {
        [TestMethod]
        public void WhenGivenIRomanShouldReturn1Arabic()
        {
            // Arrange
            string arabicNumber = "1";
            string romanNumber = "I";

            // Act
            var arabicTranslated = Translate.getArabic(romanNumber);

            // Assert
            Assert.AreEqual(arabicNumber, arabicTranslated);
        }

        [TestMethod]
        public void WhenGivenIVRomanShouldReturn4Arabic()
        {
            // Arrange
            string arabicNumber = "4";
            string romanNumber = "IV";

            // Act
            var arabicTranslated = Translate.getArabic(romanNumber);

            // Assert
            Assert.AreEqual(arabicNumber, arabicTranslated);
        }

        [TestMethod]
        public void WhenGivenMMMRomanShouldReturn3000Arabic()
        {
            // Arrange
            string arabicNumber = "3000";
            string romanNumber = "MMM";

            // Act
            var arabicTranslated = Translate.getArabic(romanNumber);

            // Assert
            Assert.AreEqual(arabicNumber, arabicTranslated);
        }

        [TestMethod]
        public void WhenGivenCCXVIIRomanShouldReturn217Arabic()
        {
            // Arrange
            string arabicNumber = "217";
            string romanNumber = "CCXVII";

            // Act
            var arabicTranslated = Translate.getArabic(romanNumber);

            // Assert
            Assert.AreEqual(arabicNumber, arabicTranslated);
        }

        [TestMethod]
        public void WhenGivenMMXIXRomanShouldReturn2019Arabic()
        {
            // Arrange
            string arabicNumber = "2019";
            string romanNumber = "MMXIX";

            // Act
            var arabicTranslated = Translate.getArabic(romanNumber);

            // Assert
            Assert.AreEqual(arabicNumber, arabicTranslated);
        }

        [TestMethod]
        public void WhenGivenMMMCMXCIXRomanShouldReturn3999Arabic()
        {
            // Arrange
            string arabicNumber = "3999";
            string romanNumber = "MMMCMXCIX";

            // Act
            var arabicTranslated = Translate.getArabic(romanNumber);

            // Assert
            Assert.AreEqual(arabicNumber, arabicTranslated);
        }
    }
}
