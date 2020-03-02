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
            "role": "STANDARD_USER"
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
            "role": "STANDARD_USER"
        }
)

ENVIRONMENTS:
GET /Environments
GET /Environments/ByProject/{projectId}
GET /Environments/AllByProject/{projectId}
POST /Environments (create new environment
        body for request sample:
        {
            "projectId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "numberOfUsers": 10,
            "dataStorage": 100,
            "analyticalApplication": "[]",
            "typeOfConnectivity": "{2f3ff4f0-b363-40ba-990d-7b80f0df574f}",
            "request": 0,
            "status": 0
        }
)
PUT /Environments (update environment
        body for request sample:
        {
            "id": "{577c9b90-8495-4ed7-9fa1-3877c64d1111}",
            "projectId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "numberOfUsers": 10,
            "dataStorage": 100,
            "analyticalApplication": "[]",
            "typeOfConnectivity": "{2f3ff4f0-b363-40ba-990d-7b80f0df574f}",
            "request": 0,
            "requestType": 0,
            "status": 0
        }
PUT /Environments/Request/{id}
        body for request sample :
        {
            "request": 20
        }

PUT /Environments/RequestType/{id}
        body for request sample :
        {
            "requestType": 20
        }

PUT /Environments/Status/{id}
        body for request sample :
        {
            "status": 20
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

PROJECTS:
GET
    /Projects
    /Projects/{id}
    /Projects/AllByTeam/{teamId}
    /Projects/AllByUser/{userId}
POST
    /Projects (create new Project item
        body for request sample :
        {
            "teamId": "{08e496a7-ea98-4619-9140-73654c8d9f92}",
            "name": "sample project",
            "cohortType": "unknown",
            "access": "DEFAULT"
        }
)
PUT
    /Projects (update Project item
        body for request sample :
        {
            "id": "{2b605924-e75a-4eef-9ba7-c2c7fe770b29}"
            "teamId": "{08e496a7-ea98-4619-9140-73654c8d9f92}",
            "name": "sample project",
            "cohortType": "unknown",
            "access": "DEFAULT"
        }
)

----------------------------------------------------------------------------------------------------------------------

TEAMS:
GET
    /Team
    /Team/{id}
    /Team/TeamUsers/{teamId}
POST
    /Team (create new Team item
        body for request sample :
        {
            "name": "sample",
            "details": "some description",
            "userId": "{214e72d0-2636-45e4-89d6-59196ed657e0}" // owner
        }
)
PUT
    /Team/AddUser/{teamId} (add user to team
        body for request sample :
        {
            "userId": "{2b605924-e75a-4eef-9ba7-c2c7fe770b29}"
        }
)
    /Team/RemoveUser/{teamId} (remove user from team
        body for request sample :
        {
            "userId": "{2b605924-e75a-4eef-9ba7-c2c7fe770b29}"
        }
)
    /Team (update new Team item
        body for request sample :
        {
            "id": "{422aa748-484c-469c-8111-6149a13d9878}"
            "name": "sample",
            "details": "some description"
        }
)

----------------------------------------------------------------------------------------------------------------------
COHORTS:
GET
    /Cohorts
    /Cohorts/{id} - Alive cohort by project (CohortRepresentation)
    /Cohorts/ByProject/{projectId} - Alive cohort by project (CohortRepresentation) Not-Rejected header can be specified.
    /Cohorts/AllByProject/{projectId}
POST
    /Cohorts (create new Cohort item
        body for request sample :
        {
            "projectId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "numberOfSubjectsRequired": 1,
            "cohortType": "unknown",
            "requestAdmin": 0,
            "requestUser": 0,
            "status": 0.
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
    /Cohorts (update Cohort item
        body for request sample :
        {
            "id": "{248b5596-9b28-43b4-b433-c45fff62921c}",
            "projectId": "{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}",
            "numberOfSubjectsRequired": 1,
            "cohortType": "unknown",
            "requestAdmin": 0,
            "requestUser": 0,
            "status": 0,
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
PUT /Cohorts/RequestType/{id}
        body for request sample :
        {
            "requestType": 20
        }
PUT /Cohorts/Status/{id}
        body for request sample :
        {
            "status": 20
        }
PUT /Cohorts/LinksStatus/{cohortId}
        body for request sample :
        {
            "enumLinksIds":["{03c3f457-50ff-4e55-a89b-b806468272b3}", "{0948e5f4-264a-454f-89b5-9e89ce8ce9f3}"],
            "status":20
        }

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
GET /Notifications/ByProject/{projectId}
PUT /Notifications/Processed/{id} - mark as read

----------------------------------------------------------------------------------------------------------------------
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
