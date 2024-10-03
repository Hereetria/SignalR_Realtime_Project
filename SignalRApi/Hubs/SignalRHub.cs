using Microsoft.AspNetCore.SignalR;
using SignalRApi.DAL;
using SignalRApi.DAL.Abstract;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IProductDal _productDal;

        public SignalRHub(ICategoryDal categoryDal, IProductDal productDal)
        {
            _categoryDal = categoryDal;
            _productDal = productDal;
        }

        public async Task SendStatistic()
        {
            var value = _categoryDal.CategoryCount();
            await Clients.All.SendAsync("RecieverCategoryCount",value);

            var value2 = _categoryDal.GetActiveCategories();
            await Clients.All.SendAsync("ActiveCategoryCount",value2);
        }
        

    }
}
