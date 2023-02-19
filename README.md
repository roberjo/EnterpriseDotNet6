# Enterprise DotNet 6 API 
This is an Enterprise-ready API built using .NET 6, designed with best practices and common patterns in mind. The API features include Dependency Injection, Serilog Logging, Repository Factory Pattern, Unit Tests, IP Address based Rate Limiting, Dockerization, Security Headers, and Swagger Endpoint Documentation.

![GitHub contributors](https://img.shields.io/github/contributors/roberjo/enterprisedotnet6?style=flat-square)
![GitHub](https://img.shields.io/github/license/roberjo/enterprisedotnet6?style=flat-square)
![GitHub Repo stars](https://img.shields.io/github/stars/roberjo/enterprisedotnet6?style=flat-square)
![Twitter Follow](https://img.shields.io/twitter/follow/auroberjo?style=flat-square)
![GitHub search hit counter](https://img.shields.io/github/search/roberjo/enterprisedotnet6/goto?style=flat-square)

# Dependencies
- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Serilog](https://serilog.net/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [AspNetRateLimit](https://github.com/stefanprodan/AspNetCoreRateLimit)
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle)

## Installation
Clone this repository and use the dotnet CLI to run the application.

```bash
git clone https://github.com/roberjo/enterprisedotnet6.git
cd enterprisedotnet6
dotnet run
```

## Configuration
The configuration for the API can be found in the appsettings.json file, where you can configure the connection string for the database, the logging configuration, and the rate limiting configuration.

## Usage
To use the API, navigate to https://localhost:5001/swagger to view the Swagger endpoint documentation. Here you can interact with the API and test the various endpoints.

The API also includes IP Address based Rate Limiting to prevent abuse of the API. Requests from a specific IP address will be limited based on the rate limit configuration in the appsettings.json file.

## Logging
The API uses Serilog for logging, which is a structured logging library. The logging configuration can be found in the appsettings.json file. The logs are written to the console and a rolling file.

## Security
The API includes security headers that can be configured in the appsettings.json file to enhance the security of the application.

## Unit Tests
The API includes a unit test project that can be found in the tests folder. These tests use the xUnit testing framework and can be run using the dotnet CLI.

```bash
cd tests
dotnet test
```

## Docker
The API can be run in a Docker container. To create a Docker image, navigate to the root directory of the API and run the following command:

```bash
docker build -t your-image-name .
```
This will create a Docker image with the name your-image-name.

To run the Docker container, use the following command:

```bash
docker run -p 8080:80 -d your-image-name
```
This will run the container on port 8080. You can access the API by navigating to http://localhost:8080/swagger.

## Conclusion
This API is designed to be an Enterprise-ready API that includes best practices and common patterns. With its use of Dependency Injection, Serilog Logging, Repository Factory Pattern, Unit Tests, IP Address based Rate Limiting, Dockerization, Security Headers, and Swagger Endpoint Documentation, it provides a robust and reliable solution for building modern, scalable APIs.

## License
EnterpriseDotNet6 is released under the MIT License. See the [LICENSE](https://github.com/roberjo/EnterpriseDotNet6/LICENSE.txt) file for more information.
