namespace ECommerce.Application.DTOs
{
    public class DashboardStatsDto
    {
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public int LowStockProducts { get; set; }
        public List<string> TopProductNames { get; set; } = new();
        public List<int> TopProductSalesCount { get; set; } = new();
    }
}