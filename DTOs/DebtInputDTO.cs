using System.ComponentModel.DataAnnotations;

namespace BudgetNinjaAPI.DTOs
{
  public class DebtInputDTO
  {
    [Required]
    public double Balance { get; set; }
    [Required]
    public double InterestRate { get; set; }
    [Required]
    public double MinimumPayment { get; set; }
    [Required]
    public string Name { get; set; }
  }
}