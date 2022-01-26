using System.Collections.Generic;

namespace SeriesFavoritas.Interfaces
{
    public interface IUsuarios<T>
    {
        List<T> ListaUsuarios();
        T RetornaPorId(int id);
        void InsereNome(T entidadenome);
        void Exclui(int id);
    
       int ProximoId();


    }
}