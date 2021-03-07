using System.Collections.Generic;
using SlothEnterprise.External;

namespace SlothEnterprise.Product
{
    public class ApplicationResultDTO : IApplicationResult
    {
        public int? ApplicationId { get; set; }
        public bool Success { get; set; }
        public IList<string> Errors { get; set; }
    }
}
