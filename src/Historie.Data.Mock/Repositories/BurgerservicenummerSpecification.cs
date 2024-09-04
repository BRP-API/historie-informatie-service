using Historie.Data.Mock.Entities;
using System.Linq.Expressions;

namespace Historie.Data.Mock.Repositories;

public class BurgerservicenummerSpecification : Specification<Persoon>
{
    private readonly string _burgerservicenummer;

    public BurgerservicenummerSpecification(string burgerservicenummer)
    {
        _burgerservicenummer = burgerservicenummer;
    }
    public override Expression<Func<Persoon, bool>> ToExpression()
    {
        return persoon => persoon != null &&
                          !string.IsNullOrWhiteSpace(persoon.BurgerserviceNummer) &&
                          persoon.BurgerserviceNummer == _burgerservicenummer;
    }
}
