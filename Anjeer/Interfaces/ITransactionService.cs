using Anjeer.Models;

namespace Anjeer.Interfaces;

public interface ITransactionService
{
	void Create(Transaction transaction);
	Transaction GetById(int id);
	List<Transaction> GetAllBySenderCardNumber(string cardNumber);
	List<Transaction> GetAllByRecieverCardNumber(string cardNumber);
}