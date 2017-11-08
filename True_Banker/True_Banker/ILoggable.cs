using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace True_Banker
{
    interface ILoggable<T> where T : Logger
    {
        void createLogFile(ref string message);
    }
}
