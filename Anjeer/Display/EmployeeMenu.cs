using Anjeer.Models;
using Anjeer.Services;
using System.ComponentModel;

namespace Anjeer.Display;

public class EmployeeMenu
{
	private readonly EmployeeService employeeService;
    public EmployeeMenu(EmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    public void Create()
	{
		var employee = new Employee();

        Console.Write("Enter ID: ");
        employee.Id = int.Parse(Console.ReadLine().Trim());
        
        Console.Write("Enter FirstName: ");
        employee.FirstName = Console.ReadLine().Trim();
        
        Console.Write("Enter LastName: ");
        employee.LastName = Console.ReadLine().Trim();

        Console.Write("Enter Passport number: ");
        employee.PassportNumber = Console.ReadLine().Trim();

        int increment = 1;
		foreach (var item in GetPositions())
            Console.WriteLine($"{increment++}. {item}");
        Console.Write("Enter position: ");
        var position = int.Parse(Console.ReadLine().Trim());

        var resultPosition = position switch
        {
            1 => employee.Position = Position.Cashier,
            2 => employee.Position = Position.Administrator,
            3 => employee.Position = Position.Operator,
            4 => employee.Position = Position.Guard,
            _ => employee.Position = 0
        };

        var createdEmployee = employeeService.Create(employee);
        Console.WriteLine("Successfully created");
        Thread.Sleep(1500);
        Console.WriteLine(
            $"\nID: {createdEmployee.Id}\n" +
            $"FirstName: {createdEmployee.FirstName}\n" +
            $"LastName: {createdEmployee.LastName}\n" +
            $"Passport number: {createdEmployee.PassportNumber}\n" +
            $"Position: {createdEmployee.Position}\n");
        Thread.Sleep(1500);
        Console.Clear();
    }

    public void Update()
	{
        var employee = new Employee();

        Console.Write("Enter ID: ");
        var id = int.Parse(Console.ReadLine().Trim());

        Console.Write("Enter FirstName: ");
        employee.FirstName = Console.ReadLine().Trim();

        Console.Write("Enter LastName: ");
        employee.LastName = Console.ReadLine().Trim();

        Console.Write("Enter Passport number: ");
        employee.PassportNumber = Console.ReadLine().Trim();

        int increment = 1;
        foreach (var item in GetPositions())
            Console.WriteLine($"{increment++}. {item}");
        Console.Write("Enter position: ");
        var position = int.Parse(Console.ReadLine().Trim());

        var resultPosition = position switch
        {
            1 => employee.Position = Position.Cashier,
            2 => employee.Position = Position.Administrator,
            3 => employee.Position = Position.Operator,
            4 => employee.Position = Position.Guard,
            _ => employee.Position = 0
        };

        var updatedEmployee = employeeService.Update(id, employee);
        Console.WriteLine("Successfully updated");
        Thread.Sleep(1500);
        Console.WriteLine(
            $"\nID: {updatedEmployee.Id}\n" +
            $"FirstName: {updatedEmployee.FirstName}\n" +
            $"LastName: {updatedEmployee.LastName}\n" +
            $"Passport number: {updatedEmployee.PassportNumber}\n" +
            $"Position: {updatedEmployee.Position}\n");
        Thread.Sleep(1500);
        Console.Clear();
    }

	public void Delete()
	{
        Console.Write("Enter ID: ");
        var id = int.Parse(Console.ReadLine().Trim());

        if(employeeService.Delete(id))
            Console.WriteLine("Successfully deleted");

        Console.WriteLine("Employee is not found");
    }

    public void GetById()
	{
        Console.Clear();
        Console.Write("Enter ID: ");
        var id = int.Parse(Console.ReadLine().Trim());
        var employee = employeeService.GetById(id);

        Console.WriteLine(
            $"\nID: {employee.Id}\n" +
            $"FirstName: {employee.FirstName}\n" +
            $"LastName: {employee.LastName}\n" +
            $"Passport number: {employee.PassportNumber}\n" +
            $"Position: {employee.Position}\n");
        Thread.Sleep(1500);
    }

	public void GetByPassportNumber()
	{
        Console.Write("Enter passport number: ");
        string passportNumber = Console.ReadLine().Trim();
        var employee = employeeService.GetByPassportNumber(passportNumber);

        Console.WriteLine(
            $"\nID: {employee.Id}\n" +
            $"FirstName: {employee.FirstName}\n" +
            $"LastName: {employee.LastName}\n" +
            $"Passport number: {employee.PassportNumber}\n" +
            $"Position: {employee.Position}\n");
    }

	public void GetAll()
	{

	}

	public void GetAllByPosition()
	{

	}

    public string DisplayChoices()
	{
        Console.WriteLine("----- Employee -----");
        Console.WriteLine("" +
            "1. Create\n" +
            "2. Update\n" +
            "3. Delete\n" +
            "4. GetById\n" +
            "5. GetAll\n" +
            "6. GetAllByPosition\n" +
            "7. GetByPassportNumber\n" +
            "8. Back");
        Console.Write(">>> ");
        var choice = Console.ReadLine().Trim();
        Console.Clear();
        return choice;
    }

	public void Display()
	{
        
        bool circle = true;
        while (circle)
        {
            var choice = DisplayChoices();
            switch (choice)
            {
                case "1":
                    Create();
                    break;
                case "2":
                    Update();
                    break;
                case "3":
                    Delete();
                    break;
                case "4":
                    GetById();
                    break;
                case "5":
                    GetAll();
                    break;
                case "6":
                    GetAllByPosition();
                    break;
                case "7":
                    GetByPassportNumber();
                    break;
                case "8":;
                    circle = false;
                    break;
                default:
                    Console.WriteLine("To'g'ri kirit!!!");
                    Thread.Sleep(1500);
                    DisplayChoices();
                    break;
            }
        }

    }

	private List<string> GetPositions()
	{
        var values = Enum.GetValues(typeof(Position))
                         .Cast<Position>()
                         .ToList();

        var result = new List<string>();
        foreach (var value in values)
            result.Add(GetOperationTypeName(value));
	
		return result;
    }

    private string GetOperationTypeName(Position type)
    {
        var memberInfo = typeof(Position).GetMember(type.ToString());
        if (memberInfo.Length > 0)
        {
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                return ((DescriptionAttribute)attributes[0]).Description;
        }

        return type.ToString();
    }
}