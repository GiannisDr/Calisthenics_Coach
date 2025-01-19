# Calisthenics Coach API

The **Calisthenics Coach API** is designed to help users track and progress through various calisthenics exercises, workouts, and achieve their fitness goals. The API provides endpoints to manage users, exercises, workouts, and track progress through different skill levels: **Beginner**, **Intermediate**, and **Pro**.

## Table of Contents

- [Technologies Used](#technologies-used)
- [Features](#features)
- [Setup & Installation](#setup--installation)
- [Database Configuration](#database-configuration)
- [API Endpoints](#api-endpoints)
- [Running the Project](#running-the-project)
- [Swagger API Documentation](#swagger-api-documentation)
- [Contributing](#contributing)

## Technologies Used

- **.NET 8** for the backend framework.
- **Entity Framework Core** for ORM and database management.
- **PostgreSQL** for database storage.
- **Docker** for containerizing the PostgreSQL database.
- **Swashbuckle.AspNetCore** for generating Swagger documentation.
- **Minimal API** for defining API endpoints.

## Features

- **User Management**: Register users, track progress, and set goals.
- **Exercise Tracking**: Assign exercises based on skill levels (Beginner, Intermediate, Pro).
- **Workout Programs**: Generate workout programs based on user skill levels and goals.
- **Progress Tracking**: Track progress in exercises and workouts (sets, reps, etc.).
- **Skill Progression**: Automate skill progression based on user performance (reps/sets).
- **API Documentation**: Swagger UI for easy interaction with the API.

## Setup & Installation

### Prerequisites

- .NET 8 SDK
- PostgreSQL database (can be run via Docker)
- Docker (if using for PostgreSQL containerization)

## Why We Don't Use AutoMapper or Other Mapping Libraries

In this project, we have chosen to **avoid using AutoMapper** or other automatic mapping libraries for the following reasons:

1. **Performance Costs**:
   - Libraries like AutoMapper introduce a slight overhead due to runtime configuration, reflection, and the mapping process itself. While this is negligible for small-scale applications, it can become a bottleneck in high-performance systems where mapping happens frequently.

2. **Explicit Mapping Logic**:
   - By writing custom mapping logic, we make the transformation between entities and domain models explicit. This improves code readability and debugging since the mapping behavior is easy to understand and modify.

3. **Control and Flexibility**:
   - Custom mappers provide fine-grained control over the mapping process. This allows for optimizations and complex logic that would be harder to implement or maintain with automatic mappers.

4. **Project Simplicity**:
   - Removing the dependency on third-party libraries simplifies the project, reduces package maintenance, and avoids potential versioning issues.

For these reasons, we have implemented **custom mappers** to handle the conversion between database entities and domain models.

---

## Custom Mappers

We have created custom static mapper classes for converting between:
1. **Database Entities** (used in persistence) and
2. **Domain Models** (used in the service layer).

Each entity has a corresponding mapper class, ensuring a clean separation of concerns.


### Clone the repository

```bash
git clone https://github.com/your-username/calisthenics-coach-api.git
cd calisthenics-coach-api
