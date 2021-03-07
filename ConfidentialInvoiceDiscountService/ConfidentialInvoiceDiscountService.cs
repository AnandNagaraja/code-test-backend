using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;

namespace SlothEnterprise.ConfidentialInvoiceDiscountService
{
    public class ConfidentialInvoiceDiscountService : IConfidentialInvoiceService, IProductService
    {
        private readonly ICompanyDataRequestService _companyDataRequestService;

        public ConfidentialInvoiceDiscountService(ICompanyDataRequestService companyDataRequestService)
        {
            _companyDataRequestService = companyDataRequestService;
        }

        public IApplicationResult SubmitApplicationFor(ISellerApplication application)
        {
            var confidentialInvoiceDiscount = (ConfidentialInvoiceDiscount)application.Product;
            return SubmitApplicationFor(_companyDataRequestService.GetCompanyDataRequestFromApplication(application), confidentialInvoiceDiscount.TotalLedgerNetworth, confidentialInvoiceDiscount.AdvancePercentage, confidentialInvoiceDiscount.VatRate);
        }

        public IApplicationResult SubmitApplicationFor(CompanyDataRequest applicantData, decimal invoiceLedgerTotalValue,
            decimal advantagePercentage, decimal vatRate)
        {
            //Todo: Implement the InvoiceDiscount logic for ConfidentialInvoiceDiscountService

            return new ApplicationResultDTO
            {
                Success = true,
                ApplicationId = 1 // generate and return valid Application ID
            };
        }





    }
}
