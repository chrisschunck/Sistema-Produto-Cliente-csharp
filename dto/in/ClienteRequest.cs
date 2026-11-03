using System.ComponentModel.DataAnnotations;

public class ClienteRequestDTO
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [MaxLength(100), MinLength(2)]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress]
    [MaxLength(100), MinLength(5)]
    [Unique]
    public string Email { get; set; }
    [Required(ErrorMessage = "Telefone é obrigatório")]
    [Phone]
    [MaxLength(20), MinLength(10)]
    public string Telefone { get; set; }
    [Required(ErrorMessage = "Endereço é obrigatório")]
    [MaxLength(200), MinLength(10)]
    public string Endereco { get; set; }
    [Required(ErrorMessage = "Cpf é obrigatório")]
    [Unique]
    [MaxLength(14), MinLength(14)]
    public string Cpf { get; set; }
}
