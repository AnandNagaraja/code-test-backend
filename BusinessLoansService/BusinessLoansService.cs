using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;


namespace SlothEnterprise.BusinessLoansService
{
    public class BusinessLoansService : IBusinessLoansService, IProductService
    {
        private readonly ICompanyDataRequestService _companyDataRequestService;

        public BusinessLoansService(ICompanyDataRequestService companyDataRequestService)
        {
            _companyDataRequestService = companyDataRequestService;
        }


        public IApplicationResult SubmitApplicationFor(ISellerApplication application)
        {

            return SubmitApplicationFor(_companyDataRequestService.GetCompanyDataRequestFromApplication(application), GetLoansRequest(application));

        }

        public IApplicationResult SubmitApplicationFor(CompanyDataRequest applicantData, LoansRequest businessLoans)
        {
            //Todo: Implement the business logic for applying BusinessLoansApplication and return valid application ID and success State

            return new ApplicationResultDTO
            {
                Success = true,
                ApplicationId = 1 // generate and return valid Application ID
            };
        }

        public LoansRequest GetLoansRequest(ISellerApplication application)
        {
            var loans = (BusinessLoans)application.Product;

            return new LoansRequest
            {
                InterestRatePerAnnum = loans.InterestRatePerAnnum,
                LoanAmount = loans.LoanAmount
            };
        }


    }


}
