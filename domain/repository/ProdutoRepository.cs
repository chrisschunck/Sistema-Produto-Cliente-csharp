using System
using domain.model
using context

public class ProdutoRepository
{
    private readonly DbContext _dbContext;
    
    public ProdutoRepository()
    {
        _dbContext = dbcontext;
    }
    public void AdicionarProduto(Produto produto)
    {
        _dbContext.Add(produto);
        _dbContext.SaveChanges();
    }
    public void AtualizarProdutoPorId(Produto produto)
    {
        var produtoExistente = _dbContext.Produto.Find(id));
        if (produtoExistente != null)
        {
            produtoExistente.nome = produto.nome;
            produtoExistente.descricao = produto.descricao;
            produtoExistente.preco = produto.preco;
            produtoExistente.quantidade = produto.quantidade;
        }
        _dbContext.Produto.Update(produtoExistente);
        _dbContext.SaveChanges();
    }
    public void DeletarProdutoPorId(long id)
    {
        var produto = _dbContext.Produto.Find(id);
        if (produto != null)
        {
            _dbContext.Remove(produto);
        }
        _dbContext.SaveChanges();
    }
    public Produto ObterProdutoPorId(long id)
    {
        return _dbContext.Produto.Find(id);
    }
    public IEnumerable<Produto> ObterTodosProdutos()
    {
        return _dbContext;
    }
}
