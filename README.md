# Evaluacion


## Descipción
Proyecto creado con .NET 6, EF Core 6, MediatR como implementación de patrón de diseño mediator, CQRS para separar operaciones modificacion/lectura, FluentValidation, Swagger, Automapper para mapeo de entidades -> dto's, InMemoryCaching como cache en memoria, xUnit para pruebas. El proyecto se encuentra divido en las capas Application, Infraestructure y Domain como implementación de clean architecture.

## Uso
Para utilizar el proyecto es necesario:
1. Tener instalado el SDK de .NET 6.
2. Clonar o descargar el proyecto.
3. Dentro de src/Evaluacion.API/ correr el comando `dotnet run`.
* El proyecto corre sobre `https://localhost:7192`, se puede utilizar swagger para probar los endpoints (`https://localhost:7192/swagger/index.html`) o cualquier api client.
* El proyecto utiliza EF.InMemory para crear una base de datos en memoria, en caso de querer persistir los datos es necesario cambiar el valor de `"UseInMemoryDatabase"` a `false` dentro de `appsettings.json`.
* La aplicación guarda logs de información en un archivo logs.txt que se encuentra en `src/Evaluacion.API/`.
