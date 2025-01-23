using Microsoft.AspNetCore.Mvc;

namespace Mahta.Utilities.ScalarRegistration.Sample.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private static List<Customer> _customers = new List<Customer>
    {
        new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
        new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" },
        new Customer { Id = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com" }
    };

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    // GET: /customer
    [HttpGet(Name = "GetCustomers")]
    public IEnumerable<Customer> Get()
    {
        return _customers;
    }

    // GET: /customer/{id}
    [HttpGet("{id}", Name = "GetCustomerById")]
    public ActionResult<Customer> GetById(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    // POST: /customer
    [HttpPost(Name = "CreateCustomer")]
    public ActionResult<Customer> Post([FromBody] Customer newCustomer)
    {
        if (_customers.Any(c => c.Email == newCustomer.Email))
            return Conflict("A customer with this email already exists.");

        newCustomer.Id = _customers.Max(c => c.Id) + 1; // Generate new ID based on the max ID in the list
        _customers.Add(newCustomer);
        return CreatedAtRoute("GetCustomerById", new { id = newCustomer.Id }, newCustomer);
    }

    // PUT: /customer/{id}
    [HttpPut("{id}", Name = "UpdateCustomer")]
    public ActionResult Put(int id, [FromBody] Customer updatedCustomer)
    {
        var existingCustomer = _customers.FirstOrDefault(c => c.Id == id);
        if (existingCustomer == null)
            return NotFound();

        existingCustomer.FirstName = updatedCustomer.FirstName;
        existingCustomer.LastName = updatedCustomer.LastName;
        existingCustomer.Email = updatedCustomer.Email;

        return NoContent(); // 204 No Content after update
    }

    // DELETE: /customer/{id}
    [HttpDelete("{id}", Name = "DeleteCustomer")]
    public ActionResult Delete(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
            return NotFound();

        _customers.Remove(customer);
        return NoContent(); // 204 No Content after deletion
    }
}
