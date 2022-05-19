
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcoretest.Models;

[Table("Customers")]
public class Customer
{

    [Key, Required]
    public int ID { get; set; }
    public string CompanyName{get;set;}
    public string Address{get;set;}
    public string Phone{get;set;}
}