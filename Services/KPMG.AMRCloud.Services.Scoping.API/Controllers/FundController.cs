using KPMG.AMRCloud.Services.Scoping.Domain.AggregateRoots.FundAggregate;
using KPMG.AMRCloud.Services.Scoping.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FundController> _logger;
        public FundController(
            IMediator mediator,
            ILogger<FundController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet]
        public AssetMngmntAnalysisDetails Get()
        {
            var rng = new Random();
            return new AssetMngmntAnalysisDetails
            {
               AnalysisId = rng.Next(),
               FundName = "Test Fund"
            };
        }


        [Route("add")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add([FromBody] CreateFundRequest req)
        {
            _logger.LogInformation( 
                   "Sending request to create fund " + req.Name + "." );
          
            if (!await _mediator.Send(req))
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
