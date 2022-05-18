
using Microsoft.EntityFrameworkCore;

namespace efcoretest.Models;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAll(int offset, int limit);
    Customer Find(string CustomerID);
    void Add(Customer Customer);
    void Update(Customer Customer);
    void Remove(string CustomerID);
}

public class CustomerRepository : ICustomerRepository
{
    private TestDbContext _context;

    public CustomerRepository(TestDbContext context)
    {
        _context = context;
    }

    public void Add(Customer Customer)
    {
        throw new NotImplementedException();
    }

    public Customer Find(string CustomerID)
    {
        return _context
            .Customers
            .Find(CustomerID);
    }

    public IEnumerable<Customer> GetAll(int offset, int limit)
    {
        return _context
            .Customers
            .OrderBy(c => c.CompanyName)
            .Skip(offset)
            .Take(limit)
            .AsNoTracking()
            .ToList();
    }

    public void Remove(string CustomerID)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer Customer)
    {
        throw new NotImplementedException();
    }
}