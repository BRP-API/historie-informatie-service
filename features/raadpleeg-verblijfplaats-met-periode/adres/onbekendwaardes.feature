#language: nl

Functionaliteit: leveren van adresregels wanneer straat en/of huisnummer van een adres de standaardwaarde heeft


  Regel: adressering wordt niet geleverd als 'straatnaam (11.10)' en/of 'huisnummer (11.20)' de standaardwaarde als waarde heeft

    Abstract Scenario: persoon heeft een adres met <omschrijving>
      Gegeven adres 'A1' heeft de volgende gegevens
      | gemeentecode (92.10) | straatnaam (11.10) | huisnummer (11.20) | postcode (11.60) |
      | 0800                 | <straatnaam>       | <huisnummer>       | 1234AB           |
      En de persoon met burgerservicenummer '000000012' is ingeschreven op adres 'A1' met de volgende gegevens
      | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
      | 0800                              | 20231014                           |
      Als verblijfplaatshistorie wordt gezocht met de volgende parameters
      | naam                | waarde              |
      | type                | RaadpleegMetPeriode |
      | burgerservicenummer | 000000012           |
      | datumVan            | 2023-07-01          |
      | datumTot            | 2024-01-01          |
      Dan heeft de response een verblijfplaats voorkomen met de volgende gegevens
      | type  | datumVan.type | datumVan.datum | datumVan.langFormaat | gemeenteVanInschrijving.code | gemeenteVanInschrijving.omschrijving |
      | Adres | Datum         | 2023-10-14     | 14 oktober 2023      | 0800                         | Hoogeloon, Hapert en Casteren        |
      En heeft het verblijfplaats voorkomen de volgende 'verblijfadres' gegevens
      | naam            | waarde                     |
      | korteStraatnaam | <korteStraatnaam>          |
      | huisnummer      | <huisnummer-verblijfadres> |
      | postcode        | 1234AB                     |

      Voorbeelden:
      | straatnaam               | huisnummer | omschrijving                             | korteStraatnaam          | huisnummer-verblijfadres |
      | .                        | 88         | een straatnaam met standaardwaarde       |                          | 88                       |
      | Jonkheer van Riemsdijkln | 0          | een huisnummer met standaardwaarde       | Jonkheer van Riemsdijkln |                          |
      | .                        | 0          | straat en huisnummer met standaardwaarde |                          |                          |
