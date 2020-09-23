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
            //多個負數
            yield return new TestCaseExpectAndActualModel
            {
                MockGetPointDate = DateTime.Parse("2020/02/10")
                ,
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(-10,DateTime.Parse("2020/02/09")),
                 _modelBuilder.CreatePointDetail(-10.5M,DateTime.Parse("2020/02/09")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(-10,DateTime.Parse("2020/02/09")),
                 _modelBuilder.CreatePointDetail(-10.5M,DateTime.Parse("2020/02/09")),
                }
            };

            //多個負數，需要排序
            yield return new TestCaseExpectAndActualModel
            {
                MockGetPointDate = DateTime.Parse("2020/02/10")
                ,
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(-10   ,DateTime.Parse("2020/02/10")),
                 _modelBuilder.CreatePointDetail(-10.5M,DateTime.Parse("2020/02/09")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(-10.5M,DateTime.Parse("2020/02/09")),
                 _modelBuilder.CreatePointDetail(-10   ,DateTime.Parse("2020/02/10")),
                }
            };

            //多個負數，需要排序，結算日為2/09
            yield return new TestCaseExpectAndActualModel
            {
                MockGetPointDate = DateTime.Parse("2020/02/09")
                ,
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(-10   ,DateTime.Parse("2020/02/09")),
                 _modelBuilder.CreatePointDetail(-10.5M,DateTime.Parse("2020/02/19")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(-10,DateTime.Parse("2020/02/09")),
                }
            };
        }
    }
}
