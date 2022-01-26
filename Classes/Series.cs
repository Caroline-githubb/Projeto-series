using System;

namespace SeriesFavoritas
{
    public class Series : EntidadeBase
    {
        private string? Titulo { get; set; }
        private Genero Genero { get; set; }
        private string? Descricao { get; set; }
        private string SeriesFavoritas { get; set; }
        private int Temporadas { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Series(int id, Genero genero, string? titulo, int ano, int temporadas, string? descricao)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Ano = ano;
            Descricao = descricao;
            Temporadas = temporadas;
            Excluido = false;

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Temporadas: " + this.Temporadas + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
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