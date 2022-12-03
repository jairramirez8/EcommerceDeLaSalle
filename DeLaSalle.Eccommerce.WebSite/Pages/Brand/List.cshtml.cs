using DeLaSalle.Eccommerce.WebSite.Services.Interfaces;
using DeLaSalle.Ecommerce.Coree.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Eccommerce.WebSite.Pages.Brand;

public class ListModel : PageModel
{
    private readonly IBrandService _service;
    public List<BrandDto> Brands { get; set; }

    public ListModel(IBrandService service)
    {
        Brands = new List<BrandDto>();
        _service = service;
    }
    
    public async Task<IActionResult> OnGet()
    {
        //Llamada al servicio
        var response = await _service.GetAllAsync();
        Brands = response.Data;

        return Page();
        
    }
}