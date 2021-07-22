using System;
using System.ComponentModel.DataAnnotations;

namespace NinjaSoft.Tools.Finance.BudgetNinja.Common.DTOs
{
    public class BudgetEntry
    {
        public BudgetEntry()
        {
            Name = string.Empty;
            EntryType = BudgetEntryTypes.Bill;
            Balance = 0;
            LastUpdate = DateTime.UtcNow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetEntry"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        /// <param name="subCategory">The sub category.</param>
        /// <param name="balance">The balance.</param>
        public BudgetEntry(string name, BudgetEntryTypes type, double balance)
        {
            Name = name;
            EntryType = type;
            Balance = balance;
            LastUpdate = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the account URL.
        /// </summary>
        /// <value>The account URL.</value>
        [Display(Name = "Account Website", Order = 13)]
        [StringLength(255, ErrorMessage = "The Account URL must not be longer than 255 characters.")]
        public string? AccountURL { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        [Display(Name = "Balance", Order = 5)]
        public double? Balance { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        [Display(Name = "Category", Order = 4)]
        [StringLength(255, ErrorMessage = "The Category name must be no longer than 255 characters.")]
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the credit limit.
        /// </summary>
        /// <value>The credit limit.</value>
        [Display(Name = "Credit Limit", Order = 9)]
        public double? CreditLimit { get; set; }

        /// <summary>
        /// Gets or sets the desired payment.
        /// </summary>
        /// <value>The desired payment.</value>
        [Display(Name = "Desired Payment", Order = 7)]
        public double? DesiredPayment { get; set; }

        /// <summary>
        /// Gets or sets the date due.
        /// </summary>
        /// <value>The date due.</value>
        [Display(Name = "Due Date", Order = 10)]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the type, like Debt Item or Recurring Bill.
        /// </summary>
        /// <value>The type.</value>
        public BudgetEntryTypes EntryType { get; set; }

        /// <summary>
        /// Gets or sets the frequency.
        /// </summary>
        /// <value>The frequency.</value>
        [Display(Name = "Payment Frequency", Order = 8)]
        public double? Frequency { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the BudgetEntry.
        /// </summary>
        /// <value>The identifier.</value>
        [Display(Name = "Id", Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the interest rate of the Loan or Credit Card Balance
        /// </summary>
        /// <value>The interest rate.</value>
        [Display(Name = "Intrest", Order = 11)]
        public double? InterestRate { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [Display(Name = "Last Updated", Order = 12)]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Gets or sets the minimum payment.
        /// </summary>
        /// <value>The minimum payment.</value>
        [Display(Name = "Minimum Payment", Order = 6)]
        public double? MinimumPayment { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a nickname between {2} and {1} characters")]
        [Display(Name = "Account Name", Order = 3)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        [Display(Name = "Priority", Order = 2)]
        public int? Priority { get; set; }
    }
}