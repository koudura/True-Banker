using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Enumerator holder for Opertions
/// </summary>
enum Operation : int { WithDraw, Deposit, Payment, Transfer, Create, Register, Delete, Upgrade, RollBack, Edit, Login, Logout }
/// <summary>
/// Enumartoe holder for Account rights
/// </summary>
enum Rights { Client, Admin }
/// <summary>
/// Enumerator holder for Account Type
/// </summary>
enum AccountVersion { Current, Saving, Sealed }
/// <summary>
/// Enumerator holder for the Gender personality of the new Client
/// </summary>
enum Gender : int { Female = 0, Male = 1 }

namespace True_Banker
{
    partial class DataBank<A> : IData<A>
        where A : Account
    {

        private A accountType;
        private Client clientInfo;
        private static readonly string PATH = "Data_Bank/TBank.truedb";
        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        public A AccountType { get { return this.accountType; } }
        /// <summary>
        /// Gets the client information.
        /// </summary>
        /// <value>
        /// The client information.
        /// </value>
        public Client ClientInfo { get { return this.clientInfo; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBank{A}"/> class.
        /// </summary>
        /// <param name="_clientInfo">The client information.</param>
        /// <param name="_accountType">Type of the account.</param>
        public DataBank(Client _clientInfo, A _accountType)
        {
            this.accountType = _accountType;
            this.clientInfo = _clientInfo;
        }
        public void registerClient()
        {

            BackUpData(this);
        }

        /// <summary>
        /// Gets the client accounts.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        public A[] getClientAccounts(Client client)
        {
            List<A> accs = new List<A>();


            A[] acounts = accs.ToArray();
            return acounts;
        }
    }

    /// <summary>
    /// Databank class for storing data of each customer
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <seealso cref="True_Banker.IData{A}" />
    [Serializable]
    partial class DataBank<A>
    {
        /// <summary>
        /// The temporary data
        /// </summary>
        private static IDictionary<Client, A> tempData = new Dictionary<Client, A>();
        /// <summary>
        /// Gets the data store.
        /// </summary>
        /// <value>
        /// The data store.
        /// </value>
        public static IDictionary<Client, A> DataStore {
            get { return tempData; }
            private set { tempData = value; }
        }
        /// <summary>
        /// Backs up data.
        /// </summary>
        /// <param name="databank">The databank.</param>
        public void BackUpData(DataBank<A> databank)
        {
            Stream stream = new FileStream(PATH, FileMode.Append, FileAccess.Write);
            File.SetAttributes(PATH, FileAttributes.Normal);

            IFormatter format = new BinaryFormatter();
            format.Serialize(stream, databank);
            File.SetAttributes(PATH, FileAttributes.ReadOnly);
            File.SetAttributes(PATH, FileAttributes.Hidden);
            stream.Close();
        }


    }
}
