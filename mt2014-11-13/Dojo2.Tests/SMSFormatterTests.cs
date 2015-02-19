using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dojo2;
using System.Text;

namespace Dojo2.Tests
{
    [TestClass]
    public class SMSFormatterTests
    {

        private SMSFormatter formatter;

        [TestInitialize]
        public void Setup()
        {
            formatter = new SMSFormatter();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsIfCharIsNotOnMap()
        {
            formatter.GetNumericalMessage("*");
        }
        
        [TestMethod]
        public void ConvertS_ToNumberLetter()
        {
            string expected = "7777";
            string actual = formatter.GetNumericalMessage("S");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertA_ToNumberLetter()
        {
            string expected = "2";
            string actual = formatter.GetNumericalMessage("A");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertF_ToNumberLetter()
        {
            string expected = "333";
            string actual = formatter.GetNumericalMessage("F");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertSimpleWordToNumberWord()
        {
            string expected = "3332";
            string actual = formatter.GetNumericalMessage("FA");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertFALAToNumberWord()
        {
            string expected = "33325552";
            string actual = formatter.GetNumericalMessage("FALA");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertFASpaceLAToNumberWord()
        {
            string expected = "333205552";
            string actual = formatter.GetNumericalMessage("FA LA");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertRepeatNumberToNumberWord()
        {
            string expected = "7_777666477726_633777_7777";
            string actual = formatter.GetNumericalMessage("PROGRAMMERS");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertFullSentenceToNumberSequence()
        {
            var sentence = "SEMPRE ACESSO O DOJOPUZZLES";
            var expected = "77773367_7773302_222337777_777766606660366656667889999_9999555337777";

            var sequence = formatter.GetNumericalMessage(sentence);

            Assert.AreEqual(expected, sequence);
        }

        [TestMethod]
        public void ConvertCaseInsensitiveToNumberWord()
        {
            string expected = "7_777666477726_633777_7777";
            string actual = formatter.GetNumericalMessage("Programmers");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LimitMessageLenght()
        {
            StringBuilder numberLetter = new StringBuilder();

            numberLetter.Append('A', 256);

            formatter.GetNumericalMessage(numberLetter.ToString());
        }
    }
}
