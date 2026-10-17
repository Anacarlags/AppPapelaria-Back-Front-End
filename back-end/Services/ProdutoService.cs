using minhaPrimeiraApi.Models;
using minhaPrimeiraApi.Repositories;


namespace minhaPrimeiraApi.Services;
public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<List<Produto>> ListarTodosAsync(int id)
    {
        return await _produtoRepository.ListarTodosAsync(id);
    }

    public async Task<Produto> ListarPorIdAsync(int id)
    {
        return await _produtoRepository.ListarPorIdAsync(id);
    }

    public async Task<Produto> CriarAsync(Produto produto)
    {
        if(produto.Preco <= 0.1m)
            throw new ArgumentException("O preço do produto deve ser maior que zero.");
        if(await _produtoRepository.ExisteNomeDuploAsync(produto.Nome, produto.Id))
            throw new ArgumentException("Já existe um produto com o mesmo nome.");
        
        return await _produtoRepository.CriarAsync(produto);
    }

    public async Task<Produto> AtualizarAsync(int id, Produto produtoAtualizado)
    {
        return await _produtoRepository.AtualizarAsync(id, produtoAtualizado);
    }

    public async Task<bool> DeletarAsync(int id)
    {
        return await _produtoRepository.DeletarAsync(id);
    }
}