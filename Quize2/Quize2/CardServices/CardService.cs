using Quize2.Entites;
using Quize2.Repository;

namespace Quize2.CardServices;

public class CardService
{
    private readonly ICardRepository _cardRepository = new CardRepository();

    public bool UserExist(string userName, string CartNo, string pass)
    {
      var flag =  _cardRepository.LogIn(userName,CartNo, pass);
        if (flag)
        {
            return true;
        }
        return false;
    }
    public bool CardExist(string CartNo)
    {
        var flag = _cardRepository.Check(CartNo);
        if (flag)
        {
            return true;
        }
        return false;
    }
    public Card? GetCard(string cardNo)
    {
        return _cardRepository.GetCardByCardNo(cardNo);
    }
    public void Update(string cardNo)
    {
        _cardRepository.UpdateCardStatus(cardNo);
    }

    public void ChangePass(string cardNo,string oldPass, string newPass)
    {
        if(oldPass == newPass)
        {
            Console.WriteLine("the passwords you enetred is the same!!!");
            return;
        }
        if (!_cardRepository.UpdatePass(cardNo, oldPass, newPass))
        {
            Console.WriteLine("your old password is incorrect!!!");
            return;
        }
        Console.WriteLine("your password changed successfully.");
    }

}
