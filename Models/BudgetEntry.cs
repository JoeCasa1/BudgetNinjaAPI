using System;

namespace BudgetNinjaAPI.Models
{
  public record BudgetEntry
  {
    public Uri AccountURL { get; init; }

    public double Balance { get; init; }

    public string Category { get; init; }

    public double CreditLimit { get; init; }

    public string DueDate { get; init; }

    public double DesiredPayment { get; init; }

    public double Frequency { get; init; }

    public double InterestRate { get; init; }

    public DateTime LastUpdate { get; init; }

    public double MininmumPayment { get; init; }

    public string Name { get; init; }

    public int Priority { get; init; }

    public BudgetEntryType EntryType { get; init; }
    public Guid Id { get; init; }
  }
}