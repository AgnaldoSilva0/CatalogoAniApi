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
    public class CadastrarAnimeHandlerTesteUnitario
    {
        private readonly AnimeBuilder _animeBuilder;

        private readonly Mock<IRepositorio<Anime>> _repositorioAnimeMock;
        private readonly Mock<IValidarAnime> _validarAnime;

        private readonly CadastrarAnimeHandler _cadastrarAnimeHandler;

        public CadastrarAnimeHandlerTesteUnitario()
        {
            _animeBuilder = new AnimeBuilder();

            _repositorioAnimeMock = new Mock<IRepositorio<Anime>>();
            _validarAnime = new Mock<IValidarAnime>();

            _cadastrarAnimeHandler = new CadastrarAnimeHandler(_repositorioAnimeMock.Object, _validarAnime.Object);
        }

        [Fact(DisplayName = "Quando tentar cadastrar um anime válido, deve validar e chamar o método de atualização do repositório")]
        public async void QuandoTentarCadastrarUmAnimeValidoDeveValidarEChamarOMetodoDeCadastroDoRepositorio()
        {
            // Arrange
            var anime = new AnimeBuilder().ComId(1).ComNome("Anime Teste").Build();
            _repositorioAnimeMock.Setup(x => x.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(anime);

            // Act
            await _cadastrarAnimeHandler.Handle(new CadastrarAnimeCommand(), new CancellationToken());

            // Assert
            _validarAnime.Verify(x => x.Validar(It.IsAny<TipoOperacao>(), It.IsAny<Anime>()), Times.Once);
            _repositorioAnimeMock.Verify(x => x.AdicionarAsync(It.IsAny<Anime>()), Times.Once);
        }

        [Fact(DisplayName = "Quando tentar cadastrar um anime inválido, não deve chamar o método de atualização do repositório")]
        public async void QuandoTentarCadastrarUmAnimeInvalidoNaoDeveChamarOMetodoDeCadastroDoRepositorio()
        {
            // Arrange
            var anime = new AnimeBuilder().ComId(1).ComNome("Anime Teste").Build();
            _repositorioAnimeMock.Setup(x => x.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(anime);
            _validarAnime.Setup(x => x.Validar(It.IsAny<TipoOperacao>(), It.IsAny<Anime>())).Throws(new ValidacaoExcecao());

            // Act
            var excecaoLancada = await Assert.ThrowsAsync<ValidacaoExcecao>(async () =>
            {
                await _cadastrarAnimeHandler.Handle(new CadastrarAnimeCommand(), new CancellationToken());
            });

            // Assert
            _repositorioAnimeMock.Verify(x => x.AdicionarAsync(It.IsAny<Anime>()), Times.Never);
        }
    }
}
