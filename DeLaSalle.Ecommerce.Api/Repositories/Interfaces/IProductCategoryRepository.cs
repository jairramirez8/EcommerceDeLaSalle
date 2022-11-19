using DeLaSalle.Ecommerce.Coree.Entities;

namespace DeLaSalle.Ecommerce.Api.Repositories.Interfaces.Interfaces;

public interface IProductCategoryRepository
{
    
    Task<ProductCategory> SaveAsync(ProductCategory category);
    
    Task<ProductCategory> UpdateAsync(ProductCategory category);

    Task<List<ProductCategory>> GetAllAsync();
    
    Task<bool> DeleteAsync(int id);
    
    Task<ProductCategory> GetById(int id);
}