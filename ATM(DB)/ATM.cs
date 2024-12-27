using ATM_DB_.Model;
using Microsoft.EntityFrameworkCore;

namespace ATM_DB_
{
    public class ATM
    {
        //public void Read()
        //{
        //    AppDbContext db = new AppDbContext();
        //    var lst = db.TblUsers.Where(x => x.IsLocked == false).ToList();
        //    foreach ( var x in lst )
        //    {
        //        Console.WriteLine(x.UserId);
        //        Console.WriteLine(x.UserName);
        //        Console.WriteLine(x.AccountNo);
        //        Console.WriteLine(x.Amount);

        //    }
        //}

        private readonly AppDbContext _db = new AppDbContext();
        public void ATMSystem()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to ATM..");
                Console.Write("Enter UserName: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Password: ");
                string password = Console.ReadLine();
                
                if(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(password) )
                {
                    Console.WriteLine("Username and Password don't have to null....");
                    continue;
                }

                var user = _db.TblUsers.FirstOrDefault(u => u.UserName == name && u.Password == password);

                if(user == null )
                {
                    Console.WriteLine("\nInvalid user...");
                    continue;
                }

                Console.WriteLine("Login Successfully...");

                while (true)
                {
                        #region option choice

                        Console.WriteLine("\nChoose Options.");
                        Console.WriteLine("1. Withdraw");
                        Console.WriteLine("2. Deposit");
                        Console.WriteLine("3. Check Balance");
                        Console.WriteLine("4. Check Report");
                        Console.WriteLine("5. Log Out");
                        Console.WriteLine("6. End Program");

                        string option = Console.ReadLine();

                        #endregion

                        #region option check

                        switch (option)
                        {
                            case "1":

                                Console.WriteLine("Please Enter your withdraw amount: ");
                                decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());

                                if (withdrawAmount != null)
                                {
                                    if (withdrawAmount < 0 || withdrawAmount >= user.Amount)
                                    {
                                        Console.WriteLine("Invalid amount...");

                                    }
                                    else if (user.Amount >= withdrawAmount)
                                    {
                                        user.Amount -= withdrawAmount;

                                        _db.TblTransactions.Add(new TransactionModel
                                        {
                                            UserId = user.UserId,
                                            TransactionAmount = withdrawAmount,
                                            TransactionType = "Withdraw",
                                            CreatedDate = DateTime.Now
                                        });
                                        _db.SaveChanges();
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
                                decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                                if (depositAmount != null)
                                {
                                    if (depositAmount < 0)
                                    {
                                        Console.WriteLine("Invalid amount..");
                                    }
                                    else
                                    {
                                        user.Amount += depositAmount;

                                        _db.TblTransactions.Add(new TransactionModel
                                        {
                                            UserId = user.UserId,
                                            TransactionAmount = depositAmount,
                                            TransactionType = "Deposit",
                                            CreatedDate = DateTime.Now
                                        });
                                        _db.SaveChanges();
                                        Console.WriteLine("Deposit successfully..");
                                    }
                                }
                                break;

                            case "3":

                                Console.WriteLine($"Your Balance: {user.Amount}");
                                break;

                            case "4":
                                var transactions = _db.TblTransactions.Where(t => t.UserId == user.UserId);

                                if (transactions != null)
                                {
                                    Console.WriteLine("Transaction Report:");

                                    foreach (var transaction in transactions)
                                    {
                                        Console.WriteLine($"{transaction.CreatedDate}: {transaction.TransactionType} of {transaction.TransactionAmount}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Transaction report is empty....");
                                }
                                break;
                            case "5":
                                Console.WriteLine("Logout successfully...");
                                Console.ReadLine();
                                break;
                            case "6":
                                Console.WriteLine("Ending ATM. Good Bye");
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine("Invalid option.Please choose again...");
                                break;
                        }
                        #endregion

                        if (option == "5") break;                   
                }
            }               
        }
    }
}
