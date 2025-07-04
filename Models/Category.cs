using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NaShop.Models;

public class Category
{
    public int Id { get; set; }
    [MinLength(3)]
    public string Name { get; set; }
    [ValidateNever]
    public List<Product> Products { get; set; }
}