using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutoController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost]
    [Authorize(Roles="admin")]
    public ActionResult<ProdutoResponseDTO> AdicionarProduto([Validate], ProdutoRequestDTO produto)
    {
        var novoProduto = new Produto
        {
            nome = produto.Nome,
            descricao = produto.Descricao,
            preco = produto.Preco,
            quantidade = produto.Quantidade
        };

        _produtoService.AdicionarProduto(novoProduto);
        return CreatedAtAction(nameof(ObterProdutoPorId), new { id = novoProduto.id }, novoProduto);
    }

    [HttpPut("{id:long}")]
    public ProdutoResponseDTO AtualizarProdutoPorId([Validate], long id, ProdutoRequestDTO produto)
    {
        var produtoAtualizado = new Produto
        {
            id = id,
            nome = produto.Nome,
            descricao = produto.Descricao,
            preco = produto.Preco,
            quantidade = produto.Quantidade
        };

        _produtoService.AtualizarProdutoPorId(produtoAtualizado);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public void DeletarProdutoPorId(long id)
    {
        _produtoService.DeletarProdutoPorId(id);
        return NoContent();
    }

    [HttpGet("{id:long}")]
    public ActionResult<ProdutoResponseDTO> ObterProdutoPorId(long id)
    {
        var produto = _produtoService.ObterProdutoPorId(id);
        return produto is null ? NotFound() : Ok(produto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProdutoResponseDTO>> ObterTodosProdutos()
    {
        return Ok(_produtoService.ObterTodosProdutos());
    }
}
