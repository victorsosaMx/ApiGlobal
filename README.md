# API Proxy Controller

[![.NET](https://img.shields.io/badge/.NET-6.0+-purple.svg)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-6.0+-blue.svg)](https://docs.microsoft.com/aspnet/core)
[![RestSharp](https://img.shields.io/badge/RestSharp-Latest-green.svg)](https://restsharp.dev/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

Un controlador proxy robusto y flexible para ASP.NET Core que centraliza y estandariza las llamadas a múltiples APIs externas desde una sola interfaz unificada.

## 🚀 Características

- **Proxy Unificado**: Centraliza llamadas a múltiples APIs externas
- **Múltiples Métodos HTTP**: Soporte para GET, POST, PUT, DELETE, PATCH
- **Flexibilidad de Formato**: Respuestas en JSON, XML, HTML, texto plano
- **Autenticación**: Soporte para tokens de autorización y Bearer tokens
- **Codificación**: Manejo de ISO-8859-1 para sistemas legacy
- **Logging**: Sistema de logging configurable y detallado
- **Descarga de Archivos**: Generación automática de archivos de respuesta
- **Validación**: Validación robusta de parámetros de entrada
- **Manejo de Errores**: Gestión comprehensiva de errores y excepciones

## 📋 Requisitos

- .NET 6.0 o superior
- ASP.NET Core 6.0+
- RestSharp (última versión)
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Logging

## 🛠️ Instalación

1. Clona el repositorio:
```bash
git clone https://github.com/victorsosaMx/ApiGlobal.git
cd ApiGlobal
```

2. Instala las dependencias:
```bash
dotnet restore
```

3. Configura `appsettings.json`:
```json
{
  "ApiServers": {
    "DummyData1": "https://dummyjson.com",
    "JsonPlaceholder": "https://jsonplaceholder.typicode.com",
    "MiApiPersonalizada": "https://mi-api.ejemplo.com"
  },
  "DirectorioLogs": "C:\\Logs\\ApiProxy\\"
}
```

## 🔧 Configuración

### Servidores API
Define los servidores disponibles en la sección `ApiServers` del archivo `appsettings.json`:

```json
{
  "ApiServers": {
    "servidor1": "https://api1.ejemplo.com",
    "servidor2": "https://api2.ejemplo.com"
  }
}
```

### Directorio de Logs
Configura la ruta donde se almacenarán los logs:

```json
{
  "DirectorioLogs": "C:\\Logs\\ApiProxy\\"
}
```

## 📚 Uso

### Endpoint Principal
```
POST /ApiProxy
```

### Estructura de Solicitud

```json
{
  "Servidor": "DummyData1",
  "Opcion": "products",
  "Metodo": "GET",
  "Usuario": "Sistema",
  "Sistema": "MI PROGRAMA",
  "Funcion": "MI FUNCION",
  "Body": "json",
  "CorregirISO8859": false,
  "DescargaArchivoSwagger": true,
  "LogSoloEnError": false,
  "AuthorizationToken": "",
  "BearerAuthorizationToken": "",
  "Parametros": {
 
  }
}
```

### Parámetros de Solicitud

| Parámetro | Tipo | Requerido | Descripción |
|-----------|------|-----------|-------------|
| `Servidor` | string | ✅ | Nombre del servidor configurado |
| `Opcion` | string | ✅ | Endpoint o ruta específica |
| `Metodo` | string | ✅ | Método HTTP (GET, POST, PUT, DELETE, PATCH) |
| `Usuario` | string | ❌ | Usuario que realiza la solicitud |
| `Sistema` | string | ❌ | Sistema origen de la solicitud |
| `Funcion` | string | ❌ | Función que ejecuta la solicitud |
| `Body` | string | ❌ | Formato de respuesta (json, xml, html, text) |
| `CorregirISO8859` | bool | ❌ | Usar codificación ISO-8859-1 |
| `DescargaArchivoSwagger` | bool | ❌ | Generar archivo de descarga |
| `LogSoloEnError` | bool | ❌ | Registrar solo errores |
| `AuthorizationToken` | string | ❌ | Token de autorización directo |
| `BearerAuthorizationToken` | string | ❌ | Bearer token |
| `Parametros` | object | ❌ | Parámetros de la solicitud |

## 📖 Ejemplos de Uso

### 1. Solicitud GET Simple
```json
{
  "Servidor": "DummyData1",
  "Opcion": "products",
  "Metodo": "GET",
  "Usuario": "Sistema",
  "Sistema": "MI PROGRAMA",
  "Funcion": "OBTENER_PRODUCTOS",
  "Body": "json",
  "Parametros": {
    "limit": "5"
  }
}
```

### 2. Solicitud POST con Autenticación
```json
{
  "Servidor": "MiApiPersonalizada",
  "Opcion": "users",
  "Metodo": "POST",
  "Usuario": "admin",
  "Sistema": "USER_MANAGEMENT",
  "Funcion": "CREAR_USUARIO",
  "Body": "json",
  "BearerAuthorizationToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "Parametros": {
    "name": "Juan Pérez",
    "email": "juan@ejemplo.com",
    "role": "user"
  }
}
```

### 3. Solicitud con Descarga de Archivo
```json
{
  "Servidor": "DummyData1",
  "Opcion": "products",
  "Metodo": "GET",
  "Body": "json",
  "DescargaArchivoSwagger": true,
  "Parametros": {
    "limit": "100"
  }
}
```

### 4. Solicitud con Codificación ISO-8859-1
```json
{
  "Servidor": "SistemaLegacy",
  "Opcion": "consulta",
  "Metodo": "POST",
  "Body": "xml",
  "CorregirISO8859": true,
  "Parametros": {
    "usuario": "admin",
    "consulta": "SELECT * FROM productos"
  }
}
```

## 🔍 Respuestas

### Respuesta Exitosa
```json
{
  "products": [
    {
      "id": 1,
      "title": "iPhone 9",
      "description": "An apple mobile...",
      "price": 549
    }
  ]
}
```

### Respuesta de Error
```json
{
  "Error": "Se produjo un error al procesar la solicitud.",
  "Details": "Servidor no válido: ServidorInexistente",
  "Timestamp": "2024-01-15T10:30:00Z"
}
```

## 📊 Logging

El sistema genera logs detallados que incluyen:

- Método HTTP utilizado
- URL construida
- Headers de solicitud y respuesta
- Códigos de estado
- Tiempo de respuesta
- Contenido de respuesta (configurable)
- Información de autenticación (sin mostrar tokens)

### Estructura de Logs
```
{DirectorioLogs}/
├── {Sistema}/
│   └── {Funcion}/
│       └── log_{fecha}.json
```

## 🛡️ Seguridad

- **Validación de Entrada**: Todos los parámetros son validados
- **Escape de URL**: Los parámetros de URL son escapados apropiadamente
- **Métodos HTTP**: Solo se permiten métodos HTTP válidos
- **Sanitización**: Los paths de archivos son sanitizados
- **Timeout**: Timeout configurado para evitar solicitudes colgadas

## 🔧 Configuración Avanzada

### Timeout Personalizado
```csharp
private const int DEFAULT_TIMEOUT_SECONDS = 360; // 6 minutos
```

### Tipos de Contenido Soportados
- `application/json`
- `application/xml`
- `text/html`
- `text/plain`
- `application/x-www-form-urlencoded`

### Codificaciones Soportadas
- UTF-8 (por defecto)
- ISO-8859-1 (para sistemas legacy)

## 🚀 Pruebas

### Usando cURL
```bash
curl -X POST "https://localhost:7127/ApiProxy" \
  -H "Content-Type: application/json" \
  -d '{
    "Servidor": "DummyData1",
    "Opcion": "products",
    "Metodo": "GET",
    "Body": "json",
    "Parametros": {
      "limit": "5"
    }
  }'
```

### Usando Swagger
Accede a la documentación interactiva:
```
https://localhost:7127/swagger/index.html
```

## 📈 Monitoreo

El controlador incluye headers informativos para debugging:

- `Constructed-Url`: URL completa construida
- `Constructed-Url-Method`: Método HTTP utilizado

## 🤝 Contribución

1. Fork el proyecto
2. Crea tu rama de características (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📝 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

## 🙏 Agradecimientos

- [RestSharp](https://restsharp.dev/) por la excelente librería HTTP
- [ASP.NET Core](https://docs.microsoft.com/aspnet/core) por el framework
- La comunidad de desarrolladores por el feedback y contribuciones

## 📞 Soporte

Si tienes problemas o preguntas:

1. Revisa la [documentación](#-uso)
2. Busca en [Issues](https://github.com/tu-usuario/api-proxy-controller/issues)
3. Crea un [nuevo Issue](https://github.com/tu-usuario/api-proxy-controller/issues/new)

---

⭐ ¡No olvides dar una estrella si este proyecto te ayudó!
