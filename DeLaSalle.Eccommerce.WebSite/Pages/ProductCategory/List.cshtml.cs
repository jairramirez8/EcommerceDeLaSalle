using DeLaSalle.Eccommerce.WebSite.Services.Interfaces;
using DeLaSalle.Ecommerce.Coree.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Eccommerce.WebSite.Pages.ProductCategory;

public class ListModel : PageModel
{
    private readonly IProductCategoryService _service;
    public List<ProductCategoryDto> ProductCategories { get; set; }

    public ListModel(IProductCategoryService service)
    {
        ProductCategories = new List<ProductCategoryDto>();
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        //Llamada al servicio
        var response = await _service.GetAllAsync();
        ProductCategories = response.Data;

        return Page();
        
    }
}