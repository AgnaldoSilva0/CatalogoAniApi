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
        public async Task<IEnumerable<Anime>> GetAnime()
        {
            var anime = await _mediator.Send(new ObterTodosAnimesRequest());

            return anime;
        }

        [HttpGet("v1/anime", Name = "ObterAnimes")]
        public async Task<IEnumerable<Anime>> GetAnimes([FromQuery] ObterAnimeRequest obterAnimeRequest)
        {
            return await _mediator.Send(obterAnimeRequest);
        }
    }
}
