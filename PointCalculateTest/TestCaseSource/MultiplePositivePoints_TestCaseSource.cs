using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TDD_PointCalculate;
using TDD_PointCalculate.EF;

namespace PointCalculator_Test.TestCaseSource
{
    class MultiplePositivePoints_TestCaseSource : IEnumerable
    {
        private ModelBuilder _modelBuilder;
        public MultiplePositivePoints_TestCaseSource()
        {
            _modelBuilder = new ModelBuilder();
        }


        public IEnumerator GetEnumerator()
        {
            //多個正數
            yield return new TestCaseExpectAndActualModel
            {
                MockGetPointDate = DateTime.Parse("2020/02/10")
                ,
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreatePointDetail(10.5M,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/03/20")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreatePointDetail(10.5M,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/03/20")),
                }
            };

            //多個正數需要排序
            yield return new TestCaseExpectAndActualModel
            {
                MockGetPointDate = DateTime.Parse("2020/02/10")
                ,
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/03/20")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/25")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/03/18")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/25")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/03/18")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/03/20")),
                }
            };
            
            //多個正數需要排序，且計算截止日為2/10
            yield return new TestCaseExpectAndActualModel
            {
                MockGetPointDate = DateTime.Parse("2020/02/10")
                ,
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/03/20")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/10"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/12"),DateTime.Parse("2020/02/25")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/20"),DateTime.Parse("2020/03/18")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/10"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/03/20")),
                }
            };

            //多個正數且計算截止日為2/01
            yield return new TestCaseExpectAndActualModel
            {
                MockGetPointDate = DateTime.Parse("2020/02/01")
                ,
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/03/20")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/10"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/12"),DateTime.Parse("2020/02/25")),
                 _modelBuilder.CreatePointDetail(10,DateTime.Parse("2020/02/20"),DateTime.Parse("2020/03/18")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                }
            };
        }
    }
}
