# OpeqeSample
**BLL** (business logic layer): Include API (Web API) and GIS Service

**DAL** (data access layer): Include Entities and Repository

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
**GetDistance**(Calculate distance and save to databse): 

Type:POST

URL: {apiUrl}/api/GIS/GetDistance

Authorization Type: Bearer

Content-Type: application/json;charset=UTF-8

Request Body: {"OriginLatitude":{val},"OriginLongitude":{val},"DestinationLatitude":{val},"DestinationLongitude":{val}}

**GetHistory**: 

Type:POST

URL: {apiUrl}/api/GIS/GetHistory

Authorization Type: Bearer

Content-Type: application/json;charset=UTF-8


