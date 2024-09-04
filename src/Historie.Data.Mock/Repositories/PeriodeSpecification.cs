using Historie.Data.Mock.Entities;
using Historie.Data.Mock.Extensions;
using Historie.Data.Mock.Repositories;
using System.Linq.Expressions;

namespace Historie.Data.Mock.Repositories;

public class PeriodeSpecification : Specification<Persoon>
{
    private readonly string _datumVan;
    private readonly string _datumTot;

    public PeriodeSpecification(string datumVan, string datumTot)
    {
        _datumVan = datumVan;
        _datumTot = datumTot;
    }
    public override Expression<Func<Persoon, bool>> ToExpression()
    {
        return persoon => persoon != null &&
                          persoon.Verblijfplaats != null &&
                          (persoon.Verblijfplaats.DatumAanvangAdreshouding != null &&
                          _datumTot.ToDateTimeOffset().ToNumber() > persoon.Verblijfplaats.DatumAanvangAdreshouding.ToNumber() ||
                          persoon.Verblijfplaats.DatumAanvangAdresBuitenland != null &&
                          _datumTot.ToDateTimeOffset().ToNumber() > persoon.Verblijfplaats.DatumAanvangAdresBuitenland.ToNumber())
                          &&
                          (
                           persoon.Verblijfplaats.DatumEindeAdreshouding == null &&
                            persoon.Verblijfplaats.DatumEindeAdresBuitenland == null
                           ||
                           persoon.Verblijfplaats.DatumEindeAdreshouding != null &&
                            _datumVan.ToDateTimeOffset().ToNumber() < persoon.Verblijfplaats.DatumEindeAdreshouding.ToNumber()

                           ||
                           persoon.Verblijfplaats.DatumEindeAdresBuitenland != null &&
                            _datumVan.ToDateTimeOffset().ToNumber() < persoon.Verblijfplaats.DatumEindeAdresBuitenland.ToNumber()

                          );
    }
}
