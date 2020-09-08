using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_PointCalculate.EF
{
    class PointContext:DbContext
    {

        public PointContext():base()
        { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer("");
        }


        DbSet<PointTransaction> PointTransaction { get; set; }
    }
}
