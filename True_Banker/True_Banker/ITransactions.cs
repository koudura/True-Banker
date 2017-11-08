using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace True_Banker
{

    interface ITransactions<V, M>
        where V : struct
        where M : struct
    {

        string getAccountType(V type);
        void WithDraw(decimal W_amount);
        void Deposit(decimal D_amount);
        void TransferTo(Account acc, decimal T_amount);
        decimal getAccountBalance();


    }
}
