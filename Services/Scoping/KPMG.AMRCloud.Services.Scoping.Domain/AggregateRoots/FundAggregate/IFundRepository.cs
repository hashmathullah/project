using KPMG.AMRCloud.Services.Scoping.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Domain.AggregateRoots.FundAggregate
{
    public interface IFundRepository : IRepository<AssetMngmntAnalysisDetails>
    {
        AssetMngmntAnalysisDetails Add(AssetMngmntAnalysisDetails dtls);
        AssetMngmntAnalysisDetails Update(AssetMngmntAnalysisDetails buyer);
        
        AssetMngmntAnalysisDetails FindByAnalysisIdAsync(int analysisId);
    }
}
