# ThreeAmigos Staff Application

ThreeAmigosStaff is a sample application built using ASP.NET Core and Entity Framework Core utilising dependancy injection.

The construction of this project:
```
├── Services
│   ├── Customer
│   │   ├── CustomerDto.cs
│   │   ├── CustomerService.cs
│   │   ├── Data
│   │   │   └── customerContext.cs
│   │   ├── FakeCustomerService.cs
│   │   └── ICustomerService.cs
│   ├── Order
│   │   ├── FakeOrderService.cs
│   │   ├── IOrderService.cs
│   │   ├── OrderDto.cs
│   │   └── OrderService.cs
│   ├── Product
│   │   ├── FakeProductService.cs
│   │   ├── IProductService.cs
│   │   ├── ProductDto.cs
│   │   ├── ProductHistoryDto.cs
│   │   ├── ProductService.cs
│   │   └── ReviewDto.cs
│   ├── Purchase
│   │   ├── FakePurchaseService.cs
│   │   ├── IPurchaseService.cs
│   │   ├── PurchaseDto.cs
│   │   └── PurchaseService.cs
│   ├── Review
│   │   ├── FakeReviewService.cs
│   │   ├── IReviewService.cs
│   │   ├── ReviewDto.cs
│   │   └── ReviewService.cs
│   └── Staff
│       ├── FakeStaffService.cs
│       ├── IStaffService.cs
│       ├── StaffDto.cs
│       └── StaffService.cs
```

**To view the full structure go to [structure](./STRUCTURE.md)**

## Getting Started
Use these instuctions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017^](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.^](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300-rc1)

This is a front end application that uses serveral API's which are deployed to azure and exposed on these URL's:
## Front End Applications:
- [Staff Application](https://staffapplication.azurewebsites.net/)
  - [Staff Application Code](https://github.com/mhamwala/StaffApplication)
- [Customer Application](https://threesamigosapplication.azurewebsites.net/)
  - [Customer Application Code](https://github.com/jimmylid12/CustomerApplication)
  
## API's:

- [Third Party Orders API](https://third-party-orders-api01.azurewebsites.net/api/orders)
  - [Third Party Service Code](./ThreeAmigosStaff/ThreeAmigosStaff/Services/Purchase/PurchaseService.cs)
- [Manage Products API](https://manage-products-api.azurewebsites.net/api/products)
  - [Manage Products Service Code](./ThreeAmigosStaff/ThreeAmigosStaff/Services/Product/ProductService.cs)
- [Customer Accounts API](https://customeraccountapi.azurewebsites.net/api/customeraccounts)
  - [Customer Accounts Service Code](./ThreeAmigosStaff/ThreeAmigosStaff/Services/Customer/CustomerService.cs)
- [Staff Accounts API](https://staffaccountapi.azurewebsites.net/api/staffaccounts)
  - [Staff Accounts Service Code](./ThreeAmigosStaff/ThreeAmigosStaff/Services/Staff/StaffService.cs)
- [Customer Orders API](https://customerorderapi.azurewebsites.net/api/ordersservice)
  - [Customer Orders Service Code](./ThreeAmigosStaff/ThreeAmigosStaff/Services/Order/OrderService.cs)

### Setup [Development Mode]
Follow these steps to get your development environment setup with live API's:

  1. Clone the repository
  2. Traverse to the `ThreeAmigosStaff` directory.
  3. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  4. Next, build the solution by running:
     ```
     dotnet build
     ```
  5. Finally, within the `ThreeAmigosStaff` directory, launch the project by running:
     ```
     dotnet run
     ```

If you would like to manually run and build the API's, SQL server and and test it with the ThreeAmigosStaff App for whatever reason you can use docker-compose to do so.

### Setup [Production Mode]
  1. Go to the `ThreeAmigosStaff` directory.
  2. Edit the `docker-compose.yml` file by uncommenting which API you would like to run.
  3. At the root directory, restore required packages by running:
     ```
     docker-compose up --build
     ```
  4. Check that all the containers are up an running:
     ```
     docker ps -a
     ```
  5. Check the docker-compose file for the ports that are being exposed. Then go to http://localhost:5100

### Setup [Docker Compose]
  1. Go to the [Startup.cs](./ThreeAmigosStaff/ThreeAmigosStaff/Startup.cs) file.
  2. Add an `!` to the `_env.IsDevelopment` to force it to run in production mode: (example)
  ```bash
  if (!_env.IsDevelopment())
  ```
  3. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  4. Next, build the solution by running:
     ```
     dotnet build
     ```
  5. Finally, within the `ThreeAmigosStaff` directory, launch the project by running:
     ```
     dotnet run
     ```

## Technologies
* .NET Core 2.^
* ASP.NET Core 2.^
* Entity Framework Core 2.^
* Docker Compose
* Docker
