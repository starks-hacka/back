using System;
using XPInc.Hackathon.Starks.Domain.SeedWork;

namespace XPInc.Hackathon.Starks.Domain.AggregatesModel.AlertAggregate
{
    public class Alert : Entity, IAggregateRoot
    {
        public string Alerta { get; private set; }
        public string Host { get; private set; }
        public string Prioridade { get; private set; }
        public string Ambiente { get; private set; }
        public string Corretora { get; private set; }
        public string Equipe { get; private set; }
        public string Email_app { get; private set; }
        public string Criticidade { get; private set; }
        public string Status { get; private set; }

        public Alert(string alerta, string host, string prioridade, string ambiente, 
            string corretora, string equipe, string email_app, string criticidade, string status, Guid id) : base(id)
        {
            Alerta = alerta;
            Host = host;
            Prioridade = prioridade;
            Ambiente = ambiente;
            Corretora = corretora;
            Equipe = equipe;
            Email_app = email_app;
            Criticidade = criticidade;
            Status = status;
        }
    }
}
