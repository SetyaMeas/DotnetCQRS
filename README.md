# Setup

- Run: `dotnet build`
- Call **AddCQRSServices** from **DependencyInjection.cs** to register in the project where **Handler-class** located.

---

## Example of Registration

```xml
<!-- Application Layer -->
<!-- Application.csproj -->
<!-- Add package reference -->

<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>net9.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
    </PropertyGroup>

    <PropertyGroup>
        <RootNamespace>Application</RootNamespace>
        <AssemblyName>Application</AssemblyName>
    </PropertyGroup>

    <ItemGroup>
        <ProjectReference Include=".\Path\To\CQRS.csproj" />
    </ItemGroup>

    <ItemGroup>
      <PackageReference Include="Microsoft.Extensions.Hosting" />
    </ItemGroup>
</Project>
```

```csharp
// Application Layer
// Register dependency injection

using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.AddCQRSServices(Assembly.GetExecutingAssembly());
        }
    }
}
```
