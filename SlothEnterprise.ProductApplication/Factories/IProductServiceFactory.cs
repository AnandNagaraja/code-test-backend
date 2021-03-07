using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;

namespace SlothEnterprise.ProductApplication.Factories
{
    public interface IProductServiceFactory
    {
        IProductService GetProductService(ISellerApplication application);
    }
}