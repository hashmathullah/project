using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Domain.Exceptions
{
       public class ScopingDomainException : Exception
    {
        public ScopingDomainException()
        { }

        public ScopingDomainException(string message)
            : base(message)
        { }

        public ScopingDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
