using System.ComponentModel;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Coree.Dto;
using DeLaSalle.Ecommerce.Coree.Entities;
using DeLaSalle.Ecommerce.Coree.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductCategoriesController : ControllerBase
{
    
    private readonly IProductCategoryService _productCategoryService;
    
    
    public ProductCategoriesController(
        IProductCategoryService productCategoryService)
    {

        _productCategoryService = productCategoryService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<ProductCategoryDto>>>> GetAll()
    {
        var response = new Response<List<ProductCategoryDto>>
        {
            Data = await _productCategoryService.GetAllAsync()
        };
        
        return Ok(response);
    }


    [HttpPost]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Post([FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategoryDto>
        {
            Data = await _productCategoryService.SaveAsync(categoryDto)
        };

        return Created($"/api/[controller]/{response.Data.Id}", response);


    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> GetById(int id)
    {
        var response = new Response<ProductCategoryDto>();
        
        
        if (!await _productCategoryService.ProductCategoryExist(id))
        {
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }

        response.Data = await _productCategoryService.GetById(id);
        return Ok(response);


    }

    [HttpPut]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Update([FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategoryDto>();
        
        if (!await _productCategoryService.ProductCategoryExist(categoryDto.Id))
        {
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }

        response.Data = await _productCategoryService.UpdateAsync(categoryDto);

        return Ok(response);
        
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _productCategoryService.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }

}