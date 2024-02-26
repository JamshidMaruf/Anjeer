using Anjeer.Services;

namespace Anjeer.Display;

public class MainMenu
{
	// Objects of services
	private readonly CardService cardService;
    private readonly CustomerService customerService;
	private readonly EmployeeService employeeService;
	private readonly TransactionService transactionService;

	// Objects of menues
	private readonly CardMenu cardMenu;
	private readonly EmployeeMenu employeeMenu;
	private readonly CustomerMenu customerMenu;
	private readonly TransactionMenu transactionMenu;

    public MainMenu()
    {
        this.cardService = new CardService();
		this.customerService = new CustomerService();
		this.employeeService = new EmployeeService();
		this.transactionService = new TransactionService(cardService);

		this.cardMenu = new CardMenu(cardService);
		this.customerMenu = new CustomerMenu(customerService);
		this.employeeMenu = new EmployeeMenu(employeeService);
		this.transactionMenu = new TransactionMenu(transactionService, cardService);
    }

	
	public void Display()
	{
		bool circle = true;
		while (circle)
		{
            Console.WriteLine("------- Info -------");
            Console.WriteLine("1. Customers\n2. Employees\n3. Cards\n4. Transactions");
            Console.Write(">>> ");
            int choice = int.Parse(Console.ReadLine());
			Console.Clear();
			switch (choice)
			{
				case 1:
					customerMenu.Display();
					break;
				case 2:
					employeeMenu.Display();
					break;
				case 3:
					cardMenu.Display();
					break;
				case 4:
					transactionMenu.Display();
					break;
				default: 
					Console.WriteLine(""); 
					break;
			}
        }
	}
}
