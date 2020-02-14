# medalynxAPIMVC
https://docs.microsoft.com/ru-ru/aspnet/core/web-api/?view=aspnetcore-3.1

DUMP
mysqldump --column-statistics=0 -uroot -pm1llions --host 35.188.34.140 medalynx_db > medalinx_db_backup.sql


API USAGES:

USERS:
GET /Users
GET /Users/{id} (localhost:5000/Users/{9ccf25f2-2500-4af3-a64c-10f3f83d8da1})
GET /Users/me (get user. Session Id obtain from headers)

POST /Users/Login (check credentials)
        body for request sample:
        {
            "UserEmail": "igor.grebenev@quantumsoft.ru",
            "Password": "some_pwd"
        }

GET /Users/Logout/{sessionId}

POST /Users/Email
        body for request sample:
        {
            "UserEmail": "igor.grebenev@quantumsoft.ru",
        }

POST /Users/Password
        body for request sample:
        {
            "Password": "some_pwd"
        }

POST /Users (create new user
        body for request sample:
        {
            "email": "igor.grebenev@quantumsoft.ru",
            "firstName": "Igor",
            "lastName": "Grebenev",
            "companyName": "Quantumsoft",
            "request": 0,
            "password": "",
            "role": "STANDART_USER"
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
            "password": "",
            "role": "STANDART_USER"
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
PUT /Enviroments (update enviroment
        body for request sample:
        {
            "id": "{577c9b90-8495-4ed7-9fa1-3877c64d1111}",
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
    /CohortEnums/{enumId}/values
----------------------------------------------------------------------------------------------------------------------


COHORTS:
GET
    /Cohorts
    /Cohorts/{id} - Alive cohort by user (CohortRepresentation)
    /Cohorts/ByUser/{userId} - Alive cohort by user (CohortRepresentation) Request-Type header required (see RequestType). If Request-Type not passed or have invalid value assume CreatedOrApproved
DELETE
    /Cohorts/{id} - Remove cohort
POST
    /Cohorts (create new Cohort item
        body for request sample :
        {
            "userId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "numberOfSubjectsRequired": 1,
            "cohortType": "unknown",
            "requestAdmin": 0,
            "requestUser": 0,
            "cohortEnumLinks": [
                {
                "cohortEnumId": "{cc77ecca-8279-4c9d-b321-064ba492ba9e}",
                "enumItemId": null,
                "include": 0,
                "percentage": 0,
                "numberOfSubjects": 0,
                "enumItem":
                    {
                        "stageOfTumour": 3,
                        "numberOfNodesAffected": 6,
                        "numberOfMetastasis": 6
                    }
                }
            ]
        }
)
PUT
    /Cohorts (create new Cohort item
        body for request sample :
        {
            "id": "{248b5596-9b28-43b4-b433-c45fff62921c}",
            "userId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "numberOfSubjectsRequired": 1,
            "cohortType": "unknown",
            "requestAdmin": 0,
            "requestUser": 0,
            "cohortEnumLinks": [
                {
                "id" ... Link can contains id for update or will be create new. If link not present in this property - link will removed
                "cohortEnumId": "{cc77ecca-8279-4c9d-b321-064ba492ba9e}",
                "enumItemId": null,
                "include": 0,
                "percentage": 0,
                "numberOfSubjects": 0,
                "enumItem":
                    {
                        "stageOfTumour": 3,
                        "numberOfNodesAffected": 6,
                        "numberOfMetastasis": 6
                    }
                }
            ]
        }
)

----------------------------------------------------------------------------------------------------------------------
// AnalyticalApplications
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
----------------------------------------------------------------------------------------------------------------------
NOTIFICATIONS:
GET /Notifications
GET /Notifications/{id}
POST /Notifications (create new notification
        body for request sample:
        {
            "userId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "message": "Environment request from Wendy Howard",
            "noicationType": 0,
            "status": 0,
            "creationDate": "2020-01-31T12:00:00",
            "lastUpdate": "2020-01-31T12:00:00"
        }
)
PUT /Notifications (update notification
        body for request sample:
        {
            "id": "{8a299213-b198-459b-b8d8-e7829f6e4677}",
            "userId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "message": "Environment request from Wendy Howard",
            "noicationType": 0,
            "status": 0,
            "creationDate": "2020-01-31T12:00:00",
            "lastUpdate": "2020-01-31T12:00:00"
        }
)

MESSAGES:
GET /Messages
GET /Messages/{userId}
POST /Messages (create new message for user
        body for request sample:
        {
            "userId": "{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}",
            "MessageBody": "message text"
        }
)
