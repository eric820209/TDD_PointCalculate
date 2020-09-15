using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_PointCalculate
{
    public class DateTimeService : IDateTimeService
    {
        private DateTime targetDate;

        public DateTimeService()
        {
        }

        public DateTimeService(DateTime date)
        {
            targetDate = date;
        }

        public DateTimeService(string dateStr)
        {
            targetDate = DateTime.Parse(dateStr);
        }


        public DateTime GetDate()
        {
            if (targetDate != null)
                return targetDate;
            else
                return DateTime.Now;
        }
    }
}
