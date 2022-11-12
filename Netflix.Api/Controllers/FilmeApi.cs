using Microsoft.AspNetCore.Mvc;
using Netflix.Api.Models;
using Netflix.Api.Services;

namespace Netflix.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeApi : ControllerBase
{
    private readonly IFilmeService _filmeService;

    public FilmeApi(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }


    [HttpGet("/listar-filmes")]
    public List<Filme> GetFilmes()
    {
        return _filmeService.ListarFilmes();
    }


    [HttpGet("/listar-filme/{id}")]
    public Filme? GetFilme(string id)
    {
        return _filmeService.ObterFilme(id);
    }


    [HttpPost("/")]
    public IActionResult PostFilme([FromBody] Filme filme)
    {

        var response = _filmeService.SalvarFilme(filme);

        if (response is true) {
            return Ok("Filme cadastrado com sucesso!");
        }

        else {
            return BadRequest("Nome do filme não informado!");
        }

    }


    [HttpPut("/{id}")]
    public IActionResult PutFilme(string id, [FromBody] Filme filme) 
    {
        filme.Id = id;
        
        var response = _filmeService.AlterarFilme(filme);

        if (response is true) {
            return Ok("Filme alterado com sucesso!");
        }

        else {
            return BadRequest("Filme não encontrado!");
        }

    }


    [HttpDelete("/{id}")]
    public IActionResult DeleteFilme(string id)
    {
        var response = _filmeService.DeletarFilme(id);

        if (response is true) {
            return Ok("Filme deletado com sucesso!");
        }

        else {
            return BadRequest("Filme não encontrado!");
        }
    }
}

