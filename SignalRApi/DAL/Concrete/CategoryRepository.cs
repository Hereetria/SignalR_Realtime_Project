using SignalRApi.DAL.Abstract;
using SignalRApi.DAL.Entities;

namespace SignalRApi.DAL.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        public CategoryRepository(SignalRContext context) : base(context)
        {
        }

        public int GetActiveCategories()
        {
            using var context = new SignalRContext();
            return context.Categories.Where(c => c.Status == true).Count();
        }


        public int CategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count();  
        }
    }
}
