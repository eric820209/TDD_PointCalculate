using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_PointCalculate.Models
{
    class PointModel
    {
        public decimal Point { get; set; }
        public DateTime ExpireDate { get; set; }
        public ActivityModel Activity { get; set; }
        public PointTypeModel PointType { get; set; }
        public int TypeId { get; set; }
    }
}
