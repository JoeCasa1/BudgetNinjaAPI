using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetNinjaAPI.DTOs
{
  public class DebtUpdateDTO
  {
    [Required]
    public double Balance { get; set; }

    [Required]
    public Guid Id { get; set; }

    [Required]
    public double InterestRate { get; set; }

    [Required]
    public double MinimumPayment { get; set; }

    [Required]
    public string Name { get; set; }
  }
}