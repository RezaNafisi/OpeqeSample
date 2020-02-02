# OpeqeSample
**BLL** (business logic layer): Include API (Web API) and GIS Service

**DAL** (data access layer): Include Entities and Repository
```
Note:
All data is stored in, in-memory collections : DAL -> Opeqe.Sample.DAL.Repository -> GenericRepository.cs -> list
```

**Common** (common projects): Include Log and Models

**Presentation** : Include web project (using angularJS)
## Configes
**Service Hosting Ip and Port:** BLL-> Services -> Opeqe.Sample.BLL.Services.GIS -> App.config -> baseAddresses

**Api Service Url:** BLL-> Opeqe.Sample.BLL.API -> Web.config -> appSettings -> ServiceUrl value

**Web project API Url:** Presentation -> Opeqe.Sample.Presentation.Web -> app -> app.js -> baseUrl (line 33)

## Run
1. Run GIS Service
2. Run/Host API
3. Run/Host Web project
4. Register Users
5. Login and use

## Use postman
**Login:** {apiUrl}/token

Sample:
```
var settings = {
  "url": "{apiUrl}/token",
  "method": "POST",
  "timeout": 0,
  "headers": {
    "Content-Type": "application/x-www-form-urlencoded"
  },
  "data": {
    "grant_type": "password",
    "username": "reza",
    "password": "123456"
  }
};
```
**Register:**

Type: POST

Body: {"Email":{email},"Name":{name},"Password":{pass},"ConfirmPassword":{confirm pass}}

Content-Type: application/json; charset=utf-8

**GetDistance**(Calculate distance and save to databse): 

Type: POST

URL: {apiUrl}/api/GIS/GetDistance

Authorization Type: Bearer

Content-Type: application/json;charset=UTF-8

Request Body: {"OriginLatitude":{val},"OriginLongitude":{val},"DestinationLatitude":{val},"DestinationLongitude":{val}}

**GetHistory**: 

Type: GET

URL: {apiUrl}/api/GIS/GetHistory

Authorization Type: Bearer

Content-Type: application/json;charset=UTF-8


