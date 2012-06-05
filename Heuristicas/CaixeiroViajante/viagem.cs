using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace CaixeiroViajante
{
    public class Viagem : ISolucao
    {
        public Cidade partida;
        private float kmPercorridos;
        private List<IComponente> rota; 
        public List<IComponente> Componentes
        {
            get;            
            set;          
        }

        public Viagem()
        {
            Componentes = new List<IComponente>();
            rota = new List<IComponente>();
            kmPercorridos = 0;
        }

        public void GerarViagem(Cidade partida)
        {
            Acesso menorCaminho = new Acesso();
            partida.cidadeVisitada = true;
            rota.Add(partida);

            Cidade temp = EscolheCidadeProxima(partida.acessos);



           
        }

        public Cidade EscolheCidadeProxima(List<Acesso> DestPossiveis, Cidade primeira )
        {
            Cidade cidade = primeira;
            Acesso menor = (Acesso)DestPossiveis.FirstOrDefault();
            foreach (Acesso acesso in DestPossiveis)
            {
                if (menor != null)
                    if ((float)menor.km < (float)acesso.km && acesso.destino.cidadeVisitada == false)
                    {
                        menor = acesso;
                        cidade = acesso.destino;
                    }
 
            }
            return cidade;

        }
        
        public float Avaliacao
        {
            get { throw new NotImplementedException(); }
        }

        public void AddComponente(IComponente Componente)
        {
            if (Componente == null)
                return;

            Cidade cidade = (Cidade)Componente;
            

            if (!Componentes.Contains(Componente))
            {
                Componentes.Add(cidade);
            }
        }

        public void RemoveComponente(IComponente Componente)
        {
            if (Componente == null)
                return;

            Cidade cidade = (Cidade)Componente;


            if (Componentes.Contains(Componente))
            {
                Componentes.Remove(cidade);
            }
        }
    }
}
