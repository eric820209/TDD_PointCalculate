using System;
using System.Collections.Generic;
using System.Text;
using TDD_PointCalculate.EF;
using TDD_PointCalculate.Models;

namespace TDD_PointCalculate
{
    interface IPointCalculator
    {
        List<PointModel> GetFinalPoints(IEnumerable<PointTransactionDetail> pointTransactionDetails);
    }
}
