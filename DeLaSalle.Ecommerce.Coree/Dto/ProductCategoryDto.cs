using DeLaSalle.Ecommerce.Coree.Entities;

namespace DeLaSalle.Ecommerce.Coree.Dto;

public class ProductCategoryDto : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ProductCategoryDto()
    {
        
    }

    public ProductCategoryDto(ProductCategory category)
    {
        Id = category.Id;
        Name = category.Name;
        Description = category.Description;
    }
}