using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Dynamic;

//https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop
//ideas for inherited classes, credit card, savings account card etc
namespace BankAccount;
public class CardHolder
{
       public int Pin { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public double Balance { get; set; }
       public bool loggedIn { get; set; }

       public CardHolder(int pinNum, string fName, string lName, double currBalance)
       {
              //ideas for inherited classes, credit card, savings account card etc
              this.Pin = pinNum;
              this.FirstName = fName;
              this.LastName = lName;
              this.Balance = currBalance;
       }


       static void printOptions()
       {
              Console.WriteLine("Choose an action");
              Console.WriteLine("1. Deposit");
              Console.WriteLine("2. Withdraw");
              Console.WriteLine("3. Show Balance");
              Console.WriteLine("4. Exit");
       }

       //passing the cardholder as param here is useless, as it is within scope - leave it for practice
       static void deposit(CardHolder currUser)
       {
              Console.WriteLine("How much do you want to deposit?");
              // Console.WriteLine(currUser.firstName);
              // currUser.firstName = "noob";
              // Console.WriteLine(currUser.firstName);
              try
              {
                     double depAmount = Double.Parse(Console.ReadLine());
                     currUser.Balance += depAmount;
                     Console.WriteLine("Transaction complete. New Balance: " + currUser.Balance);
              }
              catch (Exception ex)
              {
                     Console.Write($"An error occurred -> {ex.Message}");
              }
       }

       static void withdraw(CardHolder currUser)
       {
              Console.WriteLine("How much do you want to withdraw?");
              try
              {
                     //need to add ref or out or smth to this, doesnt update the actual value between actions
                     double withdrawAmount = Double.Parse(Console.ReadLine());
                     if (withdrawAmount < currUser.Balance)
                     {
                            currUser.Balance -= withdrawAmount;

                     }
                     else
                     {
                            Console.WriteLine("You cannot withdraw more than your current balance");
                     }

                     Console.WriteLine("Transaction complete. New Balance: " + currUser.Balance);

              }
              catch (Exception ex)
              {
                     Console.Write($"An error occurred -> {ex.Message}");
              }

       }

       static void showBalance(CardHolder currUser)
       {
              Console.WriteLine("Your current balance is: " + currUser.Balance);
       }

       static CardHolder findAccount(List<CardHolder> cardHolders1)
       {

              Console.Write("Please enter your PIN: ");
              string customerPin = Console.ReadLine();
              //could have just made pin "string" from the start, just testing stuff
              int pin = int.Parse(customerPin);
              if (!int.TryParse(customerPin, out pin))
              {
                     Console.WriteLine("Invalid input");
                     // return false;
              }
              CardHolder currentCustomer = cardHolders1.FirstOrDefault(a => a.Pin == pin);
              if (currentCustomer != null) { Console.WriteLine("Pin correct!"); currentCustomer.loggedIn = true; } else { Console.WriteLine("Incorrect pin"); }
              Console.WriteLine(currentCustomer);
              // if (currentCustomer != null) outcome = true;


              return currentCustomer;

       }


       public static void Main(string[] args)
       {
              int choice;
              CardHolder currentAccount;
              bool pinCorrect = false;

              printOptions();
              // Deposit.deposit(1000); 
              List<CardHolder> cardHolders = new List<CardHolder>();
              // CardHolder testholder = new CardHolder("12193841984", 5678, "Stan", "Edgar", 150.22);
              cardHolders.Add(new CardHolder(5671, "Stan", "Edgar", 154240.22));
              cardHolders.Add(new CardHolder(5672, "John", "Homelander", 152279.34));
              cardHolders.Add(new CardHolder(5673, "Billy", "Butcher", 1500.72));
              cardHolders.Add(new CardHolder(5674, "Hughie", "Campbell", 170.80));
              cardHolders.Add(new CardHolder(5675, "Mother's", "Milk", 15000.00));
              //ask for pin until a correct one is given
              do
              {
                     Console.Write("Choose an action: ");
                     choice = Int32.Parse(Console.ReadLine());
                     if (choice == 4) break;
                     currentAccount = findAccount(cardHolders);
                     if (currentAccount.loggedIn == false && choice != 4) currentAccount = findAccount(cardHolders);
                     if (choice == 1) deposit(currentAccount);
                     if (choice == 2) withdraw(currentAccount);
                     if (choice == 3) showBalance(currentAccount);


                     // checkPin("5677", cardHolders);}


              } while (choice > 0 && choice < 4);
              Console.WriteLine("Goodbye!");


       }
}
