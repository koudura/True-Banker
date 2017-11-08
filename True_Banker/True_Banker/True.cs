using System;
using System.Linq;

namespace True_Banker
{
    class True
    {


        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize(100, 35);
            Console.Title = "True Bank v1.0";



            //Console.WriteLine(String.Format("{0}{1}", 4, 'J'));
            // Main();
            // Landing(ConsoleColor.Yellow, ConsoleColor.Red);
            //    User user = new User("JAMes","james@goole.com","1915BJ","0906785434");

            //   Client cli = new Client(user);
            //  Savings saver = new Savings(cli);
            // DataBank<Savings> saverdata = new DataBank<Savings>(cli,saver);
            //   saverdata.BackUpData(saverdata);

            // string print = "A2C3B4";
            // print.GroupBy(x =>  Char.IsDigit(x) );

            //  Console.WriteLine(print);

            //var allnum =
            //    from n in print
            //    group n by Char.IsDigit(n) into grouup
            //    select new { id = grouup.Key, num = grouup };
            //foreach (var g in allnum) {
            //    Console.WriteLine("group of char of {0}", g.id);
            //    foreach (var n in g.num) {
            //        Console.WriteLine(n);
            //       }
            //}

            Landing(ConsoleColor.Cyan, ConsoleColor.Red);
            //Client newCustomer = new Client(newUSer);
            //Current fresh = new Current(newCustomer);

            //Client newcust = new Client(multi);

            //// decimal amount = Decimal.Parse(Console.ReadLine());
            //// fresh.Deposit(amount);
            //decimal amountd = Decimal.Parse(Console.ReadLine());
            //fresh.WithDraw(amountd);
            Console.ReadLine();

        }

        /// <summary>
        /// Prints the header.
        /// </summary>
        private static void PrintHeader()
        {
            Console.WriteLine("\t\t\t\t\tWelcome To True Banker !!!.\t");
            string bar = "-";
            for (int i = 0; i < 99; i++)
            {
                bar += "-";
            }
            Console.WriteLine("{0}\t\n", bar);
        }

        /// <summary>
        /// Landing Page
        /// </summary>
        /// <param name="fcolor">The fcolor.</param>
        /// <param name="icolor">The icolor.</param>
        public static void Landing(ConsoleColor fcolor, ConsoleColor icolor)
        {
            Console.Clear();
            Console.ForegroundColor = fcolor;
            PrintHeader();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1.\tSign Up");
            Console.WriteLine("2.\tSign In");

            Console.ForegroundColor = icolor;
            Console.WriteLine("\n\n (^Use the numbers for navigation^))");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Input >> ");
            Console.ForegroundColor = icolor;

            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                Console.Beep();
                switch (input)
                {
                    case 1:
                        SignUpPage(fcolor, icolor);
                        break;
                    case 2:
                        SignInPage(fcolor, icolor);
                        break;
                    default:
                        Landing(fcolor, icolor);
                        break;
                }
            }
            else { Landing(fcolor, icolor); }


        }

        /// <summary>
        /// Sign up page.
        /// </summary>
        /// <param name="fcolor">The fcolor.</param>
        /// <param name="icolor">The icolor.</param>
        public static void SignUpPage(ConsoleColor fcolor, ConsoleColor icolor)
        {
            Console.Beep();
            Console.Clear();
            Console.ForegroundColor = fcolor;
            PrintHeader();
            Console.WriteLine("\t SIGN UP.\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1.\t Sign Up (with existing True account.)");
            Console.WriteLine("2.\t Sign Up (with new True account.)\n ");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Input >> ");
            Console.ForegroundColor = icolor;

            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1:
                        enterOldAccount(fcolor, icolor);
                        break;
                    case 2:
                        registerNewAccount(fcolor, icolor);
                        break;
                    default:
                        SignUpPage(fcolor, icolor);
                        break;
                }
            }
            else { SignUpPage(fcolor, icolor); }
        }

        private static void SignInPage(ConsoleColor fcolor, ConsoleColor icolor)
        {
            Console.Beep();



        }

        private static void registerNewAccount(ConsoleColor fcolor, ConsoleColor icolor)
        {
            Console.Clear();
            Console.ForegroundColor = fcolor;
            PrintHeader();
            Console.WriteLine("\t Sign Up As !!.\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1.\t Administrator");
            Console.WriteLine("2.\t Customer\n ");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Input >> ");
            Console.ForegroundColor = icolor;
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1:
                        getAdminData(fcolor, ConsoleColor.White);
                        break;
                    case 2:
                        getCustomerData(fcolor, ConsoleColor.White);
                        break;
                    default:
                        registerNewAccount(fcolor, icolor);
                        break;
                }
            }
            else { registerNewAccount(fcolor, icolor); }


        }

        /// <summary>
        /// Controller for any old(existing) account.
        /// </summary>
        /// <param name="fcolor">The fcolor.</param>
        /// <param name="icolor">The icolor.</param>
        private static void enterOldAccount(ConsoleColor fcolor, ConsoleColor icolor)
        {

        }
        /// <summary>
        /// Gets the customer data.
        /// </summary>
        /// <param name="fcolor">The fcolor.</param>
        /// <param name="icolor">The icolor.</param>
        private static void getCustomerData(ConsoleColor fcolor, ConsoleColor icolor)
        {
            Console.Clear();
            Console.ForegroundColor = fcolor;
            PrintHeader();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t New User SignUp Form !!.\n\t (please do comply to fill the form according to the constraints, else a refill is invoked.)\n");

            User starter = new User();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*User Name (only alphabets & numbers allowed in field)>> ");
            Console.ForegroundColor = icolor;
            Console.Beep();
            starter.UserName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Email Adress (must be a valid email Adress with \'@\') >> ");
            Console.ForegroundColor = icolor;
            Console.Beep();
            starter.Email = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Pass Code (max length of 8)>> ");
            Console.ForegroundColor = icolor;
            Console.Beep();
            starter.PassCode = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Mobile Number (must be valid mobile number)>> ");
            Console.ForegroundColor = icolor;
            Console.Beep();
            starter.MobileNo = Console.ReadLine();

            if (isSafeForm(starter.UserName, starter.Email, starter.PassCode, starter.MobileNo))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tThanks for Registring with True !!!. (Enter any key to continue ....)");
                User createUser = new User(starter.UserName, starter.Email, starter.PassCode, starter.MobileNo);
                Console.ForegroundColor = fcolor;
                Console.Beep();
                Console.WriteLine("\t\t\tSign UP SuccessFull !!");
                addClient(createUser);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\nForm Contains Illegal Characters !! , press enter to invoke refill ...");
                Console.ReadLine();
                Console.Beep();


                getCustomerData(fcolor, icolor);
            }
        }

        /// <summary>
        /// Filling of the client form.
        /// </summary>
        /// <param name="n_client">The n client.</param>
        /// <param name="RYGBW">The color.</param>
        private static void fillClientForm(Client n_client, params ConsoleColor[] RYGBW)
        {
            Console.Clear();
            Console.ForegroundColor = RYGBW[1];
            PrintHeader();

            Console.ForegroundColor = RYGBW[3];
            Console.WriteLine("\t New Client Sign up Form !!.\n\t (please do comply to fill the form according to the constraints, else a refill is invoked.)\n");

            string name, fname, mname, lname, email, gender;
            int? mobile; int pin; DateTime date;

            collectData(out fname, out mname, out lname, RYGBW[2], RYGBW[4]);
            name = fname + " " + mname + " " + lname;

            collectData(out email, out gender, RYGBW[2], RYGBW[0]);
            collectData(out mobile, out pin, RYGBW[2], RYGBW[0]);
            date = DateTime.Now;



            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Email Adress (must be a valid email Adress with \'@\') >> ");
            Console.ForegroundColor = RYGBW[0];
            Console.Beep();
            n_client.ClientEmail = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Pass Code (max length of 8)>> ");
            Console.ForegroundColor = RYGBW[0];
            Console.Beep();
            //    starter.PassCode = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Mobile Number (must be valid mobile number)>> ");
            Console.ForegroundColor = RYGBW[0];
            Console.Beep();
            //  starter.MobileNo = Console.ReadLine();

        }

        /// <summary>
        /// Collects the name.
        /// </summary>
        /// <param name="fname">The fname.</param>
        /// <param name="mname">The mname.</param>
        /// <param name="lname">The lname.</param>
        /// <param name="GW">The gw.</param>
        private static void collectData(out string fname, out string mname, out string lname, params ConsoleColor[] GW)
        {

            Console.ForegroundColor = GW[0];
            Console.WriteLine("|>First Name (*alphabetics only) >> ");
            Console.ForegroundColor = GW[1];
            fname = Console.ReadLine();
            fname = fname.Trim(' ');
            Console.Beep();

            Console.ForegroundColor = GW[0];
            Console.WriteLine("|> Middle Name >> ");
            Console.ForegroundColor = GW[1];
            mname = Console.ReadLine();
            mname = mname.Trim(' ');
            Console.Beep();

            Console.ForegroundColor = GW[0];
            Console.WriteLine("|> Last Name >> ");
            Console.ForegroundColor = GW[1];
            lname = Console.ReadLine();
            lname = lname.Trim(' ');
            Console.Beep();

        }

        private static void collectData(out string email, out string gender, params ConsoleColor[] GW)
        {
            Console.ForegroundColor = GW[0];
            Console.WriteLine("|> Email (*alphanumerics & contains(@) only) >> ");
            Console.ForegroundColor = GW[1];
            email = Console.ReadLine();
            email = email.Trim(' ');
            Console.Beep();

            Console.ForegroundColor = GW[0];
            Console.WriteLine("|> Gender (*)  >> ");
            Console.ForegroundColor = GW[1];
            gender = Console.ReadLine();
            gender = gender.Trim(' ');
            Console.Beep();
        }
        private static void collectData(out int? mobile, out int pin, params ConsoleColor[] GW)
        {
            mobile = null;
            pin = 9;
        }



        /// <summary>
        /// Adds the client to database and opens new Account.
        /// </summary>
        /// <param name="args_user">The arguments user.</param>
        private static void addClient(params User[] args_user)
        {
            Client[] newClient = new Client[args_user.Length];
            Console.Beep();

            for (int i = 0; i < args_user.Length; i++)
            {
                newClient[i] = new Client(args_user[i]);
                fillClientForm(newClient[i], ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.White);
            }
        }

        /// <summary>
        /// Determines whether the inputs  from user violates any rules.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        /// <param name="pass">The pass.</param>
        /// <param name="mobile">The mobile.</param>
        /// <returns>
        ///   <c>true</c> if no Violation occurs in Form; Otherwise, <c>false</c>.
        /// </returns>
        private static bool isSafeForm(string name, string email, string pass, string mobile)
        {
            if (name == null || email == null || pass == null || mobile == null)
            {
                return false;
            }
            else if (!email.Contains('@'))
            {
                return false;
            }
            else if (pass.Length > 8 || pass.Length <= 0)
            {
                return false;
            }
            foreach (char c in name)
            {
                if (Char.IsSymbol(c) || Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            foreach (char c in mobile)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the admin data.
        /// </summary>
        /// <param name="fcolor">The fcolor.</param>
        /// <param name="icolor">The icolor.</param>
        private static void getAdminData(ConsoleColor fcolor, ConsoleColor icolor)
        {

        }

        /// <summary>
        /// Chooses the Account type
        /// </summary>
        /// <param name="u">The Client 'u'.</param>
        private static void AccountChoice(Client u)
        {
            int select;
            if (int.TryParse(Console.ReadLine(), out select))
            {
                Console.Beep();
                if (select > 3 || select <= 0)
                {
                    Console.Beep();
                    AccountChoice(u);
                }
                else
                {
                    switch (select)
                    {
                        case 1:
                            createCurrent(AccountVersion.Current, u);
                            break;
                        case 2:
                            createSaving(AccountVersion.Saving, u);
                            break;
                        case 3:
                            createSealed(AccountVersion.Sealed, u);
                            break;
                    }
                }
            }
            else { AccountChoice(u); }
        }

        /// <summary>
        /// Creates new current account for n number of new clients
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="cli">The cli.</param>
        public static void createCurrent(AccountVersion version, params Client[] cli)
        {
            Console.Beep();

        }
        /// <summary>
        /// Creates new savings account for n number of new clients
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="cli">The cli.</param>
        public static void createSaving(AccountVersion version, params Client[] client)
        {
            Console.Beep();
            foreach (var cli in client)
            {
                Savings saver = new Savings(cli);
                DataBank<Savings> saverdata = new DataBank<Savings>(cli, saver);
                saverdata.BackUpData(saverdata);
            }
           
          
            
        }
        /// <summary>
        /// Creates new  sealed account for n number of new clients
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="cli">The cli.</param>
        public static void createSealed(AccountVersion version, params Client[] cli)
        {
            Console.Beep();

        }

        public static string GetId(string ham)
        {
            L2: try
            {

                string[] name_args = ham.Split(' ');
                char[] nameTag = new char[3];
                int[] namecode = new int[3]; int nameCode = 0;
                for (int i = 0; i < nameTag.Length; i++)
                {
                    nameTag[i] = (name_args[i].Remove(0, 0).ToUpper()[0]);
                    namecode[i] = nameTag[i];
                    nameCode += namecode[i];
                }

                int ms, ss, mn, hr;
                hr = DateTime.Now.Hour;
                mn = DateTime.Now.Minute;
                ss = DateTime.Now.Second;
                ms = DateTime.Now.Millisecond;
                int avg_nmcode = nameCode / 3;
                int avg = (hr + mn + ss + ms) / 4;
                int dayofyear = DateTime.Now.DayOfYear;

                string avg_str = (avg <= 9) ? String.Format("{0}{1}{2}", 0, 0, avg) : String.Format("{0}{1}", 0, avg);
                avg_str = (avg > 99) ? avg.ToString() : avg_str;

                string avg_code = (avg_nmcode <= 9) ? String.Format("{0}{1}{2}", 0, 0, avg_nmcode) : String.Format("{0}{1}", 0, avg_nmcode);
                avg_code = (avg_nmcode > 99) ? avg_nmcode.ToString() : avg_code;

                string sex = String.Format("{0}", 1);


                string day = (dayofyear <= 9) ? String.Format("{0}{1}{2}", 0, 0, dayofyear) : String.Format("{0}{1}", 0, dayofyear);
                day = (dayofyear > 99) ? dayofyear.ToString() : day;

                string id = String.Format("{0}{1}{2}{3}{4}{5}{6}", sex, nameTag[0], day, nameTag[1], avg_str, nameTag[2], avg_code);

                return id;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("no name");
                ham = Console.ReadLine();
                goto L2;
            }

        }
    }

    enum Gender { Male, Female }
}
