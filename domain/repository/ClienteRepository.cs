using System
using domain.dbContext
using domain.model

public class ClienteRepository
{
    private readonly DbContext _dbContext;
    public ClienteRepository()
    {
        _dbContext = dbcontext;
    }
    public void AdicionarCliente(Cliente cliente)
    {
        _dbContext.Add(cliente);
        _dbContext.SaveChanges();
    }
    public void AtualizarClientePorId(long id, Cliente cliente)
    {
        var clienteExistente = _dbContext.Cliente.Find(id);
        if (clienteExistente != null)
        {
            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefone = cliente.Telefone;
            clienteExistente.Endereco = cliente.Endereco;
            clienteExistente.Cpf = cliente.Cpf;
        }
        _dbContext.Cliente.Update(clienteExistente);
        _dbContext.SaveChanges();
    }
    public void DeletarClientePorId(long id)
    {
        var cliente = _dbContext.Cliente.Find(id));
        if (cliente != null)
        {
            _dbContext.Remove(cliente);
            _dbContext.SaveChanges();
        }
    }
    public Cliente ObterClientePorId(long id)
    {
        return _dbContext.Cliente.Find(id);
    }
    public IEnumerable<Cliente> ObterTodosClientes()
    {
        return _dbContext;
    }
}
