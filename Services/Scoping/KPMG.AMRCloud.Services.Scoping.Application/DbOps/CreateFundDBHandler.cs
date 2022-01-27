using KPMG.AMRCloud.Services.Scoping.Domain.AggregateRoots.FundAggregate;
using KPMG.AMRCloud.Services.Scoping.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Application.DbOps
{
    public class CreateFundDBHandler : IRequestHandler<CreateFundRequest, bool>
    {
        private readonly IFundRepository _fundRepository;
        private readonly ILogger<CreateFundDBHandler> _logger;

        public CreateFundDBHandler(
          IFundRepository fundRepository, ILogger<CreateFundDBHandler> logger)
        {
            _fundRepository = fundRepository ?? throw new ArgumentNullException(nameof(fundRepository));
        
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateFundRequest req, CancellationToken cancellationToken)
        {
            _fundRepository.Add(new AssetMngmntAnalysisDetails { FundName = req.Name});

            return await _fundRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
