using DataGetter.Models;
using models;
using System;

namespace Services;
public interface IFakeAppService
{
    Task<List<string>> GetAllProducts();
    Task<string> GetProductByID(int id);
    Task<List<string>> GetCategories();
    Task<List<string>> GetProductByCategory(string category);
    Task<List<Cart>> GetCartById(int id);
    Task<List<Product>> GetProductsByLimit(int limit);
}
