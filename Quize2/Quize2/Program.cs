using Quize2.CardServices;
using Quize2.TransactionServices;
using Quize2.Entites;
using Quize2.PasswordCreator;

CardService _cardService = new CardService();
TransactionService _transactionService = new TransactionService();
PasswordCreator _passCreator = new PasswordCreator();
Card card = null;
int count = 0;
bool login = false;
_passCreator.Passcreate();
while (count < 3)
{
    Console.WriteLine("Please Log In First:");
    Console.Write("Enter Card Number: ");
    var cardNo = Console.ReadLine();

    if (cardNo.Length != 16)
    {
        Console.WriteLine("Card number must be 16 digits!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        continue;
    }

    var exists = _cardService.CardExist(cardNo);
    if (!exists)
    {
        Console.WriteLine("Card not found!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        continue;
    }

    Console.Write("Enter Password: ");
    var password = Console.ReadLine();

    Console.Write("Enter userName: ");
    var userName = Console.ReadLine();

    bool isValidUser = _cardService.UserExist(userName,cardNo, password);
    if (isValidUser == false)
    {
        count++;
        Console.WriteLine($"Incorrect password! Attempts left: {3 - count}");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        if (count >= 3)
        {
            card = _cardService.GetCard(cardNo);
            if (card != null)
            {
                card.IsActive = false;
                _cardService.Update(card.CardNumber);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
        Console.Clear();
        continue;
    }

    card = _cardService.GetCard(cardNo);
    if (card != null && card.IsActive)
    {
        login = true;
    }

    while (login)
    {
        Console.Clear();
        Console.WriteLine("\nBank System Menu:");
        Console.WriteLine("1. Transfer");
        Console.WriteLine("2. Show all Transactions");
        Console.WriteLine("3. Show balance");
        Console.WriteLine("4. Change card password");
        Console.WriteLine("4. Exit");
        Console.Write("Select an option: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                if (!card.IsActive)
                {
                    Console.WriteLine("Your card is deactivated. You cannot perform any transfers.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }

                Console.Write("Enter Destination Card Number: ");
                var cardNo2 = Console.ReadLine();
                if (cardNo2.Length != 16)
                {
                    Console.WriteLine("Card number must be 16 digits!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }

                var cardExist = _cardService.GetCard(cardNo2);
                if (cardExist is null)
                {
                    Console.WriteLine("Destination card not found!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine(cardExist.ToString());
                
                Console.Write("Enter amount: ");
                if (!int.TryParse(Console.ReadLine(), out int amount) || amount <= 0)
                {
                    Console.WriteLine("Invalid input for amount. Please enter a positive number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }

                Console.Write("Enter Temporary password");
                string tPass = Console.ReadLine();
                if (!_transactionService.CheckFilePass(tPass))
                {
                    Console.WriteLine("Temporary password is incorrect!!!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }

                bool transferStatus = _transactionService.Transfer(card.CardNumber, cardNo2, amount);
                if (transferStatus)
                {
                    Console.WriteLine("Transfer completed successfully.");
                }
                else
                {
                    Console.WriteLine("Transfer failed. Please try again.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;

            case "2":
                //Console.Write("Enter your card number: ");
                //var cardNoToCheck = Console.ReadLine();
                //if (!_cardService.CardExist(cardNoToCheck))
                //{
                //    Console.WriteLine("Card not found!");
                //    Console.WriteLine("Press any key to continue...");
                //    Console.ReadKey();
                //    break;
                //}

                var hasTransactions = _transactionService.GetTransactions(card.CardNumber);
                if (!hasTransactions)
                {
                    Console.WriteLine("You don't have any transactions.");
                }
                else
                {
                    Console.WriteLine("Transactions retrieved successfully.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;

            case "3":
                Console.WriteLine($"your balance for Card : {card.CardNumber} -----> {card.Balance}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
                break;

            case "4":
                Console.WriteLine("Enter your old password");
                string oldPass = Console.ReadLine();

                Console.WriteLine("Enter your new password");
                string newPass = Console.ReadLine();
                _cardService.ChangePass(card.CardNumber,oldPass, newPass);
                break;

            case "5":
                login = false;
                Console.WriteLine("Logging out...");
                break;

            default:
                Console.WriteLine("Invalid option. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
        }
    }
}
Console.ReadLine();