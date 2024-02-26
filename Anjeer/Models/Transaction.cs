namespace Anjeer.Models;

public class Transaction
{
    public int Id { get; set; }
    public string SenderCardNumber { get; set; }
    public string SenderPassword { get; set; }
    public string RecieverCardNumber { get; set; }
	public int EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; }
}