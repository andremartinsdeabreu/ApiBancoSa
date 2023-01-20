using Dominio.Enums;

namespace Domain.Models.Interfaces
{
    public interface IRetorno
    {
        public StatusCredito Status { get; set; }
        public double ValorTotal { get; set; }
        public double ValorJuros { get; set; }
    }
}
