using System.ComponentModel.DataAnnotations;

public class ClienteRequestDTO
{
    [Required]
    [MaxLength(100), MinLength(2)]
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    [MaxLength(100), MinLength(5)]
    public string Email { get; set; }
    [Required]
    [Phone]
    [MaxLength(20), MinLength(10)]
    public string Telefone { get; set; }
    [Required]
    [MaxLength(200), MinLength(10)]
    public string Endereco { get; set; }
    [Required]
    [MaxLength(14), MinLength(14)]
    public string Cpf { get; set; }
}