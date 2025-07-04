using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NaShop.Models;

public class Company
{
    public int Id { get; set; }
    [DisplayName("Company Name")]
    [MinLength(3)]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    [ValidateNever]
    public List<Product> Products { get; set; }
}