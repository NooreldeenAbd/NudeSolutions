using Dev_Assignment.DAL.Models;
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
        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var response = await _insuranceService.GetInsuredItemsAsyn();
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult> Post(InsuredItem item)
        {
            var response = await _insuranceService.AddInsuredItemAsyn(item);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _insuranceService.DeleteInsuredItemAsyn(id);
            return Ok(response);
        }

    }
}
