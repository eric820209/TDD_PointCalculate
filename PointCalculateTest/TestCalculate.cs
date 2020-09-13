using NUnit.Framework;
using PointCalculator_Test.TestCaseSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TDD_PointCalculate;
using TDD_PointCalculate.EF;
using TDD_PointCalculate.Models;

namespace PointCalculator_Test
{
    public class Tests
    {
        private PointPiorityQueue _pointPiorityQueue;
        private ModelBuilder _modelBuilder;
        [SetUp]
        public void Setup()
        {
            _pointPiorityQueue = new PointPiorityQueue();
            _modelBuilder = new ModelBuilder();
        }

        [Test]
        [TestCase("1")]
        [TestCase("10.52")]
        [TestCase("-20.56")]
        public void Calculate_OnePointTransactionDetailRecord_ReturnSpecifyPoint(decimal points)
        {
            ///Arrange
            List<PointTransactionDetail> transactions = new List<PointTransactionDetail>
            {
            _modelBuilder.CreateTransactionDetail(points),
            };
            ///Action
            var actual = _pointPiorityQueue.Calculate(transactions);

            ///Assert
            List<PointTransactionDetail> expect = new List<PointTransactionDetail>
            {
            _modelBuilder.CreateTransactionDetail(points),
            };

            Assert.AreEqual(JsonSerializer.Serialize(expect), JsonSerializer.Serialize(actual));
        }

        [Test]
        [TestCaseSource(typeof(MultiplePositivePoints_TestCaseSource))]
        public void Calculate_MultiplePositiveRecord_OrderByExpireDate(List<PointTransactionDetail> points)
        {
            ///Arrange
            // In  MultiplePositivePoints_TestCaseSource class

            ///Action
            var actual = _pointPiorityQueue.Calculate(points);

            ///Assert
            var expect = points.OrderBy(x => x.TransactionDateTime);

            Assert.AreEqual(JsonSerializer.Serialize(expect), JsonSerializer.Serialize(actual));
        }



    }
}