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
