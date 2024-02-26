using Anjeer.Models;
using Anjeer.Services;
using System.Globalization;

namespace Anjeer.Display;

public class CustomerMenu
{
	private readonly CustomerService customerService;
    public CustomerMenu(CustomerService customerService)
    {
		this.customerService = customerService;
    }

    public void Create()
	{
		var customer = new Customer();

		Console.Write("Enter ID: ");
		customer.Id = int.Parse(Console.ReadLine());

		Console.Write("Enter FirstName: ");
		customer.FirstName = Console.ReadLine();

		Console.Write("Enter LastName: ");
		customer.LastName = Console.ReadLine();

		Console.Write("Enter Phone: ");
		customer.Phone = Console.ReadLine();

		Console.Write("Enter DateOfBirth (dd/MM/yyyy): ");
		customer.DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "d/MM/yyyy", CultureInfo.CurrentCulture);

		customerService.Create(customer);
	}

	public void Update()
	{
		var customer = new Customer();

		Console.Write("Enter ID: ");
		customer.Id = int.Parse(Console.ReadLine());

		Console.Write("Enter FirstName: ");
		customer.FirstName = Console.ReadLine();

		Console.Write("Enter LastName: ");
		customer.LastName = Console.ReadLine();

		Console.Write("Enter Phone: ");
		customer.Phone = Console.ReadLine();

		Console.Write("Enter DateOfBirth (dd/MM/yyyy): ");
		customer.DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "d/MM/yyyy", CultureInfo.CurrentCulture);

		customerService.Update(customer.Id, customer);
        Console.WriteLine("Updated");
    }

	public void Delete()
	{
		Console.Write("Enter ID: ");
		int id = int.Parse(Console.ReadLine());
		bool result = customerService.Delete(id);
		if(result)
            Console.WriteLine("Deleted");
    }

	public void GetByid()
	{

		Console.Write("Enter ID: ");
		int id = int.Parse(Console.ReadLine());
		var result = customerService.GetById(id);
		Console.WriteLine($"ID: {result.Id}  |  FirstName: {result.FirstName}  |   LastName: {result.LastName}   |  Phone: {result.Phone}   |  Date: {result.DateOfBirth.Year}");
	}

	public void GetAll()
	{
		foreach (var item in customerService.GetAll())
			Console.WriteLine($"ID: {item.Id}  |  FirstName: {item.FirstName}  |   LastName: {item.LastName}   |  Phone: {item.Phone}   |  Date: {item.DateOfBirth.Year}");
	}

	public int DisplayChoices()
	{
		Console.WriteLine("1. Create\n2. Update\n3. Delete\n4. GetById\n5. GetAll\n6. Back");
		Console.Write(">>> ");
		var choice = int.Parse(Console.ReadLine());
		Console.Clear();
		return choice;
	}

	public void Display()
	{
		bool circle = true;
		while (circle)
		{
			int choice = DisplayChoices();
            switch (choice)
			{
				case 1:
					Create();
					break;
				case 2:
					Update();
					break;
				case 3:
					Delete();
					break;
				case 4:
					GetByid();
					break;
				case 5:
					GetAll();
					break;
				case 6:
					DisplayChoices();
					break;
				default:
					Console.WriteLine("Should choose numbers above!");
					System.Threading.Thread.Sleep(1500);
					break;
			}

		}
			
	}
}
