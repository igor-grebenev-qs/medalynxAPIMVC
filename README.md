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