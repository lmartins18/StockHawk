using Microsoft.AspNetCore.Mvc;
using StockHawk.Service;
using StockHawk.Service.DTOs;

namespace StockHawk.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SummaryController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public SummaryController(IOrderService orderService, IProductService productService, ICategoryService categoryService)
    {
        _orderService = orderService;
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet("dashboard")]
    [ProducesResponseType<SummaryDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDashboardSummary()
    {
        var ordersCount = await _orderService.GetOrderCountAsync();
        var productsCount = await _productService.GetProductCountAsync();
        var categoriesCount = await _categoryService.GetCategoryCountAsync();
        var lowStockProducts = await _productService.GetLowStockProductsAsync();
        var outOfStockProducts = await _productService.GetOutOfStockProductsAsync();
        var totalSales = await _orderService.GetTotalSalesAsync();
        var recentOrders = await _orderService.GetRecentOrdersAsync();

        var summary = new SummaryDto
        {
            TotalOrders = ordersCount,
            TotalProducts = productsCount,
            TotalCategories = categoriesCount,
            LowStockProducts = lowStockProducts,
            OutOfStockProducts = outOfStockProducts,
            TotalSales = totalSales,
            RecentOrders = recentOrders,
        };

        return Ok(summary);
    }
}
