using System;

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
}
