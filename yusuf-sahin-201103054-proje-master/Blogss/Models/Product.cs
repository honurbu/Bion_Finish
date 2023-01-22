namespace Blogss.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }

        public string ImageUrl { get; set; }



        public int CategoryId { get; set; }
        public Category Category { get; set; }



    }
}
