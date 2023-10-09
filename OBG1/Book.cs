namespace OBG1
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }
        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException(nameof(Title), "Title Cannot be Null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException(nameof(Title), "Title must be atleast 3 character");
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0 || Price > 1200)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "price must be 1200 or under");
            }
        }

        public void Validate()
        {
            ValidatePrice();
            ValidateTitle();
        }
    }
}