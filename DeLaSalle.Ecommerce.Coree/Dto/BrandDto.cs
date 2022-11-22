using DeLaSalle.Ecommerce.Coree.Entities;

namespace DeLaSalle.Ecommerce.Coree.Dto;

public class BrandDto : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    public BrandDto()
    {
        
    }

    public BrandDto(Brand brand)
    {
        Id = brand.Id;
        Name = brand.Name;
        Description = brand.Description;
    }
}