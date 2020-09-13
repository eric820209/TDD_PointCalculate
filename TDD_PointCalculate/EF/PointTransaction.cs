using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_PointCalculate.EF
{
    class PointTransaction
    {
        public long SqlId { get; set; }
        public Guid Id { get; set; }
        public Guid? PurchaseTransactionId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int? MarketId { get; set; }
        public Guid? UserDetailId { get; set; }
        public int? MemberId { get; set; }
        public int? MemberDiscountId { get; set; }
        public int? TransationMethodId { get; set; }
        public decimal? RealPoint { get; set; }
        public int? ChangePointReasonId { get; set; }
        public Guid? RedeemTransactionId { get; set; }
        public int? ApproveStatusId { get; set; }
        public int? TypeId { get; set; }
        public int? MemberSchemeTypeId { get; set; }
        public DateTime? UpdateTimeStamp { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string PhysicalCardNumber { get; set; }
        public Guid? PointTypeId { get; set; }
        public int? ShopId { get; set; }

        public virtual PointType PointType { get; set; }

        public virtual ICollection<PointTransactionDetail> PointTransactionDetail { get; set; }

    }
}
