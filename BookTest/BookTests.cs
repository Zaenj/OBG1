using OBG1;

namespace BookTest
{
    [TestClass()]

    public class BookTests
    {
        private readonly Book _book = new() { Id = 1, Title = "Fersken Book", Price = 414 };
        private readonly Book _NullBookTitle = new() { Id = 2, Price = 400 };
        private readonly Book _EmptyTitle = new() { Id = 3, Title = "2", Price = 400 };
        private readonly Book _PriceHigh = new() { Id = 4, Title = "RedBull Book", Price = 1201 };
        private readonly Book _PriceLow = new() { Id = 5, Title = "DellBook", Price = -1 };


        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("1 Fersken Book 414", _book.ToString());
        }
        [TestMethod]
        public void ValidateTitle()
        {
            _book.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => _NullBookTitle.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => _EmptyTitle.ValidateTitle());
        }

        [TestMethod]
        public void ValidatePrice()
        {
            _book.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _PriceHigh.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _PriceLow.ValidatePrice());

        }

        [TestMethod]

        public void Validate()
        {
            _book.Validate();
        }
    }
}