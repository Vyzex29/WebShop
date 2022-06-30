namespace DataAccess.Context.Entity
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<SubCategory> SubCategories { get; set; }
    }
}
