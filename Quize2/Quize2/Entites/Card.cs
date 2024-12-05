using System.ComponentModel.DataAnnotations;

namespace Quize2.Entites;

public class Card
{
    [Key]
    public string CardNumber { get; set; }
    public float Balance { get; set; }
    public bool IsActive { get; set; } = true;
    public string Password { get; set; }
    public float? DailyTransferAmount { get; set; } = 0;
    public DateTime? TodayTransaction { get; set; }
    public virtual List<Transaction> SourceCards { get; set; }
    public virtual List<Transaction> DestinationCards { get; set; }
    public User User { get; set; }
    public string HolderName { get; set; }

    public override string ToString()
    {
        return $"CardNo = {CardNumber}\nHolderName = {HolderName}";
    }
}
