namespace DataAccess.Context.Entity
{
    public class SubCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public List<Product> Products { get; set; }
    }
}
