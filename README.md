
# 🏭 MDF Price API

![C#](https://img.shields.io/badge/C%23-ASP.NET%20Core-512BD4?logo=dotnet)
![REST API](https://img.shields.io/badge/API-REST-blue)
![SQL](https://img.shields.io/badge/Database-SQLServer-lightgrey)
![License](https://img.shields.io/badge/License-MIT-orange)

## 🚀 Overview
MDF Price API is a **.NET Core backend service** that exposes structured endpoints for retrieving rebar product pricing data.  
It provides the raw data consumed by the analysis and dashboard services.

---

## ⚡ Features
- 📦 **Product listing** with details: name, type, size, form, standard, warehouse, and price  
- ⏱ **Timestamped pricing updates** with Jalali date support  
- 🔌 **JSON REST API** for easy consumption by other apps  
- 🗄 **Database integration** for scalable storage

---

## 🛠️ Tech Stack
- **ASP.NET Core 6**
- **Entity Framework Core**
- **SQL Server Database**
- **Swagger** for API documentation

---

## 📌 Endpoints
| Method | Endpoint            | Description                    |
|--------|--------------------|--------------------------------|
| `GET`  | `/api/Products`    | Retrieve all product data      |
| `GET`  | `/api/Products/{id}` | Retrieve product by ID        |

---

## ⚙️ Installation

# Clone the repo
    git clone https://github.com/frau-azadeh/MdfPriceApi.git
    cd RebarPriceApi

# Restore dependencies
    dotnet restore

# Run the API
    dotnet run

---

## 🤝 Contributing

Contributions are warmly welcomed!

Feel free to fork this repo, create a feature branch, and submit a pull request.

---

## 🌻Developed by

Azadeh Sharifi Soltani
