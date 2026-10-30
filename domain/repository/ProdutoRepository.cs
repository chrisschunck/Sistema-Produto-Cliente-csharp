public class ProdutoRepository
{
    private readonly List<Produto> _produtos;
    public ProdutoRepository()
    {
        _produtos = new List<Produto>();
    }
    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }
    public void AtualizarProdutoPorId(Produto produto)
    {
        var produtoExistente = _produtos.FirstOrDefault(p => p.id == produto.id);
        if (produtoExistente != null)
        {
            produtoExistente.nome = produto.nome;
            produtoExistente.descricao = produto.descricao;
            produtoExistente.preco = produto.preco;
            produtoExistente.quantidade = produto.quantidade;
        }
    }
    public void DeletarProdutoPorId(long id)
    {
        var produto = _produtos.FirstOrDefault(p => p.id == id);
        if (produto != null)
        {
            _produtos.Remove(produto);
        }
    }
    public Produto ObterProdutoPorId(long id)
    {
        return _produtos.FirstOrDefault(p => p.id == id);
    }
    public IEnumerable<Produto> ObterTodosProdutos()
    {
        return _produtos;
    }
}