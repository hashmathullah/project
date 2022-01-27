﻿using KPMG.AMRCloud.Services.Scoping.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Domain.AggregateRoots.FundAggregate
{
    public class AssetMngmntAnalysisDetails : EntityBase, IAggregateRoot
    {
        public int AnalysisId { get;  set; }

        public string FundName { get; set; }
    }
}
