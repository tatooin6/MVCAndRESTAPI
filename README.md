# .NET Core 6 MVC Web Application with Web API REST Services
# MVCAndRESTAPI
This is a project that contains a MVC Web Application and a Web API in Net Core 6. Feel free to explore and fork as you need.

## Overview

This project is a .NET Core 6 MVC Web Application integrated with Web API REST services. The application demonstrates a comprehensive setup including backend API services for handling data and a frontend MVC application for presenting the data to the users. The project includes functionalities for managing books and authors, implemented with Entity Framework for data access.

## Features

- **MVC Web Application**: Provides a user interface for interacting with the application.
- **Web API**: RESTful API services for managing data (books and authors).
- **Entity Framework Core**: ORM for database access and management.
- **Authentication and Authorization**: Secure the API endpoints.
- **Responsive Design**: Ensure the application is usable on various devices.
- **Docker Integration**: Containerization of the application for easy deployment.

## Technologies Used

- .NET Core 6
- ASP.NET Core MVC
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Docker
- Visual Studio 2022
- Git

## Getting Started

### Prerequisites

- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [Docker](https://www.docker.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/your-username/your-repo-name.git
    cd your-repo-name
    ```

2. **Build the Docker containers**:
    Ensure Docker is running, then build and start the containers using Docker Compose.
    ```bash
    docker-compose up -d
    ```

3. **Update the Database**:
    Use the Package Manager Console in Visual Studio or the command line to apply migrations and update the database.
    ```bash
    dotnet ef database update
    ```

4. **Run the Application**:
    Start both the Web API and the MVC application.
    - **Web API**: Ensure it's running on a specified port (e.g., https://localhost:7277)
    - **MVC Application**: Ensure it's running on a different port (e.g., https://localhost:7065)

## Usage

1. **Access the Web Application**:
    Open your browser and navigate to the MVC application URL, typically https://localhost:5000. But this project is meant to open on port 7065.

2. **Interacting with the API**:
    Use tools like Postman or cURL to interact with the Web API endpoints. For example:
    ```bash
    GET https://localhost:7277/api/books
    GET https://localhost:7277/api/authors
    ```

## Project Structure

- **AuthorsWebApplication**: The MVC project containing the user interface components.
- **WebAPIAutores**: The Web API project handling backend data services.
- **Entities**: Contains the data models (e.g., Book, Author).
- **Controllers**: API controllers for handling HTTP requests.
- **Views**: Razor views for the MVC application.
- **Migrations**: Entity Framework Core migrations for database schema management.

## Contributing

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature-branch-name`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch-name`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- Microsoft Documentation
- ASP.NET Core Community

