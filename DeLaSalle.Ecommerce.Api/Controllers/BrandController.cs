using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Coree.Dto;
using DeLaSalle.Ecommerce.Coree.Http;
using DeLaSalle.Ecommerce.Coree.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandController : ControllerBase
{

    private readonly IBrandService _brandService;
    
    
    public BrandController(IBrandService brandService)
    {

        _brandService = brandService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<BrandDto>>>> GetAll()
    {
        var response = new Response<List<BrandDto>>
        {
            Data = await _brandService.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Brand>>> Post([FromBody] BrandDto brandDto)
    {
        var response = new Response<BrandDto>
        {
            Data = await _brandService.SaveAsync(brandDto)
        };
        
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }
 //tes
 //Termine practica 4
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<BrandDto>>> GetById(int id)
    {
        
        var response = new Response<BrandDto>();
        
        if (!await _brandService.BrandExist(id))
        {
            response.Errors.Add("Brand Not Found");
            return NotFound(response);
        }

        response.Data = await _brandService.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<BrandDto>>> Update([FromBody] BrandDto brandDto)
    {
        var response = new Response<BrandDto>();
        
        if (!await _brandService.BrandExist(brandDto.Id))
        {
            response.Errors.Add("Brand Not Found");
            return NotFound(response);
        }

        response.Data = await _brandService.UpdateAsync(brandDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _brandService.DeleteAsync(id);
    }
 
}