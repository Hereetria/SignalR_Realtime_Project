using SignalRApi.DAL.Entities;

namespace SignalRApi.DAL.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        public int CategoryCount();

        public int GetActiveCategories();
    }
}
