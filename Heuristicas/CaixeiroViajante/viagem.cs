using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace CaixeiroViajante
{
    public class Viagem : ISolucao
    {
        public string cidPartida;
        public float kmPercorridos;
        public List<IComponente> rota;
        public List<IComponente> Componentes
        {
            get;
            set;
        }

        public float Avaliacao
        {
            get { return kmPercorridos; }
        }

        public Viagem()
        {
            Componentes = new List<IComponente>();
            rota = new List<IComponente>();
            kmPercorridos = 0;

        }

        public void AddComponente(IComponente Componente)
        {
            if (Componente == null)
                return;
            Acesso aresta = (Acesso)Componente;
            if (!Componentes.Contains(Componente))
                Componentes.Add(aresta);
        }

        public void RemoveComponente(IComponente Componente)
        {
            if (Componente == null)
                return;
            Acesso aresta = (Acesso)Componente;
            if (Componentes.Contains(Componente))
                Componentes.Remove(aresta);
        }


        public void GerarViagem(string partida)
        {
            kmPercorridos = 0;
            Acesso tmp = new Acesso();
            // procurar na lista de componentes a primeira aresta que a cidade de partida seja igual a recebida pela função
            foreach (Acesso a in Componentes)
            {
                if (a.cidPartida == partida)
                {
                    tmp = a;
                    break;
                }
            }
            // buscando a cidade mais próxima da partida
            foreach (Acesso a in Componentes)
                if (a.cidPartida == partida && a.km < tmp.km)
                    tmp = a;

            kmPercorridos = tmp.km;
            rota.Add(tmp);
            Boolean gerandoRota = true;
            Acesso inRota = (Acesso)rota.FirstOrDefault();

            while (gerandoRota == true)
            {
                tmp = EscolheCidadeProxima();

                // verifica se é o final da rota
                if (tmp.cidDestino == inRota.cidPartida)                
                    gerandoRota = false;                    
               
                rota.Add(tmp);
                kmPercorridos += tmp.km;
            }
        }

        private Acesso EscolheCidadeProxima()
        {
            Acesso fimRota = (Acesso)rota.LastOrDefault();// cidade atual
            Acesso inRota = (Acesso)rota.FirstOrDefault();
            Acesso temp = new Acesso();
            Acesso menor = new Acesso();
            Boolean cidVisit;

            foreach (Acesso acesso in Componentes)
            {
                if (acesso.cidPartida == fimRota.cidDestino && acesso.cidDestino != inRota.cidPartida)
                {
                    if (menor.km == -1 || acesso.km < menor.km)
                    {
                        // verifica se cidade ja foi visitada
                        cidVisit = false;
                        foreach (Acesso tmp in rota)
                        {
                            if (tmp.cidPartida == acesso.cidDestino)
                            {
                                cidVisit = true;                                
                                break;
                            }
                        } // encerra verificação de cidade visitada

                        // se a cidade não foi visitada e a distancia for menor troca o valor a ser retornado 
                        if (cidVisit == false)                        
                            menor = acesso;                                                    
                    }
                }
                else if (acesso.cidDestino == inRota.cidPartida)
                        temp = acesso;
            }

            // caso não haja outra cidade a ser visitada manda a aresta que encerra a rota.
            if (menor.km == -1)            
                menor = temp;
            
            return menor;
        }       
    }
}