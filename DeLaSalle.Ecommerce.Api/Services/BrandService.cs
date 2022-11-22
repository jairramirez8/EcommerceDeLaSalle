using DeLaSalle.Ecommerce.Api.Repositories.Interfaces.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Coree.Dto;
using DeLaSalle.Ecommerce.Coree.Entities;

namespace DeLaSalle.Ecommerce.Api.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    
    public async Task<bool> BrandExist(int id)
    {
        var brand = await _brandRepository.GetById(id);
        return (brand != null);
    }

    public async Task<BrandDto> SaveAsync(BrandDto brandDto)
    {
        var brand = new Brand
        {
            Name = brandDto.Name,
            Description = brandDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now

        };
        
        brand = await _brandRepository.SaveAsync(brand);
        brand.Id = brand.Id;

        return brandDto;
    }

    public async Task<BrandDto> UpdateAsync(BrandDto brandDto)
    {
        var brand = await _brandRepository.GetById(brandDto.Id);
        
        if(brand == null)
        
            throw new Exception("Brand Not Found");

        
        brand.Name = brandDto.Name;
        brand.Description = brandDto.Description;
        brand.UpdatedBy = "";
        brand.UpdatedDate = DateTime.Now;
        
        await _brandRepository.UpdateAsync(brand);

        return brandDto;
    }

    public async Task<List<BrandDto>> GetAllAsync()
    {
        var brands = await _brandRepository.GetAllAsync();
        var brandsDto = 
            brands.Select(c => new BrandDto(c)).ToList();
        return brandsDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _brandRepository.DeleteAsync(id);
    }

    public async Task<BrandDto> GetById(int id)
    {
        var brand = await _brandRepository.GetById(id);

        if (brand == null)
            throw new Exception("Brand Not Found");

        var brandDto = new BrandDto(brand);
        return brandDto;
    }
}