public class ProdutoService
{
    private readonly ProdutoRepository _produtoRepository;
    public ProdutoService(ProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public void AdicionarProduto(Produto produto)
    {
        _produtoRepository.AdicionarProduto(produto);
    }
    public void AtualizarProdutoPorId(Produto produto)
    {
        _produtoRepository.AtualizarProdutoPorId(produto);
    }
    public void DeletarProdutoPorId(long id)
    {
        _produtoRepository.DeletarProdutoPorId(id);
    }
    public Produto ObterProdutoPorId(long id)
    {
        return _produtoRepository.ObterProdutoPorId(id);
    }
    public IEnumerable<Produto> ObterTodosProdutos()
    {
        return _produtoRepository.ObterTodosProdutos();
    }
}