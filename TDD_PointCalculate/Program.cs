using Microsoft.Extensions.DependencyInjection;
using System;
using TDD_PointCalculate.EF;

namespace TDD_PointCalculate
{
    class Program
    {
        static void Main(string[] args)
        {
            #region build container
            var services = new ServiceCollection()
            .AddDbContext<PointContext>()
            .AddTransient<IPointCalculator, PointCalculator>()
            .AddTransient<IDateTimeService,DateTimeService>()
            .BuildServiceProvider();
            #endregion




        }
    }
}
