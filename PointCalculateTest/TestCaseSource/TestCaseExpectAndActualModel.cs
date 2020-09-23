using System;
using System.Collections.Generic;
using System.Text;
using TDD_PointCalculate;
using TDD_PointCalculate.EF;

namespace PointCalculator_Test.TestCaseSource
{
    public class TestCaseExpectAndActualModel
    {
        /// <summary>
        /// 過往分數
        /// </summary>
        public List<PointTransactionDetail> funcInput { get; set; }
        /// <summary>
        /// 預期算完結果
        /// </summary>
        public List<PointTransactionDetail> expectFuncOutput { get; set; }

        /// <summary>
        /// 計算分數的日期
        /// </summary>
        public DateTime MockGetPointDate { get; set; }
    }
}
