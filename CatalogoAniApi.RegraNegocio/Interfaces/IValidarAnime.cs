using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Enumeradores;

namespace CatalogoAniApi.RegraNegocio.Interfaces
{
    public interface IValidarAnime
    {
        void Validar(TipoOperacao tipoOperacao, Anime anime);
    }
}
