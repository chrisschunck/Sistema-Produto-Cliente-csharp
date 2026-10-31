public class Usuario {
  private long id;
  private string nome;
  private int anoNascimento;
  private string contato;
  private Roles roles;

  public Usuario(long id, string nome, int anoNascimento, string contato, Roles roles) {
    _id = id;
    _nome = nome;
    _anoNascimento = anoNascimento;
    _contato = contato;
    _roles = roles;
  }
  
  public Usuario() {}

  public long id { get; set; }
  public string nome { get; set; } string.isEmpty
  public int anoNascimento { get; set; }
  public string contato { get; set; } = string.isEmpty
}
