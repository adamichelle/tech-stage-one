using NUnit.Framework;
using authors;

namespace authorsTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetUsernames_InputIs1_ShouldReturnListWithCountEquals1()
        {
            var result = AuthorsLib.GetUsernames(1);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetUsernames_InputIs0_ShouldReturnEmptyList()
        {
            var result = AuthorsLib.GetUsernames(0);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetUsernames_InputIs16_ShouldReturnListWithCountEquals15()
        {
            var result = AuthorsLib.GetUsernames(16);

            Assert.AreEqual(15, result.Count);
        }

        [Test]
        public void GetUsernamesSortedByRecordDate_InputIs1_ShouldReturnListWithCountEquals1()
        {
            var result = AuthorsLib.GetUsernamesSortedByRecordDate(1);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetUsernamesSortedByRecordDate_InputIs0_ShouldReturnEmptyList()
        {
            var result = AuthorsLib.GetUsernamesSortedByRecordDate(0);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetUsernamesSortedByRecordDate_InputIs16_ShouldReturnListWithCountEquals15()
        {
            var result = AuthorsLib.GetUsernamesSortedByRecordDate(16);

            Assert.AreEqual(15, result.Count);
        }
    }
}