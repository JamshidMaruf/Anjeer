namespace Anjeer.Models;

public class Card
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Password { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Balance { get; set; }
    public int CustomerId { get; set; }
    public CardType Type { get; set; }
}