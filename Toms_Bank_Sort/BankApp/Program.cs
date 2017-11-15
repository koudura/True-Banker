using System;
using BankLib;
namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(AccountNumberGenerator.GenerateCurrent());
            Console.Read();
        }
    }


    public class LevelOne
    {
        string message = "1.Create Account\n"
            +"2. Login\n"
            +"3.Exit\n\n";
        public LevelOne()
        {
            action();
        }

        public void action()
        {
            Console.WriteLine(message);
            int act = 0;
            string s = Console.ReadLine();
            int.TryParse(s, out act);

            switch (act)
            {
                case 1:
                  //  CreateAccount ca = new CreateAccount();
                    break;

                case 2:
                   // Login lg = new Login();
                    break;

                case 3:


                default:
                    action();
                    break;
            }

        }

    }
}
