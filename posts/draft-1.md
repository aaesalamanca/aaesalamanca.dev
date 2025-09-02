---
published-date: 2024-07-15
edited-date: 2024-07-20
description: 'Primeros pasos con Razor Pages en .NET 8.'
is-draft: true
---

# Introducción a Razor Pages

Razor Pages simplifica el modelo de páginas en ASP.NET Core.

```csharp
public class HelloModel : PageModel
{
    public string Message { get; private set; } = "Hola!";
    public void OnGet() { }
}
```
