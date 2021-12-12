using WS_Mascotas.Models.Base;
using WS_Mascotas.Models.Request;

namespace WS_Mascotas.Services
{
    public interface IUsuarioService
    {
        public void Add(Agregar model);
    }
}
