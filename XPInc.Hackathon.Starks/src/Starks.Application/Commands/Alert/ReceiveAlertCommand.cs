using MediatR;

namespace XPInc.Hackathon.Starks.Application.Commands.Alert
{
    public class ReceiveAlertCommand : IRequest<bool>
    {
        public string Alerta { get; set; }
        public string Host { get; set; }
        public string Prioridade { get; set; }
        public string Ambiente { get; set; }
        public string Corretora { get; set; }
        public string Equipe { get; set; }
        public string Email_app { get; set; }
        public string Criticidade { get; set; }
        public string Status { get; set; }
    }
}
