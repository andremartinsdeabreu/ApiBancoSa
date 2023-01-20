using Dominio.Enums;
using System;

namespace Dominio.Models.Interfaces
{
    public interface ICredito
    {
        public double ValorCredito { get; set; }
        public TipoCredito TipoCredito { get; set; }
        public byte QuantidadeParcelas { get; set; }
        public DateTime PrimeiroVencimento { get; set; }
    }
}
