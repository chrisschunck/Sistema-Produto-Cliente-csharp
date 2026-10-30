public class ClienteRepository
{
    private readonly List<Cliente> _clientes;
    public ClienteRepository()
    {
        _clientes = new List<Cliente>();
    }
    public void Adicionar(Cliente cliente)
    {
        _clientes.Add(cliente);
    }
    public void AtualizarClientePorId(Cliente cliente)
    {
        var clienteExistente = _clientes.FirstOrDefault(c => c.id == cliente.id);
        if (clienteExistente != null)
        {
            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefone = cliente.Telefone;
            clienteExistente.Endereco = cliente.Endereco;
            clienteExistente.Cpf = cliente.Cpf;
        }
    }
    public void DeletarClientePorId(long id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.id == id);
        if (cliente != null)
        {
            _clientes.Remove(cliente);
        }
    }
    public Cliente ObterClientePorId(long id)
    {
        return _clientes.FirstOrDefault(c => c.id == id);
    }
    public IEnumerable<Cliente> ObterTodosClientes()
    {
        return _clientes;
    }
}