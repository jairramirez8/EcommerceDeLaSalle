using DeLaSalle.Eccommerce.WebSite.Services.Interfaces;
using DeLaSalle.Ecommerce.Coree.Dto;
using DeLaSalle.Ecommerce.Coree.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Eccommerce.WebSite.Pages.Brand;

public class Edit : PageModel
{
    [BindProperty] public BrandDto Brand { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    private readonly IBrandService _service;
    
    public Edit(IBrandService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        Brand = new BrandDto();
        
        if (id.HasValue)
        {
            //Obtener informacion del servicio (API)
            var response = await _service.GetById(id.Value);
            Brand = response.Data;
        }

        if (Brand == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<BrandDto> response;
        
        if (Brand.Id > 0)
        {
            //Actualizar
            response = await _service.UpdateAsync(Brand);

        }
        else
        {
            //Insertar
            response = await _service.SaveAsync(Brand);
            
        }

        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        Brand = response.Data;
        return RedirectToPage("./List");
        
    }
}