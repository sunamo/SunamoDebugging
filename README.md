# SunamoDebugging

## Short description

Pomocné třídy pro snazší ladění, vycházející z BCL a vlastního kódu.


Some BCl+mine code's helper classes for easier debugging

## Overview

SunamoDebugging is part of the Sunamo package ecosystem, providing modular, platform-independent utilities for .NET development.

## Main Components

### Key Classes

- **MemoryDebug**
- **NameValueCollectionDebug**
- **SqlServerHelperDebug**
- **StringBuilderDebug**
- **StringBuilderDebug2**

### Key Methods

- `Init()`
- `WriteLine()`
- `OverallConsumedByThisMethod()`
- `Print()`
- `RowsInTables()`
- `StringBuilder()`
- `CheckValidity()`
- `CheckValidityWorker()`

## Installation

```bash
dotnet add package SunamoDebugging
```

## Dependencies

- **Microsoft.Extensions.Logging.Abstractions** (v9.0.3)

## Package Information

- **Package Name**: SunamoDebugging
- **Version**: 25.6.7.1
- **Target Framework**: net9.0
- **Category**: Platform-Independent NuGet Package
- **Source Files**: 11

## Related Packages

This package is part of the Sunamo package ecosystem. For more information about related packages, visit the main repository.

## License

See the repository root for license information.

<!-- sunamo:test-coverage:start -->
## Test coverage

| Metric | Value |
|---|---|
| Method | static |
| Test projects | 1 |
| Public types referenced by tests | 0/5 (0.0 %) |
| Public methods referenced by tests | 0/10 (0.0 %) |
| Line coverage | n/a |
| Branch coverage | n/a |
| Generated (UTC) | 2026-11-22 21:24 |

<!-- sunamo:test-coverage:data {"package":"SunamoDebugging","container":"pinp","testProjects":1,"publicTypes":5,"typesReferencedByTests":0,"publicMethods":10,"methodsReferencedByTests":0,"lineRate":null,"branchRate":null,"method":"static","generatedUtc":"2026-11-22 21:24"} -->
<!-- sunamo:test-coverage:end -->
