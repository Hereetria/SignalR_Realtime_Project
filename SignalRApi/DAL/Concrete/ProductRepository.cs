using SignalRApi.DAL.Abstract;
using SignalRApi.DAL.Entities;

namespace SignalRApi.DAL.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductDal
    {
        public ProductRepository(SignalRContext context) : base(context)
        {

        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }
    }
}
