using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_PointCalculate.Models
{
    public class PointModel
    {
        public decimal Point { get; set; }
        public DateTime ExpireDate { get; set; }
        public ActivityModel Activity { get; set; }
        public PointTypeModel PointType { get; set; }
        public int TypeId { get; set; }
    }
    /// <summary>
    /// 行銷活動
    /// </summary>
    public class ActivityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    /// <summary>
    /// 分數種類
    /// 一般分數/集星/遊戲次數
    /// </summary>
    public class PointTypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
