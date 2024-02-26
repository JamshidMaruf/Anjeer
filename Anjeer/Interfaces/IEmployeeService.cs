using Anjeer.Models;

namespace Anjeer.Interfaces;

public interface IEmployeeService
{
	Employee Create(Employee employee);
	Employee Update(int id, Employee employee);
	bool Delete(int id);
	Employee GetById(int id);
	Employee GetByPassportNumber(string passportNumber);
	List<Employee> GetAll();
	List<Employee> GetAllByPosition(Position position);
}
