using Dev_Assignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dev_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly ILogger<InsuranceController> _logger;
        private readonly IInsuranceService _insuranceService;
        public InsuranceController(ILogger<InsuranceController> logger, IInsuranceService insuranceService)
        {
            _logger = logger;
            _insuranceService = insuranceService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public async Task<ActionResult> Get()
        {
            return Ok("Get");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("Post")]
        public async Task<ActionResult> Post()
        {
            return Ok("Post");
        }

    }
}
