using INVENTORY.Application.ServiceInterfaces.Authentication;
using INVENTORY.Application.ServiceInterfaces.Sales;
using INVENTORY.Domain.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY.API.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : BaseController
    {
        private readonly ISalesOrderService _iSalesOrderService;
        private readonly ILogger<AccountsController> _logger;
        public SalesOrderController(ISalesOrderService salesOrderService, ILogger<AccountsController> logger)
        {
            _iSalesOrderService= salesOrderService;
            _logger = logger;
        }

        [HttpPost("Create"), ProducesResponseType(StatusCodes.Status204NoContent), ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAsync([FromForm] SalesOrderModel salesOrder)
        {
            var result = await _iSalesOrderService.CreatAsync(salesOrder);
            return Ok();
        }
        [HttpPost("Update"), ProducesResponseType(StatusCodes.Status204NoContent), ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAsync([FromForm] SalesOrderModel salesOrder)
        {
            var result = await _iSalesOrderService.UpdateAsync(salesOrder);
            return Ok();
        }
        [HttpPost("Delete"), ProducesResponseType(StatusCodes.Status204NoContent), ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteAsync([FromForm] int id)
        {
            var result = await _iSalesOrderService.DeleteAsync(id);
            return Ok();
        }
        [HttpPost("Get"), ProducesResponseType(StatusCodes.Status204NoContent), ProducesDefaultResponseType]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _iSalesOrderService.GetAsync();
            return Ok();
        }
        [HttpPost("GetById"), ProducesResponseType(StatusCodes.Status204NoContent), ProducesDefaultResponseType]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _iSalesOrderService.GetByIdAsync(id);
            return Ok();
        }
    }
}
