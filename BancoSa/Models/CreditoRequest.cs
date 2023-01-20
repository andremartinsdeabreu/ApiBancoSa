using Dominio.Enums;
using Dominio.Models.Interfaces;
using System;

namespace BancoSa.Models
{
    public class CreditoRequest : ICredito
    {
        public double ValorCredito { get; set; }
        public TipoCredito TipoCredito { get; set; }
        public byte QuantidadeParcelas { get; set; }
        public DateTime PrimeiroVencimento { get; set; }
    }
}
