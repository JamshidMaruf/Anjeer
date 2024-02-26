using Anjeer.Interfaces;
using Anjeer.Models;
using Anjeer.Services;

namespace Anjeer.Display;

public class TransactionMenu
{
	private readonly CardService cardService;
	private readonly TransactionService transactionService;
	public TransactionMenu(TransactionService transactionService, CardService cardService)
	{
		this.cardService = cardService;
		this.transactionService = transactionService;
	}

	public void Create()
	{

	}

	public void GetByid()
	{

	}

	public void GetAllByCardId()
	{

	}

	public void GetAllByCustomerId()
	{

	}

	public void GetAllByType()
	{

	}

	public void DisplayChoices()
	{

	}

	public void Display()
	{

	}
}