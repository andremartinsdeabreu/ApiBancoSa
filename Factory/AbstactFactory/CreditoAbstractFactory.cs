using Dominio.Models.Base;
using Dominio.Models.Interfaces;

namespace Factory.AbstactFactory
{
    public abstract class CreditoAbstractFactory
    {
        public abstract CreditoBase CriaCredito();
        public static CreditoAbstractFactory CreateFactory(ICredito credito)
        {
            return new CreditoFactory(credito);
        }
    }
}
