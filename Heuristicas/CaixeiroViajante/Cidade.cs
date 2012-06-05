using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace CaixeiroViajante
{
    class Cidade : IComponente
    {
        public List<Acesso> acessos;
        public string nome { get; set; }
        public Boolean cidadeVisitada { get; set; }

        public Cidade()
        {
            acessos = new List<Acesso>();
            cidadeVisitada = false;
        }
        
        void AddAcesso(Acesso acesso)
        {
            if (acesso == null)
                return;
            if (!acessos.Contains(acesso))
            {
               acessos.Add(acesso);
            }
        }

        void RemoveAcesso(Acesso acesso)
        {
            if (acesso == null)
                return;
            if (acessos.Contains(acesso))
            {
                acessos.Remove(acesso);
            }
        }

        public object Valor
        {
            get { throw new NotImplementedException(); }
        }
    }
}
