using System;
using FluentAssertions;
using Moq;
using SlothEnterprise.External;
using SlothEnterprise.Product;
using SlothEnterprise.Product.Applications;
using Xunit;

namespace SlothEnterprise.BusinessLoansService.Tests
{
    public class BusinessLoansServiceTests
    {
        private readonly IProductService _sut;
        private readonly ISellerApplication _sellerApplication;

        public BusinessLoansServiceTests()
        {
            var companyDataRequest = new CompanyDataRequest { CompanyNumber = 200 };
            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, new BusinessLoans { InterestRatePerAnnum = 10, LoanAmount = 100000 });
            _sellerApplication = sellerApplicationMock.Object;

            var companyDataRequestServiceMock = new Mock<ICompanyDataRequestService>();
            companyDataRequestServiceMock.Setup(c => c.GetCompanyDataRequestFromApplication(_sellerApplication)).Returns(companyDataRequest);

            _sut = new BusinessLoansService(companyDataRequestServiceMock.Object);
        }

        [Fact]
        public void BusinessLoansService_SubmitApplicationFor_WhenCalledWithBusinessLoans_ShouldReturnSuccessApplication()
        {
            var applicationResult = _sut.SubmitApplicationFor(_sellerApplication);

            applicationResult.Should().NotBeNull();
            applicationResult.Should().BeOfType(typeof(ApplicationResultDTO), "because a {0} is returned", typeof(ApplicationResultDTO));

            applicationResult.ApplicationId.Should().Be(1, "because application is success");
            applicationResult.Success.Should().BeTrue("because application is success");

        }
    }
}
