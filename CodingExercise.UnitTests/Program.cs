using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CodingExercise.App;
using NUnit.Framework;

namespace CodingExercise.UnitTests
{
    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public int Value { get; set; }
    }

    public class Sequence
    {
        public List<Point> Points { get; set; }
        public string Direction { get; set; }
    }






    public class GridProcessor
    {
        public const int MAX_HOPS = 4;


        public void GetMax(int[,] sourceData)
        {
            int maxValRow = 0;
            int maxValCol = 0;
            int maxSum = 0;
            string direction = string.Empty;

            for (int row = 0; row < 20; row++)
            {
                for (int col = 0; col < 20; col++)
                {
                    var sn = ProductNorth(sourceData, row, col);
                    if (sn > maxSum)
                    {
                        maxValRow = row;
                        maxValCol = col;
                        maxSum = sn;
                        direction = "North";
                    }

                    var sne = ProductNorthEast(sourceData, row, col);
                    if (sne > maxSum)
                    {
                        maxValRow = row;
                        maxValCol = col;
                        maxSum = sne;
                        direction = "NorthEast";
                    }

                    var se = ProductEast(sourceData, row, col);
                    if (se > maxSum)
                    {
                        maxValRow = row;
                        maxValCol = col;
                        maxSum = se;
                        direction = "East";
                    }

                    var sse = ProductSouthEast(sourceData, row, col);
                    if (sse > maxSum)
                    {
                        maxValRow = row;
                        maxValCol = col;
                        maxSum = sse;
                        direction = "SouthEast";
                    }

                    var ss = ProductSouth(sourceData, row, col);
                    if (ss > maxSum)
                    {
                        maxValRow = row;
                        maxValCol = col;
                        maxSum = ss;
                        direction = "South";
                    }

                    var ssw = ProductSouthWest(sourceData, row, col);
                    if (ssw > maxSum)
                    {
                        maxValRow = row;
                        maxValCol = col;
                        maxSum = ssw;
                        direction = "SouthWest";
                    }

                    var sw = ProductWest(sourceData, row, col);
                    if (sw > maxSum)
                    {
                        maxValRow = row;
                        maxValCol = col;
                        maxSum = sw;
                        direction = "West";
                    }

                    var snw = ProductNorthWest(sourceData, row, col);
                    if (snw > maxSum)
                    {
                        maxValRow = row;
                        maxValCol = col;
                        maxSum = ssw;
                        direction = "NorthWest";
                    }

                }

            }

            Console.Write("The max sum was {0} starting on row {1} at column {2} and heading {3}", maxSum, maxValRow, maxValCol, direction);
        }


    
        public int ProductNorth(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow - x, x => col);
        }

        public int ProductNorthEast(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow - x, x => col + x);
        }

        public int ProductEast(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow, x => col + x);
        }

        public int ProductSouthEast(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow + x, x => col + x);
        }


        public int ProductSouth(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow + x, x => col);
        }

        public int ProductSouthWest(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow + x, x => col - x);
        }

        public int ProductWest(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow, x => col - x);
        }

        public int ProductNorthWest(int[,] sourceData, int startRow, int col)
        {
            return GetSequence(sourceData, x => startRow - x, x => col - x);
        }

        private int GetSequence(int[,] data, Func<int, int> row, Func<int, int> col)
        {
            var sum = 1;
            for (var i = 0; i < MAX_HOPS; i++)
            {
                sum = sum * GetValue(data, row(i), col(i));
            }
            return sum;
        }



        private int GetValue(int[,] sourceData, int row, int col)
        {
            if (row < 0) return 1;
            if (row > 19) return 1;
            if (col > 19) return 1;
            if (col < 0) return 1;

            return sourceData[row, col];
        }
    }


    [TestFixture]
    public class CalculationTests
    {
        private int[,] _data;
        private GridProcessor _processor;

        [TestFixtureSetUp]
        public void BeforeAnyTestsHaveRun()
        {
            _data = new DataSource().AsArray();
            _processor = new GridProcessor();
        }


        [Test]
        public void GetsMaxValueInPrimaryDirections()
        {
            _processor.GetMax(_data);
        }

        [Test]
        public void CalcNorthGetsSumOf4Lines()
        {
            Assert.AreEqual(2802800, _processor.ProductNorth(_data, 19, 0));
        }

        [Test]
        public void CalcNorthIgnoresBeyondRow0()
        {
            Assert.AreEqual(16, _processor.ProductNorth(_data, 1, 0));
        }

        [Test]
        public void ProductNorthEastGetsCorrectValues()
        {
            Assert.AreEqual(24468444, _processor.ProductNorthEast(_data, 3, 0));
        }

        [Test]
        public void ProductNorthEastIgnoresBeyond0()
        {
            Assert.AreEqual(98, _processor.ProductNorthEast(_data, 1, 0));
        }


        [Test]
        public void CalcEastGetsSum4OnARow()
        {
            Assert.AreEqual(336140, _processor.ProductEast(_data, 1, 0));
        }

        [Test]
        public void CalcEastIgnoresBeyondCol20()
        {
            Assert.AreEqual(5110, _processor.ProductEast(_data, 1, 18));
        }

        [Test]
        public void ProductSouthEastGetsCorrectValues()
        {
            Assert.AreEqual(255528, _processor.ProductSouthEast(_data, 7, 5));
        }

        [Test]
        public void ProductSouthEastIgnoresBoyond20()
        {
            Assert.AreEqual(240, _processor.ProductSouthEast(_data, 18, 18));
        }

        [Test]
        public void CalcSouthGetsSumOf4Lines()
        {
            Assert.AreEqual(34144, _processor.ProductSouth(_data, 0, 0));
        }

        [Test]
        public void CalcSouthIgnoresBeyondRow20()
        {
            Assert.AreEqual(728, _processor.ProductSouth(_data, 18, 0));
        }


        [Test]
        public void ProductSouthWestGetsCorrectValues()
        {
            Assert.AreEqual(238576, _processor.ProductSouthWest(_data, 16, 3));
        }

        [Test]
        public void ProductSouthWestIgnoresBoyond20()
        {
            Assert.AreEqual(0, _processor.ProductSouthWest(_data, 18, 2));
        }

        [Test]
        public void ProductSouthWestHandlesAZero()
        {
            Assert.AreEqual(0, _processor.ProductSouthWest(_data, 18, 2));
        }

        [Test]
        public void ProductSouthWestHandlesByondRow20()
        {
            Assert.AreEqual(80, _processor.ProductSouthWest(_data, 18, 18));
        }

        [Test]
        public void CalcWestGetsSum4OnARow()
        {
            Assert.AreEqual(829440, _processor.ProductWest(_data, 2, 7));
        }

        [Test]
        public void CalcWestIgnoresBeyondCol0()
        {
            Assert.AreEqual(1215, _processor.ProductWest(_data, 5, 1));
        }

        [Test]
        public void ProductNorthWestGetsCorrectValues()
        {
            Assert.AreEqual(685860, _processor.ProductNorthWest(_data, 3, 19));
        }

        [Test]
        public void ProductNorthWestIgnoresBeyond0()
        {
            Assert.AreEqual(78840, _processor.ProductNorthWest(_data, 2, 19));
        }


    }


    
    


    [TestFixture]
    public class DataSourceBaslineTests
    {
        [Test]
        public void DataIs20By20()
        {
            var data = new DataSource().AsArray();

            Assert.AreEqual(data.GetLength(0), 20);
            Assert.AreEqual(data.GetLength(1), 20);
        }
    }

}
