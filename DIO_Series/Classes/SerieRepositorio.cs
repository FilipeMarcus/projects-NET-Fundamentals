using System;
using System.Collections.Generic;
using DIO_Series.Interfaces;

namespace DIO_Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();

        public void Atualiza(int id, Serie objeto) 
        {
            listaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSeries.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {   
            // Count sempre está um numero a frente do indice do vetor
            return listaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}