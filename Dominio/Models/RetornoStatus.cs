using Dominio.Enums;

namespace Dominio.Models
{
    public class RetornoStatus
    {
        public StatusCredito Status { get; set; }
        public double ValorTotal { get; set; }
        public double ValorJuros { get; set; }
    }
}
