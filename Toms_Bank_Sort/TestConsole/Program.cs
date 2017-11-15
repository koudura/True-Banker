using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLib;
using System.IO;
namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool g = Validation.ValidAccountNumOrAmt("17102612288");
            //var s = SuperGlobal.db.Retrieve("017102612288", "1111");

            FileInfo g = new FileInfo(@"C:\Users\tomiwa\Documents\man.txt");
            string i =Path.GetFileNameWithoutExtension(@"C:\Users\tomiwa\Documents\man.txt");
            Console.WriteLine(i);
            Console.Read();

        }
    }
}
