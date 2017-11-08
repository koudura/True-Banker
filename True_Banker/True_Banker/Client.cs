using System;

namespace True_Banker
{

    [Serializable]
    class Client
    {
        /// <summary>
        /// The client name
        /// </summary>
        private string clientName;
        /// <summary>
        /// The email
        /// </summary>
        private string email;
        /// <summary>
        /// The gender
        /// </summary>
        private Gender gender;
        /// <summary>
        /// The mobile nos
        /// </summary>
        private int? mobileNo;
        /// <summary>
        /// The dob
        /// </summary>
        private DateTime dob;
        /// <summary>
        /// The pin code
        /// </summary>
        private int pinCode;
        /// <summary>
        /// The client identifier pincode
        /// </summary>
        private string clientID;
        /// <summary>
        /// The user to be associated with this client
        /// </summary>
        private User _user;

        /// <summary>
        /// The client created accounts
        /// </summary>
        private static Account[] clientAccounts = new Account[TmaxAccounts];
        /// <summary>
        /// The max accounts per each costumer
        /// </summary>
        private static int TmaxAccounts = 4;
        private static int noOfAccounts;

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        /// <value>
        /// The name of the client.
        /// </value>
        public string ClientName { get { return this.clientName; } set { clientName = value; } }
        public string ClientEmail { get { return this.email; } set { email = value; } }
        public Gender ClientSex { get { return this.gender; } set { gender = value; } }
        public int? ClientPhoneNo { get { return this.mobileNo; } set { this.mobileNo = value; } }
        public DateTime DOB { get { return this.dob; } set { this.dob = value; } }
        public int ClientPin { get { return this.pinCode; } private set { this.pinCode = value; } }
        public string ClientID { get { return this.clientID; } private set { this.clientID = value; } }
        public Account[] ClientAccounts { get { return clientAccounts; } set { clientAccounts = value; } }
        public int NumOfAccounts { get { return clientAccounts.Length; } set { noOfAccounts = value; } }

        //    public AccountVersion AccountType { get; { se} }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="newUser">The new user.</param>
        public Client(User newUser)
        {
            this._user = newUser;
            _init_CID();
            Console.WriteLine("user now registered as client");
        }


        public Client() { }

        /// <summary>
        /// Initializes the cid.
        /// </summary>
        private void _init_CID()
        {

            try
            {
                string[] name_args = ClientName.Split(' ');
                char[] nameTag = new char[3];
                int[] namecode = new int[3]; int nameCode = 0;
                for (int i = 0; i < nameTag.Length; i++)
                {
                    nameTag[i] = (name_args[i].Remove(0, 0).ToUpper()[0]);
                    namecode[i] = (int)nameTag[i];
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

                string sex = String.Format("{0}", (int)ClientSex);


                string day = (dayofyear <= 9) ? String.Format("{0}{1}{2}", 0, 0, dayofyear) : String.Format("{0}{1}", 0, dayofyear);
                day = (dayofyear > 99) ? dayofyear.ToString() : day;

                ClientID = String.Format("{0}{1}{2}{3}{4}{5}{6}", sex, nameTag[0], day, nameTag[1], avg_str, nameTag[2], avg_code);
            }
            catch (IndexOutOfRangeException ex)
            {
                new Logger().LogException("A Certain field of the form has a  null entry", LogExceptionType.Null);
                //   _init_CID();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Account"/> with the specified cid.
        /// </summary>
        /// <value>
        /// The <see cref="Account"/>.
        /// </value>
        /// <param name="CID">The customer identification.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Account this[Client CID, int index] {
            get {
                if (DataBank<Account>.DataStore.ContainsKey(CID))
                {
                    if (index >= 0 || index < TmaxAccounts)
                    {
                        return clientAccounts[index];
                    }
                }
                return null;
            }
            set {
                if (index >= 0 || index < TmaxAccounts)
                {
                    clientAccounts[index] = (clientAccounts[index] == null) ? value : clientAccounts[index];
                }

            }
        }
    }

    /// <summary>
    /// Structure for storing user details
    /// </summary>
    [Serializable]
    public struct User
    {
        /// <summary>
        /// The email
        /// </summary>
        private string email;
        /// <summary>
        /// The username
        /// </summary>
        private string username;
        /// <summary>
        /// The passcode
        /// </summary>
        private string passcode;
        /// <summary>
        /// The mobile no
        /// </summary>
        private string mobileNo;
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get { return email; } set { email = value; } }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get { return username; } set { username = value; } }
        /// <summary>
        /// Gets or sets the pass code.
        /// </summary>
        /// <value>
        /// The pass code.
        /// </value>
        public string PassCode { get { return username; } set { passcode = value; } }
        /// <summary>
        /// Gets or sets the mobile number
        /// </summary>
        /// <value>
        /// The mobile no.
        /// </value>
        public string MobileNo { get { return mobileNo; } set { mobileNo = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> struct.
        /// </summary>
        /// <param name="_username">The username.</param>
        /// <param name="_email">The email.</param>
        /// <param name="_passcode">The passcode.</param>
        /// <param name="_mobileno">The mobileno.</param>
        public User(string _username, string _email, string _passcode, string _mobileno)
        {
            this.email = _email;
            this.username = _username;
            this.passcode = _passcode;
            this.mobileNo = _mobileno;
        }
    }
}
