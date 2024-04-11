using DotLiveDesignPatterns.Core.Entities;

namespace DotLiveDesignPatterns.Core.Repositories;

public interface ICustomerRepository
{
    List<Customer> GetBlockedCustomers();
    Customer GetCustomerById(Guid id);
}