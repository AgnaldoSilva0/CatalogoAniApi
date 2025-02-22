using CatalogoAniApi.Comandos.Commands;
using CatalogoAniApi.Comandos.Requests;
using CatalogoAniApi.Modelo.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoAniApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly ILogger<AnimeController> _logger;
        private readonly IMediator _mediator;

        public AnimeController(ILogger<AnimeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("v1/anime/todos", Name = "ObterTodosAnimes")]
        public async Task<IEnumerable<Anime>> ObterTodosAnimes()
        {
            var anime = await _mediator.Send(new ObterTodosAnimesRequest());

            return anime;
        }

        [HttpGet("v1/anime/obter", Name = "ObterAnimes")]
        public async Task<IEnumerable<Anime>> ObterAnimes([FromQuery] ObterAnimeRequest obterAnimeRequest)
        {
            return await _mediator.Send(obterAnimeRequest);
        }

        [HttpPost("v1/animes/cadastro", Name = "CadastrarAnime")]
        public async Task<IActionResult> CadastrarAnime([FromBody] CadastrarAnimeCommand command)
        {
            var anime = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObterAnimes), new { id = anime.Id }, anime);
        }

        [HttpPut("v1/animes/atualizar/{id}", Name = "AtualizarAnime")]
        public async Task<IActionResult> AtualizarAnime(int id, [FromBody] AtualizarAnimeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var anime = await _mediator.Send(command);
            return Ok(anime);
        }

        [HttpDelete("v1/animes/deletar/{id}", Name = "DeletarAnime")]
        public async Task<IActionResult> DeletarAnime(int id)
        {
            var command = new DeletarAnimeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
