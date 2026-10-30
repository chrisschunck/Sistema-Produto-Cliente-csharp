using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("clientes")]
public class Cliente {

    [Column("id")]
    private long _id;
    [Column("nome")]
    private string nome;
    [Column("email")]
    private string email;
    [Column("telefone")]
    private string telefone;
    [Column("endereco")]
    private string endereco;
    [Column("cpf")]
    private string cpf;
    public Cliente(long id, string nome, string email, string telefone, string endereco, string cpf) {
        id = id;
        nome =  nome;
        email = email;
        telefone = telefone;
        endereco = endereco;
        cpf = cpf;
    }

    public Cliente() {}

    [Required]
    [DisplayName("ID")]
    public long id { get; set; } = 0;
    [Required]
    [DisplayName("Nome")]
    public string Nome { get; set; } = string.Empty;
    [Required]
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;
    [DisplayName("Telefone")]
    [Required]
    public string Telefone { get; set; } = string.Empty;
    [DisplayName("Endereco")]
    [Required]
    public string Endereco { get; set; } = string.Empty;
    [DisplayName("CPF")]
    [Required]
    public string Cpf {get; set; } = string.Empty;
}