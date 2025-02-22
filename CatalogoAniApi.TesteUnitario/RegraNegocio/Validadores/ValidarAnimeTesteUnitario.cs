using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Enumeradores;
using CatalogoAniApi.Modelo.Excecoes;
using CatalogoAniApi.RegraNegocio.Interfaces;
using CatalogoAniApi.RegraNegocio.Validadores;
using CatalogoAniApi.TesteUnitario.RegraNegocio.Validadores.DadosParaTeste;

namespace CatalogoAniApi.TesteUnitario.RegraNegocio.Validadores
{
    public class ValidarAnimeTesteUnitario
    {
        private readonly IValidarAnime _validarAnime;

        public ValidarAnimeTesteUnitario()
        {
            _validarAnime = new ValidarAnime();
        }

        [Theory(DisplayName = "Não deve lançar exceção quando validar um anime com informações válidas.")]
        [InlineData(TipoOperacao.Adicionar)]
        [InlineData(TipoOperacao.Atualizar)]
        public void NaoDeveLancarExcecaoQuandoValidarUmAnimeComInformacoesValidas(TipoOperacao tipoOperacao)
        {
            var anime = new Anime
            {
                Nome = "Anime Teste",
                Diretor = "Diretor Teste",
                Resumo = "Resumo Teste de anime"
            };

            _validarAnime.Validar(tipoOperacao, anime);
        }

        [Theory(DisplayName = "Não deve ser permitido inserir ou atualizar um anime com nome vazio ou nulo.")]
        [MemberData(nameof(ValidarAnimeDadosParaTeste.ObterOperacaoEAnimeComNomeInvalido), MemberType = typeof(ValidarAnimeDadosParaTeste))]
        public void NaoDeveSerPermitidoInserirOuAtualizarUmAnimeComNomeVazioOuNulo(TipoOperacao tipoOperacao, Anime anime)
        {
            var mensagemDeExcecaoEsperada = "Nome do anime é obrigatório.";

            var excecaoLancada = Assert.Throws<ValidacaoExcecao>(() =>
            {
                _validarAnime.Validar(tipoOperacao, anime);
            });

            Assert.Contains(mensagemDeExcecaoEsperada, excecaoLancada.Message);
        }

        [Theory(DisplayName = "Não deve ser permitido inserir ou atualizar um anime com nome com menos que dois caracteres.")]
        [MemberData(nameof(ValidarAnimeDadosParaTeste.ObterOperacaoEAnimeComQuantidadeDeCaracteresInsuficiente), MemberType = typeof(ValidarAnimeDadosParaTeste))]
        public void NaoDeveSerPermitidoInserirOuAtualizarUmAnimeComNomeComMenosQueDoisCaracteres(TipoOperacao tipoOperacao, Anime anime)
        {
            var mensagemDeExcecaoEsperada = "Tamanho minímo para o campo Nome é de dois caracteres.";

            var excecaoLancada = Assert.Throws<ValidacaoExcecao>(() =>
            {
                _validarAnime.Validar(tipoOperacao, anime);
            });

            Assert.Contains(mensagemDeExcecaoEsperada, excecaoLancada.Message);
        }

        [Theory(DisplayName = "Não deve ser permitido inserir ou atualizar um anime com diretor vazio ou nulo.")]
        [MemberData(nameof(ValidarAnimeDadosParaTeste.ObterOperacaoEAnimeComDiretorInvalido), MemberType = typeof(ValidarAnimeDadosParaTeste))]
        public void NaoDeveSerPermitidoInserirOuAtualizarUmAnimeComDiretorVazioOuNulo(TipoOperacao tipoOperacao, Anime anime)
        {
            var mensagemDeExcecaoEsperada = "Diretor do anime é obrigatório.";

            var excecaoLancada = Assert.Throws<ValidacaoExcecao>(() =>
            {
                _validarAnime.Validar(tipoOperacao, anime);
            });

            Assert.Contains(mensagemDeExcecaoEsperada, excecaoLancada.Message);
        }

        [Theory(DisplayName = "Não deve ser permitido inserir ou atualizar um anime com resumo vazio ou nulo.")]
        [MemberData(nameof(ValidarAnimeDadosParaTeste.ObterOperacaoEAnimeComResumoInvalido), MemberType = typeof(ValidarAnimeDadosParaTeste))]
        public void NaoDeveSerPermitidoInserirOuAtualizarUmAnimeComResumoVazioOuNulo(TipoOperacao tipoOperacao, Anime anime)
        {
            var mensagemDeExcecaoEsperada = "Resumo do anime é obrigatório.";

            var excecaoLancada = Assert.Throws<ValidacaoExcecao>(() =>
            {
                _validarAnime.Validar(tipoOperacao, anime);
            });

            Assert.Contains(mensagemDeExcecaoEsperada, excecaoLancada.Message);
        }

        [Theory(DisplayName = "Não deve ser permitido inserir ou atualizar um anime com resumo com menos de dez caracteres.")]
        [MemberData(nameof(ValidarAnimeDadosParaTeste.ObterOperacaoEAnimeComResumoComQuantidadeDeCaracteresInvalido), MemberType = typeof(ValidarAnimeDadosParaTeste))]
        public void NaoDeveSerPermitidoInserirOuAtualizarUmAnimeComResumoComMenosDeDezCaracteres(TipoOperacao tipoOperacao, Anime anime)
        {
            var mensagemDeExcecaoEsperada = "Tamanho minímo do resumo é de dez caracteres.";

            var excecaoLancada = Assert.Throws<ValidacaoExcecao>(() =>
            {
                _validarAnime.Validar(tipoOperacao, anime);
            });

            Assert.Contains(mensagemDeExcecaoEsperada, excecaoLancada.Message);
        }
    }
}
