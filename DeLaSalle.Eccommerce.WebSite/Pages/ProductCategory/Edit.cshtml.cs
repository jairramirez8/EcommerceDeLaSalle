using DeLaSalle.Eccommerce.WebSite.Services.Interfaces;
using DeLaSalle.Ecommerce.Coree.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Eccommerce.WebSite.Pages.ProductCategory;

public class Edit : PageModel
{
    [BindProperty] public ProductCategoryDto ProductCategoryDto { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    private readonly IProductCategoryService _service;
    
    
    
    public Edit(IProductCategoryService service)
    {
        ProductCategoryDto = new ProductCategoryDto();
        _service = service;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        ProductCategoryDto = new ProductCategoryDto();
        
        if (id.HasValue)
        {
            //Obtener informacion del servicio (API)
            var response = await _service.GetById(id.Value);
            ProductCategoryDto = response.Data;
        }

        if (ProductCategoryDto == null)
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
        
        var name = ProductCategoryDto.Name;
        var description = ProductCategoryDto.Description;
/*
        if (ProductCategoryDto.Id > 0)
        {
            //Actualizar
            response = await _service.UpdateAsync(ProductCategoryDto);

        }
        else
        {
            //Insertar
            response = await _service.UpdateAsync(ProductCategoryDto);
            
        }

        ProductCategoryDto = response.Data;
        */
        return RedirectToPage("./List");
        
    }
}