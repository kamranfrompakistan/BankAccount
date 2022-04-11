namespace Models
{
    public class SavingBankAccount : BankAccount
    {
        public static new int BankAccountsTotal = 0;
        public SavingBankAccount(decimal openingBalance = 500) : base(BankAccountType.Saving, openingBalance)
        {
            BankAccountsTotal++;
        }
        public override bool WithDraw(decimal amount)
        {
            decimal tax = 0;
            if (amount > 50000)
            {
                tax = 0.06M * amount;
            }

            amount = amount - tax;

            return base.WithDraw(amount);
        }
    }
}
