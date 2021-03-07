using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;
using SlothEnterprise.SelectInvoiceService;
using Xunit;


namespace SlothEnterprise.SelectInvoiceService.Tests
{
    public class SelectInvoiceServiceTests
    {
        private readonly IProductService _sut;
        private readonly Mock<ICompanyDataRequestService> _companyDataRequestServiceMock;
        private readonly ISellerApplication _sellerApplication;

        public SelectInvoiceServiceTests()
        {
            var companyDataRequest = new CompanyDataRequest { CompanyNumber = 100 };
            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, new SelectiveInvoiceDiscount { InvoiceAmount = 100, AdvancePercentage = 75 });
            _sellerApplication = sellerApplicationMock.Object;



            _companyDataRequestServiceMock = new Mock<ICompanyDataRequestService>();
            _companyDataRequestServiceMock.Setup(c => c.GetCompanyDataRequestFromApplication(_sellerApplication)).Returns(companyDataRequest);

            _sut = new SelectInvoiceService(_companyDataRequestServiceMock.Object);
        }

        [Fact]
        public void SelectInvoiceService_SubmitApplicationFor_WhenCalledWithSelectiveInvoiceDiscount_ShouldReturnSuccessApplication()
        {
            var applicationResult = _sut.SubmitApplicationFor(_sellerApplication);


            applicationResult.Should().NotBeNull();
            applicationResult.Should().BeOfType(typeof(ApplicationResultDTO), "because a {0} is returned", typeof(ApplicationResultDTO));

            applicationResult.ApplicationId.Should().Be(1, "because application is success");
            applicationResult.Success.Should().BeTrue("because application is success");


        }
    }
}
