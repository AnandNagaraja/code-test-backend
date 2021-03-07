using System;
using SlothEnterprise.BusinessLoansService;
using SlothEnterprise.ConfidentialInvoiceDiscountService;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;
using SlothEnterprise.ProductApplication.Factories;
//using SlothEnterprise.ProductApplication.Applications;
//using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.SelectInvoiceService;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService : IProductApplicationService
    {

        private readonly IProductServiceFactory _productServiceFactory;

        public ProductApplicationService(IProductServiceFactory productServiceFactory)
        {
            _productServiceFactory = productServiceFactory;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var productService = _productServiceFactory.GetProductService(application);
            var result = productService.SubmitApplicationFor(application);
            return (result.Success) ? result.ApplicationId ?? -1 : -1;

        }




    }
}
