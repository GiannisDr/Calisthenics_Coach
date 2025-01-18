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

### Clone the repository

```bash
git clone https://github.com/your-username/calisthenics-coach-api.git
cd calisthenics-coach-api
