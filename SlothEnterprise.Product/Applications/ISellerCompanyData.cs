using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.Product.Applications
{
    public interface ISellerCompanyData
    {
        string Name { get; set; }
        int Number { get; set; }
        string DirectorName { get; set; }
        DateTime Founded { get; set; }
    }
}
