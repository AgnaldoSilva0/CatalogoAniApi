using CatalogoAniApi.Comandos.Requisicoes;
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

        [HttpGet("anime", Name = "ObterAnime")]
        public async Task<Anime> GetAnime()
        {
            var anime = await _mediator.Send(new ObterAnimeRequest(1));

            return anime;
        }
    }
}
