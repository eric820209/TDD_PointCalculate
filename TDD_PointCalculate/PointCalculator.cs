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
        private IEnumerable<PointTransactionDetail> PointsInQueue;
        //使用piority queue的觀念，確保分數進出、消費時，不會用到過期的分數或是到期日較晚的分數(分數快到期的要先用)
        public List<PointModel> Calculate(IEnumerable<PointTransactionDetail> transactions)
        {

            return null;
        }



    }
}
