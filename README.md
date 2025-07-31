# 🪖 TJ, the REST API
A minimal REST API for counting the mornings remaining in Finnish conscript service.☀️

## Minimalist Stack
- ASP.NET Core
- Swagger / OpenAPI

## Documentation
Request format: GET `/{period: int[1/2]}/{year: int}/{duration: int}`

### Example Requests
- GET `1/25/255`
- GET `2/2020/165`
- GET `1/2030/347`

### Example Response
As of July 31, 2025
```json
GET /1/25/255
{
    "days": 48,
    "weeks": 6.86,
    "months": 1.6,
    "seconds": 4149191
}
```
Swagger documentation can be found at `/swagger/` endpoint when project is ran in development mode.

## Getting started

1. Clone the repository
```bash
git clone https://github.com/Jegarde/TJ-API.git
cd TJ-API
```
2. Run it
```
dotnet restore
dotnet run
```

## Licence
Licenced under the MIT licence!