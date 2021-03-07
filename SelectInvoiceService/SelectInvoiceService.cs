using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;

namespace SlothEnterprise.SelectInvoiceService
{
    public class SelectInvoiceService : ISelectInvoiceService, IProductService
    {

        private readonly ICompanyDataRequestService _companyDataRequestService;

        public SelectInvoiceService(ICompanyDataRequestService companyDataRequestService)
        {
            _companyDataRequestService = companyDataRequestService;
        }

        public int SubmitApplicationFor(string companyNumber, decimal invoiceAmount, decimal advancePercentage)
        {
            //Todo: Implement the business logic for SelectiveInvoiceDiscount and return valid application ID

            return 1; // generate and return valid Application ID
        }

        public IApplicationResult SubmitApplicationFor(ISellerApplication application)
        {
            var companyDataRequest = _companyDataRequestService.GetCompanyDataRequestFromApplication(application);
            var selectiveInvoiceDiscount = (SelectiveInvoiceDiscount)application.Product;

            var resultApplicationId = SubmitApplicationFor(companyDataRequest.CompanyNumber.ToString(), selectiveInvoiceDiscount.InvoiceAmount,
               selectiveInvoiceDiscount.AdvancePercentage);

            return new ApplicationResultDTO
            {
                Success = true,
                ApplicationId = resultApplicationId
            };

        }
    }
}
