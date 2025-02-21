using Historie.Data.Mock.Entities;
using Historie.Data.Mock.Generated;

namespace Historie.Data.Mock.Repositories;

public static class PersoonQueryExtensions
{
    public static Specification<Persoon> ToSpecification(this RaadpleegMetPeriode query)
    {
        return new BurgerservicenummerSpecification(query.Burgerservicenummer!)
            .And(new PeriodeSpecification(query.DatumVan!, query.DatumTot!))
            ;
    }
}
