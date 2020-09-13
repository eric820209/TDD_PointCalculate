using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TDD_PointCalculate.EF;

namespace PointCalculator_Test.TestCaseSource
{
    public class MultipleNegativePoints_TestCaseSource : IEnumerable
    {
        ModelBuilder _modelBuilder;
        public MultipleNegativePoints_TestCaseSource()
        {
            _modelBuilder = new ModelBuilder();
        }
        public IEnumerator GetEnumerator()
        {
            yield return new List<PointTransactionDetail>
            {
            _modelBuilder.CreateTransactionDetail(-10,DateTime.Parse("2020/02/09")),
            _modelBuilder.CreateTransactionDetail(-10.5M,DateTime.Parse("2020/02/09")),
            };

            yield return new List<PointTransactionDetail>
            {
            _modelBuilder.CreateTransactionDetail(-10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/05/02")),
            _modelBuilder.CreateTransactionDetail(-10.5M,DateTime.Parse("2020/02/09")),
            };
        }
    }
}
