# medalynxAPIMVC
https://docs.microsoft.com/ru-ru/aspnet/core/web-api/?view=aspnetcore-3.1

DUMP
mysqldump --column-statistics=0 -uroot -pm1llions --host 35.188.34.140 medalynx_db > medalinx_db_backup.sql


sample used:
GET localhost:5000/Users
GET localhost:5000/Users/{9ccf25f2-2500-4af3-a64c-10f3f83d8da1}
POST localhost:5000/Users


GET http://localhost:5000/Users
GET http://localhost:5000/Users/{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}

POST localhost:5000/Users - create
body for request :
{
    "email": "igor.grebenev@quantumsoft.ru",
    "firstName": "Igor",
    "lastName": "Grebenev",
    "companyName": "Quantumsoft",
    "request": 0,
    "password": ""
}