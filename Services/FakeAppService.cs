using DataGetter.Models;
using models;
using System;
using System.Text.Json;

namespace Services;
public class FakeAppService : IFakeAppService
{
    public async Task<List<string>> GetAllProducts()
    {
        List<string> products = new List<string>();
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage ms = await client.GetAsync("https://fakestoreapi.com/products");
            String jsonString = await ms.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(jsonString);
            List<Product> productsList = JsonSerializer.Deserialize<List<Product>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true  });
            products = productsList.Select(x => x.Title).ToList();
        }
        return products;
    }

    public async Task<List<string>> GetCategories()
    {
        List<string> categories = new List<string>();
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage ms = await client.GetAsync("https://fakestoreapi.com/products/categories");
            String jsonString = await ms.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(jsonString);
            categories = JsonSerializer.Deserialize<List<string>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        return categories;
    }

    public async Task<List<string>> GetProductByCategory(string category)
    {
        List<string> res;
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage ms = await client.GetAsync("https://fakestoreapi.com/products");
            String jsonString = await ms.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(jsonString);
            List<Product> productsList = JsonSerializer.Deserialize<List<Product>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            res = productsList.Where(x => x.Category == category).Select(x => x.Title).ToList();
        }
        return res;
    }

    public async Task<string> GetProductByID(int id)
    {
        String res;
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage ms = await client.GetAsync($"https://fakestoreapi.com/products/{id}");
            String jsonString = await ms.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(jsonString);
            Product p = JsonSerializer.Deserialize<Product>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            res = p.Title;
        }
        return res;
    }

    public async Task<List<Cart>> GetCartById(int id)
    {
        List<Cart> res;
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage ms = await client.GetAsync($"https://fakestoreapi.com/carts?userId={id}");
            String jsonString = await ms.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(jsonString);
            res = JsonSerializer.Deserialize<List<Cart>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        return res;
    }

    public async Task<List<Product>> GetProductsByLimit(int limit)
    {
        List<Product> products;
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage ms = await client.GetAsync($"https://fakestoreapi.com/products?limit={limit}");
            String jsonString = await ms.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(jsonString);
            products = JsonSerializer.Deserialize<List<Product>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        return products;
    }

}
