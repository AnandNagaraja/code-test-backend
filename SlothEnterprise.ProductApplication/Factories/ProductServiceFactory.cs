using System;
using System.Collections.Generic;
using System.Text;
using SlothEnterprise.BusinessLoansService;
using SlothEnterprise.ConfidentialInvoiceDiscountService;
using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;
using SlothEnterprise.SelectInvoiceService;

namespace SlothEnterprise.ProductApplication.Factories
{
    public class ProductServiceFactory : IProductServiceFactory
    {
        private readonly ICompanyDataRequestService _companyDataRequestService;

        public ProductServiceFactory(ICompanyDataRequestService companyDataRequestService)
        {
            _companyDataRequestService = companyDataRequestService;
        }


        public IProductService GetProductService(ISellerApplication application)
        {
            switch (application.Product)
            {
                case BusinessLoans _:
                    return new BusinessLoansService.BusinessLoansService(_companyDataRequestService);
                case ConfidentialInvoiceDiscount _:
                    return new ConfidentialInvoiceDiscountService.ConfidentialInvoiceDiscountService(_companyDataRequestService);
                case SelectiveInvoiceDiscount _:
                    return new SelectInvoiceService.SelectInvoiceService(_companyDataRequestService);
                default:
                    throw new InvalidOperationException();
            }
        }

    }
}
