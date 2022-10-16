using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace BankAccount;
public class CardHolder
{
       int pin;
       string firstName;
       string lastName;
       double balance;

       public CardHolder(int pin, string firstName, string lastName, double balance)
       {
              this.pin = pin;
              this.firstName = firstName;
              this.lastName = lastName;
              this.balance = balance;
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

              // byte[] choice = Byte.Parse();
       }

       //passing the cardholder as param here is useless, as it is within scope - leave it for practice
       static void deposit(CardHolder currUser)
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

       static void withdraw(CardHolder currUser)
       {
              Console.WriteLine("How much do you want to withdraw?");
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

       static void showBalance(CardHolder currUser)
       {
              Console.WriteLine("Your current balance is: " + currUser.getBalance());
       }

       static CardHolder findAccount(List<CardHolder> cardHolders1)
       {
              bool outcome = false;
              Console.Write("Please enter your PIN: ");
              string customerPin = Console.ReadLine();
              //could have just made pin "string" from the start, just testing stuff
              int pin = int.Parse(customerPin);
              if (!int.TryParse(customerPin, out pin))
              {
                     Console.WriteLine("Invalid input");
                     // return false;
              }
              CardHolder currentCustomer = cardHolders1.FirstOrDefault(a => a.pin == pin);
              Console.WriteLine(currentCustomer);
              // if (currentCustomer != null) outcome = true;


              return currentCustomer;

       }


       public static void Main(string[] args)
       {
              int choice;
              CardHolder currentAccount;
              bool pinCorrect = false;
              do
              {
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
                     Console.Write("Choose an action: ");
                     choice = Int32.Parse(Console.ReadLine());
                     currentAccount = findAccount(cardHolders);
                     if (pinCorrect == false && choice != 4) currentAccount = findAccount(cardHolders);
                     if (choice == 1) deposit(currentAccount);
                     if (choice == 2) withdraw(currentAccount);
                     if (choice == 3) showBalance(currentAccount);

                     // checkPin("5677", cardHolders);}


              } while (choice > 0 && choice < 4);
              Console.WriteLine("Goodbye");
       }
}
