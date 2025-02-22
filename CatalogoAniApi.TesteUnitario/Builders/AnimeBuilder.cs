using CatalogoAniApi.Modelo.Entidades;

namespace CatalogoAniApi.TesteUnitario.Builders
{
    public class AnimeBuilder
    {
        private int _id;
        private string? _nome;
        private string? _diretor;
        private string? _resumo;

        public AnimeBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public AnimeBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public AnimeBuilder ComDiretor(string diretor)
        {
            _diretor = diretor;
            return this;
        }

        public AnimeBuilder ComResumo(string resumo)
        {
            _resumo = resumo;
            return this;
        }

        public Anime Build()
        {
            return new Anime
            {
                Id = _id,
                Nome = _nome,
                Diretor = _diretor,
                Resumo = _resumo
            };
        }
    }
}
