using CodingExercise.App;
using NUnit.Framework;

namespace CodingExercise.UnitTests
{
    [TestFixture]
    public class ProductTests
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
            Assert.AreEqual(70600674, _processor.GetMax(_data, null).Product());
        }


        [Test]
        public void ProductEastGetsSum4OnARow()
        {
            Assert.AreEqual(336140, _processor.ProductToRight(_data, 1, 0).Product());
        }

        [Test]
        public void ProductEastIgnoresBeyondCol20()
        {
            Assert.AreEqual(5110, _processor.ProductToRight(_data, 1, 18).Product());
        }

        [Test]
        public void ProductSouthEastGetsCorrectValues()
        {
            Assert.AreEqual(255528, _processor.ProductToLowerRight(_data, 7, 5).Product());
        }

        [Test]
        public void ProductSouthEastIgnoresBoyond20()
        {
            Assert.AreEqual(240, _processor.ProductToLowerRight(_data, 18, 18).Product());
        }

        [Test]
        public void ProductSouthGetsSumOf4Lines()
        {
            Assert.AreEqual(34144, _processor.ProductDown(_data, 0, 0).Product());
        }

        [Test]
        public void CalcSouthIgnoresBeyondRow20()
        {
            Assert.AreEqual(728, _processor.ProductDown(_data, 18, 0).Product());
        }


        [Test]
        public void ProductSouthWestGetsCorrectValues()
        {
            Assert.AreEqual(238576, _processor.ProductLowerLeft(_data, 16, 3).Product());
        }

        [Test]
        public void ProductSouthWestIgnoresBoyond20()
        {
            Assert.AreEqual(0, _processor.ProductLowerLeft(_data, 18, 2).Product());
        }

        [Test]
        public void ProductSouthWestHandlesAZero()
        {
            Assert.AreEqual(0, _processor.ProductLowerLeft(_data, 18, 2).Product());
        }

        [Test]
        public void ProductSouthWestHandlesByondRow20()
        {
            Assert.AreEqual(80, _processor.ProductLowerLeft(_data, 18, 18).Product());
        }



    }
}