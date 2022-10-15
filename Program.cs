using System;
using System.Security.AccessControl;
using ATM.Deposit;
using static ATM.Deposit.Deposit;

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
       }

       public static void Main(string[] args)
       {

              try
              {
                     printOptions();
                     Deposit.deposit(1000);
              }
              catch (Exception)
              {
                     Console.Write("An error occurred...");
              }
       }
}
