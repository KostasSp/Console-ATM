using System;
using System.Security.AccessControl;

namespace BankAccount;
public class CardHolder
{
       string cardNum;
       int pin;
       string firstName;
       string lastName;
       double balance;

       public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
       {
              this.cardNum = cardNum;
              this.pin = pin;
              this.firstName = firstName;
              this.lastName = lastName;
              this.balance = balance;
       }

       public string getNum()
       {
              return cardNum;
       }

       public string getFirstName()
       {
              return firstName;
       }

       public string getLastName()
       {
              return lastName;
       }

       public double getBalance()
       {
              return balance;
       }

       public void setNum(string num)
       {
              cardNum = num;
       }

       public void setPin(int newPin)
       {
              pin = newPin;
       }

       public void setFirstName(string fname)
       {
              firstName = fname;
       }

       public void setLastName(string lname)
       {
              lastName = lname;
       }

       public void setBalance(double newBalance)
       {
              balance = newBalance;
       }

       static void printOptions()
       {
              Console.WriteLine("Choose an action");
              Console.WriteLine("1. Deposit");
              Console.WriteLine("2. Withdraw");
              Console.WriteLine("3. Show Balance");
              Console.WriteLine("4. Exit");
              // char choice = new char();
              int choice = Int32.Parse(Console.ReadLine());
              // byte[] choice = Byte.Parse();
              if (choice != 4)
              {
                     Console.WriteLine("hey");
              }
       }

       //passing the cardholder as param here is useless, as it is within scope - leave it for practice
       void deposit(CardHolder currUser)
       {
              Console.WriteLine("How much do you want to deposit?");
              try
              {
                     double depAmount = Double.Parse(Console.ReadLine());
                     currUser.setBalance(currUser.getBalance() + depAmount);
                     Console.WriteLine("Transaction complete. New Balance: " + currUser.getBalance());
              }
              catch (Exception ex)
              {
                     Console.Write($"An error occurred -> {ex.Message}");
              }
       }

       void withdraw(CardHolder currUser)
       {
              Console.WriteLine("How much do you want to deposit?");
              try
              {
                     double withdrawAmount = Double.Parse(Console.ReadLine());
                     if (withdrawAmount < currUser.getBalance())
                     {
                            currUser.setBalance(currUser.getBalance() - withdrawAmount);
                     }
                     else
                     {
                            Console.WriteLine("You cannot withdraw more than your current balance");
                     }

                     Console.WriteLine("Transaction complete. New Balance: " + currUser.getBalance());
              }
              catch (Exception ex)
              {
                     Console.Write($"An error occurred -> {ex.Message}");
              }
       }

       void getCurrentBalance(CardHolder currUser)
       {
              Console.WriteLine("Your current balance is: " + currUser.getBalance());
       }

       public static void Main(string[] args)
       {
              printOptions();
              // Deposit.deposit(1000); 
       }
}
