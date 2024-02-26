using Anjeer.Interfaces;
using Anjeer.Models;

namespace Anjeer.Services;

public class TransactionService : ITransactionService
{
	private readonly CardService cardService;
	private readonly List<Transaction> transactions;
	public TransactionService(CardService cardService)
	{
		this.cardService = cardService;
		this.transactions = new List<Transaction>();
	}

	public void Create(Transaction transaction)
	{
		var senderCard = cardService.GetByNumber(transaction.SenderCardNumber);
		if (senderCard is null)
			throw new Exception($"This senderCard={transaction.SenderCardNumber} is not found");

        var recieverCard = cardService.GetByNumber(transaction.RecieverCardNumber);
		if (recieverCard is null)
			throw new Exception($"This recieverCard={transaction.RecieverCardNumber} is not found");

		if (senderCard.Password != transaction.SenderPassword)
			throw new Exception("Incorrect password");

		if(senderCard.Balance < transaction.Amount)
			throw new Exception("Balance is not enough");
			
		senderCard.Balance -= transaction.Amount;
		cardService.Update(senderCard.Id, senderCard);

		recieverCard.Balance += transaction.Amount;
		cardService.Update(recieverCard.Id, recieverCard);

		transaction.CreatedAt = DateTime.Now;
		transactions.Add(transaction);
	}

	public Transaction GetById(int id) =>
		transactions.FirstOrDefault(transaction => transaction.Id.Equals(id));

	public List<Transaction> GetAllBySenderCardNumber(string cardNumber)
	{
		var result = new List<Transaction>();

		foreach (var transaction in transactions)
			if (transaction.SenderCardNumber == cardNumber)
				result.Add(transaction);

		return result;
	}

	public List<Transaction> GetAllByRecieverCardNumber(string cardNumber)
	{
		var result = new List<Transaction>();

		foreach (var transaction in transactions)
			if (transaction.RecieverCardNumber == cardNumber)
				result.Add(transaction);

		return result;
	}
}