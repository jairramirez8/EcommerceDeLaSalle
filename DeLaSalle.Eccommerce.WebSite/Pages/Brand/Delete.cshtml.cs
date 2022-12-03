using DeLaSalle.Eccommerce.WebSite.Services.Interfaces;
using DeLaSalle.Ecommerce.Coree.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Eccommerce.WebSite.Pages.Brand;

public class Delete : PageModel
{
    [BindProperty] public BrandDto Brand { get; set; }
    //public List<string> Errors { get; set; } = new List<string>();
    private readonly IBrandService _service;

    public Delete(IBrandService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        Brand = new BrandDto();
        //Obtener informacion del servicio (API)
        var response = await _service.GetById(id);
        Brand = response.Data;

        if (Brand == null)
        {
            return RedirectToPage("/Error");
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(Brand.Id);
        
        return RedirectToPage("./List");
        
    }
}