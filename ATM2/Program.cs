using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Show Balance");
            Console.WriteLine("4.Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How mucy ££ would you like to deposit? ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit + currentUser.getBalance());
            Console.WriteLine("Thank you for your ££. Your new balance is: " +currentUser.getBalance());

        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How mucy ££ would you like to withdraw? ");
            double withdraw = double.Parse(Console.ReadLine());
            if (withdraw > currentUser.getBalance())
            {
                Console.WriteLine("Unable to complete transaction due to unsufficient funds. Please try again.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Thank you for your custom. Your new balance is: " + currentUser.getBalance());
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1638267829461526", 7821, "Ken", "Lacks", 19738.73));
        cardHolders.Add(new cardHolder("8273516273092816", 6253, "Wayne", "Dapain", 81.61));
        cardHolders.Add(new cardHolder("1920363537383936", 1001, "Anonymous", "Mystery", 19263748.99));
        cardHolders.Add(new cardHolder("1234567890123456", 1234, "test", "test", 1000));
        cardHolders.Add(new cardHolder("787425678987656", 8465, "Adam", "Map", 7546.88));

        Console.WriteLine("Welcome to simple ATM");
        Console.WriteLine("Please insert your debit card");
        String debitCardNum = "";
        cardHolder currentUser;
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognised. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognised. Please try again.");
            }
        }

        Console.WriteLine("Please enter your pin");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Pin not recognised. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Pin not recognised. Please try again.");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;  
            }
        } while (option!=4);
        Console.WriteLine("Thank you, have a nice day");
    }
}
