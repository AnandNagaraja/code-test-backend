using FluentAssertions;
using Moq;
using SlothEnterprise.BusinessLoansService;
using SlothEnterprise.ConfidentialInvoiceDiscountService;
using SlothEnterprise.Product.Applications;
using SlothEnterprise.ProductApplication.Factories;
using SlothEnterprise.SelectInvoiceService;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests.Factories
{
    public class ProductServiceFactoryTests
    {
        private readonly IProductServiceFactory _sut;

        private readonly Mock<ICompanyDataRequestService> _companyDataRequestServiceMock;

        public ProductServiceFactoryTests()
        {
            _companyDataRequestServiceMock = new Mock<ICompanyDataRequestService>();

            _sut = new ProductServiceFactory(_companyDataRequestServiceMock.Object);
        }


        [Fact]
        public void ProductServiceFactory_GetProductService_WhenCalledWithBusinessLoanApplication_ShouldReturnBusinessLoanService()
        {

            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, new BusinessLoans());
            var productService = _sut.GetProductService(sellerApplicationMock.Object);

            productService.Should().BeOfType(typeof(BusinessLoansService.BusinessLoansService), "because a {0} is returned", typeof(BusinessLoansService.BusinessLoansService));
        }

        [Fact]
        public void ProductServiceFactory_GetProductService_WhenCalledWithConfidentialInvoiceDiscountApplication_ShouldReturnConfidentialInvoiceDiscountService()
        {

            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, new ConfidentialInvoiceDiscount());
            var productService = _sut.GetProductService(sellerApplicationMock.Object);

            productService.Should().BeOfType(typeof(ConfidentialInvoiceDiscountService.ConfidentialInvoiceDiscountService), "because a {0} is returned", typeof(ConfidentialInvoiceDiscountService.ConfidentialInvoiceDiscountService));
        }

        [Fact]
        public void ProductServiceFactory_GetProductService_WhenCalledWithSelectiveInvoiceDiscountApplication_ShouldReturnSelectInvoiceService()
        {

            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, new SelectiveInvoiceDiscount());
            var productService = _sut.GetProductService(sellerApplicationMock.Object);

            productService.Should().BeOfType(typeof(SelectInvoiceService.SelectInvoiceService), "because a {0} is returned", typeof(SelectInvoiceService.SelectInvoiceService));
        }



    }
}
