#language: nl

@proxy @geen-protocollering
Functionaliteit: raadplegen historie levert opschorting bijhouding

    Achtergrond:
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | straatnaam (11.10) |
      | 0800                 | Korte straatnaam   |

  
  Regel: opschortingBijhouding wordt geleverd

    Abstract Scenario: historie wordt gevraagd van persoon waarvoor de bijhouding is opgeschort
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20220801                           |
      En de persoon heeft de volgende 'inschrijving' gegevens
      | naam                                 | waarde                         |
      | reden opschorting bijhouding (67.20) | <reden opschorting bijhouding> |
      | datum opschorting bijhouding (67.10) | 20220829                       |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2022-01-01          |
      | datumTot            | 2023-01-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type  | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | datumVan.type | datumVan.datum | datumVan.langFormaat | functieAdres.code | functieAdres.omschrijving |
      | Adres | 0800                         | Hoogeloon, Hapert en Casteren        | Datum         | 2022-08-01     | 1 augustus 2022      | W                 | woonadres                 |
      En heeft het verblijfplaats voorkomen de volgende 'adressering' gegevens
      | adresregel1      |
      | Korte straatnaam |
      En heeft het verblijfplaats voorkomen de volgende 'verblijfadres' gegevens
      | korteStraatnaam  |
      | Korte straatnaam |
      En heeft de response de volgende gegevens
      | naam               | waarde                           |
      | opschortingBijhouding.reden.code         | <reden opschorting bijhouding>   |
      | opschortingBijhouding.reden.omschrijving | <reden opschorting omschrijving> |
      | opschortingBijhouding.datum.type         | Datum                            |
      | opschortingBijhouding.datum.datum        | 2022-08-29                       |
      | opschortingBijhouding.datum.langFormaat  | 29 augustus 2022                 |

      Voorbeelden:
      | reden opschorting bijhouding | reden opschorting omschrijving |
      | O                            | overlijden                     |
      | E                            | emigratie                      |
      | M                            | ministerieel besluit           |
      | R                            | pl is aangelegd in de rni      |
      | .                            | onbekend                       |
