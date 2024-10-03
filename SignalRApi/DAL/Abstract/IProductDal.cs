using SignalRApi.DAL.Entities;

namespace SignalRApi.DAL.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        public int ProductCount();
    }
}
