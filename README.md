# 🇫🇮🪖 TJ, the REST API
A minimal REST API for counting the mornings remaining in Finnish conscript service. TJ VÄBÄ! ☀️

## Minimalist Stack
- ASP.NET Core (9.0)
- Swagger (6.5)

## Documentation
Request format: GET `/{period: int[1/2]}/{year: int}/{duration: int = 0}`

### Good To Know
The API has correct starting and end dates for arrival patches 1/16 to 2/26.

For other patches, we default to January 6th as starting date and July 7th as ending date.

### Example Requests
- GET `1/25/255`
- GET `2/2020/165`
- GET `1/2030/347`
- GET `1/2020/` (duration defaults to 0)

### Example Response
As of August 2, 2025
```json
GET /1/25/255
{
    "days": 46.6,
    "weeks": 6.66,
    "months": 1.55,
    "seconds": 4026460,
    "startDate": 1736121600,
    "returnDate": 1758150000
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

## TJ VÄBÄ?
Yes.
