#language: nl

Functionaliteit: leveren van adresregels wanneer land van een verblijf buitenland de standaardwaarde heeft of geen enkele adresregel een waarde heeft


  Regel: adressering voor een verblijfplaats buitenland wordt niet geleverd als 'land (13.10)' de standwaarde 0000 heeft

    Scenario: persoon heeft een verblijfplaats buitenland en 'land (13.10)' heeft de standaardwaarde
      Gegeven de persoon met burgerservicenummer '000000012' heeft de volgende 'verblijfplaats' gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adres buitenland (13.20) | land (13.10) | regel 1 adres buitenland (13.30) | regel 2 adres buitenland (13.40) | regel 3 adres buitenland (13.50) |
      | 1999                              | 20231014                               | 0000         | Rue du pomme 26                  | Bruxelles                        | postcode 1000                    |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2024-01-01          |
      | datumTot            | 2024-07-01          |
      Dan heeft de response een verblijfplaats voorkomen met de volgende gegevens
      | type                     | datumVan.type | datumVan.datum | datumVan.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving |
      | VerblijfplaatsBuitenland | Datum         | 2023-10-14     | 14 oktober 2023      | 1999                         | Registratie Niet Ingezetenen (RNI)   |
      En heeft het verblijfplaats voorkomen de volgende 'verblijfadres' gegevens
      | naam   | waarde          |
      | regel1 | Rue du pomme 26 |
      | regel2 | Bruxelles       |
      | regel3 | postcode 1000   |


  Regel: adressering voor een verblijfplaats buitenland wordt niet geleverd als 'regel 1 adres buitenland (13.30)', 'regel 2 adres buitenland (13.40)' en 'regel 3 adres buitenland (13.50)' geen waarde hebben

    Scenario: persoon heeft een verblijfplaats buitenland en 'regel 1 adres buitenland (13.30)', 'regel 2 adres buitenland (13.40)' en 'regel 3 adres buitenland (13.50)' hebben geen waarde
      Gegeven de persoon met burgerservicenummer '000000346' heeft de volgende 'verblijfplaats' gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adres buitenland (13.20) | land (13.10) |
      | 1999                              | 20231014                               | 6014         |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2024-01-01          |
      | datumTot            | 2024-07-01          |
      Dan heeft de response een verblijfplaats voorkomen met de volgende gegevens
      | type                     | datumVan.type | datumVan.datum | datumVan.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving |
      | VerblijfplaatsBuitenland | Datum         | 2023-10-14     | 14 oktober 2023      | 1999                         | Registratie Niet Ingezetenen (RNI)   |
      En heeft het verblijfplaats voorkomen de volgende 'verblijfadres' gegevens
      | naam              | waarde                       |
      | land.code         | 6014                         |
      | land.omschrijving | Verenigde Staten van Amerika |

    Abstract Scenario: persoon heeft een verblijfplaats buitenland en <omschrijving> dus adressering kan worden geleverd
      Gegeven de persoon met burgerservicenummer '000000346' heeft de volgende 'verblijfplaats' gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adres buitenland (13.20) | land (13.10) | regel 1 adres buitenland (13.30) | regel 2 adres buitenland (13.40) | regel 3 adres buitenland (13.50) |
      | 1999                              | 20231014                               | 6014         | <regel1>                         | <regel2>                         | <regel3>                         |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2024-01-01          |
      | datumTot            | 2024-07-01          |
      Dan heeft de response een verblijfplaats voorkomen met de volgende gegevens
      | type                     | datumVan.type | datumVan.datum | datumVan.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving |
      | VerblijfplaatsBuitenland | Datum         | 2023-10-14     | 14 oktober 2023      | 1999                         | Registratie Niet Ingezetenen (RNI)   |
      En heeft het verblijfplaats voorkomen de volgende 'verblijfadres' gegevens
      | naam              | waarde                       |
      | land.code         | 6014                         |
      | land.omschrijving | Verenigde Staten van Amerika |
      | regel1            | <regel1>                     |
      | regel2            | <regel2>                     |
      | regel3            | <regel3>                     |
      En heeft het verblijfplaats voorkomen de volgende 'adressering' gegevens
      | naam              | waarde                       |
      | land.code         | 6014                         |
      | land.omschrijving | Verenigde Staten van Amerika |
      | adresregel1       | <regel1>                     |
      | adresregel2       | <regel2>                     |
      | adresregel3       | <regel3>                     |

      Voorbeelden:
      | regel1          | regel2    | regel3        | omschrijving                    |
      | Rue du pomme 26 |           |               | alleen regel1 heeft een waarde  |
      |                 | Bruxelles |               | alleen regel2 heeft een waarde  |
      |                 |           | postcode 1000 | alleen regel3 heeft eeen waarde |
