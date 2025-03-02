using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;



namespace API_Livraria.Models;

public class Livro
{
    [Key] // Define que este campo é a chave primária
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [SwaggerSchema(ReadOnly = true)]  // O id será apenas para leitura
    public int Id { get; set; }

    [Required(ErrorMessage = "O título é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O autor é obrigatório")]
    public string Autor { get; set; }

    [Required(ErrorMessage = "O gênero é obrigatório")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "A quantidade em estoque é obrigatória")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa")]
    public int Estoque { get; set; }

}
