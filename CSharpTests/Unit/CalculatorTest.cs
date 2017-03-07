using CSharp.Unit;
using NUnit.Framework;
using System;

namespace CSharp.NUnit.Tests
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator calculator;
        private int valueA = 0;
        private int valueB = 0;

        [SetUp]
        protected void setUp()
        {
            calculator = new Calculator();
            valueA = 4;
            valueB = 2;
        }

        [TearDown]
        protected void tearDown()
        {
        }

        [Test]
        public void testGetResultAdd()
        {
            calculator.valueA = valueA;
            calculator.valueB = valueB;
            Assert.AreEqual(valueA + valueB, calculator.getResult(Calculator.Operations.Add));
        }

        [Test, Combinatorial]
        public void testGetResultAddCombinatorial([Values(2, 4, 6)] int a, [Values(1, 3)] int b)
        {
            calculator.valueA = a;
            calculator.valueB = b;
            Assert.AreEqual(a + b, calculator.getResult(Calculator.Operations.Add));
        }

        [Test, Sequential]
        public void testGetResultAddSequential([Values(2, 4, 6)] int a, [Values(1, 3)] int b)
        {
            calculator.valueA = a;
            calculator.valueB = b;
            Assert.AreEqual(a + b, calculator.getResult(Calculator.Operations.Add));
        }

        [Test]
        public void testGetResultSub()
        {
            calculator.valueA = valueA;
            calculator.valueB = valueB;
            Assert.AreEqual(valueA - valueB, calculator.getResult(Calculator.Operations.Sub));
        }

        [Test]
        public void testGetResultMult()
        {
            calculator.valueA = valueA;
            calculator.valueB = valueB;
            Assert.AreEqual(valueA * valueB, calculator.getResult(Calculator.Operations.Mult));
        }

        [Test]
        public void testGetResultDiv()
        {
            calculator.valueA = valueA;
            calculator.valueB = valueB;
            Assert.AreEqual(valueA / valueB, calculator.getResult(Calculator.Operations.Div));
        }

        [TestCaseSource("GetOperations")]
        public void testGetResulOperation(Calculator.Operations operation)
        {
            calculator.valueA = valueA;
            calculator.valueB = valueB;
            calculator.getResult(operation);
        }

        /// <summary>
        /// Retrieve all value from enum 
        /// </summary>
        /// <returns>Array with enum values</returns>
        private static Array GetOperations()
        {
            return Enum.GetValues(typeof(Calculator.Operations));
        }
    }
}
