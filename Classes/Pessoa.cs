using System;

namespace SeriesFavoritas
{
    public class Pessoa : EntidadeBase
    {
        private string? Nome { get; set; }
        private bool Excluido {get; set;}
        public Pessoa(string nome, int id)
        {
            this.Nome = nome;
            this.Id = id;
        }


        public override string ToString()
        {
            string retorno = "";
            retorno += "Digite o seu nome: " + this.Nome + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
           
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}
