// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using ATM;

class AtmWallet
{
    static void Main(string[] args)
    {
        #region insert data

        List<User> users = new List<User>
        {
            new User("S001", "002#cc", "chaw", "002111111Y", 230000),
            new User("S002", "112#ee", "thet", "096734678W", 12345002),
            new User("S003", "072#uu", "mya", "002111111Y", 267000),
            new User("S004", "035#pp", "san", "002111111Y", 230000),
            new User("S005", "002#oo","sein", "002111111Y", 230000),
        };
        #endregion

        #region check loggeduser

        while (true)
        {
            Console.WriteLine("Welcome to ATM..");
            User loggedUser = Login(users);

            if(loggedUser != null)
            {
                options(loggedUser);
            }
            else
            {
                Console.WriteLine("ATM is restarting...");
            }
            //options(loggedUser);
            //loggedUser = null;
        }
        #endregion
    }

    public static User? Login(List<User> users)
    {
        int attempt = 0;

        try
        {
            #region check attempt, lock, password

            while (attempt < 3)
            {
                Console.WriteLine("Please Enter your UserId: ");
                string userId = Console.ReadLine();
                Console.WriteLine("Please Enter your Password: ");
                string password = Console.ReadLine();

                var user = users.FirstOrDefault(u => u.UserId == userId);

                if (user != null)
                {
                    if (user.IsLocked)
                    {
                        Console.WriteLine("Account is locked. Please restart again...");
                        return null;
                    }

                    if (user.Password == password)
                    {
                        Console.WriteLine("Login Successfully..");
                        return user;
                    }
                }
                             
                Console.WriteLine("Invalid Credentials.Try again..");
                attempt++;
            }
            
            Console.WriteLine("Too many failed attempts. Account is locked..");
            return null;

            #endregion

        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    static void options(User user)
    {
        try
        {   
            while(true)
            {
                #region option choice

                Console.WriteLine("\nChoose Options.");
                Console.WriteLine("1. Withdraw");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Log Out");
                Console.WriteLine("5. End Program");

                string option = Console.ReadLine();

                #endregion

                #region option check

                switch (option)
                {
                    case "1":

                        Console.WriteLine("Please Enter your withdraw amount: ");
                        if (int.TryParse(Console.ReadLine(), out int withdrawAmount))
                        {
                            if (withdrawAmount < 0)
                            {
                                Console.WriteLine("Invalid amount...");
                            }
                            else if (user.Amount >= withdrawAmount)
                            {
                                user.Amount -= withdrawAmount;
                                Console.WriteLine("Withdraw successfully...");
                            }
                            else
                            {
                                Console.WriteLine("Withdraw amount is not sufficient..");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.Please enter a valid amount...");
                        }
                        break;

                    case "2":

                        Console.WriteLine("Please Enter your deposit amount: ");
                        if (int.TryParse(Console.ReadLine(), out int depositAmount))
                        {
                            if (depositAmount < 0)
                            {
                                Console.WriteLine("Invalid amount..");
                            }
                            else
                            {
                                user.Amount += depositAmount;
                                Console.WriteLine("Deposit successfully..");
                            }
                        }
                        break;

                    case "3":

                        Console.WriteLine($"Your Balance: {user.Amount}");
                        break;

                    case "4":
                        Console.WriteLine("Logout successfully...");
                        Console.ReadLine();
                        return;
                        
                    case "5":
                        Console.WriteLine("Ending ATM. Good Bye");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option.Please choose again...");
                        break;
                }
                if (option == "4") break;
                #endregion
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

