using System;

namespace True_Banker
{

    /// <summary>
    /// Interface to store account methods to be used in all class
    /// </summary>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="M"></typeparam>
    interface IAccount<V, M>
        where V : struct
        where M : struct
    {

        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        string GetAccountType(V type);
        /// <summary>
        /// Withdraws the specified w amount.
        /// </summary>
        /// <param name="W_amount">The w amount.</param>
        void Withdraw(decimal W_amount);
        /// <summary>
        /// Deposits the specified d amount.
        /// </summary>
        /// <param name="D_amount">The d amount.</param>
        void Deposit(decimal D_amount);
        /// <summary>
        /// Transfers to.
        /// </summary>
        /// <param name="acc">The acc.</param>
        /// <param name="T_amount">The t amount.</param>
        void TransferTo(Account acc, decimal T_amount);
        /// <summary>
        /// Gets the account balance.
        /// </summary>
        /// <returns></returns>
        decimal getAccountBalance();


    }
}
