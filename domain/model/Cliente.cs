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
    [Column("senha")]
    private string senha;
    [Column("telefone")]
    private string telefone;
    [Column("endereco")]
    private string endereco;
    [Column("cpf")]
    private string cpf;
    public Cliente(long id, string nome, string email, string senha, string telefone, string endereco, string cpf) {
        id = id;
        nome =  nome;
        email = email;
        senha = senha;
        telefone = telefone;
        endereco = endereco;
        cpf = cpf;
    }

    public Cliente() {}

    [KeyColumn("Chave primária, usada como identificador principal")]
    [Required]
    [JsonProperty]
    [DisplayName("ID")]
    public long id { get; set; } = 0;
    [Required(ErrorMessage = "Nome é obrigatório")]
    [JsonProperty]
    [DisplayName("Nome")]
    public string Nome { get; set; } = string.isEmpty;
    [Required(ErrorMessage = "Email é obrigatório")]
    [JsonProperty]
    [DisplayName("Email")]
    public string Email { get; set; } = string.isEmpty;
    [Required(ErrorMessage = "Senha é obrigatório")]
    [JsonProperty]
    [DisplayName("Senha")]
    public string Senha { get; set; } = string.isEmpty;
    [JsonProperty]
    [DisplayName("Telefone")]
    [Required(ErrorMessage = "Telefone é obrigatório")]
    public string Telefone { get; set; } = string.isEmpty;
    [JsonProperty]
    [DisplayName("Endereco")]
    [Required(ErrorMessage = "Endereço é obrigatório")]
    public string Endereco { get; set; } = string.isEmpty;
    [JsonProperty]
    [DisplayName("CPF")]
    [Required(ErrorMessage = "Cpf é obrigatório")]
    public string Cpf {get; set; } = string.isEmpty;
}
