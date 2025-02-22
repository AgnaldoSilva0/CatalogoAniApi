using CatalogoAniApi.Comandos.Commands;
using CatalogoAniApi.Comandos.Handlers;
using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Enumeradores;
using CatalogoAniApi.Modelo.Excecoes;
using CatalogoAniApi.RegraNegocio.Interfaces;
using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using CatalogoAniApi.TesteUnitario.Builders;
using Moq;

namespace CatalogoAniApi.TesteUnitario.Handlers
{
    public class AtualizarAnimeHandlerTesteUnitario
    {
        private readonly AnimeBuilder _animeBuilder;

        private readonly Mock<IRepositorio<Anime>> _repositorioAnimeMock;
        private readonly Mock<IValidarAnime> _validarAnime;

        private readonly AtualizarAnimeHandler _atualizarAnimeHandler;

        public AtualizarAnimeHandlerTesteUnitario()
        {
            _animeBuilder = new AnimeBuilder();

            _repositorioAnimeMock = new Mock<IRepositorio<Anime>>();
            _validarAnime = new Mock<IValidarAnime>();

            _atualizarAnimeHandler = new AtualizarAnimeHandler(_repositorioAnimeMock.Object, _validarAnime.Object);
        }

        [Fact(DisplayName = "Quando tentar atualizar um anime válido, deve validar e chamar o método de atualização do repositório")]
        public async void QuandoTentarAtualizarUmAnimeValidoDeveValidarEChamarOMetodoDeAtualizacaoDoRepositorio()
        {
            // Arrange
            var anime = new AnimeBuilder().ComId(1).ComNome("Anime Teste").Build();
            _repositorioAnimeMock.Setup(x => x.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(anime);

            // Act
            await _atualizarAnimeHandler.Handle(new AtualizarAnimeCommand(), new CancellationToken());

            // Assert
            _validarAnime.Verify(x => x.Validar(It.IsAny<TipoOperacao>(), It.IsAny<Anime>()), Times.Once);
            _repositorioAnimeMock.Verify(x => x.ObterPorIdAsync(It.IsAny<int>()), Times.Once);
            _repositorioAnimeMock.Verify(x => x.AtualizarAsync(It.IsAny<Anime>()), Times.Once);
        }

        [Fact(DisplayName = "Não deve ser válida a atualização de um anime caso ele não exista")]
        public async void NaoDeveSerValidaAAtualizacaoDeUmAnimeCasoEleNaoExista()
        {
            // Arrange
            var mensagemDeExcecaoEsperada = "Anime não encontrado";

            // Act
            var excecaoLancada = await Assert.ThrowsAsync<ValidacaoExcecao>(async () =>
            {
                await _atualizarAnimeHandler.Handle(new AtualizarAnimeCommand(), new CancellationToken());
            });

            // Assert
            Assert.Contains(mensagemDeExcecaoEsperada, excecaoLancada.Message);
        }

        [Fact(DisplayName = "Quando tentar atualizar um anime inválido, não deve chamar o método de atualização do repositório")]
        public async void QuandoTentarAtualizarUmAnimeInvalidoNaoDeveChamarOMetodoDeAtualizacaoDoRepositorio()
        {
            // Arrange
            var anime = new AnimeBuilder().ComId(1).ComNome("Anime Teste").Build();
            _repositorioAnimeMock.Setup(x => x.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(anime);
            _validarAnime.Setup(x => x.Validar(It.IsAny<TipoOperacao>(), It.IsAny<Anime>())).Throws(new ValidacaoExcecao());

            // Act
            var excecaoLancada = await Assert.ThrowsAsync<ValidacaoExcecao>(async () =>
            {
                await _atualizarAnimeHandler.Handle(new AtualizarAnimeCommand(), new CancellationToken());
            });

            // Assert
            _repositorioAnimeMock.Verify(x => x.AtualizarAsync(It.IsAny<Anime>()), Times.Never);
        }
    }
}
