using System;
using System.Collections.Generic;
using System.Text;
using TDD_PointCalculate.EF;

namespace TDD_PointCalculate
{
    public class PointPiorityQueue
    {
        private List<PointTransactionDetail> pointsInQueue;

        public PointPiorityQueue()
        {
            pointsInQueue = new List<PointTransactionDetail>();
        }
        /// <summary>
        /// 使用piority queue，確保分數進出、消費時，不會用到過期的分數或是到期日較晚的分數(分數快到期的要先用)
        /// </summary>
        /// <param name="pointTransactionDetails"></param>
        /// <returns></returns>
        public List<PointTransactionDetail> Calculate(IEnumerable<PointTransactionDetail> pointTransactionDetails)
        {
            foreach (var point in pointTransactionDetails)
            {
                if (pointsInQueue.Count == 0)
                {
                    pointsInQueue.Add(point);
                }
                else
                {
                    AccumulatePoint(point);
                }
            }
            return pointsInQueue;
        }



        private void AccumulatePoint(PointTransactionDetail pointTransactionDetail)
        {
            bool isAdd = false;
            for (int i = 0; i < pointsInQueue.Count; i++)
            {
                //逐一比較到期日，從最小到最大，若比較的對象>要插入的，則插入
                if (pointsInQueue[i].ExprieDate > pointTransactionDetail.ExprieDate)
                {
                    pointsInQueue.Insert(i,pointTransactionDetail);
                    isAdd = true;
                    break;
                }
            }
            if(!isAdd)
            {
                pointsInQueue.Add(pointTransactionDetail);
            }
        }
    }
}
