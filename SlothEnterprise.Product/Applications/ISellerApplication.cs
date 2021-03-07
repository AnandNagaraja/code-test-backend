using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.Product.Applications
{
    public interface ISellerApplication
    {
        IProduct Product { get; set; }
        ISellerCompanyData CompanyData { get; set; }
    }
}
