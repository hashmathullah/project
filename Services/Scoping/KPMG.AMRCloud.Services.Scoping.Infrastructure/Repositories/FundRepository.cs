using KPMG.AMRCloud.Services.Scoping.Domain.AggregateRoots.FundAggregate;
using KPMG.AMRCloud.Services.Scoping.Domain.Common;
using KPMG.AMRCloud.Services.Scoping.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Infrastructure.Repositories
{
    public class FundRepository
         : IFundRepository
    {
        private readonly ScopingContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public FundRepository(ScopingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public AssetMngmntAnalysisDetails Add(AssetMngmntAnalysisDetails details)
        {
           
                return _context.FundDetails
                    .Add(details)
                    .Entity;
           
        }

        public AssetMngmntAnalysisDetails Update(AssetMngmntAnalysisDetails dtl)
        {
            return _context.FundDetails
                    .Update(dtl)
                    .Entity;
        }

  
        public  AssetMngmntAnalysisDetails FindByAnalysisIdAsync(int analysisId)
        {
            return _context.FundDetails.FirstOrDefault(b => b.AnalysisId == analysisId);
        }
    }
}
