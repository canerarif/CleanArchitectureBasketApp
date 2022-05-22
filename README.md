# CicekSepetiBasket
Cicek Sepeti Case Study

## Technologies

* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
* [PostgreSQL](https://www.postgresql.org/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/)
* [Docker](https://www.docker.com/)

## Follow these steps to install the application:
1. Clone this repository on your local.
2. Go to the CicekSepetiBasket directory
3. Run the `docker-compose up` at command line
4. Run `http://localhost:8080/swagger/index.html` url in your browser

## Notes:
1. pgAdmin URL is `http://localhost:5050/`
2. pgAdmin Server Informations: 
    - General Name: postgres
    - Host name/adress: postgres
    - Password: changeme

## Seed Data:

### Basket

| Id  | ProductCount | ProductId | CreateDate |
| ------------- | ------------- | ------------- | ------------- |
| 7a4ccfeb-0174-49e1-a3a2-b1a85c982608  | 2  | fbc178bf-6751-48bb-8df3-5dfbf00194ec  | 2022-04-18 19:45:08.860821+00  |
| 88dda06e-1796-46ac-adc7-ff4cf90a8a01  | 7  | f27e09f4-7a24-4890-a595-a02827a98aa4  | 2022-04-18 19:45:08.860829+00  |
| e02167e2-db7e-4919-af3e-d7a8c5d0b594  | 4  | 5c95c5d4-c887-493d-9589-0efc9f20e67e  | 2022-04-18 19:45:08.860829+00  |

### Products

| Id  | ProductName | Stock | CreateDate |
| ------------- | ------------- | ------------- | ------------- |
| 5c95c5d4-c887-493d-9589-0efc9f20e67e  | Paper A4  | 10  | 2022-04-18 19:45:08.860802+00  |
| f27e09f4-7a24-4890-a595-a02827a98aa4  | Book  | 100  | 2022-04-18 19:45:08.860829+00  |
| fbc178bf-6751-48bb-8df3-5dfbf00194ec  | Pencil  | 20  | 2022-04-18 19:45:08.860829+00  |


