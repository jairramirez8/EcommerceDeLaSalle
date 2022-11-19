using DeLaSalle.Ecommerce.Coree.Dto;
using DeLaSalle.Ecommerce.Coree.Http;

namespace DeLaSalle.Eccommerce.WebSite.Services.Interfaces;

public interface IProductCategoryService
{
    Task<Response<List<ProductCategoryDto>>> GetAllAsync();
    Task<Response<ProductCategoryDto>> GetById(int d);
    Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto productCategory);
    Task<Response<ProductCategoryDto>> UpdateAsync(ProductCategoryDto productCategory);
    Task<Response<bool>> DeleteAsync(int id);

}