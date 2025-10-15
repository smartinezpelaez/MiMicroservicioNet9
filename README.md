# 🧩 MiMicroservicio API (.NET 8 + MongoDB + Azure)

Microservicio desarrollado en **.NET 8** con arquitectura limpia (Core, Infrastructure, API), persistencia en **MongoDB**, y preparado para despliegue en **Azure App Service** y **Cosmos DB**.

---

## 🚀 Características principales

- API REST construida con **ASP.NET Core 8**
- Persistencia en **MongoDB** (local o Cosmos DB en Azure)
- Arquitectura limpia (Core / Infrastructure / Api)
- Repositorio genérico con inyección de dependencias
- Integración con **Swagger UI**
- Preparado para despliegue en **Azure App Service**
- Automatizable con **Azure Logic Apps**

---

## 🗂️ Estructura del proyecto

MiMicroservicio/
│
├── MiMicroservicio.Api/ # Proyecto principal (API REST)
├── MiMicroservicio.Core/ # Entidades, interfaces, lógica de negocio
├── MiMicroservicio.Infrastructure/ # Repositorios, conexión a MongoDB
├── README.md # Documentación del proyecto
└── MiMicroservicio.sln # Solución principal


---

## ⚙️ Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [MongoDB local o Atlas](https://www.mongodb.com/try/download/community)
- [Visual Studio Code](https://code.visualstudio.com/)
- Extensión **C# for VS Code**
- Cuenta en [Azure](https://portal.azure.com/)
- Extensión **Azure App Service** para VS Code

---

## 🧰 Configuración local

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/tu-usuario/MiMicroservicio.git
   cd MiMicroservicio
2. Editar el archivo appsettings.json en MiMicroservicio.Api:

"MongoSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "MiMicroservicioDB"
}

3. Ejecutar el proyecto localmente:
cd MiMicroservicio.Api
dotnet run

4. Abrir Swagger UI:
https://localhost:5001/swagger

## Endpoints principales

| Método | Endpoint             | Descripción                    |
| ------ | -------------------- | ------------------------------ |
| GET    | `/api/clientes`      | Obtiene todos los clientes     |
| GET    | `/api/clientes/{id}` | Obtiene un cliente por ID      |
| POST   | `/api/clientes`      | Crea un nuevo cliente          |
| PUT    | `/api/clientes/{id}` | Actualiza un cliente existente |
| DELETE | `/api/clientes/{id}` | Elimina un cliente             |

## ☁️ Despliegue en Azure

1. Publicar el proyecto:
cd MiMicroservicio.Api
dotnet publish -c Release -o ../publish

2. Subir el contenido de /publish a Azure App Service
(puedes hacerlo desde Visual Studio Code con la extensión Azure App Service).

3. Configurar en el portal de Azure:

Variable de entorno MongoSettings__ConnectionString

Variable de entorno MongoSettings__DatabaseName

4. Verificar en producción:
https://<tu-appservice>.azurewebsites.net/swagger

## 🔄  Migración a Cosmos DB (opcional)
Crea un recurso Azure Cosmos DB for MongoDB API

Actualiza tu cadena de conexión en appsettings.json o en variables de entorno:

"MongoSettings": {
  "ConnectionString": "mongodb://<user>:<password>@<tu-cosmos-uri>/?ssl=true",
  "DatabaseName": "MiMicroservicioDB"
}

## Automatizacion del flujo de trabajo con Git actions y LogicApps

- Se crea flijo de trabajo para pruebas automatizadas con Logicapps y GitActions


## 🧩 Estructura de carpetas recomendada

MiMicroservicio.Api/
│
├── Controllers/
├── appsettings.json
├── Program.cs
└── Properties/

## 👨‍💻 Autor

Steven Martínez
Ingeniero de Sistemas | Desarrollador .NET

🛠️ Licencia
Este proyecto se distribuye bajo la licencia MIT.
Puedes usarlo libremente para aprendizaje o como base para tus proyectos.