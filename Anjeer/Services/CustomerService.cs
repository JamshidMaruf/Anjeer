using Anjeer.Interfaces;
using Anjeer.Models;

namespace Anjeer.Services;

public class CustomerService : ICustomerService
{
	private List<Customer> customers;
    public CustomerService()
    {
		customers = new List<Customer>();
    }

    public void Create(Customer customer)
	{
		customers.Add(customer);
	}

	public bool Delete(int id)
	{
		var existCustomer = customers.FirstOrDefault(customer => customer.Id.Equals(id));
		return customers.Remove(existCustomer);
	}

	public List<Customer> GetAll() => customers;
	
	public Customer GetById(int id) =>
		customers.FirstOrDefault(customer => customer.Id.Equals(id));

	public void Update(int id, Customer customer)
	{
		var existCustomer = customers.FirstOrDefault(customer => customer.Id.Equals(id));
		if(existCustomer is not null)
		{
			existCustomer.Id = id;
			existCustomer.Phone = customer.Phone;
			existCustomer.LastName = customer.LastName;
			existCustomer.FirstName = customer.FirstName;
			existCustomer.DateOfBirth = customer.DateOfBirth;
		}
	}
}