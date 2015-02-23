using CodingExercise.App;
using NUnit.Framework;

namespace CodingExercise.UnitTests
{
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
            Assert.AreEqual(2802800, _processor.ProductNorth(_data, 19, 0).Product());
        }

        [Test]
        public void CalcNorthIgnoresBeyondRow0()
        {
            Assert.AreEqual(16, _processor.ProductNorth(_data, 1, 0).Product());
        }

        [Test]
        public void ProductNorthEastGetsCorrectValues()
        {
            Assert.AreEqual(24468444, _processor.ProductNorthEast(_data, 3, 0).Product());
        }

        [Test]
        public void ProductNorthEastIgnoresBeyond0()
        {
            Assert.AreEqual(98, _processor.ProductNorthEast(_data, 1, 0).Product());
        }


        [Test]
        public void CalcEastGetsSum4OnARow()
        {
            Assert.AreEqual(336140, _processor.ProductEast(_data, 1, 0).Product());
        }

        [Test]
        public void CalcEastIgnoresBeyondCol20()
        {
            Assert.AreEqual(5110, _processor.ProductEast(_data, 1, 18).Product());
        }

        [Test]
        public void ProductSouthEastGetsCorrectValues()
        {
            Assert.AreEqual(255528, _processor.ProductSouthEast(_data, 7, 5).Product());
        }

        [Test]
        public void ProductSouthEastIgnoresBoyond20()
        {
            Assert.AreEqual(240, _processor.ProductSouthEast(_data, 18, 18).Product());
        }

        [Test]
        public void CalcSouthGetsSumOf4Lines()
        {
            Assert.AreEqual(34144, _processor.ProductSouth(_data, 0, 0).Product());
        }

        [Test]
        public void CalcSouthIgnoresBeyondRow20()
        {
            Assert.AreEqual(728, _processor.ProductSouth(_data, 18, 0).Product());
        }


        [Test]
        public void ProductSouthWestGetsCorrectValues()
        {
            Assert.AreEqual(238576, _processor.ProductSouthWest(_data, 16, 3).Product());
        }

        [Test]
        public void ProductSouthWestIgnoresBoyond20()
        {
            Assert.AreEqual(0, _processor.ProductSouthWest(_data, 18, 2).Product());
        }

        [Test]
        public void ProductSouthWestHandlesAZero()
        {
            Assert.AreEqual(0, _processor.ProductSouthWest(_data, 18, 2).Product());
        }

        [Test]
        public void ProductSouthWestHandlesByondRow20()
        {
            Assert.AreEqual(80, _processor.ProductSouthWest(_data, 18, 18).Product());
        }

        [Test]
        public void CalcWestGetsSum4OnARow()
        {
            Assert.AreEqual(829440, _processor.ProductWest(_data, 2, 7).Product());
        }

        [Test]
        public void CalcWestIgnoresBeyondCol0()
        {
            Assert.AreEqual(1215, _processor.ProductWest(_data, 5, 1).Product());
        }

        [Test]
        public void ProductNorthWestGetsCorrectValues()
        {
            Assert.AreEqual(685860, _processor.ProductNorthWest(_data, 3, 19).Product());
        }

        [Test]
        public void ProductNorthWestIgnoresBeyond0()
        {
            Assert.AreEqual(78840, _processor.ProductNorthWest(_data, 2, 19).Product());
        }


    }
}