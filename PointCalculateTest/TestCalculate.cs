using Moq;
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
            Mock<IDateTimeService> mock_DateTimeService = new Mock<IDateTimeService>();
            mock_DateTimeService.Setup(x => x.GetDate()).Returns(DateTime.Parse("2020/03/12"));

            _pointPiorityQueue = new PointPiorityQueue(mock_DateTimeService.Object);
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
        public void Calculate_MultiplePositiveRecord_OrderByExpireDate(TestCaseExpectAndActual caseDetail )
        {
            ///Arrange

            ///Action
            var actual = _pointPiorityQueue.Calculate(caseDetail.funcInput);

            ///Assert
            var expect = caseDetail.expectFuncOutput;

            Assert.AreEqual(JsonSerializer.Serialize(expect), JsonSerializer.Serialize(actual));
        }


        [Test]
        [TestCaseSource(typeof(MultipleNegativePoints_TestCaseSource))]
        public void Calculate_MultipleNegativeRecord_MergeBecomeOneNegativePoint(TestCaseExpectAndActual caseDetail)
        {
            ///Arrange

            ///Action
            var actual = _pointPiorityQueue.Calculate(caseDetail.funcInput);

            ///Assert
            var expect = caseDetail.expectFuncOutput;

            Assert.AreEqual(JsonSerializer.Serialize(expect), JsonSerializer.Serialize(actual));
        }
        [Test]
        [TestCaseSource(typeof(MixingPositiveNegative_TestCaseSource))]
        public void Calculate_MixingPositiveNegative_OffSet(TestCaseExpectAndActual caseDetail)
        {
            ///Arrange

            ///Action
            var actual = _pointPiorityQueue.Calculate(caseDetail.funcInput);

            ///Assert
            var expect = caseDetail.expectFuncOutput;

            Assert.AreEqual(JsonSerializer.Serialize(expect), JsonSerializer.Serialize(actual));
        }
    }
}