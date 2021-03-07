using System;
using System.Collections.Generic;
using System.Text;
using SlothEnterprise.External;
using SlothEnterprise.Product.Applications;

namespace SlothEnterprise.Product
{
    public interface IProductService
    {
        IApplicationResult SubmitApplicationFor(ISellerApplication application);
    }
}
