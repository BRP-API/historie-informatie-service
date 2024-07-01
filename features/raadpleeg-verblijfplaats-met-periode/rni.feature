# language: nl

@api @geen-protocollering
Functionaliteit: RNI-deelnemer gegevens leveren voor verblijfplaatshistorie met periode

    Achtergrond:
      Gegeven landelijke tabel 'RNI-deelnemerstabel' heeft de volgende waarden
      | code | omschrijving                                                       |
      | 0201 | Sociale Verzekeringsbank (inzake AOW, Anw en AKW)                  |
      

  Regel: RNI-deelnemer gegevens op een geleverde verblijfplaats worden geleverd

    Scenario: In de periode heeft de persoon verblijfplaats buitenland met RNI-deelnemer gegevens 
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op een buitenlands adres met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adres buitenland (13.20) | land adres buitenland (13.10) | regel 1 adres buitenland (13.30) | rni-deelnemer (88.10) | omschrijving verdrag (88.20)         |
      | 1999                              | 20070516                               | 6014                          | Die Straße                       | 0201                  | Artikel 45 EU-Werkingsverdrag (VWEU) |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2022-01-01          |
      | datumTot            | 2023-01-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type                     | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | datumVan.type | datumVan.datum | datumVan.langFormaat |
      | VerblijfplaatsBuitenland | 1999                         | Registratie Niet Ingezetenen (RNI)   | Datum         | 2007-05-16     | 16 mei 2007          |
      En heeft het verblijfplaats voorkomen de volgende 'verblijfadres' gegevens
      | naam              | waarde                       |
      | land.code         | 6014                         |
      | land.omschrijving | Verenigde Staten van Amerika |
      | regel1            | Die Straße                   |
      En heeft het verblijfplaats voorkomen de volgende 'adressering' gegevens
      | naam              | waarde                       |
      | land.code         | 6014                         |
      | land.omschrijving | Verenigde Staten van Amerika |
      | adresregel1       | Die Straße                   |
      En heeft het verblijfplaats voorkomen de volgende 'rni' gegevens
      | naam                   | waarde                                            |
      | deelnemer.code         | 0201                                              |
      | deelnemer.omschrijving | Sociale Verzekeringsbank (inzake AOW, Anw en AKW) |
      | omschrijvingVerdrag    | Artikel 45 EU-Werkingsverdrag (VWEU)              |
   