#language: nl

@proxy @geen-protocollering
Functionaliteit: raadplegen verblijfplaatshistorie levert geheimhoudingPersoonsgegevens


  Regel: Indicatie geheim met waarde hoger dan 0 wordt altijd meegeleverd

    Abstract Scenario: gevraagde persoon heeft indicatie geheim met waarde <indicatie geheim>
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) | straatnaam (11.10) |
      | 0800                 | 0800010000000001                         | Teststraat         |
      En de persoon met burgerservicenummer '000000024' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20100818                           |
      En de persoon heeft de volgende 'inschrijving' gegevens
      | indicatie geheim (70.10) |
      | <indicatie geheim>       |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000024           |
      | datumVan            | 2010-07-01          |
      | datumTot            | 2020-07-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type  | datumVan.type | datumVan.datum | datumVan.langFormaat | adresseerbaarObjectIdentificatie | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | functieAdres.code | functieAdres.omschrijving | verblijfadres.korteStraatnaam | adressering.adresregel1 |
      | Adres | Datum         | 2010-08-18     | 18 augustus 2010     | 0800010000000001                 | 0800                         | Hoogeloon, Hapert en Casteren        | W                 | woonadres                 | Teststraat                    | Teststraat              |
      En heeft de response de volgende gegevens
      | geheimhoudingPersoonsgegevens |
      | true                          |

      Voorbeelden:
      | indicatie geheim | geleverd indicatie geheim |
      | 1                | 1                         |
      | 2                | 2                         |
      | 3                | 3                         |
      | 4                | 4                         |
      | 5                | 5                         |
      | 6                | 6                         |
      | 7                | 7                         |

  Scenario: gevraagde persoon heeft indicatie geheim met waarde 0
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) | straatnaam (11.10) |
      | 0800                 | 0800010000000001                         | Teststraat         |
      En de persoon met burgerservicenummer '000000024' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20100818                           |
      En de persoon heeft de volgende 'inschrijving' gegevens
      | indicatie geheim (70.10) |
      | 0                        |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000024           |
      | datumVan            | 2010-07-01          |
      | datumTot            | 2020-07-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type  | datumVan.type | datumVan.datum | datumVan.langFormaat | adresseerbaarObjectIdentificatie | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | functieAdres.code | functieAdres.omschrijving | verblijfadres.korteStraatnaam | adressering.adresregel1 |
      | Adres | Datum         | 2010-08-18     | 18 augustus 2010     | 0800010000000001                 | 0800                         | Hoogeloon, Hapert en Casteren        | W                 | woonadres                 | Teststraat                    | Teststraat              |
