using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces.Interfaces;
using DeLaSalle.Ecommerce.Coree.Http;
using DeLaSalle.Ecommerce.Coree.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandController : ControllerBase
{
    private readonly IBrandRepository _brandRepository;
    
    
    public BrandController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Brand>>>> GetAll()
    {
        var brands = await _brandRepository.GetAllAsync();
        var response = new Response<List<Brand>>();
        response.Data = brands;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Brand>>> Post([FromBody] Brand brand)
    {
        brand = await _brandRepository.SaveAsync(brand);
        
        var response = new Response<Brand>();
        response.Data = brand;
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Brand>>> GetById(int id)
    {
        var brand = await _brandRepository.GetById(id);
        var response = new Response<Brand>();
        response.Data = brand;

        if (brand == null)
        {
            response.Errors.Add("Product brand Not Found");
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Brand>>> Update([FromBody] Brand brand)
    {
        var result = await _brandRepository.UpdateAsync(brand);
        var response = new Response<Brand> { Data = result };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _brandRepository.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
 
}