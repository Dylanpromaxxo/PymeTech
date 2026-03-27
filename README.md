# 🧾 PymeTech - Sistema Administrativo SaaS para Gestión de Inventario

## 📌 Descripción

**PymeTech** es un sistema administrativo tipo **SaaS (Software as a Service)** enfocado en la **gestión de inventario para pequeñas y medianas empresas (PYMES)**.

El sistema permite administrar productos, usuarios, inventario y operaciones administrativas mediante una **arquitectura limpia, segura y escalable**.

Está construido con **.NET, Entity Framework, MediatR, JWT y Middlewares personalizados**, permitiendo una estructura profesional y preparada para futuras integraciones como **facturación electrónica**.

---

## 🚀 Tecnologías utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* MediatR (CQRS)
* JWT Authentication
* Clean Architecture
* Swagger
* Repository Pattern
* Middlewares
* IPipelineBehavior
* Dependency Injection

---

## 🧠 Arquitectura

El proyecto sigue **Clean Architecture** y el patrón **CQRS con MediatR**.

```
PymeTech
│
├── PymeTech.API
├── PymeTech.Application
├── PymeTech.Domain
├── PymeTech.Infrastructure
└── PymeTech.Tests (futuro)
```

### 🔹 Domain

* Entidades
* Interfaces
* Reglas de negocio

### 🔹 Application

* Commands
* Queries
* Handlers
* DTOs
* IPipelineBehavior
* Validators

### 🔹 Infrastructure

* Entity Framework
* Repositories
* Base de datos
* Implementaciones

### 🔹 API

* Controllers
* JWT
* Swagger
* Middlewares
* Configuración

---

## 🔐 Seguridad

El sistema implementa **autenticación y autorización con JWT**.

Características:

* Login seguro
* Generación de tokens
* Protección de endpoints
* Validación de usuarios
* Seguridad en la API

---

## ⚙️ Middlewares

El sistema implementa **middlewares personalizados** para mantener una arquitectura limpia y controlada.

### 🧯 Middleware de control de excepciones

Permite capturar errores globales y devolver respuestas controladas:

* manejo de excepciones
* respuestas HTTP correctas
* control centralizado de errores
* evita lógica de errores en controllers

Esto mejora la mantenibilidad y el control de la API.

---

## 🧪 Validaciones con IPipelineBehavior

Se implementa **IPipelineBehavior con MediatR** para validar comandos y queries antes de ejecutarlos.

### Beneficios:

* validaciones centralizadas
* código limpio
* separación de responsabilidades
* control de errores antes del handler
* arquitectura profesional

Flujo:

```
Request → Validator → PipelineBehavior → Handler → Response
```

---

## 📦 Funcionalidades

* Gestión de usuarios
* Gestión de productos
* Gestión de inventario
* API REST
* Autenticación JWT
* CQRS con MediatR
* Entity Framework
* Swagger
* Middleware de excepciones
* Validaciones con IPipelineBehavior

---

## 🧾 Futuras integraciones

* Facturación electrónica
* Multi-tenant
* Roles y permisos
* Dashboard administrativo
* Reportes
* Frontend web
* Docker
* CI/CD
* Auditoría de acciones


---

## 🔑 Autenticación

Enviar el token en los headers:

```
Authorization: Bearer token
```

---

## 🎯 Objetivo del proyecto

Construir un **sistema SaaS profesional para PYMES** que permita:

* control de inventario
* seguridad avanzada
* arquitectura escalable
* validaciones centralizadas
* control global de excepciones
* futura integración con facturación electrónica

---

## 👨‍💻 Autor

**Dylan Jiménez**
Desarrollador .NET
GitHub: https://github.com/Dylanpromaxxo

---

## ⭐ Estado del proyecto

🟡 En desarrollo

Próximas mejoras:

* facturación electrónica
* multi-tenant
* roles
* frontend
* docker
* tests
