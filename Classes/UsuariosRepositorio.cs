using System;
using System.Collections.Generic;
using SeriesFavoritas.Interfaces;

namespace SeriesFavoritas 
{
    public class UsuariosRepositorio : IUsuarios<Pessoa>
    {
        private List<Pessoa> listaNomes = new List<Pessoa>();
		public void Atualiza(int id, Pessoa objeto)
		{
			listaNomes[id] = objeto;
		}

            public void Exclui(int id)
		{
			listaNomes[id].Excluir();
		}

		public void InsereNome(Pessoa objeto)
		{
			listaNomes.Add(objeto);
		}


        public List<Pessoa> ListaUsuarios()
        {
            return listaNomes;
        }

        public int ProximoId()
		{
			return listaNomes.Count;
		}

		public Pessoa RetornaPorId(int id)
		{
			return listaNomes[id];
		}

        
    }
}