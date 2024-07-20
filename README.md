# StockHawk - NCI Final Project

Inventory Management System with Azure Integration

StockHawk is a web-based application designed to simplify inventory management processes for businesses. Built with a focus on user-friendliness and scalability, StockHawk empowers users to efficiently track and manage their product inventory.

## Details:

This project implements a web-based Inventory Management System named StockHawk. It's a monolithic application deployed in Docker containers to Azure App Service.

## Functionalities:

- **Product Management:** Add, edit, and delete products with details like name, description, category, price, and quantity.
- **Supplier Management:** Add, edit, and delete suppliers with contact information and payment terms.
- **Order Management:** Users can create purchase orders for products from suppliers, specifying quantity and expected delivery date. Admins can approve/reject user-submitted orders.
- **Inventory Tracking:** Track current stock levels for each product and receive alerts for low stock.
- **User Roles and Permissions:** Implement RBAC (Role-Based Access Control) with Admin and User roles. Admins have additional functionalities like user management and order approval.

## Technology Stack:

- **Frontend:** React
- **Backend:** ASP.NET Core
- **Database:** SQL Sever / Azure SQL
- **Authentication:** Azure B2C
- **Deployment:** Docker Containers on Azure App Service
- **CI/CD:** GitHub Actions

## Project Setup:

1. Clone this repository.
2. Configure your chosen database connection details in the ASP.NET Core project (appsettings.json).
3. Configure Azure B2C tenant details and integration with your ASP.NET Core API (refer to Azure B2C documentation).
4. Configure Azure service principal credentials and App Service deployment settings in your GitHub Actions workflows (refer to GitHub Actions documentation).

## Docker Setup:

Dockerfiles will be created to package both the React application and the ASP.NET Core API into container images.

## Running the Application Locally:

1. Ensure you have Docker installed and running on your development machine.
2. Build the Docker images using docker build commands (refer to the project's documentation for specific commands).
3. Run the containers using docker run commands (refer to the project's documentation for specific commands).

## Deployment:

This project utilizes GitHub Actions for automated deployment. Pushing code changes to the main branch will trigger the workflows to:

1. Build Docker images for the React application and ASP.NET Core API.
2. Push the Docker images to a container registry (e.g., Azure Container Registry).
3. Deploy the container images to separate Azure App Services.
