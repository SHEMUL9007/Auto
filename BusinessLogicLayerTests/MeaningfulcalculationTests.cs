using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Tests
{
    [TestClass()]
    public class MeaningfulcalculationTests
    {
       
        [TestMethod()]
        public void calculate_profitTest_for_normalProfit()
        {
            // Arrange
            Meaningfulcalculation MCTester = new Meaningfulcalculation();
            decimal sellprice =2000;
            decimal purchaseprice= 1000;
            decimal actual_answer;
            decimal expected_answer = 200;
            // Act
            actual_answer = MCTester.calculate_profit(sellprice, purchaseprice);
            // Assert
            Assert.AreEqual(expected_answer, actual_answer);
        }


        [TestMethod()]
        public void calculate_profitTest_forLoss()
        {
            // Arrange
            Meaningfulcalculation MCTester = new Meaningfulcalculation();
            decimal sellprice = 2000;
            decimal purchaseprice = 3000;
            decimal actual_answer;
            decimal expected_answer = -200;
            // Act
            actual_answer = MCTester.calculate_profit(sellprice, purchaseprice);
            // Assert
            Assert.AreEqual(expected_answer, actual_answer);
        }

        [TestMethod()]
        public void calculate_profitTest_forZero()
        {
            // Arrange
            Meaningfulcalculation MCTester = new Meaningfulcalculation();
            decimal sellprice = 2000;
            decimal purchaseprice = 2000;
            decimal actual_answer;
            decimal expected_answer = 0;
            // Act
            actual_answer = MCTester.calculate_profit(sellprice, purchaseprice);
            // Assert
            Assert.AreEqual(expected_answer, actual_answer);
        }
    }
}