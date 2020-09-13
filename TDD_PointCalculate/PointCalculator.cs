using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD_PointCalculate.EF;
using TDD_PointCalculate.Models;

namespace TDD_PointCalculate
{
    public class PointCalculator : IPointCalculator
    {
        PointPiorityQueue _pointPiorityQueue;
        public PointCalculator(PointPiorityQueue pointPiorityQueue)
        {
            _pointPiorityQueue = pointPiorityQueue;
        }
        public List<PointModel> GetFinalPoints(IEnumerable<PointTransactionDetail> pointTransactionDetails)
        {
            var calculatedPointTransactionDetails =_pointPiorityQueue.Calculate(pointTransactionDetails);

            var finalPoints = calculatedPointTransactionDetails.Select(x => new PointModel
            {
                Point = x.Point.Value,
                Activity = new ActivityModel { Id = x.Activity == null ? Guid.Empty : x.Activity.Id, Name = x.Activity == null ? "空活動" : x.Activity.Name },
                ExpireDate = x.ExprieDate.Value,
                PointType = new PointTypeModel { Id = x.PointTransaction.PointTypeId.Value, Name = x.PointTransaction.PointType.Name },
                TypeId = x.PointTransaction.TypeId.Value
            }).ToList();

            return finalPoints;
        }



    }
}
