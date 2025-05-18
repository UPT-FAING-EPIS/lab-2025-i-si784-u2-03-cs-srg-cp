using System;

namespace Bank.Domain
{
    /// <summary>
    /// Represents a bank account with basic operations like debit and credit.
    /// </summary>
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private readonly string m_customerName = string.Empty;
        private double m_balance;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="customerName">The name of the customer.</param>
        /// <param name="balance">The initial balance.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Gets the current balance of the account.
        /// </summary>
        public double Balance { get { return m_balance; } }

        /// <summary>
        /// Withdraws a specific amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the amount is greater than the balance or less than zero.</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            m_balance -= amount; 
        }

        /// <summary>
        /// Adds a specific amount to the account.
        /// </summary>
        /// <param name="amount">The amount to add.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the amount is less than zero.</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance += amount;
        }
    }
}
