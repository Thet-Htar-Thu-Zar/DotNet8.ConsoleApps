namespace ATM
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string AccountNo { get; set; }
        public int Amount { get; set; }
        public bool IsLocked { get; set; } = false;

        public User (string userId, string password, string name, string accountNo, int amount)
        {
            UserId = userId;
            Password = password;
            Name = name;
            AccountNo = accountNo;
            Amount = amount;
        }
    }
}
