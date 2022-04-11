namespace Models
{
    public class CurrentBankAccount : BankAccount
    {
        public static new int BankAccountsTotal = 0;
        public CurrentBankAccount(decimal openingBalance = 1000) : base(BankAccountType.Current, openingBalance)
        {
            BankAccountsTotal++;
        }
        public override bool WithDraw(decimal amount)
        {
            amount = amount - 50;
            return base.WithDraw(amount);
        }
    }
}
