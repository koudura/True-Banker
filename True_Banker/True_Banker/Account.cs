
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// The True_Banker namespace.
/// </summary>
namespace True_Banker
{
    /// <summary>
    /// Abstract Class Account: which controls the major operations of other Account types.
    /// </summary>
    /// <seealso cref="True_Banker.IAccount{AccountVersion, Operation}" />
    /// <seealso cref="True_Banker.IAccount{AccountVersion,Operation}" />
    [Serializable]
    abstract class Account : IAccount<AccountVersion, Operation>
    {
        /// <summary>
        /// The Account balance
        /// </summary>
        protected decimal acc_Balance;
        private readonly Client AccHolder;

        /// <summary>
        /// The account number initialization
        /// </summary>
        private readonly AccountNumber accNum;
        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>The account balance.</value>
        public virtual decimal Balance { get { return this.acc_Balance; } protected set { this.acc_Balance = value; } }

        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public virtual AccountNumber AccountNumber { get { return this.accNum; } }



        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        protected Account(AccountVersion version, Client holder)
        {
            this.acc_Balance = 0;
            AccHolder = holder;
            this.accNum = _init_AccountNumber(version);
        }

        /// <summary>
        /// Initializes the account number.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        protected AccountNumber _init_AccountNumber(AccountVersion version)
        {
            AccountNumber acc = new AccountNumber(version, AccHolder.ClientID);

            return acc;
        }

        /// <summary>
        /// Withdraws the specified positive w amount.
        /// </summary>
        /// <param name="W_amount">The w amount.</param>
        public void Withdraw(decimal W_amount)
        {
            if (this.acc_Balance <= 0)
            {
                new Logger().LogException("Withdrawal from an empty Account balance.", LogExceptionType.Empty);
            }
            else if (this.acc_Balance < W_amount)
            {
                new Logger().LogException("Withdrawal beyond Bound of Funds.", LogExceptionType.Bounds);
            }
            else if (W_amount < 0)
            {
                new Logger().LogException("Illegal Argument has been passed into the System.", LogExceptionType.Illegal);
            }
            else { this.acc_Balance -= W_amount; }
            Console.WriteLine(acc_Balance);
        }

        /// <summary>
        /// Deposits the specified positive d amount.
        /// </summary>
        /// <param name="D_amount">The d amount.</param>
        public void Deposit(decimal D_amount)
        {
            if (D_amount < 0)
            {
                new Logger().LogException("Illegal Argument has been passed into the System.", LogExceptionType.Illegal);
            }
            else { this.acc_Balance += D_amount; }
        }

        /// <summary>
        /// Gets the account balance.
        /// </summary>
        /// <returns>System.Decimal.</returns>
        public abstract decimal getAccountBalance();
        /// <summary>
        /// Transfers a t amount of money to specified exixting Account
        /// </summary>
        /// <param name="acc">The acc.</param>
        /// <param name="T_amount">The t amount.</param>
        public void TransferTo(Account acc, decimal T_amount) { }

        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns>System.String.</returns>
        public string GetAccountType(AccountVersion version)
        {
            return version.ToString();
        }


    }



    /// <summary>
    /// Current Account class of type 'current'
    /// </summary>
    /// <seealso cref="True_Banker.Account" />
    [Serializable]
    sealed class Current : Account
    {
        /// <summary>
        /// The account balance for Current Account
        /// </summary>
        private decimal balance;
        /// <summary>
        /// The client to be registered
        /// </summary>
        Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Current" /> class.
        /// </summary>
        /// <param name="_client">The client.</param>
        public Current(Client _client)
            : base(AccountVersion.Current, _client)
        {
            this.balance = acc_Balance;
            this.client = _client;
        }
        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public override AccountNumber AccountNumber { get { return base.AccountNumber; } }
        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>The account balance.</value>
        public override decimal Balance {
            get { return base.Balance; }
            protected set { base.Balance = value; }
        }


        /// <summary>
        /// Withdraws the specified non-negative w amount.
        /// </summary>
        /// <param name="W_amount">The w amount.</param>
        public new void Withdraw(decimal W_amount)
        {
            base.Withdraw(W_amount);
        }
        /// <summary>
        /// Deposits the specified non-negative d amount.
        /// </summary>
        /// <param name="D_amount">The d amount.</param>
        public new void Deposit(decimal D_amount)
        {
            base.Deposit(D_amount);
        }
        /// <summary>
        /// Transfers a t amount of money to specified exixting Account
        /// </summary>
        /// <param name="acc">The acc.</param>
        /// <param name="T_amount">The t amount.</param>

        public new void TransferTo(Account acc, decimal T_amount)
        {


        }

        /// <summary>
        /// Gets the account balance.
        /// </summary>
        /// <returns>System.Decimal.</returns>
        public override decimal getAccountBalance()
        {
            return base.acc_Balance;
        }

    }

    /// <summary>
    /// Savings Account type for short-term savings -Account
    /// </summary>
    /// <seealso cref="True_Banker.Account" />
    [Serializable]
    sealed class Savings : Account
    {

        private decimal balance;

        /// <summary>
        /// The client  to be registered
        /// </summary>
        Client client;


        /// <summary>
        /// Initializes a new instance of the <see cref="Savings" /> class.
        /// </summary>
        /// <param name="_client">The client.</param>
        public Savings(Client _client)
            : base(AccountVersion.Saving, _client)
        {
            this.balance = acc_Balance;
            this.client = _client;
        }

        //This works in VS2017.
        //public override AccountNumber AccountNumber => base.AccountNumber;
        //public override decimal Balance => base.Balance;

        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public override AccountNumber AccountNumber { get { return base.AccountNumber; } }
        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>The account balance.</value>
        public override decimal Balance {
            get { return base.Balance; }
            protected set { base.Balance = value; }
        }

        /// <summary>
        /// Withdraws the specified positive w amount.
        /// </summary>
        /// <param name="W_amount">The w amount.</param>
        public new void Withdraw(decimal W_amount)
        {
            base.Withdraw(W_amount);
        }

        /// <summary>
        /// Deposits the specified positive d amount.
        /// </summary>
        /// <param name="D_amount">The d amount.</param>
        public new void Deposit(decimal D_amount)
        {
            base.Deposit(D_amount);
        }

        /// <summary>
        /// Transfers a t amount of money to specified exixting Account
        /// </summary>
        /// <param name="acc">The acc.</param>
        /// <param name="T_amount">The t amount.</param>
        public new void TransferTo(Account acc, decimal T_amount) { }

        /// <summary>
        /// Gets the account balance.
        /// </summary>
        /// <returns>System.Decimal.</returns>
        public override decimal getAccountBalance()
        {
            return balance;
        }

    }

    /// <summary>
    /// Sealedor Domiciliary account for long-term saving -Account
    /// </summary>
    /// <seealso cref="True_Banker.Account" />
    [Serializable]
    sealed class Sealed : Account
    {

        private decimal balance;
        /// <summary>
        /// The client to be registered
        /// </summary>
        Client client;


        /// <summary>
        /// Initializes a new instance of the <see cref="Sealed" /> class.
        /// </summary>
        /// <param name="_client">The client.</param>
        public Sealed(Client _client)
            : base(AccountVersion.Sealed, _client)
        {
            this.balance = acc_Balance;
            this.client = _client;
        }

        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public override AccountNumber AccountNumber { get { return base.AccountNumber; } }
        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>The account balance.</value>
        public override decimal Balance {
            get { return base.Balance; }
            protected set { base.Balance = value; }
        }

        /// <summary>
        /// Withdraws the specified w amount.
        /// </summary>
        /// <param name="W_amount">The w amount.</param>
        public new void Withdraw(decimal W_amount)
        {
            base.Withdraw(W_amount);
        }

        /// <summary>
        /// Deposits the specified d amount.
        /// </summary>
        /// <param name="D_amount">The d amount.</param>
        public new void Deposit(decimal D_amount)
        {
            base.Deposit(D_amount);
        }

        /// <summary>
        /// Transfers a t amount of money to specified exixting Account
        /// </summary>
        /// <param name="acc">The acc.</param>
        /// <param name="T_amount">The t amount.</param>
        public new void TransferTo(Account acc, decimal T_amount) { }

        /// <summary>
        /// Gets the account balance.
        /// </summary>
        /// <returns>System.Decimal.</returns>
        public override decimal getAccountBalance()
        {
            return balance;
        }
    }


    /// <summary>
    /// struct to hold the Account number
    /// </summary>
    /// <seealso cref="System.Runtime.Serialization.ISerializable" />
    [Serializable]
    struct AccountNumber : ISerializable
    {
        private string acc_Number;
        private const int bankNo = 024;
        private string CID;
        //   private readonly Int64 accountNumber;

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            string keyID = "ACN" + CID;
            info.AddValue(keyID, encrypt(acc_Number));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountNumber" /> struct.
        /// </summary>
        /// <param name="version">The version of account.</param>
        /// <param name="CID">The cid.</param>
        public AccountNumber(AccountVersion version, string CID)
        {
            acc_Number = CID;
            this.CID = CID;
        }

        //public AccountNumber(SerializationInfo info, StreamingContext context)
        //{
        //    ///    string keyid = "ACN" + this.CID;
        //    //  this.acc_Number = (String)info.GetValue()
        //    // this.CID = 
        //}

        /// <summary>
        /// Encrypts the Account number
        /// </summary>
        /// <param name="ACN">The acn.</param>
        /// <returns>"ACN"</returns>
        public string encrypt(string ACN)
        {


            return ACN;
        }
    }
}
