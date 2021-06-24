using System;

namespace NinjaSoft.Tools.Finance.BudgetNinja.Common.DTOs
{
    public class BudgetEntryInputModel
    {
        public Uri AccountURL { get; set; }

        public double Balance { get; set; }

        public string Category { get; set; }

        public double CreditLimit { get; set; }

        public double DesiredPayment { get; set; }

        public string DueDate { get; set; }

        public BudgetEntryTypes EntryType { get; set; }

        public double Frequency { get; set; }

        public double InterestRate { get; set; }

        public DateTime LastUpdate { get; set; }

        public double MininmumPayment { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }
    }
}