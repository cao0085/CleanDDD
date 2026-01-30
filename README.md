# CleanDDD

A .NET 9 project template based on Clean Architecture and Domain-Driven Design (DDD) principles.

## Tech Stack

- .NET 9
- ASP.NET Core Web API
- MediatR (CQRS Pattern)
- Scalar (API Documentation)

## Project Structure

```
CleanDDD/
├── CleanDDD.Domain/           # Domain Layer - Entities, Value Objects, Domain Events
├── CleanDDD.Application/      # Application Layer - Commands, Queries, Handlers
├── CleanDDD.Infrastructure/   # Infrastructure Layer - Database, External Services
├── CleanDDD.WebApi/           # Presentation Layer - API Controllers
└── CleanDDD.Domain.UnitTests/ # Domain Layer Unit Tests
```

## Architecture

### Layer Dependencies

```
WebApi → Infrastructure → Application → Domain
```

- **Domain**: Core business logic, no external dependencies
- **Application**: Use case implementations, defines interfaces (Ports)
- **Infrastructure**: Implements Application layer interfaces (Adapters)
- **WebApi**: HTTP entry point, handles request/response

## Getting Started

```bash
# Restore packages
dotnet restore

# Run the project
dotnet run --project CleanDDD.WebApi

# Run tests
dotnet test
```

## Notes

### MediatR Registration

```csharp
// MediatR v12 registration
// Auto-registers IMediator, ServiceFactory, and custom Handlers
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<LoginUserCommand>();
});
```

### MediatR Execution Flow

```csharp
// Send - Single Handler processing
var result = await _mediator.Send(new LoginUserCommand("user", "pwd"));

// Publish - Broadcast event to all Handlers
await _mediator.Publish(new UserLoggedInNotification(userId));
```

### Controller Flow

1. Inject `IMediator` via DI
2. Call `mediator.Send(command)` to dispatch command
3. MediatR resolves and executes the corresponding Handler
