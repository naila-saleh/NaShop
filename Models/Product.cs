using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NaShop.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string Name { get; set; }
    public string Description { get; set; }
    [Range(0,100000)]
    public decimal Price { get; set; }
    [Range(0,5)]
    public double Rate { get; set; }
    public int Quantity { get; set; }
    [Range(0,100)]
    public double Discount { get; set; }
    [RegularExpression(@".*\.(jpg|jpeg|png|gif|bmp|webp|svg)$")]
    public string? Image { get; set; }
    public int CategoryId { get; set; }
    [ValidateNever]
    public Category Category { get; set; }
    public int CompanyId { get; set; }
    [ValidateNever]
    public Company Company { get; set; }
}