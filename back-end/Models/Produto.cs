using System.ComponentModel.DataAnnotations;

namespace minhaPrimeiraApi.Models;

public class Produto
{
    public int Id { get; set; }
    
    [Required (ErrorMessage = "O nome do Produto é Obrigatório")]
    [MaxLength(100, ErrorMessage = "O Nome não pode ter mais de 100 caracteres.")]
    public string Nome { get; set; }
    
    [Range(0.01, 1000, ErrorMessage = " O preço deve ser ente 0,01 e 1.000")]
    public decimal Preco { get; set; }


}