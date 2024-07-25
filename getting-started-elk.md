# Getting Started ELK met Historie API

- Start de ELK applicaties met `docker compose -f .docker/elk.yml up -d`
- De log bestanden onder `./test-data/logs` worden door Filebeat ingelezen
- Navigeer naar Kibana met de url `http://localhost:5601`
- Klik de `Explore on my own` link op de welkom scherm van Kibana
- Klik de hamburger icoon links boven op de home scherm om de menu items te tonen
- Selecteer `Discover` menu item on de `Analytics` menu items groep
- Klik de `Create data view` button
- In de **Create data view** scherm, vul 'brp-api' in de *Index pattern* veld. In de *timestamp field* veld wordt automatisch '@timestamp' geselecteerd
- Klik op de `Save data view to Kibana` button
- Klik op de `View all matches` button in de **Discover** scherm om de geïmporteerde logregels te tonen
- Stop de ELK applicatie met `docker compose -f .docker/elk.yml down --volumes`
