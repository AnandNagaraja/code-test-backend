using SlothEnterprise.Product.Applications;


namespace SlothEnterprise.ProductApplication
{
    public interface IProductApplicationService
    {
        int SubmitApplicationFor(ISellerApplication application);
    }
}