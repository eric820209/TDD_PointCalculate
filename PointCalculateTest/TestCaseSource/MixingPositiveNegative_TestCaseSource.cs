using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TDD_PointCalculate.EF;

namespace PointCalculator_Test.TestCaseSource
{
    public class MixingPositiveNegative_TestCaseSource:IEnumerable
    {
        ModelBuilder _modelBuilder;
        public MixingPositiveNegative_TestCaseSource()
        {
            _modelBuilder = new ModelBuilder();
        }

        public IEnumerator GetEnumerator()
        {
            #region 1. +100 -10 =90
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(-10,DateTime.Parse("2020/02/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(90,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                }
            };
            #endregion

            #region 2. +100 -100 =[]
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(-100,DateTime.Parse("2020/02/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                }
            };
            #endregion

            #region 3. +100 -120 = -20
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(-120,DateTime.Parse("2020/02/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(-20,DateTime.Parse("2020/02/10")),
                }
            };
            #endregion

            #region 4. +100(過期) +80 -20 = 60
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/01/01"),DateTime.Parse("2020/01/20")),
                 _modelBuilder.CreateTransactionDetail(80,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(-20,DateTime.Parse("2020/02/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(60,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                }
            };
            #endregion

            #region 5. +100(過期) +100 -100 = []
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/01/01"),DateTime.Parse("2020/01/20")),
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(-100,DateTime.Parse("2020/02/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                }
            };
            #endregion

            #region 6. +100(過期) +60(2/10) +100(2/20) -100= 60(2/20)
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/01/01"),DateTime.Parse("2020/01/20")),
                 _modelBuilder.CreateTransactionDetail(60,DateTime.Parse("2020/02/08"),DateTime.Parse("2020/02/10")),
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(-100,DateTime.Parse("2020/02/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(60,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                }
            };
            #endregion

            #region 7. +100(過期) +60(2/10) +40(2/20) -100 = []
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/01/01"),DateTime.Parse("2020/01/20")),
                 _modelBuilder.CreateTransactionDetail(60,DateTime.Parse("2020/02/08"),DateTime.Parse("2020/02/10")),
                 _modelBuilder.CreateTransactionDetail(40,DateTime.Parse("2020/02/09"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(-100,DateTime.Parse("2020/02/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                }
            };
            #endregion

            #region 8. +100(過期) +60(2/10) +40(2/20) +50(3/10) -120 = 30(3/10)
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/01/01"),DateTime.Parse("2020/01/20")),
                 _modelBuilder.CreateTransactionDetail(60,DateTime.Parse("2020/02/01"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(40,DateTime.Parse("2020/02/03"),DateTime.Parse("2020/02/25")),
                 _modelBuilder.CreateTransactionDetail(50,DateTime.Parse("2020/02/10"),DateTime.Parse("2020/03/10")),
                 _modelBuilder.CreateTransactionDetail(-120,DateTime.Parse("2020/02/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(30,DateTime.Parse("2020/02/10"),DateTime.Parse("2020/03/10")),
                }
            };
            #endregion

            #region 9. +100(過期) +60(2/10) +40(2/20)  -120 +50(交易日還沒到3/15，3/20)= -20
            //還沒發生的
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/01/01"),DateTime.Parse("2020/01/20")),
                 _modelBuilder.CreateTransactionDetail(60,DateTime.Parse("2020/02/01"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(40,DateTime.Parse("2020/02/03"),DateTime.Parse("2020/02/25")),
                 _modelBuilder.CreateTransactionDetail(-120,DateTime.Parse("2020/02/10")),
                 _modelBuilder.CreateTransactionDetail(50,DateTime.Parse("2020/03/15"),DateTime.Parse("2020/03/20")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(-20,DateTime.Parse("2020/02/10")),
                }
            };
            #endregion

            #region 10. +100(過期) +60(2/10) +40(2/20)  -120 +50(3/10)= 30(3/10)
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/01/01"),DateTime.Parse("2020/01/20")),
                 _modelBuilder.CreateTransactionDetail(60,DateTime.Parse("2020/02/01"),DateTime.Parse("2020/02/10")),
                 _modelBuilder.CreateTransactionDetail(40,DateTime.Parse("2020/02/03"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(-120,DateTime.Parse("2020/02/10")),
                 _modelBuilder.CreateTransactionDetail(50,DateTime.Parse("2020/02/12"),DateTime.Parse("2020/03/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(30,DateTime.Parse("2020/02/12"),DateTime.Parse("2020/03/10")),
                }
            };
            #endregion

            #region 11. +100(過期) +60(2/10) +40(2/20)  -120 +20(3/10)= []
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/01/01"),DateTime.Parse("2020/01/20")),
                 _modelBuilder.CreateTransactionDetail(60,DateTime.Parse("2020/02/01"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(40,DateTime.Parse("2020/02/03"),DateTime.Parse("2020/02/25")),
                 _modelBuilder.CreateTransactionDetail(-120,DateTime.Parse("2020/02/19")),
                 _modelBuilder.CreateTransactionDetail(20,DateTime.Parse("2020/02/10"),DateTime.Parse("2020/03/10")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                }
            };
            #endregion

            #region 10. +100(過期) +60(2/10) +40(2/20)  -120 +50(3/10) -50 = -20
            yield return new TestCaseExpectAndActual
            {
                funcInput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(100,DateTime.Parse("2020/01/01"),DateTime.Parse("2020/01/20")),
                 _modelBuilder.CreateTransactionDetail(60,DateTime.Parse("2020/02/01"),DateTime.Parse("2020/02/13")),
                 _modelBuilder.CreateTransactionDetail(40,DateTime.Parse("2020/02/03"),DateTime.Parse("2020/02/20")),
                 _modelBuilder.CreateTransactionDetail(-120,DateTime.Parse("2020/02/10")),
                 _modelBuilder.CreateTransactionDetail(50,DateTime.Parse("2020/02/12"),DateTime.Parse("2020/03/10")),
                 _modelBuilder.CreateTransactionDetail(-50,DateTime.Parse("2020/02/13")),
                },
                expectFuncOutput = new List<PointTransactionDetail>
                {
                 _modelBuilder.CreateTransactionDetail(-20,DateTime.Parse("2020/02/13")),
                }
            };
            #endregion




        }
    }
}
