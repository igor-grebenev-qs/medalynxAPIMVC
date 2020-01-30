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

ENVIROMENTS:
GET /Enviroments
GET /Enviroments/{UserId}
POST /Enviroments (create new enviroment
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

ENUMMS:
----------------------------------------------------------------------------------------------------------------------
GET
    /AnalyticalApplications
    /AnalyticalApplications/{id}
POST
    /AnalyticalApplications (create new AnalyticalApplications item
        body for request sample :
        {
            "pos": 9,
            "name": "BWA"
        },
)
PUT
    /AnalyticalApplications (update AnalyticalApplications item
        body for request sample :
        {
            "id": "{01176d49-d602-46b3-bdee-ead758ccec07}",
            "pos": 7,
            "name": "BWA"
        },
)
----------------------------------------------------------------------------------------------------------------------
GET
    /CohortEnums
    /CohortEnums/{id}
POST
    /CohortEnums (create new AnalyticalApplications item
        body for request sample :
        {
            "name": "PreviousTreatments"
        },
)
----------------------------------------------------------------------------------------------------------------------


COHORTS:
!!! Important !!! When cohort creating links will be filled from original enumst into CohortEnumLinks !!!
GET
    /Cohorts
    /Cohorts/{id}
POST
    /Cohorts (create new Cohort item
        body for request sample :
        {
            "userId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "numberOfSubjectsRequired": 1,
            "cohortType": "unknown",
            "request": 0,
            "creationDate": "2020-01-30T06:25:13",
            "lastUpdate": "2020-01-30T06:25:13"
        }
)
PUT
    /AnalyticalApplications (update Cohort item
        body for request sample :
        {
            "id": "{c9b1ab2d-fa5d-4ce1-9604-3b7b6061c95b}",
            "userId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "numberOfSubjectsRequired": 1,
            "cohortType": "unknown",
            "request": 0,
            "creationDate": "2020-01-30T06:25:13",
            "lastUpdate": "2020-01-30T06:25:13"
        }
)
