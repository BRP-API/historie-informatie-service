#language: nl

@proxy @geen-protocollering
Functionaliteit: leveren van adresregels wanneer land van een verblijf buitenland de standaardwaarde heeft of geen enkele adresregel een waarde heeft



  Regel: adressering voor een verblijfplaats buitenland wordt niet geleverd als 'regel 1 adres buitenland (13.30)', 'regel 2 adres buitenland (13.40)' en 'regel 3 adres buitenland (13.50)' geen waarde hebben

    Scenario: persoon heeft een verblijfplaats buitenland en 'regel 1 adres buitenland (13.30)', 'regel 2 adres buitenland (13.40)' en 'regel 3 adres buitenland (13.50)' hebben geen waarde
      Gegeven de persoon met burgerservicenummer '000000012' heeft de volgende 'verblijfplaats' gegevens
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

    Scenario: persoon heeft een verblijfplaats buitenland en alleen regel1 heeft een waarde dus adressering kan worden geleverd
      Gegeven de persoon met burgerservicenummer '000000012' heeft de volgende 'verblijfplaats' gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adres buitenland (13.20) | land (13.10) | regel 1 adres buitenland (13.30) |
      | 1999                              | 20231014                               | 6014         | Rue du pomme 26                  |
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
      | regel1            | Rue du pomme 26              |
      En heeft het verblijfplaats voorkomen de volgende 'adressering' gegevens
      | naam              | waarde                       |
      | land.code         | 6014                         |
      | land.omschrijving | Verenigde Staten van Amerika |
      | adresregel1       | Rue du pomme 26              |

    Scenario: persoon heeft een verblijfplaats buitenland en alleen regel2 heeft een waarde dus adressering kan worden geleverd
      Gegeven de persoon met burgerservicenummer '000000012' heeft de volgende 'verblijfplaats' gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adres buitenland (13.20) | land (13.10) | regel 2 adres buitenland (13.40) |
      | 1999                              | 20231014                               | 6014         | Rue du pomme 26                  |
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
      | regel2            | Rue du pomme 26              |
      En heeft het verblijfplaats voorkomen de volgende 'adressering' gegevens
      | naam              | waarde                       |
      | land.code         | 6014                         |
      | land.omschrijving | Verenigde Staten van Amerika |
      | adresregel2       | Rue du pomme 26              |

    Scenario: persoon heeft een verblijfplaats buitenland en alleen regel3 heeft een waarde dus adressering kan worden geleverd
      Gegeven de persoon met burgerservicenummer '000000012' heeft de volgende 'verblijfplaats' gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adres buitenland (13.20) | land (13.10) | regel 3 adres buitenland (13.50) |
      | 1999                              | 20231014                               | 6014         | Rue du pomme 26                  |
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
      | regel3            | Rue du pomme 26              |
      En heeft het verblijfplaats voorkomen de volgende 'adressering' gegevens
      | naam              | waarde                       |
      | land.code         | 6014                         |
      | land.omschrijving | Verenigde Staten van Amerika |
      | adresregel3       | Rue du pomme 26              |
