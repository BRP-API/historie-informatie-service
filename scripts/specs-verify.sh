#!/bin/bash

PARAMS="{ \
    \"logFileToAssert\": \"./test-data/logs/historie-informatie-service.json\", \
    \"oAuth\": { \
        \"enable\": false \
    } \
}"

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie-summary.txt \
                -f summary \
                features/docs \
                --tags "not @integratie"

npx cucumber-js -f json:./test-reports/cucumber-js/historie/test-result.json \
                -f summary:./test-reports/cucumber-js/historie/test-result-summary.txt \
                -f summary \
                features/raadpleeg-verblijfplaats-met-periode \
                --world-parameters "$PARAMS"