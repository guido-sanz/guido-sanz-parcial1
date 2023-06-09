<h1 align="center">
  <p align="center">GUIDO-SANZ-APP-MOTOS</p>
</h1>

![Imagen ilustrativa](https://github.com/guido-sanz/guido-sanz-parcial1/blob/main/img/ColDualSptNoRack.jpg)

<p align="left">
   <img src="https://img.shields.io/badge/STATUS-EN%20DESAROLLO-green">
   <img src="https://img.shields.io/badge/LANGUAJE-.NET-blueviolet">
   <img src="https://img.shields.io/badge/VERSION-1.0-blue">
   <img src="https://img.shields.io/badge/LICENSE-ISTEA-orange"> 
</p>

<h2>Descripción del Proyecto</h2>
<p>El proyecto existente es un sistema de gestión que permite administrar agencias de motos, controlar inventarios y supervisar las motos en stock. Proporciona una plataforma donde los usuarios pueden crear agencias, agregar y actualizar motos en sus inventarios exclusivos, así como realizar un seguimiento de las ventas y generar informes relacionados. El objetivo es optimizar la gestión de las agencias de motos, mejorar la eficiencia en el control de inventarios y brindar herramientas para el seguimiento y análisis de datos relevantes.</p>

## :hammer:Funcionalidades del proyecto

- `Funcionalidad 1`: Administración de agencias
    - Creación de agencias con información básica (nombre, ubicación, contacto, etc.)
    - Edición y actualización de detalles de agencias existentes.
    - Asignación de usuarios y permisos a cada agencia.
      
- `Funcionalidad 2`: Gestión de inventarios
    - Creación de inventarios exclusivos para cada agencia.
    - Edición y actualización de detalles de agencias existentes.
    - Agregado de motos al inventario con detalles específicos (marca, modelo, año, características, precios, etc.).
    - Actualización y eliminación de motos existentes en el inventario.
    - Seguimiento de la disponibilidad de las motos en stock.

- `Funcionalidad 3`: Control de ventas
    - Registro de ventas de motos realizadas por cada agencia.
    - Seguimiento de las motos vendidas y su estado actual.
    - Generación de informes de ventas, incluyendo datos como agencia, moto vendida, fecha y precio.

- `Funcionalidad negocio`
    - Al cargar una nueva moto al inventario, si esta moto ya existe se le suma a la cantidad en stock.
    - Al ingresar al inventario de una oficina se muestra la cantidad total de dinero en stock y la cantidad de motos en stock.

## 📁 Acceso al proyecto

- `¿Como acceder al proyecto`:
    - [Link a repositorio github](https://github.com/guido-sanz/guido-sanz-parcial1)

## 🛠️ Abre y ejecuta el proyecto

-  `¿Como ejecutar el proyecto`:
    - 1° instalar la dependencias para utilizar ORM
        - "dotnet tool install --global dotnet-aspnet-codegenerator"          
        - "dotnet tool install --global dotnet-ef"
        - "dotnet add package Microsoft.EntityFrameworkCore.Design"
        - "dotnet add package Microsoft.EntityFrameworkCore.SQLite"
        - "dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design"
        - "dotnet add package Microsoft.EntityFrameworkCore.Tools"
    - 2° Ejecutar el comando "dotnet build"
    - 3° ejecutar el comando "dotnet run" para iniciar la aplicacion

## ✔:Tecnologías utilizadas
  - Microsoft .NET
  - HTML
  - JAVASCRIPT

