using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_PointCalculate.EF
{
    public class Activity
    {
        public int SqlId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? RslId { get; set; }
        public DateTime? RslModifiedTime { get; set; }
    }
}
