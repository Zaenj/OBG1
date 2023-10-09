using OBG1;

namespace BookTest
{
    [TestClass]
    public class RepositoryTests
    {
        private BooksRepository _repo;

        [TestInitialize]
        public void Setup()
        {
            _repo = new BooksRepository();
        }

        /// Test all books are returned.
        [TestMethod]
        public void Get_NoFilter_AllBooks()
        {
            var result = _repo.Get().ToList();
            Assert.AreEqual(5, result.Count);
        }

        /// Test filtering by title returns the correct books.
        [TestMethod]
        public void Get_ByTitle_CorrectBooks()
        {
            var result = _repo.Get(title: "Harryspot").ToList();
            Assert.AreEqual(1, result.Count);
        }

        /// Test that adding a book increments the total book count.
        [TestMethod]
        public void Add_Book_IncreasesCount()
        {
            var book = new Book() { Title = "New", Price = 350 };
            _repo.Add(book);
            Assert.AreEqual(6, _repo.GetAllBook().Count);
        }

        /// Test removing a book with a valid ID decreases the total book count.
        [TestMethod]
        public void Remove_ValidId_DecreasesCount()
        {
            _repo.Remove(1);
            Assert.AreEqual(4, _repo.GetAllBook().Count);
        }

        /// Test that trying to remove with an invalid ID does not change the book count.
        [TestMethod]
        public void Remove_InvalidId_NoChange()
        {
            var removedBook = _repo.Remove(100);
            Assert.IsNull(removedBook);
            Assert.AreEqual(5, _repo.GetAllBook().Count);
        }
    }
}
