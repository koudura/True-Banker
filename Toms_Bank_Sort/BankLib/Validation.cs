using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    /// <summary>
    /// Class for input validation
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Checks whether the supplied string is a valid amount or account number.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns></returns>
        public static bool ValidAccountNumOrAmt(string s)
        {
            if (s == null)
                return false;
            long num = 0;
            long.TryParse(s, out num);
            return num <= 0 ? false : true;
        }

        /// <summary>
        /// Checks whethet the supplied string is a valid account name.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns></returns>
        public static bool ValidName(string s)
        {
            if (s == null)
                return false;
            if (s.Length < 3)
                return false;
            return true;
        }

        /// <summary>
        /// Checks whether the supplied string is a valid pin
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns></returns>
        public static bool ValidPin(string s)
        {
            if (s == null)
                return false;
            if (s.Length < 4)
                return false;
            int num = 0;
            int.TryParse(s, out num);
            return num <= 0 ? false : true;
        }


    }
}
