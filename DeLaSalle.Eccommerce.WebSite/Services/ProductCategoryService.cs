using DeLaSalle.Eccommerce.WebSite.Services.Interfaces;
using DeLaSalle.Ecommerce.Coree.Dto;
using DeLaSalle.Ecommerce.Coree.Http;
using Newtonsoft.Json;

namespace DeLaSalle.Eccommerce.WebSite.Services;

public class ProductCategoryService : IProductCategoryService
{

    private readonly string _baseURL = "https://localhost:7044/";
    private readonly string _endpoint = "api/productcategories";

    public ProductCategoryService()
    {
        
    }
    
    
    public async Task<Response<List<ProductCategoryDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";

        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<List<ProductCategoryDto>>>(json);

        return response;
    }

    public async Task<Response<ProductCategoryDto>> GetById(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";

        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);

        return response;
    }

    public async Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto productCategory)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(productCategory);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);

        return response;
    
    }

    public async  Task<Response<ProductCategoryDto>> UpdateAsync(ProductCategoryDto productCategory)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(productCategory);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);

        return response;
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        
        var client = new HttpClient();
        var res = await client.DeleteAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<bool>>(json);

        return response;
        
        
    }
}