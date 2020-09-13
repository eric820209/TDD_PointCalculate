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
            foreach (var transaction in pointTransactionDetails)
            {
                if (pointsInQueue.Count == 0)
                {
                    pointsInQueue.Add(transaction);
                }
                else
                {

                }
            }
            return pointsInQueue;
        }
    }
}
