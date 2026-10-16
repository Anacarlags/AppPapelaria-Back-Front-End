using Microsoft.AspNetCore.Mvc;
using minhaPrimeiraApi.Models;
using Microsoft.EntityFrameworkCore;
using minhaPrimeiraApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace minhaPrimeiraApi.Controllers;

[ApiController]

[Route("api/[controller]")]

public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {   
        _context = context;
        
    }


    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        var Produtos = await _context.Produtos.ToListAsync();
        return Ok(Produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        if(id <= 0)
        {
            return BadRequest("O ID deve ser maior que zero");
        
        }
        
        //Percorre a Lista de produtos por ID
        var produto = await _context.Produtos.FindAsync(id);

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
        _context.Produtos.Add(prod);
        await _context.SaveChangesAsync();
        return Ok($"Produto '{prod.Nome}' Criado com Sucesso");
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Produto prodAtualizado)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }
        produto.Nome = prodAtualizado.Nome;
        produto.Preco = prodAtualizado.Preco;

        await _context.SaveChangesAsync();

        return Ok($"Produto com ID {id} atualizado com sucesso!");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return Ok($"Produto com ID {id} deletado com sucesso!");
    }

}