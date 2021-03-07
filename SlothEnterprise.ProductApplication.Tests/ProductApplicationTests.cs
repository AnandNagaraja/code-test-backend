using FluentAssertions;
using Moq;
using SlothEnterprise.ConfidentialInvoiceDiscountService;
using SlothEnterprise.External;
using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;
using SlothEnterprise.ProductApplication.Factories;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        private IProductApplicationService _sut;
        private readonly Mock<IProductService> _confidentialInvoiceServiceMock = new Mock<IProductService>();
        private readonly ISellerApplication _sellerApplication;
        private readonly Mock<IApplicationResult> _resultMock = new Mock<IApplicationResult>();
        private readonly Mock<IProductServiceFactory> _productServiceFactoryMock = new Mock<IProductServiceFactory>();

        public ProductApplicationTests()
        {
            _resultMock.SetupProperty(p => p.ApplicationId, 1);
            _resultMock.SetupProperty(p => p.Success, true);


            var productApplicationService = new Mock<IProductApplicationService>();
            productApplicationService.Setup(m => m.SubmitApplicationFor(It.IsAny<ISellerApplication>())).Returns(1);

            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, new ConfidentialInvoiceDiscount());
            _sellerApplication = sellerApplicationMock.Object;

            _confidentialInvoiceServiceMock.Setup(c => c.SubmitApplicationFor(_sellerApplication)).Returns(_resultMock.Object);
            _productServiceFactoryMock.Setup(p => p.GetProductService(_sellerApplication)).Returns(_confidentialInvoiceServiceMock.Object);
            _sut = new ProductApplicationService(_productServiceFactoryMock.Object);
        }

        [Fact]
        public void ProductApplicationService_SubmitApplicationFor_WhenCalledWithProduct_ShouldReturnOne()
        {

            var result = _sut.SubmitApplicationFor(_sellerApplication);
            result.Should().Be(1);
        }

        [Fact]
        public void ProductApplicationService_SubmitApplicationFor_WhenApplicationIsNotSuccess_ShouldReturn_MinusOne()
        {
            _resultMock.SetupProperty(p => p.Success, false);
            var result = _sut.SubmitApplicationFor(_sellerApplication);
            result.Should().Be(-1);
        }

        [Fact]
        public void ProductApplicationService_SubmitApplicationFor_WhenApplicationIdIsNull_ShouldReturn_MinusOne()
        {
            _resultMock.SetupProperty(p => p.Success, true);
            _resultMock.SetupProperty(p => p.ApplicationId, null);
            var result = _sut.SubmitApplicationFor(_sellerApplication);
            result.Should().Be(-1);
        }
    }
}