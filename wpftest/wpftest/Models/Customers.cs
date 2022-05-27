
using System.Text.Json.Serialization;

namespace efcoretest.Models;

public class Customer
{
    [JsonPropertyName("id")]
    public int ID { get; set; }
    [JsonPropertyName("companyName")]
    public string CompanyName{get;set;}
    [JsonPropertyName("address")]
    public string Address{get;set;}
    [JsonPropertyName("phone")]
    public string Phone{get;set;}
}