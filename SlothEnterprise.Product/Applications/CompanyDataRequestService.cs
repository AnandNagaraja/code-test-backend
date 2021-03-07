using SlothEnterprise.External;

namespace SlothEnterprise.Product.Applications
{
    public class CompanyDataRequestService : ICompanyDataRequestService
    {
        public CompanyDataRequest GetCompanyDataRequestFromApplication(ISellerApplication application)
        {
            return new CompanyDataRequest
            {
                CompanyFounded = application.CompanyData.Founded,
                CompanyNumber = application.CompanyData.Number,
                CompanyName = application.CompanyData.Name,
                DirectorName = application.CompanyData.DirectorName
            };
        }
    }
}
