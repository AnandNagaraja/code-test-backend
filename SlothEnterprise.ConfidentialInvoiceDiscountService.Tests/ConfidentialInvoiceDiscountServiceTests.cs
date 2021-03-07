using FluentAssertions;
using Moq;
using SlothEnterprise.External;
using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;
using Xunit;

namespace SlothEnterprise.ConfidentialInvoiceDiscountService.Tests
{
    public class ConfidentialInvoiceDiscountServiceTests
    {
        private readonly IProductService _sut;
        private readonly ISellerApplication _sellerApplication;

        public ConfidentialInvoiceDiscountServiceTests()
        {
            var companyDataRequest = new CompanyDataRequest { CompanyNumber = 150 };
            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, new ConfidentialInvoiceDiscount { TotalLedgerNetworth = 120, VatRate = 2, AdvancePercentage = 75 });
            _sellerApplication = sellerApplicationMock.Object;

            var companyDataRequestServiceMock = new Mock<ICompanyDataRequestService>();
            companyDataRequestServiceMock.Setup(c => c.GetCompanyDataRequestFromApplication(_sellerApplication)).Returns(companyDataRequest);

            _sut = new ConfidentialInvoiceDiscountService(companyDataRequestServiceMock.Object);
        }

        [Fact]
        public void ConfidentialInvoiceDiscountService_SubmitApplicationFor_WhenCalledWithConfidentialInvoiceDiscount_ShouldReturnSuccessApplication()
        {
            var applicationResult = _sut.SubmitApplicationFor(_sellerApplication);

            applicationResult.Should().NotBeNull();
            applicationResult.Should().BeOfType(typeof(ApplicationResultDTO), "because a {0} is returned", typeof(ApplicationResultDTO));

            applicationResult.ApplicationId.Should().Be(1, "because application is success");
            applicationResult.Success.Should().BeTrue("because application is success");

        }
    }
}
