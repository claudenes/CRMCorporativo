using CRMCorporativo.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CRMCorporativo.Application.DTOs;

public class ClienteDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string? CPFCNPJ { get; set; }

    [Required(ErrorMessage = "The Price is Required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "The Stock is Required")]
    [Range(1, 9999)]
    [DisplayName("Stock")]
    public string Telefone { get; set; }

    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string? Email { get; set; }

    [JsonIgnore]
    public Endereco? Endereco { get; set; }

    [DisplayName("Categories")]
    public int CategoryId { get; set; }
}
