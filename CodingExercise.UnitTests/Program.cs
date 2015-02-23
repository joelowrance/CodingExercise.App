using CodingExercise.App;
using NUnit.Framework;

namespace CodingExercise.UnitTests
{
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
