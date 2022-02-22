using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestockerApp;
using System.Collections.Generic;

namespace RestockerTests
{
    [TestClass]
    public class RestockerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var stock = new List<int>() { 0, 2, 2 };
            var supplierStock = new List<int>() { 0, 0, 2, 3 };
            int demand = 2;
            int expectedResult = 3;

            var result = Restocker.Restock(stock, supplierStock, demand);
            Assert.AreEqual(expectedResult, result, 0, "Restocker calculated incorectly");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var stock = new List<int>() { 0, 1, 2, 50, 100 };
            var supplierStock = new List<int>() { 0, 1, 2, 3, 4 };
            int demand = 4;
            int expectedResult = 5;

            var result = Restocker.Restock(stock, supplierStock, demand);
            Assert.AreEqual(expectedResult, result, 0, "Restocker calculated incorectly");
        }

        [TestMethod]
        public void TestMethod3()
        {
            var stock = new List<int>() { 0, 0, 0, 1, 2, 50, 100,20, 10, 5 , 3 };
            var supplierStock = new List<int>() { 0, 1, 2, 3, 500000 };
            int demand = 3;
            int expectedResult = 4;

            var result = Restocker.Restock(stock, supplierStock, demand);
            Assert.AreEqual(expectedResult, result, 0, "Restocker calculated incorectly");
        }

        [TestMethod]
        public void TestMethod4()
        {
            var stock = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var supplierStock = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int demand = 2;
            int expectedResult = 10;

            var result = Restocker.Restock(stock, supplierStock, demand);
            Assert.AreEqual(expectedResult, result, 0, "Restocker calculated incorectly");
        }

        [TestMethod]
        public void TestMethod5()
        {
            var stock = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var supplierStock = new List<int>() { 0,0, 1,1, 2,2, 3,3, 4,4, 5,5, 6,6, 7,7, 8,8, 9,9, 10,10 };
            int demand = 2;
            int expectedResult = 10;

            var result = Restocker.Restock(stock, supplierStock, demand);
            Assert.AreEqual(expectedResult, result, 0, "Restocker calculated incorectly");
        }
    }
}