using System.ComponentModel.DataAnnotations;

namespace Quize2.Entites;

public class User
{
    public string UserName { get; set; }
    public string Password  { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public List<Card> Cards { get; set; }
}
