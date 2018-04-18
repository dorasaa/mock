using System;
using NUnit.Framework;
using Moq;


namespace UnitTestProject1
{
    [TestFixture]
    public class StringCalculator_UnitTest1
    {
        private Mock<IStore>_mockstore;
        private StringCalculator GetCalculator()
        {
            _mockstore = new Mock<IStore>();
            var calc = new StringCalculator(_mockstore.Object);
            return calc;
        }
        [Test]
        public void Add_EmptyString_Returns_0()
        {
            var calc = GetCalculator();
            int expectedResult = 0;
            int result = calc.add("");
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1,"1")]
        [TestCase(2,"2")]
        [TestCase(3,"3")]
        public void Add_SingleNumber_Returns_Number( int expectedresult, string input)
        {
            var calc = GetCalculator();
            var ActualRes= calc.add(input);
            Assert.AreEqual(ActualRes, expectedresult);
        }

        [TestCase("1,2,3",6)]
        [TestCase("42,452,22", 516)]
        [TestCase("5,5,5,5,5,5", 30)]
        public void Add_MultipleNumbers_sumofall(string input, int expectedresult)
        {
            var calc = GetCalculator();
            var ActualRes = calc.add(input);
            Assert.AreEqual(ActualRes, expectedresult);
        }
        [TestCase("a,1",1)]
        public void Add_InvalidString_ThrowException(string input, int expectedresult)
        {
            var calc = GetCalculator();

            try
            {
                var ActualRes = calc.add(input);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
            
        }

        [TestCase("3,4")]
        [TestCase("7,9")]
        public void Add_ResultIsPremierNumber_ResultAreSaved()
        {


            var calc = GetCalculator();
            var result = calc.add("3,4");

            _mockstore.Verify(m => m.Save(It.IsAny<int>()));
        }

    } //class
     
}
