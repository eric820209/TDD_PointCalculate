using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_PointCalculate.EF
{
    class PointType
    {
        public Guid Id { get; set; }
        public int SqlId { get; set; }
        public string Name { get; set; }
        public string CrmId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CrmModifiedTime { get; set; }
        public virtual ICollection<PointTransaction> PointTransaction { get; set; }

    }
}
