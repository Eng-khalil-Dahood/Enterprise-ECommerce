using ECommerce.Application.DTOs;
using ECommerce.Persistence.Data;

namespace ECommerce.Application.Services
{
    public class DashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public DashboardStatsDto GetDashboardStats()
        {
            var stats = new DashboardStatsDto
            {
                TotalSales = _context.Orders.Where(o => o.Status == "Completed").Sum(o => o.TotalAmount),
                TotalOrders = _context.Orders.Count(),
                LowStockProducts = _context.Products.Where(p => p.Stock < 20).Count(),

                // جلب بيانات عشوائية للرسم البياني كمثال
                TopProductNames = _context.Products.Select(p => p.Name).ToList(),
                TopProductSalesCount = new List<int> { 12, 19, 3, 5 }
            };

            return stats;
        }
    }
}