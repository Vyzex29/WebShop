using DataAccess.Context.Entity;


namespace WebShopServices.Managers
{
    public interface ISubCategoryManager
    {
        public List<SubCategory> GetAll();

        public void Add(SubCategory category);
    }
}
