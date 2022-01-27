using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Domain.Contracts
{
    [DataContract]
    public class CreateFundRequest : IRequest<bool>
    {
        [DataMember]
        public string Name { get;  set; }
    }
}
