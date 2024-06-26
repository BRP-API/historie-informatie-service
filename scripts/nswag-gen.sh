#!/bin/bash

npx nswag run src/Historie.Data.Mock/DataServiceContract.nswag
npx nswag run src/Historie.Informatie.Service/InformatieServiceDataTransferObjects.nswag
npx nswag run src/Historie.Informatie.Service/DataServiceDataTransferObjects.nswag
