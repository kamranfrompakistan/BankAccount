namespace Models
{
    public abstract class BankAccount
    {
        public static int BankAccountsTotal = 0;
        private static int nextAccountNo = 10000;

        private decimal accountOpeningBalance;
        private decimal accountBalance;

        public BankAccount()
        {
            AccountId = nextAccountNo++;
            BankAccountsTotal++;
            AccountStatus = BankAccountStatus.Active;
            AccountCreationDate = DateTime.Now;
        }
        public BankAccount(BankAccountType accountType, decimal openingBalanceAmount) : this()
        {
            AccountType = accountType;
            AccountOpeningBalance = openingBalanceAmount;
        }
        public string Title { get; set; }
        public int AccountId { get; }
        public BankAccountType AccountType { get; }
        public BankAccountStatus AccountStatus { get; set; }
        public decimal AccountOpeningBalance
        {
            get { return accountOpeningBalance; }
            private set
            {
                accountOpeningBalance = value;
                AccountBalance = accountOpeningBalance;
            }
        }
        public decimal AccountBalance
        {
            get { return accountBalance; }
            set
            {
                accountBalance = value;
                AccountLastTransactionDate = DateTime.Now;
            }
        }
        public DateTime AccountCreationDate { get; }
        public DateTime AccountLastTransactionDate { get; set; }

        public virtual bool WithDraw(decimal amount)
        {
            if (amount > accountBalance)
            {
                return false;
            }

            accountBalance -= amount;
            return true;
        }

        // pay in
        public virtual bool PayIn(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            accountBalance += amount;
            return true;
        }
        public override string ToString()
        {
            return $"Title: {Title} " +
                $" Account# : {AccountId} " +
                $"Created On: {AccountCreationDate.ToString("dd-MMM-yyyy hh:mm:ss")} " +
                $"Type: {AccountType} " +
                $"Status: {AccountStatus} " +
                $"Last Trans. On: {AccountLastTransactionDate.ToString("dd-MMM-yyyy hh:mm:ss")} "+
            $"Balance: {accountBalance}";
        }
    }
}

public enum BankAccountType
{
    Saving = 1,
    Current
}

public enum BankAccountStatus
{
    Passive = 0,
    Active
}