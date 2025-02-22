using CatalogoAniApi.Comandos.Commands;
using CatalogoAniApi.Comandos.Requests;
using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Excecoes;
using CatalogoAniApi.Servicos.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoAniApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly ILogServico _logServico;
        private readonly IMediator _mediator;

        public AnimeController(ILogServico logServico, IMediator mediator)
        {
            _logServico = logServico;
            _mediator = mediator;
        }

        [HttpGet("v1/anime/todos", Name = "ObterTodosAnimes")]
        public async Task<ActionResult<IEnumerable<Anime>>> ObterTodosAnimes([FromQuery] ObterTodosAnimesRequest obterTodosAnimesRequest)
        {
            try
            {
                var animes = await _mediator.Send(obterTodosAnimesRequest);
                return Ok(animes);
            }
            catch (Exception excecao)
            {
                var mensagemDeErro = "Ocorreu um erro interno ao obter animes.";

                await _logServico.RegistrarLogAsync(mensagemDeErro, excecao);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = mensagemDeErro });
            }
        }

        [HttpGet("v1/anime/obter", Name = "ObterAnimes")]
        public async Task<ActionResult<IEnumerable<Anime>>> ObterAnimes([FromQuery] ObterAnimeRequest obterAnimeRequest)
        {
            try
            {
                var animes = await _mediator.Send(obterAnimeRequest);
                return Ok(animes);
            }
            catch (Exception excecao)
            {
                var mensagemDeErro = "Ocorreu um erro interno ao obter animes.";

                await _logServico.RegistrarLogAsync(mensagemDeErro, excecao);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = mensagemDeErro });
            }
        }

        [HttpPost("v1/animes/cadastro", Name = "CadastrarAnime")]
        public async Task<IActionResult> CadastrarAnime([FromBody] CadastrarAnimeCommand command)
        {
            try
            {
                var anime = await _mediator.Send(command);

                return CreatedAtAction(nameof(ObterAnimes), new { id = anime.Id }, anime);
            }
            catch (ValidacaoExcecao validacaoExcecao)
            {
                return BadRequest(new { message = validacaoExcecao.Message });
            }
            catch (Exception excecao)
            {
                var mensagemDeErro = "Ocorreu um interno erro ao cadastrar anime.";

                await _logServico.RegistrarLogAsync(mensagemDeErro, excecao);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = mensagemDeErro });
            }
        }

        [HttpPut("v1/animes/atualizar/{id}", Name = "AtualizarAnime")]
        public async Task<IActionResult> AtualizarAnime(int id, [FromBody] AtualizarAnimeCommand command)
        {
            try
            {
                if (id != command.Id)
                    return BadRequest(new { message = "IDs informados são divergentes." });

                var anime = await _mediator.Send(command);

                return Ok(anime);
            }
            catch (ValidacaoExcecao validacaoExcecao)
            {
                return BadRequest(new { message = validacaoExcecao.Message });
            }
            catch (Exception excecao)
            {
                var mensagemDeErro = "Ocorreu um interno erro ao atualizar anime.";

                await _logServico.RegistrarLogAsync(mensagemDeErro, excecao);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = mensagemDeErro });
            }
        }

        [HttpDelete("v1/animes/deletar/{id}", Name = "DeletarAnime")]
        public async Task<IActionResult> DeletarAnime(int id)
        {
            try
            {
                var command = new DeletarAnimeCommand { Id = id };
                await _mediator.Send(command);

                return NoContent();
            }
            catch (ValidacaoExcecao validacaoExcecao)
            {
                return BadRequest(new { message = validacaoExcecao.Message });
            }
            catch (Exception excecao)
            {
                var mensagemDeErro = "Ocorreu um interno erro ao deletar anime.";

                await _logServico.RegistrarLogAsync(mensagemDeErro, excecao);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = mensagemDeErro });
            }
        }
    }
}
