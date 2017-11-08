
namespace True_Banker
{
    interface IData<A> where A : Account
    {
        /// <summary>
        /// Gets the client accounts.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        A[] getClientAccounts(Client client);


    }
}
