public class ClienteService
{
    private readonly ClienteRepository _clienteRepository;
    public ClienteService(ClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    public void AdicionarCliente(Cliente cliente)
    {
        _clienteRepository.Adicionar(cliente);
    }
    public void AtualizarClientePorId(Cliente cliente)
    {
        _clienteRepository.AtualizarClientePorId(cliente);
    }
    public void DeletarClientePorId(long id)
    {
        _clienteRepository.DeletarClientePorId(id);
    }
    public Cliente ObterClientePorId(long id)
    {
        return _clienteRepository.ObterClientePorId(id);
    }
    public IEnumerable<Cliente> ObterTodosClientes()
    {
        return _clienteRepository.ObterTodosClientes();
    }
}