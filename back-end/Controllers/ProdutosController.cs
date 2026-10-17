using Microsoft.AspNetCore.Mvc;
using minhaPrimeiraApi.Models;
using minhaPrimeiraApi.Services;



namespace minhaPrimeiraApi.Controllers;

[ApiController]

[Route("api/[controller]")]

public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;
   public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        var Produtos = await _produtoService.ListarTodosAsync();
        return Ok(Produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListarPorId(int id)
    {
        if(id <= 0)
        {
            return BadRequest("O ID deve ser maior que zero");
        
        }
        
        //Percorre a Lista de produtos por ID
        var produto = await _produtoService.ListarPorIdAsync(id);

        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado. ");
        }

       return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] Produto prod)
    {
        if(ModelState.IsValid == false )
        {
            return BadRequest("O nome não pode estar vazio");
        }
        try
        {
            var produtoCriado = await _produtoService.CriarAsync(prod);
            return CreatedAtAction(nameof(ListarPorId), new { id = produtoCriado.Id }, produtoCriado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Produto prodAtualizado)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var produto = await _produtoService.AtualizarAsync(id, prodAtualizado);
        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }
        return Ok($"Produto com ID {id} atualizado com sucesso!");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarAsync(int id)
    {
        var produto = await _produtoService.DeletarAsync(id);
        if (produto == false)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }

        return NoContent();

    }

}