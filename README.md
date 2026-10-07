# NZWalks API

NZWalks is a REST API I built with ASP.NET Core to learn how a real backend fits together. It stores New Zealand regions and walking tracks in SQL Server, and users log in with a JWT to read or change the data depending on their role.

## Tech stack

- C# and ASP.NET Core Web API (.NET 10)
- Entity Framework Core with SQL Server (code first migrations)
- ASP.NET Core Identity for users and roles
- JWT bearer authentication
- AutoMapper for mapping between domain models and DTOs
- Swagger (Swashbuckle) for testing the API in the browser

## Features

- CRUD for Regions and Walks
- Filtering, sorting and paging on the walks list (`filterOn`, `filterQuery`, `sortBy`, `isAscending`, `pageNumber`, `pageSize`)
- Filtering on the regions list (`filterOn`, `filterQuery`)
- Register and login with Identity, which returns a JWT
- Role based access on the Regions endpoints (ReaderRole and WriterRole)
- Image upload (jpg, jpeg, png, up to 10 MB), saved to a local `Images` folder and served at `/Images`
- Request validation with a custom model validation filter
- Repository pattern (`IRegionRepository`, `IWalkRepository`, `IImageRepository`, `ITokenRepository`)
- Seed data for difficulties (Easy, Medium, Hard), six regions and a set of sample walks

## Endpoints

| Method | Route | Auth | What it does |
|---|---|---|---|
| POST | /api/Auth/register | None | Create a user, optionally with roles |
| POST | /api/Auth/login | None | Log in and get a JWT |
| GET | /api/Regions | ReaderRole or WriterRole | List regions, with optional filter |
| GET | /api/Regions/{id} | ReaderRole or WriterRole | Get one region |
| POST | /api/Regions | WriterRole | Create a region |
| PUT | /api/Regions/{id} | WriterRole | Update a region |
| DELETE | /api/Regions/{id} | WriterRole | Delete a region |
| GET | /api/Walks | None | List walks with filter, sort and paging |
| GET | /api/Walks/{id} | None | Get one walk |
| POST | /api/Walks | None | Create a walk |
| PUT | /api/Walks/{id} | None | Update a walk |
| DELETE | /api/Walks/{id} | None | Delete a walk |
| POST | /api/Images/Upload | None | Upload an image (multipart form) |

Right now only the Regions endpoints are protected. Adding roles to Walks and Images is on my to do list.

## How auth works

- Users and roles are stored in a separate database (`NZWalksAuthDb`) using ASP.NET Core Identity.
- Two roles are seeded: `ReaderRole` and `WriterRole`. You pick roles when you register.
- On login, the API checks the password with Identity, then creates a JWT signed with HMAC SHA256. The token has the user's email and roles as claims and expires after 15 minutes.
- Send the token as `Authorization: Bearer <token>`. In Swagger, use the Authorize button.

## Running it locally

Prerequisites: .NET 10 SDK, SQL Server (LocalDB or Express is fine), and the EF Core CLI (`dotnet tool install --global dotnet-ef`).

1. Clone the repo and go into `Project_NZWalks/Project_NZWalks.API`.
2. Set the connection strings and JWT settings. I recommend user secrets instead of editing `appsettings.json`:

```
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:NZWalksConnectionString" "Server=YOUR_SERVER;Database=NZWalksDb;Trusted_Connection=True;TrustServerCertificate=True"
dotnet user-secrets set "ConnectionStrings:NZWalksAuthConnectionString" "Server=YOUR_SERVER;Database=NZWalksAuthDb;Trusted_Connection=True;TrustServerCertificate=True"
dotnet user-secrets set "Jwt:Key" "A_LONG_RANDOM_SECRET_AT_LEAST_32_CHARS"
dotnet user-secrets set "Jwt:Issuer" "https://localhost:7056/"
dotnet user-secrets set "Jwt:Audience" "https://localhost:7056/"
```

3. Create both databases:

```
dotnet ef database update --context NZWalksDbContext
dotnet ef database update --context NZWalksAuthDBContext
```

4. Run it with `dotnet run` and open `https://localhost:7056/swagger` (check `Properties/launchSettings.json` if your port is different).
5. Register a user with `WriterRole`, log in, copy the token and click Authorize in Swagger.

## Project structure

```
Project_NZWalks.API/
  Controllers/        Auth, Regions, Walks, Images
  Data/               NZWalksDbContext (regions, walks, difficulties, images) and NZWalksAuthDBContext (Identity)
  Models/Domain/      Region, Walk, Difficulty, Image
  Models/DTO/         Request and response DTOs
  Repository/         Interfaces plus SQL, JWT and local image implementations
  Mappings/           AutoMapper profiles
  ActionModelFilter/  Custom model validation attribute
  Migrations/         EF Core migrations for both databases
  Images/             Uploaded images
  Program.cs          Services, Identity, JWT and Swagger setup
```

## What I want to add next

- Tests
- Role checks on Walks and Images
- Deploying it to Azure
