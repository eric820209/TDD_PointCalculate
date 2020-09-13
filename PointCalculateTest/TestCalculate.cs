using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;
using TDD_PointCalculate;
using TDD_PointCalculate.EF;
using TDD_PointCalculate.Models;

namespace PointCalculator_Test
{
    public class Tests
    {
        private PointPiorityQueue _pointPiorityQueue;
        [SetUp]
        public void Setup()
        {
            _pointPiorityQueue = new PointPiorityQueue();
        }

        [Test]
        [TestCase("1")]
        [TestCase("10.52")]
        [TestCase("-20.56")]
        public void Calculate_OnePointTransactionDetailRecord_ReturnSpecifyPoint(decimal point)
        {
            ///Arrange
            List<PointTransactionDetail> transactions = new List<PointTransactionDetail>
            {
            CreateTransactionDetail(point),
            };
            ///Action
            var actual = _pointPiorityQueue.Calculate(transactions);

            ///Assert
            List<PointTransactionDetail> expect = new List<PointTransactionDetail>
            {
            CreateTransactionDetail(point),
            };

            Assert.AreEqual(JsonSerializer.Serialize(expect),JsonSerializer.Serialize(actual));
        }




        /// <summary>
        /// 產生指定的PointTransactionDetail
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private PointTransactionDetail CreateTransactionDetail(decimal point)
        {
            PointTransactionDetail transactionDetail = new PointTransactionDetail();
            transactionDetail.Point = point;
            return transactionDetail;
        }
        private PointModel CreatePointModel(decimal point)
        {
            PointModel pointModel = new PointModel();
            pointModel.Point = point;
            pointModel.Activity = new ActivityModel { Id = Guid.Empty, Name = "" };
            pointModel.ExpireDate = DateTime.Now;
            pointModel.PointType = new PointTypeModel { Id = Guid.Empty, Name = "" };
            return pointModel;
        }
    }
}