using Models;

namespace BankAccountConsole
{
    public class Program
    {
       static void Main(string[] args)
        {
            BankAccount[] bankAccounts = new BankAccount[10];
            int bankAccountsArrayIndex = 0;
            BankAccount bankAccount = null;

            string? userSelectedMenuOption;
            string? customerAccountTitle;
            string? customerAccountType;
            string? customerAccountId;
            decimal customerAccountOpeningBalance;
            decimal customerTransactionAmount;
            bool userValidChoiceFlag = true;


            do
            {

                Console.Clear();

                Console.WriteLine("- Welcome to Offshore Bank -");
                Console.WriteLine("                        feel your black money here safe");
                Console.WriteLine("///////////////////////////////////////////////////////");

                userSelectedMenuOption = "";
                customerAccountTitle = "";
                customerAccountType = "";
                customerAccountOpeningBalance = 0;
                customerAccountId = "";


                Console.WriteLine("Press 1 for Create Account");
                Console.WriteLine("Press 2 for Search Account");
                Console.WriteLine("Press 3 for Deposit Amount");
                Console.WriteLine("Press 4 for Withdrawl Amount");
                Console.WriteLine("Press 5 to see all accounts");
                Console.WriteLine("Press any other key to exit");
                Console.WriteLine("");

                userSelectedMenuOption = Console.ReadLine().ToString();

                switch (userSelectedMenuOption)
                {
                    case "1":
                        Console.WriteLine("Enter Account Title");
                        customerAccountTitle = Console.ReadLine().ToString();

                        Console.WriteLine("Enter Opening Balance");
                        customerAccountOpeningBalance = Convert.ToDecimal(Console.ReadLine().ToString());

                        Console.WriteLine($"Enter Account Type: 1) for Saving 2) for Current Account");
                        customerAccountType = Console.ReadLine().ToString();

                        switch (customerAccountType)
                        {
                            case "1":
                                bankAccount = new SavingBankAccount(customerAccountOpeningBalance);
                                bankAccount.Title = customerAccountTitle;
                                bankAccounts[bankAccountsArrayIndex++] = bankAccount;
                                Console.WriteLine();
                                Console.WriteLine("Account Created Successfully...");
                                break;
                            case "2":
                                bankAccount = new CurrentBankAccount(customerAccountOpeningBalance);
                                bankAccount.Title = customerAccountTitle;
                                bankAccounts[bankAccountsArrayIndex++] = bankAccount;
                                Console.WriteLine();
                                Console.WriteLine("Account Created Successfully...");
                                break;
                            default:
                                Console.WriteLine("Not a valid Account Type");
                                break;
                        }

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter the account code");
                        customerAccountId = Console.ReadLine().Trim();

                        Console.WriteLine($"Total accounts: {BankAccount.BankAccountsTotal}");
                        for (int i = 0; i <= BankAccount.BankAccountsTotal; i++)
                        {
                            if (string.Compare(bankAccounts[i].AccountId.ToString(), customerAccountId) == 0)
                            {
                                Console.WriteLine(bankAccounts[i]);
                                break;
                            }
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Enter the account code for Deposit Amount");
                        customerAccountId = Console.ReadLine().Trim();

                        for (int i = 0; i <= BankAccount.BankAccountsTotal; i++)
                        {
                            if (string.Compare(bankAccounts[i].AccountId.ToString(), customerAccountId) == 0)
                            {
                                Console.WriteLine(bankAccounts[i]);
                                Console.WriteLine("Please enter to be deposited:");
                                customerTransactionAmount = Convert.ToDecimal(Console.ReadLine().Trim());
                                bankAccounts[i].PayIn(customerTransactionAmount);
                                Console.WriteLine("");
                                Console.WriteLine($"Amount Deposited successfully..");
                                Console.WriteLine("");
                                Console.WriteLine(bankAccounts[i]);
                                break;
                            }
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Enter the account code for Withdrawl an Amount");
                        customerAccountId = Console.ReadLine().Trim();

                        for (int i = 0; i <= BankAccount.BankAccountsTotal; i++)
                        {
                            if (string.Compare(bankAccounts[i].AccountId.ToString(), customerAccountId) == 0)
                            {
                                Console.WriteLine(bankAccounts[i]);
                                Console.WriteLine("Please enter to be withdrawn:");
                                customerTransactionAmount = Convert.ToDecimal(Console.ReadLine().Trim());
                                bankAccounts[i].WithDraw (customerTransactionAmount);
                                Console.WriteLine("");
                                Console.WriteLine($"Amount withdrawn successfully..");
                                Console.WriteLine("");
                                Console.WriteLine(bankAccounts[i]);
                                break;
                            }
                        }
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine($"Total accounts: {BankAccount.BankAccountsTotal}");
                        for (int i = 0; i <= BankAccount.BankAccountsTotal; i++)
                        {
                            Console.WriteLine(bankAccounts[i]);
                        }
                        break;
                    default:
                        userValidChoiceFlag = false;
                        break;
                }
                if (userValidChoiceFlag)
                {
                    Console.WriteLine();
                    Console.WriteLine("press any key to continue..");
                    Console.ReadKey();
                }
                else
                {
                    Console.Beep();
                    Console.Clear();
                }
            } while (userValidChoiceFlag);
        }
    }
}
