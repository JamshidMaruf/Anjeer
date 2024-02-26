using Anjeer.Interfaces;
using Anjeer.Models;

namespace Anjeer.Services;

public class CardService : ICardService
{
	private List<Card> cards;
	public CardService()
	{
		cards = new List<Card>();
	}

	public void Create(Card card)
	{
		cards.Add(card);
	}

	public bool Delete(int id)
	{
		var existCard = cards.FirstOrDefault(card => card.Id.Equals(id));
		return cards.Remove(existCard);
	}

	public List<Card> GetAll() => cards;

	public List<Card> GetAllByType(CardType type)
	{
		var result = new List<Card>();

		foreach (var card in cards)
			if (card.Type == type)
				result.Add(card);

		return result;
	}

	public Card GetByCustomerId(int customerId) =>
		cards.FirstOrDefault(card => card.CustomerId.Equals(customerId));

	public Card GetById(int id) =>
		cards.FirstOrDefault(card => card.Id.Equals(id));

	public Card GetByNumber(string number) =>
		cards.FirstOrDefault(card => card.Number.Equals(number));

	public void Update(int id, Card card)
	{
		var existCard = cards.FirstOrDefault(card => card.Id.Equals(id));
		if (existCard is not null)
		{
			existCard.Id = id;
			existCard.Type = card.Type;
			existCard.Number = card.Number;
			existCard.Balance = card.Balance;
			existCard.Password = card.Password;
			existCard.ExpireDate = card.ExpireDate;
			existCard.CustomerId = card.CustomerId;
		}
	}
}
