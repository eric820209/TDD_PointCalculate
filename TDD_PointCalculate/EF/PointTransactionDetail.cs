using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TDD_PointCalculate.EF
{
    public class PointTransactionDetail
    {
        [Key]
        public long SqlId { get; set; }
        public Guid Id { get; set; }
        public Guid? PointTransactionId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Point { get; set; }
        public Guid? ProductSqlId { get; set; }
        public decimal? Quantity { get; set; }
        public Guid? GroupId { get; set; }
        public Guid? UserDetailId { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public DateTime? BenefitCampaignStartDate { get; set; }
        public DateTime? BenefitCampaignEndDate { get; set; }
        public string BenefitsName { get; set; }
        public string BenefitsDescription { get; set; }
        public string BenefitsBenefitType { get; set; }
        public int? BenefitsPointEarningTypeId { get; set; }
        public int? BenefitsCalculationMethodId { get; set; }
        public string BenefitsMarketCodes { get; set; }
        public string BenefitsShopCategoryCodes { get; set; }
        public string BenefitsShopCodes { get; set; }
        public string BenefitsPurchaseProductCategoryCodes { get; set; }
        public Guid? BenefitsCalculationGroupId { get; set; }
        public int? BenefitsPriority { get; set; }
        public double? BenefitsPointConversationRate { get; set; }
        public decimal? BenefitsPointEarned { get; set; }
        public decimal? BenefitsCeilingPoint { get; set; }
        public int? BenefitsRoundingMethodId { get; set; }
        public int? BenefitsTimesOfBonusPointsGiven { get; set; }
        public int? BenefitsPointRoundingDigitId { get; set; }
        public int? BenefitsIncentivePeriodId { get; set; }
        public DateTime? BenefitsCreateDateTime { get; set; }
        public int BenefitsBenefitsMasterId { get; set; }
        public bool? BenefitsRepeat { get; set; }
        public DateTime? BenefitsRepeatStartDate { get; set; }
        public DateTime? BenefitsRepeatEndDate { get; set; }
        public int? BenefitsRepeatFrequencyId { get; set; }
        public bool? IsExcludeCalculate { get; set; }
        public DateTime? UpdateTimeStamp { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string BenefitsBenefitCode { get; set; }
        public Guid? BenefitPointTypeId { get; set; }
        public string BenefitsPosCodes { get; set; }
        public int? BenefitsPointRequired { get; set; }
        public int? BenefitsAmountReward { get; set; }
        public int? BenefitsBenefitCategoryId { get; set; }
        public int? BenefitsBenefitDepartmentId { get; set; }
        public DateTime? ExprieDate { get; set; }
        public decimal? InProcessPoint { get; set; }
        public Guid? ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual PointTransaction PointTransaction { get; set; }

    }
}
