using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Profiles;

public class VerblijfplaatsVoorkomenConverter : ITypeConverter<GbaVerblijfplaatsVoorkomen, AbstractVerblijfplaatsVoorkomen?>
{
    public AbstractVerblijfplaatsVoorkomen? Convert(GbaVerblijfplaatsVoorkomen source, AbstractVerblijfplaatsVoorkomen? destination, ResolutionContext context)
    {
        if (source == null) return null;
        if (source.IsOnbekendVerblijfplaatsBuitenlandVoorkomen()) return context.Mapper.Map<VerblijfplaatsOnbekendVoorkomen>(source);
        if (source.IsVerblijfplaatsBuitenlandVoorkomen()) return context.Mapper.Map<VerblijfplaatsBuitenlandVoorkomen>(source);
        if (source.IsAdresVoorkomen()) return context.Mapper.Map<AdresVoorkomen>(source);
        if (source.IsLocatieVoorkomen()) return context.Mapper.Map<LocatieVoorkomen>(source);
        return null;
    }
}

internal static class VerblijfplaatsVoorkomenConverterExtensions
{
    internal static bool IsAdresVoorkomen(this GbaVerblijfplaatsVoorkomen source) => !string.IsNullOrWhiteSpace(source.Straat);
    internal static bool IsLocatieVoorkomen(this GbaVerblijfplaatsVoorkomen source) => !string.IsNullOrWhiteSpace(source.Locatiebeschrijving);
    internal static bool IsVerblijfplaatsBuitenlandVoorkomen(this GbaVerblijfplaatsVoorkomen source) => source.Land != null && source.Land.Code != "0000";
    internal static bool IsOnbekendVerblijfplaatsBuitenlandVoorkomen(this GbaVerblijfplaatsVoorkomen source) => source.Land != null && source.Land.Code == "0000";
}
