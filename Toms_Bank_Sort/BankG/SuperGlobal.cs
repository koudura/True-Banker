using System;
using BankLib;

namespace BankG
{
    public static class SuperGlobal
    {
        public static Account account;
        public static Database db = new Database("", "bank", "base");
        public static FormRoot rootForm;
    }
}
