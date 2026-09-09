# Part G --- Short Answers

## Q1 --- `.csproj` Configuration

The project file should contain the four properties required in Part A:
`OutputType`, `TargetFramework`, `ImplicitUsings`, and `Nullable`.

Example:

``` xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

### Confirmation

-   `OutputType` is present and set to `Exe`, meaning the project builds
    an executable application.
-   `TargetFramework` is present and specifies the .NET version targeted
    by the project.
-   `ImplicitUsings` is present and enabled, allowing common namespaces
    to be imported automatically.
-   `Nullable` is present and enabled, enabling nullable reference type
    analysis.

> **Note:** Replace the example above with the exact contents of the
> project's actual `.csproj` file if its `TargetFramework` or other
> settings differ.

------------------------------------------------------------------------

## Q2 --- Do `#region` / `#endregion` change the compiled output? Why might you still use them?

No. `#region` and `#endregion` do not change the compiled output or the
behavior of the program.

They are used to organize source code by allowing sections of code to be
collapsed and expanded in an IDE. They can be useful for grouping
related fields, methods, or other sections in larger files.

Example:

``` csharp
#region Helper Methods

static void MethodOne()
{
}

static void MethodTwo()
{
}

#endregion
```

Their purpose is code organization and readability, not program
execution.

------------------------------------------------------------------------

## Q3 --- When would you use `///` XML documentation comments instead of a plain `//` comment?

A plain `//` comment is normally used to explain implementation details
or leave notes for developers inside the source code.

``` csharp
// Calculate the discounted order total.
TotalPrice = Quantity * UnitPrice;
```

XML documentation comments use `///` and are appropriate when
documenting classes, methods, properties, parameters, return values, and
other public APIs.

Example:

``` csharp
/// <summary>
/// Calculates the total price of the order.
/// </summary>
public void CalculateTotal()
{
    // ...
}
```

XML documentation can be recognized by development tools and used for
features such as IntelliSense and generated API documentation.

In short:

``` text
//  → comments about the code

/// → documentation for the API/code element
```

------------------------------------------------------------------------

## Q4 --- Why does C# have no true global variables, and what is the closest equivalent?

C# organizes variables and behavior inside types such as classes and
structs rather than allowing variables to exist independently in a
global scope.

The closest equivalent to a global variable is usually a `static` field
on a class because it belongs to the type itself and can be accessed
without creating an instance of that class.

Example:

``` csharp
public static class ApplicationState
{
    public static int Counter = 0;
}
```

It can then be accessed using:

``` csharp
ApplicationState.Counter++;
```

This provides global-like access while still keeping the variable owned
and organized by a type.
