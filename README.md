# Prueba BAGUER Fullstack: Registro y Login con .NET

## Descripción del Proyecto:
Este proyecto fullstack proporciona una aplicación web que permite a los usuarios registrarse y autenticarse utilizando dos endpoints proporcionados por un backend desarrollado en .NET. La interfaz de usuario está construida con Taiwklidn y DaisyUI para un diseño moderno y receptivo.

## Backend (.NET):
El backend del proyecto está construido utilizando la plataforma .NET y proporciona dos endpoints principales:

1. **Endpoint de Registro**:
   - **Ruta**: `/api/User/register`
   - **Esquema**:
     ```json
     {
       "username": "string",
       "password": "string",
       "name": "string"
     }
     ```
   - Este endpoint permite a los usuarios registrarse proporcionando un nombre de usuario, una contraseña y un nombre.

2. **Endpoint de Inicio de Sesión**:
   - **Ruta**: `/api/User/login`
   - **Esquema**:
     ```json
     {
       "username": "string",
       "password": "string"
     }
     ```
   - Este endpoint permite a los usuarios iniciar sesión proporcionando su nombre de usuario y contraseña.

## Frontend (Taiwklidn y DaisyUI):
El frontend de la aplicación está construido utilizando Taiwklidn y DaisyUI, dos herramientas de diseño que ofrecen componentes preestablecidos y estilos modernos para una experiencia de usuario atractiva y fácil de usar.

## Archivo SQL de Base de Datos:
El proyecto también incluye un script SQL que puede ser utilizado para crear y configurar la base de datos necesaria para el funcionamiento del backend. Este script puede ser importado en un sistema de gestión de bases de datos compatible para configurar la base de datos necesaria.

## Instrucciones de Ejecución:
1. Clona este repositorio en tu máquina local.
2. Configura y ejecuta el backend utilizando los siguientes comandos:
   - `dotnet build`
   - `dotnet run --project .\Presentation\`
   - `dotnet ef database update -p Persistence -s Presentation`
   - `dotnet ef migrations add name -p Persistence -s Presentation -o Data/Migrations`
3. Configura y ejecuta el frontend utilizando la extensión Live Server de Visual Studio Code.

