## Overview

This project is an OAuth login API designed for a popular mobile game, allowing only authenticated users to access different regions of the game based on their roles. The API is built using ASP.Net Core MVC and utilizes JWT tokens to securely manage user authentication and authorization.

## Features

- **Username and Password Authentication**: Users can log in with their username and password.
- **JWT Token Generation**: Upon successful login, a JWT token is generated containing the user's roles and accessible system regions.
- **Role-Based Access Control**: Users have different roles such as "player" and "admin".
- **Region-Based Access Control**: Different parts of the game are accessible based on user roles:
  - `b_game`: Default region for all logged-in users.
  - `vip_chararacter_personalize`: Accessible only to VIP users.

## Static User Data

The application uses static data for demonstration purposes. Here are the predefined users:

- **Player User**
  - Username: `player1`
  - Password: `password1`
  - Roles: `player`
  - Accessible Regions: `b_game`
  
- **Admin User**
  - Username: `admin1`
  - Password: `password2`
  - Roles: `admin`
  - Accessible Regions: `b_game`, `vip_chararacter_personalize`

## Project Structure

- **Models**: Contains the data models for users, login requests, and authentication responses.
- **Controllers**: Contains the `AuthController` which handles the login endpoint.
- **Static Data**: Contains predefined user data in the `StaticUserData` class.
- **JWT Token Generator**: A helper class to generate JWT tokens with user roles and regions in the claims.
- **Startup Configuration**: Configures services, authentication, and middleware for the application.
