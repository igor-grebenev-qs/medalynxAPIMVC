# medalynxAPIMVC
https://docs.microsoft.com/ru-ru/aspnet/core/web-api/?view=aspnetcore-3.1

DUMP
mysqldump --column-statistics=0 -uroot -pm1llions --host 35.188.34.140 medalynx_db > medalinx_db_backup.sql


API USAGES:

USERS:
GET /Users
GET /Users/{id} (localhost:5000/Users/{9ccf25f2-2500-4af3-a64c-10f3f83d8da1})
POST /Users (create new user
        body for request sample:
        {
            "email": "igor.grebenev@quantumsoft.ru",
            "firstName": "Igor",
            "lastName": "Grebenev",
            "companyName": "Quantumsoft",
            "request": 0,
            "password": ""
        }
)
PUT /Users (update exists user. You can provide not all fields. id - reqired
        body for request sample:
        {
            "id": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}"
            "email": "igor.grebenev@quantumsoft.ru",
            "firstName": "Igor",
            "lastName": "Grebenev",
            "companyName": "Quantumsoft",
            "request": 1,
            "password": ""
        }
)

Environments:
GET /Environments
GET /Environments/{UserId}
POST /Environments (create new enviroment
        body for request sample:
        {
            "userId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "numberOfUsers": 10,
            "dataStorage": 100,
            "analyticalApplication": "[]",
            "typeOfConnectivity": "{2f3ff4f0-b363-40ba-990d-7b80f0df574f}",
            "request": 0
        }
)

ENUMS:
----------------------------------------------------------------------------------------------------------------------
GET
    /AnalyticalApplications
    /AnalyticalApplications/{id}
POST
    /AnalyticalApplications (create new AnalyticalApplications item
        body for request sample :
        {
            "pos": 7,
            "name": "BWA"
        }
    )
)
----------------------------------------------------------------------------------------------------------------------
GET
    /DeseaseStates
    /DeseaseStates/{id}
POST
    /DeseaseStates (create me enum item
        body for request :
        {
            "deseaseState": "Localised Salmonella infections",
            "percentage": 0
        }
    )
)
----------------------------------------------------------------------------------------------------------------------


COHORTS: