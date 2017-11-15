using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace BankLib
{
    /// <summary>
    /// The base account class
    /// </summary>
    public abstract class Account
    {
        /// <summary>
        /// The account number
        /// </summary>
        protected readonly string accNum;

        protected ObjectId _id;

        /// <summary>
        /// The name of account holder
        /// </summary>
        protected string name;

        /// <summary>
        /// The balance in account
        /// </summary>
        protected int balance;

        /// <summary>
        /// The pin
        /// </summary>
        protected string pin;
        public Account(string name, int balance, string pin, int type)
        {
            if (type == 0)
            {
                accNum = AccountNumberGenerator.GenerateCurrent();
            }
            else
            {
                accNum = AccountNumberGenerator.GenerateSavings();
            }
            this.name = name;
            this.balance = balance;
            this.pin = pin;
        }


        public Account(AccountDoc doc)
        {
            accNum = doc.AccNum;
            name = doc.Name;
            balance = doc.Balance;
            pin = doc.Pin;
            _id = doc._id;
        }


        /// <summary>
        /// Withdraws specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public abstract void WithDraw(int amount);

        public abstract AccountDoc ToAccountDoc();
        


        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public void Deposit(int amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }


        

        public string Name { get { return name; } set { name = value; } }


        public int Balance { get { return balance; } }

        
        public string AccNum { get { return accNum; } }

        public ObjectId Id { get { return _id; } }
        
        public string Pin { get { return pin; } set { pin = value; } }
    }

    /// <summary>
    /// Represents a savings account
    /// </summary>
    /// <seealso cref="BankLib.Account" />
    public class SavingsAccount : Account
    {

        public SavingsAccount(string name, int balance,string pin) : base(name, balance, pin, 1)
        {
            balance += 500;
        }


        public SavingsAccount(AccountDoc doc) : base(doc)
        {

        }

        public override AccountDoc ToAccountDoc()
        {
            return new AccountDoc(this, 1);
        }

        public override void WithDraw(int amount)
        {
            if (amount <= 0)
            {
                throw new OperationException(ErrorMessages.error[0]);
            }
            if ( balance - amount > 500)
            {
                balance -= amount;
            }
            else
            {
                throw new OperationException(ErrorMessages.error[1]);
            }
        }
    }

    /// <summary>
    /// Represents a current account
    /// </summary>
    /// <seealso cref="BankLib.Account" />
    public class CurrentAccount : Account
    {

        public CurrentAccount(string name, int balance, string pin) : base(name, balance, pin, 0)
        {
     
        }


        public CurrentAccount(AccountDoc doc) : base(doc)
        {

        }

        public override AccountDoc ToAccountDoc()
        {
            return new AccountDoc(this, 0);
        }

        public override void WithDraw(int amount)
        {
            if (amount <= 0 ) {
                throw new OperationException(ErrorMessages.error[0]);
            }
            if (balance > amount)
            {
                balance -= amount;
            }
            else
            {
                throw new OperationException(ErrorMessages.error[1]);
            }
           
        }
    }

    /// <summary>
    /// Generates Account numbers
    /// </summary>
    public static class AccountNumberGenerator
    {
        public static string GenerateCurrent()
        {
            DateTime now = DateTime.Now;
            string p1 = now.Year.ToString().Substring(2);
            string p2 = now.Month.ToString();
            string p3 = now.Day.ToString();
            string p4 = now.Hour.ToString();
            string p5 = now.Minute.ToString();
            string p6 = now.Second.ToString();

            return "0" +p1 + p2 + p3 + p4 + p5 + p6;
        }

        public static string GenerateSavings()
        {
            DateTime now = DateTime.Now;
            string p1 = now.Year.ToString().Substring(2);
            string p2 = now.Month.ToString();
            string p3 = now.Day.ToString();
            string p4 = now.Hour.ToString();
            string p5 = now.Minute.ToString();
            string p6 = now.Second.ToString();

            return "1" + p1 + p2 + p3 + p4 + p5 + p6;
        }
    }



    /// <summary>
    /// Defines exceptions during banking operations
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class OperationException : Exception
    {
        public OperationException(string message) : base(message) { }     
    }

    public static class ErrorMessages
    {
        public static string[] error = new string[]
        {
            "Amount cannot be zero or negative",
            "Insufficient balance",
            "Wrong pin"
        };
    }
}
