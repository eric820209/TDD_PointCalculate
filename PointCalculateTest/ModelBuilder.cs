using System;
using System.Collections.Generic;
using System.Text;
using TDD_PointCalculate.EF;
using TDD_PointCalculate.Models;

namespace PointCalculator_Test
{
    public class ModelBuilder
    {
        /// <summary>
        /// 產生指定的PointTransactionDetail
        /// </summary>
        /// <param name="point">分數</param>
        /// <param name="transactionDate">此分數交易日期</param>
        /// <param name="expireDate">分數到期日</param>
        /// <returns></returns>

        public PointTransactionDetail CreatePointDetail(decimal point, DateTime? transactionDate = null, DateTime? expireDate = null)
        {
            PointTransactionDetail transactionDetail = new PointTransactionDetail();
            transactionDetail.Point = point;

            if (transactionDate != null)
                transactionDetail.TransactionDateTime = transactionDate.Value;
            if (expireDate != null)
                transactionDetail.ExprieDate = expireDate.Value;

            return transactionDetail;
        }
        /// <summary>
        /// 產生指定的PointModel
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public PointModel CreatePointModel(decimal point)
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
