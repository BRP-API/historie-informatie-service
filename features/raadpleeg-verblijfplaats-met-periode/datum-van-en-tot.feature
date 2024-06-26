#language: nl

@proxy @geen-protocollering @valideer-volgorde
Functionaliteit: leveren van datumVan en datumTot voor geleverde verblijfplaatsen

    Achtergrond:
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) | straatnaam (11.10) | huisnummer (11.20) |
      | 0800                 | 0800010000000001                         | Teststraat         | 1                  |
      En adres 'A2' heeft de volgende gegevens
      | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) | straatnaam (11.10) | huisnummer (11.20) |
      | 0800                 | 0800010000000002                         | Andere Teststraat  | 2                  |


    Scenario: actuele en historische verblijfplaatsen
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20210526                           |
      En de persoon is vervolgens ingeschreven op adres 'A2' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20231014                           |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2023-01-01          |
      | datumTot            | 2024-01-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type  | datumVan.type | datumVan.datum | datumVan.langFormaat | datumTot.type | datumTot.datum | datumTot.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | adresseerbaarObjectIdentificatie | verblijfadres.korteStraatnaam | verblijfadres.huisnummer | functieAdres.code | functieAdres.omschrijving | adressering.adresregel1 |
      | Adres | Datum         | 2023-10-14     | 14 oktober 2023      |               |                |                      | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000002                 | Andere Teststraat             | 2                        | W                 | woonadres                 | Andere Teststraat 2     |
      | Adres | Datum         | 2021-05-26     | 26 mei 2021          | Datum         | 2023-10-14     | 14 oktober 2023      | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000001                 | Teststraat                    | 1                        | W                 | woonadres                 | Teststraat 1            |

    Scenario: verblijfplaatsen in Nederland en in buitenland
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20210526                           |
      En de persoon is vervolgens ingeschreven op een buitenlands adres met de volgende gegevens
      | datum aanvang adres buitenland (13.20) | land adres buitenland (13.10) |
      | 20220730                               | 6014                          |
      En de persoon is vervolgens ingeschreven op adres 'A2' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20231014                           |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2022-01-01          |
      | datumTot            | 2024-01-01          |
      Dan heeft de response een verblijfplaats voorkomen met de volgende gegevens
      | type  | datumVan.type | datumVan.datum | datumVan.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | adresseerbaarObjectIdentificatie | functieAdres.code | functieAdres.omschrijving |
      | Adres | Datum         | 2023-10-14     | 14 oktober 2023      | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000002                 | W                 | woonadres                 |
      En heeft het verblijfplaats voorkomen de volgende 'verblijfadres' gegevens
      | korteStraatnaam   | huisnummer |
      | Andere Teststraat | 2          |
      En heeft het verblijfplaats voorkomen de volgende 'adressering' gegevens
      | adresregel1         |
      | Andere Teststraat 2 |
      En heeft de response een verblijfplaats voorkomen met de volgende gegevens
      | type                     | datumVan.type | datumVan.datum | datumVan.langFormaat | datumTot.type | datumTot.datum | datumTot.langFormaat |
      | VerblijfplaatsBuitenland | Datum         | 2022-07-30     | 30 juli 2022         | Datum         | 2023-10-14     | 14 oktober 2023      |
      En heeft het verblijfplaats voorkomen de volgende 'verblijfadres' gegevens
      | land.code | land.omschrijving            |
      | 6014      | Verenigde Staten van Amerika |
      En heeft de response een verblijfplaats voorkomen met de volgende gegevens
      | type  | datumVan.type | datumVan.datum | datumVan.langFormaat | datumTot.type | datumTot.datum | datumTot.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | adresseerbaarObjectIdentificatie | functieAdres.code | functieAdres.omschrijving |
      | Adres | Datum         | 2021-05-26     | 26 mei 2021          | Datum         | 2022-07-30     | 30 juli 2022         | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000001                 | W                 | woonadres                 |
      En heeft het verblijfplaats voorkomen de volgende 'verblijfadres' gegevens
      | korteStraatnaam | huisnummer |
      | Teststraat      | 1          |
      En heeft het verblijfplaats voorkomen de volgende 'adressering' gegevens
      | adresregel1  |
      | Teststraat 1 |

    Scenario: verblijfplaats in Nederland heeft datum aanvang met alleen jaar en maand bekend
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20210526                           |
      En de persoon is vervolgens ingeschreven op adres 'A2' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20231000                           |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2022-01-01          |
      | datumTot            | 2024-01-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type  | datumVan.type  | datumVan.datum | datumVan.jaar | datumVan.maand | datumVan.langFormaat | datumTot.type  | datumTot.jaar | datumTot.maand | datumTot.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | adresseerbaarObjectIdentificatie | functieAdres.code | functieAdres.omschrijving | adressering.adresregel1 | verblijfadres.korteStraatnaam | verblijfadres.huisnummer |
      | Adres | JaarMaandDatum |                | 2023          | 10             | oktober 2023         |                |               |                |                      | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000002                 | W                 | woonadres                 | Andere Teststraat 2     | Andere Teststraat             | 2                        |
      | Adres | Datum          | 2021-05-26     |               |                | 26 mei 2021          | JaarMaandDatum | 2023          | 10             | oktober 2023         | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000001                 | W                 | woonadres                 | Teststraat 1            | Teststraat                    | 1                        |

    Scenario: verblijfplaats in Nederland heeft datum aanvang met alleen jaar bekend
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20210526                           |
      En de persoon is vervolgens ingeschreven op adres 'A2' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20230000                           |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2022-01-01          |
      | datumTot            | 2024-01-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type  | datumVan.type | datumVan.datum | datumVan.jaar | datumVan.langFormaat | datumTot.type | datumTot.jaar | datumTot.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | adresseerbaarObjectIdentificatie | functieAdres.code | functieAdres.omschrijving | adressering.adresregel1 | verblijfadres.korteStraatnaam | verblijfadres.huisnummer |
      | Adres | JaarDatum     |                | 2023          | 2023                 |               |               |                      | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000002                 | W                 | woonadres                 | Andere Teststraat 2     | Andere Teststraat             | 2                        |
      | Adres | Datum         | 2021-05-26     |               | 26 mei 2021          | JaarDatum     | 2023          | 2023                 | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000001                 | W                 | woonadres                 | Teststraat 1            | Teststraat                    | 1                        |

    Scenario: verblijfplaats in Nederland heeft datum aanvang is onbekend
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20220526                           |
      En de persoon is vervolgens ingeschreven op adres 'A2' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 00000000                           |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2022-01-01          |
      | datumTot            | 2024-01-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type  | datumVan.type | datumVan.datum | datumVan.langFormaat | datumVan.onbekend | datumTot.type | datumTot.langFormaat | datumTot.onbekend | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | adresseerbaarObjectIdentificatie | functieAdres.code | functieAdres.omschrijving | adressering.adresregel1 | verblijfadres.korteStraatnaam | verblijfadres.huisnummer |
      | Adres | DatumOnbekend |                | onbekend             | true              |               |                      |                   | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000002                 | W                 | woonadres                 | Andere Teststraat 2     | Andere Teststraat             | 2                        |
      | Adres | Datum         | 2022-05-26     | 26 mei 2022          |                   | DatumOnbekend | onbekend             | true              | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000001                 | W                 | woonadres                 | Teststraat 1            | Teststraat                    | 1                        |

    Scenario: verblijfplaats buitenland heeft datum aanvang met alleen jaar en maand bekend
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20210526                           |
      En de persoon is vervolgens ingeschreven op een buitenlands adres met de volgende gegevens
      | datum aanvang adres buitenland (13.20) | land adres buitenland (13.10) |
      | 20220700                               | 6014                          |
      En de persoon is vervolgens ingeschreven op adres 'A2' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20231014                           |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2022-01-01          |
      | datumTot            | 2024-01-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type                     | datumVan.type  | datumVan.datum | datumVan.jaar | datumVan.maand | datumVan.langFormaat | datumTot.type  | datumTot.datum | datumTot.jaar | datumTot.maand | datumTot.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | adresseerbaarObjectIdentificatie | verblijfadres.land.code | verblijfadres.land.omschrijving | functieAdres.code | functieAdres.omschrijving | adressering.adresregel1 | verblijfadres.korteStraatnaam | verblijfadres.huisnummer |
      | Adres                    | Datum          | 2023-10-14     |               |                | 14 oktober 2023      |                |                |               |                |                      | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000002                 |                         |                                 | W                 | woonadres                 | Andere Teststraat 2     | Andere Teststraat             | 2                        |
      | VerblijfplaatsBuitenland | JaarMaandDatum |                | 2022          | 7              | juli 2022            | Datum          | 2023-10-14     |               |                | 14 oktober 2023      |                              |                                      |                                  | 6014                    | Verenigde Staten van Amerika    |                   |                           |                         |                               |                          |
      | Adres                    | Datum          | 2021-05-26     |               |                | 26 mei 2021          | JaarMaandDatum |                | 2022          | 7              | juli 2022            | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000001                 |                         |                                 | W                 | woonadres                 | Teststraat 1            | Teststraat                    | 1                        |

    Scenario: verblijfplaats buitenland heeft datum aanvang met alleen jaar bekend
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20210526                           |
      En de persoon is vervolgens ingeschreven op een buitenlands adres met de volgende gegevens
      | datum aanvang adres buitenland (13.20) | land adres buitenland (13.10) |
      | 20220000                               | 6014                          |
      En de persoon is vervolgens ingeschreven op adres 'A2' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20231014                           |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2021-12-31          |
      | datumTot            | 2024-01-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type                     | datumVan.type | datumVan.datum | datumVan.jaar | datumVan.langFormaat | datumTot.type | datumTot.datum | datumTot.jaar | datumTot.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | adresseerbaarObjectIdentificatie | verblijfadres.land.code | verblijfadres.land.omschrijving | functieAdres.code | functieAdres.omschrijving | adressering.adresregel1 | verblijfadres.korteStraatnaam | verblijfadres.huisnummer |
      | Adres                    | Datum         | 2023-10-14     |               | 14 oktober 2023      |               |                |               |                      | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000002                 |                         |                                 | W                 | woonadres                 | Andere Teststraat 2     | Andere Teststraat             | 2                        |
      | VerblijfplaatsBuitenland | JaarDatum     |                | 2022          | 2022                 | Datum         | 2023-10-14     |               | 14 oktober 2023      |                              |                                      |                                  | 6014                    | Verenigde Staten van Amerika    |                   |                           |                         |                               |                          |
      | Adres                    | Datum         | 2021-05-26     |               | 26 mei 2021          | JaarDatum     |                | 2022          | 2022                 | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000001                 |                         |                                 | W                 | woonadres                 | Teststraat 1            | Teststraat                    | 1                        |

    Scenario: verblijfplaats buitenland heeft datum aanvang is onbekend
      Gegeven de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20210526                           |
      En de persoon is vervolgens ingeschreven op een buitenlands adres met de volgende gegevens
      | datum aanvang adres buitenland (13.20) | land adres buitenland (13.10) |
      | 00000000                               | 6014                          |
      En de persoon is vervolgens ingeschreven op adres 'A2' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20231014                           |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2021-01-01          |
      | datumTot            | 2024-01-01          |
      Dan heeft de response verblijfplaatsen met de volgende gegevens
      | type                     | datumVan.type | datumVan.datum | datumVan.langFormaat | datumVan.onbekend | datumTot.type | datumTot.datum | datumTot.langFormaat | datumTot.onbekend | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving | adresseerbaarObjectIdentificatie | verblijfadres.land.code | verblijfadres.land.omschrijving | functieAdres.code | functieAdres.omschrijving | adressering.adresregel1 | verblijfadres.korteStraatnaam | verblijfadres.huisnummer |
      | Adres                    | Datum         | 2023-10-14     | 14 oktober 2023      |                   |               |                |                      |                   | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000002                 |                         |                                 | W                 | woonadres                 | Andere Teststraat 2     | Andere Teststraat             | 2                        |
      | VerblijfplaatsBuitenland | DatumOnbekend |                | onbekend             | true              | Datum         | 2023-10-14     | 14 oktober 2023      |                   |                              |                                      |                                  | 6014                    | Verenigde Staten van Amerika    |                   |                           |                         |                               |                          |
      | Adres                    | Datum         | 2021-05-26     | 26 mei 2021          |                   | DatumOnbekend |                | onbekend             | true              | 0800                         | Hoogeloon, Hapert en Casteren        | 0800010000000001                 |                         |                                 | W                 | woonadres                 | Teststraat 1            | Teststraat                    | 1                        |
