using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("produtos")]
public class Produto
{
    [Column("id")]
    private long _id;
    [Column("nome")]
    private string _nome;
    [Column("descricao")]
    private string _descricao;
    [Column("preco")]
    private decimal _preco;
    [Column("quantidade")]
    private int _quantidade;
    public Produto(long id, string nome, string descricao, decimal preco, int quantidade)
    {
        _id = id;
        _nome = nome;
        _descricao = descricao;
        _preco = preco;
        _quantidade  = quantidade;
    }
    public Produto() { }

    [KeyColumn("Chave primária, usada como identificador principal")]
    [Required]
    [JsonProperty]
    [DisplayName("ID")]
    public long id { get; set; } = 0;
    [Required]
    [JsonProperty]
    [DisplayName("Nome")]
    public string nome { get; set; } = string.Empty;
    [Required]
    [JsonProperty]
    [DisplayName("Descrição")]
    public string descricao { get; set; } = string.Empty;
    [Required]
    [JsonProperty]
    [DisplayName("Preço")]
    public decimal preco { get; set; } = 0.0m;
    [DisplayName("Quantidade")]
    [JsonProperty]
    [Required]
    public int quantidade { get; set; } = 0;
}
