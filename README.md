# SmoothStrike - Taekwondo Match Overlay System

A real-time taekwondo match scoring and overlay system for live streaming.

## Quick Start

```bash
cd MyApi
dotnet run
```

The application will start on `http://localhost:5042`

## Features

- Real-time match scoring overlay for OBS/Streamlabs
- SignalR-based real-time communication
- TCP push server for external scoring systems
- REST API for match management
- Multi-mat support

## Overlay URL

```
http://localhost:5042/tks/overlay?mat={MAT_NUMBER}
```

Example: `http://localhost:5042/tks/overlay?mat=1`

## Documentation

For complete documentation in Swedish, see [ANVÄNDARMANUAL.md](ANVÄNDARMANUAL.md)

## Key Endpoints

- **Overlay**: `/tks/overlay?mat={mat}`
- **New Match**: `POST /tks/{matchCode}/events-listener/new-match-configured`
- **Match Event**: `POST /tks/{matchCode}/events-listener/new-match-event`
- **Match Result**: `POST /tks/{matchCode}/events-listener/match-result`
- **SignalR Hub**: `/hub`

## Technology Stack

- ASP.NET Core
- SignalR for real-time communication
- Entity Framework Core with SQL Server
- TCP/UDP servers for external system integration

## License

See repository for license information.
