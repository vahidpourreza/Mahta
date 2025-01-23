using Microsoft.AspNetCore.Mvc;

namespace Mahta.Utilities.ScalarRegistration.Sample.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, InStock = true },
        new Product { Id = 2, Name = "Smartphone", Price = 799.99m, InStock = true },
        new Product { Id = 3, Name = "Tablet", Price = 499.99m, InStock = false }
    };

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    // GET: /product
    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return _products;
    }

    // GET: /product/{id}
    [HttpGet("{id}", Name = "GetProductById")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    // POST: /product
    [HttpPost(Name = "CreateProduct")]
    public ActionResult<Product> Post([FromBody] Product newProduct)
    {
        if (_products.Any(p => p.Name == newProduct.Name))
            return Conflict("A product with this name already exists.");

        newProduct.Id = _products.Max(p => p.Id) + 1; // Generate new ID based on the max ID in the list
        _products.Add(newProduct);
        return CreatedAtRoute("GetProductById", new { id = newProduct.Id }, newProduct);
    }

    // PUT: /product/{id}
    [HttpPut("{id}", Name = "UpdateProduct")]
    public ActionResult Put(int id, [FromBody] Product updatedProduct)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct == null)
            return NotFound();

        existingProduct.Name = updatedProduct.Name;
        existingProduct.Price = updatedProduct.Price;
        existingProduct.InStock = updatedProduct.InStock;

        return NoContent(); // 204 No Content after update
    }

    // DELETE: /product/{id}
    [HttpDelete("{id}", Name = "DeleteProduct")]
    public ActionResult Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        _products.Remove(product);
        return NoContent(); // 204 No Content after deletion
    }
}
