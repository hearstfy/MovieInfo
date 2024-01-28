# Movie Info

## Installation

Clone the repo to your local environment.
Run below commands in root folder to run it.

```bash
dotnet build
dotnet run --project .\MovieInfo.API
```
Endpoint is;

```bash
/api/movie/{movieName}
```

## Notes
1. Since this is an assignment not a prod app, I spent minimum possible time on it. (That's why not tests)
2. My initial plan was to use Docker, Redis for cahce and docker-compose to compsoe the app and provide the secrets etc. But Docker Engine refused to run, thats why I discarded Docker part, used in memory cache and provided secrets through appsetting file.
3. My to go architecture is Onion Architecture, that's why I followed it.
4. There are many things to improve, such as; \
4.1. Data validation on controller \
4.2. Specific handling of OmdbApi in case movie is not found, api still returns 200, thus null valued response. \
4.3. Proper handling of secrets, through cloud key vaults. \
4.4. Proper handling of errors, I just implemented a basic global error handling. \
4.5. Move cache to Redis to decouple it from application life cycle. \
4.6. Better way of data handling through layers with Layer DTOs. \
4.7. Logging \
4.8. Github actions to build and deploy the app.
4.9. Tests ofc.
