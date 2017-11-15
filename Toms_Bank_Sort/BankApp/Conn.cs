using System;
using System.Collections.Generic;
using BankLib;

namespace BankApp
{
    /// <summary>
    /// Database connections
    /// </summary>
    public static class Conn
    {
        static Database dbase = new Database("", "bank", "base");
    }
}
