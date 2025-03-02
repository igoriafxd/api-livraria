using API_Livraria.Models;
using API_Livraria.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_Livraria.Controllers;

[ApiController]
[Route("api/livros")]
public class LivrosController : ControllerBase
{
    private readonly LivroRepository _repository;

    public LivrosController()
    {
        _repository = new LivroRepository(); // Instância do repositório
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var livros = _repository.GetAll();
        return Ok(livros); // Retorna os livros com status 200 OK
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var livro = _repository.GetById(id);
        if (livro == null)
        {
            return NotFound("Livro não encontrado.");
        }

        return Ok(livro);
    }


    [HttpPost]
    public IActionResult Add([FromBody] Livro livro)
    {
        if (livro == null)
        {
            return BadRequest("Livro não pode ser nulo");
        }

        _repository.Add(livro); // Adiciona o livro ao repositório

        // Retorna 201 Created, mas sem precisar incluir o ID no JSON de entrada
        return CreatedAtAction(nameof(GetAll), new { id = livro.Id }, livro);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Livro livroAtualizado)
    {
        if (livroAtualizado == null)
        {
            return BadRequest("Os dados do livro estão inválidos.");
        }

        var livroExistente = _repository.GetById(id);
        if (livroExistente == null)
        {
            return NotFound("Livro não encontrado.");
        }

        // Verifica se o ID na URL corresponde ao ID do livro enviado no corpo
        if (livroAtualizado.Id != id)
        {
            livroAtualizado.Id = id;  // Ajusta o ID no corpo da requisição para corresponder ao ID na URL
        }

        _repository.Update(livroAtualizado);

        return NoContent(); // Retorna 204 - Atualização bem-sucedida sem conteúdo
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _repository.Delete(id); // Chama o método no serviço
            return NoContent(); // Retorna 204 se der certo
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao deletar o livro: {ex.Message}");
        }
    }





}
