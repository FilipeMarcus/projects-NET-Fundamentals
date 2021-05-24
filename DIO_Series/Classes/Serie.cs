using System;

namespace DIO_Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        public Serie(int mco_id, Genero mco_genero, string mco_titulo, string mco_descricao,
                                                                                int mco_ano)
        {
            this.id = mco_id;
            this.Genero = mco_genero;
            this.Titulo = mco_titulo;
            this.Descricao = mco_descricao;
            this.Ano = mco_ano;
            this.Excluido = false;
        }
        public override string ToString()
        {   //  Environment.NewLine =   \n pra qualquer sistema
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaID()
        {
            return this.id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}