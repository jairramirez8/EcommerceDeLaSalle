using DeLaSalle.Ecommerce.Coree.Entities;

namespace DeLaSalle.Ecommerce.Api.Repositories.Interfaces.Interfaces;

public interface IBrandRepository
{
    Task<Brand> SaveAsync(Brand brand);
    
    Task<Brand> UpdateAsync(Brand brand);

    Task<List<Brand>> GetAllAsync();

    Task<bool> DeleteAsync(int id);

    Task<Brand> GetById(int id);
    
    Task<Brand> GetByName(string name, int id =0);
}