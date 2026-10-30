using System.ComponentModel.DataAnnotations;

public class ProdutoRequestDTO
{
    [Required]
    [MaxLength(100), MinLength(2)]
    public string Nome { get; set; }
    [Required]
    [MaxLength(200), MinLength(10)]
    public string Descricao { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
    public decimal Preco { get; set; }
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser um valor não negativo.")]
    public int Quantidade { get; set; }
}