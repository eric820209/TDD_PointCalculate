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
        private ModelBuilder _modelBuilder;
        [SetUp]
        public void Setup()
        {
            _modelBuilder = new ModelBuilder();
        }

        [Test]
        [TestCaseSource(typeof(MultiplePositivePoints_TestCaseSource))]
        public void Calculate_MultiplePositiveRecord_OrderByExpireDate(TestCaseExpectAndActualModel caseDetail )
        {
            ///Arrange
            //設定截止日，因為截止日跟test case掛勾，無法在set up 設定
            Mock<IDateTimeService> mock_DateTimeService = new Mock<IDateTimeService>();
            mock_DateTimeService.Setup(x => x.GetDate()).Returns(caseDetail.MockGetPointDate);
            PointPiorityQueue _pointPiorityQueue = new PointPiorityQueue(mock_DateTimeService.Object);

            ///Action
            var actual = _pointPiorityQueue.Calculate(caseDetail.funcInput);

            ///Assert
            var expect = caseDetail.expectFuncOutput;

            Assert.AreEqual(JsonSerializer.Serialize(expect), JsonSerializer.Serialize(actual));
        }


        [Test]
        [TestCaseSource(typeof(MultipleNegativePoints_TestCaseSource))]
        public void Calculate_MultipleNegativeRecord_MergeBecomeOneNegativePoint(TestCaseExpectAndActualModel caseDetail)
        {
            ///Arrange
            Mock<IDateTimeService> mock_DateTimeService = new Mock<IDateTimeService>();
            mock_DateTimeService.Setup(x => x.GetDate()).Returns(caseDetail.MockGetPointDate);
            PointPiorityQueue _pointPiorityQueue = new PointPiorityQueue(mock_DateTimeService.Object);
            
            ///Action
            var actual = _pointPiorityQueue.Calculate(caseDetail.funcInput);

            ///Assert
            var expect = caseDetail.expectFuncOutput;

            Assert.AreEqual(JsonSerializer.Serialize(expect), JsonSerializer.Serialize(actual));
        }
        [Test]
        [TestCaseSource(typeof(MixingPositiveNegative_TestCaseSource))]
        public void Calculate_MixingPositiveNegative_OffSet(TestCaseExpectAndActualModel caseDetail)
        {
            ///Arrange
            Mock<IDateTimeService> mock_DateTimeService = new Mock<IDateTimeService>();
            mock_DateTimeService.Setup(x => x.GetDate()).Returns(caseDetail.MockGetPointDate);
            PointPiorityQueue _pointPiorityQueue = new PointPiorityQueue(mock_DateTimeService.Object);
            
            ///Action
            var actual = _pointPiorityQueue.Calculate(caseDetail.funcInput);

            ///Assert
            var expect = caseDetail.expectFuncOutput;

            Assert.AreEqual(JsonSerializer.Serialize(expect), JsonSerializer.Serialize(actual));
        }
    }
}