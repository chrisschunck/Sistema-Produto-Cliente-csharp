using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost]
    public ActionResult<Cliente> AdicionarCliente(@Validate, ClienteResponseDTO cliente)
    {
        var novoCliente = new Cliente
        {
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Endereco = cliente.Endereco,
            Cpf = cliente.Cpf
        };

        _clienteService.AdicionarCliente(novoCliente);
        return CreatedAtAction(nameof(ObterClientePorId), new { id = novoCliente.id }, novoCliente);
    }

    [HttpPut("{id:long}")]
    public IActionResult AtualizarClientePorId(long id, ClienteReponseDTO cliente)
    {
        var clienteAtualizado = new Cliente
        {
            id = id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Endereco = cliente.Endereco,
            Cpf = cliente.Cpf
        };

        _clienteService.AtualizarClientePorId(clienteAtualizado);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public IActionResult DeletarClientePorId(long id)
    {
        _clienteService.DeletarClientePorId(id);
        return NoContent();
    }

    [HttpGet("{id:long}")]
    public ActionResult<Cliente> ObterClientePorId(long id)
    {
        var cliente = _clienteService.ObterClientePorId(id);
        return cliente is null ? NotFound() : Ok(cliente);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cliente>> ObterTodosClientes()
    {
        return Ok(_clienteService.ObterTodosClientes());
    }
}
