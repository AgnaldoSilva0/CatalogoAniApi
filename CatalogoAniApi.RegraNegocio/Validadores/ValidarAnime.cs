using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Enumeradores;
using CatalogoAniApi.Modelo.Excecoes;
using CatalogoAniApi.RegraNegocio.Interfaces;

namespace CatalogoAniApi.RegraNegocio.Validadores
{
    public class ValidarAnime : IValidarAnime
    {
        public void Validar(TipoOperacao tipoOperacao, Anime anime)
        {
            switch (tipoOperacao)
            {
                case TipoOperacao.Adicionar:
                    ValidarAdicao(anime);
                    break;
                case TipoOperacao.Atualizar:
                    ValidarAtualizacao(anime);
                    break;
                case TipoOperacao.Deletar:
                    break;
                default:
                    break;
            }
        }

        private void ValidarAdicao(Anime anime)
        {
            ValidarNome(anime.Nome);
            ValidarDiretor(anime.Diretor);
            ValidarResumo(anime.Resumo);
        }

        private void ValidarAtualizacao(Anime anime)
        {
            ValidarNome(anime.Diretor);
            ValidarDiretor(anime.Diretor);
            ValidarResumo(anime.Resumo);
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ValidacaoExcecao("Nome do anime é obrigatório.");
            }

            if (nome.Count() < 2)
            {
                throw new ValidacaoExcecao("Tamanho minímo para o campo Nome é de dois caracteres.");
            }
        }

        private void ValidarDiretor(string diretor)
        {
            if (string.IsNullOrWhiteSpace(diretor))
            {
                throw new ValidacaoExcecao("Diretor do anime é obrigatório.");
            }
        }

        private void ValidarResumo(string resumo)
        {
            if (string.IsNullOrWhiteSpace(resumo))
            {
                throw new ValidacaoExcecao("Resumo do anime é obrigatório.");
            }

            if (resumo.Count() < 10)
            {
                throw new ValidacaoExcecao("Tamanho minímo do resumo para o campo Nome é de dez caracteres.");
            }
        }
    }
}
