using Dominio.Enums;
using Dominio.Models;
using Dominio.Models.Base;
using Dominio.Models.Interfaces;
using System;

namespace Factory.AbstactFactory
{
    public sealed class CreditoFactory : CreditoAbstractFactory
    {
        private readonly ICredito _credito;
        public CreditoFactory(ICredito credito)
        {
            _credito = credito;
        }
        public override CreditoBase CriaCredito()
        {
            return _credito.TipoCredito switch
            {
                TipoCredito.Direto => new CreditoDireto(_credito),
                TipoCredito.Consignado => new CreditoConsignado(_credito),
                TipoCredito.PessoaJuridica => new CreditoPessoaJuridica(_credito),
                TipoCredito.PessoaFisica => new CreditoPessoaFisica(_credito),
                TipoCredito.Imobiliario => new CreditoImobiliario(_credito),
                _ => throw new ArgumentOutOfRangeException("Tipo não implementado"),
            };
        }
    }
}
