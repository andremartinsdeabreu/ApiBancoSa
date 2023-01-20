using Domain.Models.Interfaces;
using Dominio.Enums;

namespace BancoSa.Models
{
    public class CreditoResponse : IRetorno
    {
        public StatusCredito Status { get; set; }
        public double ValorTotal { get; set; }
        public double ValorJuros { get; set; }
    }
}
