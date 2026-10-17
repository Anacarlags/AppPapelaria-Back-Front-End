
namespace minhaPrimeiraApi.Repositories;

using minhaPrimeiraApi.Models;


    public interface IProdutoRepository
    {
    
        Task<List<Produto>> ListarTodosAsync(int id);
        Task<Produto> ListarPorIdAsync(int id);
        Task<Produto> CriarAsync(Produto produto);
        Task<Produto> AtualizarAsync(int id, Produto produtoAtualizado);
        Task<bool> DeletarAsync(int id);

        Task<bool> ExisteNomeDuploAsync(string nome, int id);
        
    }
