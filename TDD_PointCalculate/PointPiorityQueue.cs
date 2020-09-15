using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD_PointCalculate.EF;

namespace TDD_PointCalculate
{
    public class PointPiorityQueue
    {
        private List<PointTransactionDetail> _pointsInQueue;
        private IDateTimeService _dateTimeService;
        public PointPiorityQueue(IDateTimeService dateTimeService)
        {
            _pointsInQueue = new List<PointTransactionDetail>();
            _dateTimeService = dateTimeService;
        }
        /// <summary>
        /// 使用piority queue，確保分數進出、消費時，不會用到過期的分數或是到期日較晚的分數(分數快到期的要先用)
        /// </summary>
        /// <param name="pointTransactionDetails"></param>
        /// <returns></returns>
        public List<PointTransactionDetail> Calculate(IEnumerable<PointTransactionDetail> pointTransactionDetails)
        {
            pointTransactionDetails = pointTransactionDetails.Where(x => x.TransactionDateTime < _dateTimeService.GetDate());
            foreach (var currentPoint in pointTransactionDetails)
            {
                if (_pointsInQueue.Count == 0)
                {
                    _pointsInQueue.Add(currentPoint);
                }
                else
                {
                    //queue的point 與新的point同符號時累加，否則則抵銷
                    var IsSameSign = _pointsInQueue[0].Point * currentPoint.Point > 0;
                    if (IsSameSign)
                    {
                        AccumulatePoint(currentPoint);
                    }
                    else 
                    {
                        OffsetPoint(currentPoint);
                    }
                }
            }
            return _pointsInQueue;
        }



        private void AccumulatePoint(PointTransactionDetail pointTransactionDetail)
        {
            bool isAdd = false;
            for (int i = 0; i < _pointsInQueue.Count; i++)
            {
                //逐一比較到期日，從最小到最大，若比較的對象>要插入的，則插入
                if (_pointsInQueue[i].ExprieDate > pointTransactionDetail.ExprieDate)
                {
                    _pointsInQueue.Insert(i, pointTransactionDetail);
                    isAdd = true;
                    break;
                }
            }
            if (!isAdd)
            {
                _pointsInQueue.Add(pointTransactionDetail);
            }
        }

        /// <summary>
        /// 抵銷分數。不論是扣除現有正分、或是抵銷現有負分
        /// </summary>
        /// <param name="currentPoint"></param>
        private void OffsetPoint(PointTransactionDetail currentPoint)
        {
            //現在這個的交易日>queue的第一個分數的到期日
            var IsExpired =currentPoint.TransactionDateTime > _pointsInQueue[0].ExprieDate;
            if(IsExpired)
            {
                _pointsInQueue.RemoveAt(0);
                OffsetPoint(currentPoint);
            }
            else
            {
                var pointGap =Math.Abs(_pointsInQueue[0].Point.Value) - Math.Abs(currentPoint.Point.Value);
                if (pointGap > 0)
                {
                    //分數夠用直接用掉，更新第一個的分數
                    _pointsInQueue[0].Point += currentPoint.Point;
                }
                else if (pointGap == 0)
                {
                    //分數剛好扣完，直接把紀錄抵銷
                    _pointsInQueue.RemoveAt(0);
                }
                else
                {
                    //分數不夠扣，先算還剩多少分要扣，第一個再拿掉
                    currentPoint.Point += _pointsInQueue[0].Point;
                    _pointsInQueue.RemoveAt(0);

                    //如果分數還有再扣第二個
                    if (_pointsInQueue.Count != 0)
                    {
                        OffsetPoint(currentPoint);
                    }
                    else
                    {
                        _pointsInQueue.Add(currentPoint);
                    }
                }
            }
        }
    }
}
