using SlothEnterprise.External;

namespace SlothEnterprise.Product.Applications
{
    public interface ICompanyDataRequestService
    {
        CompanyDataRequest GetCompanyDataRequestFromApplication(ISellerApplication application);
    }
}