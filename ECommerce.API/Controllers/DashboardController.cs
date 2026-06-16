using Microsoft.AspNetCore.Mvc;
using ECommerce.Persistence.Services;
namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var data = _dashboardService.GetDashboardStats();
            return Ok(data);
        }
    }
}