namespace Wincubate.Threading.Module01
{
	public static class Bank
	{
		public static BankAccount CreateAccount(decimal initialAmount)
		{
			return new BankAccount(initialAmount);
		}

		public static void TransferFunds(BankAccount from, decimal amount, BankAccount to)
		{
			from.Withdraw(amount);
			to.Deposit(amount);
		}
	}
}
