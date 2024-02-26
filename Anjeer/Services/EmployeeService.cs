using Anjeer.Interfaces;
using Anjeer.Models;

namespace Anjeer.Services;

public class EmployeeService : IEmployeeService
{
	private List<Employee> employees;
	public EmployeeService()
	{
		employees = new List<Employee>();
	}

	public Employee Create(Employee employee)
	{
		employees.Add(employee);
		return employee;
	}

	public bool Delete(int id)
	{
		var existEmployee= employees.FirstOrDefault(employee => employee.Id.Equals(id));
		return employees.Remove(existEmployee);
	}

	public List<Employee> GetAll() => employees;

	public List<Employee> GetAllByPosition(Position position)
	{
		var result = new List<Employee>();

		foreach (var employee in employees)
			if(employee.Position == position)
				result.Add(employee);

		return result;
	}

	public Employee GetById(int id) =>
		employees.FirstOrDefault(employee => employee.Id.Equals(id));

	public Employee GetByPassportNumber(string passportNumber) =>
		employees.FirstOrDefault(employee => employee.PassportNumber.Equals(passportNumber));
	
	public Employee Update(int id, Employee employee)
	{
		var existEmployee = employees.FirstOrDefault(customer => employee.Id.Equals(id));
		if (existEmployee is not null)
		{
			existEmployee.Id = id;
			existEmployee.Position = employee.Position;
			existEmployee.LastName = employee.LastName;
			existEmployee.FirstName = employee.FirstName;
			existEmployee.PassportNumber = employee.PassportNumber;
		}
		return existEmployee;
	}
}
