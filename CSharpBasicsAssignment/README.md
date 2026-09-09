# C# Basics --- Assignment 4

A console-based C# assignment covering the core concepts from **Module
1-1 / Lecture 01**, including project structure, variables and types,
casting, value vs. reference semantics, scope, operators, and the basic
stack/heap memory model.

## Assignment Overview

The project is organized as a set of small, focused exercises inside a
single console solution. Each part demonstrates a specific C#
fundamental through executable code, comments, console output, or
supporting Markdown documentation.

### Topics Covered

-   .NET solution and project structure
-   C# variables and built-in types
-   Type inference with `var`
-   Implicit and explicit conversions
-   Casting and `Convert.ToInt32`
-   Integer vs. floating-point division
-   Boxing and unboxing
-   `Parse` and `TryParse`
-   `float` to `decimal` conversion
-   Value types and reference types
-   `struct` copy semantics
-   `class` reference semantics
-   Basic stack and heap reasoning
-   Field, method, and block scope
-   Compound assignment operators
-   Bitwise `&`, `|`, and `^`
-   XOR-based problem solving

## Project Structure

``` text
CSharpBasicsAssignment/
├── CSharpBasicsAssignment.csproj
├── Program.cs
├── Order.cs
├── STACK_HEAP.md
├── README.md
└── ANSWERS.md
```

### File Responsibilities

  -----------------------------------------------------------------------
  File                                Purpose
  ----------------------------------- -----------------------------------
  `CSharpBasicsAssignment.csproj`     Defines the .NET project
                                      configuration and target framework.

  `Program.cs`                        Contains the executable
                                      demonstrations for the assignment
                                      parts.

  `Order.cs`                          Contains the `Order` reference type
                                      used for the value/reference and
                                      memory-model exercises.

  `STACK_HEAP.md`                     Contains the three required
                                      stack/heap diagrams and the struct
                                      comparison.

  `ANSWERS.md`                        Contains the short-answer section
                                      of the assignment.

  `README.md`                         Documents the project, covered
                                      concepts, structure, and execution
                                      instructions.
  -----------------------------------------------------------------------

## Assignment Parts

### Part A --- Project & Structure

Demonstrates understanding of the .NET project structure rather than
only running a console application.

Topics include:

-   `.csproj`
-   `Program.cs`
-   `obj/`
-   `bin/`
-   File-scoped namespaces
-   Classic `.sln` and newer `.slnx` solution formats
-   Important project properties such as `OutputType`,
    `TargetFramework`, `ImplicitUsings`, and `Nullable`

### Part B --- Variables, Types & Casting

Implements `RunTypesDemo()` to demonstrate the fundamental C# types and
conversion behavior.

Types used include:

``` csharp
int
long
double
decimal
bool
char
string
var
```

The section also demonstrates:

``` text
int → long                 implicit conversion
char → int                 implicit conversion
double → int               explicit conversion
(int)double                truncation
Convert.ToInt32(double)    rounding
int / int                  integer division
double / int               floating-point division
int → object               boxing
object → int               unboxing
string → int               parsing
float → decimal            explicit conversion
```

### Part C --- Value vs. Reference Types

Demonstrates the behavioral difference between value types and reference
types.

#### Struct copy semantics

A `Point` struct is copied:

``` csharp
Point p2 = p1;
```

Changing `p2` does not modify `p1` because the value itself was copied.

#### Class reference semantics

An `Order` class is used to demonstrate reference assignment:

``` csharp
Order o2 = o1;
```

Both variables refer to the same `Order` instance, so a modification
through one reference is visible through the other.

The section also uses:

``` csharp
object.ReferenceEquals(o1, o3)
```

to verify that two references point to the exact same object.

### Part D --- Scope & Operators

Covers three forms of variable scope:

-   Field scope
-   Method scope
-   Block scope

It also demonstrates compound assignment operators:

``` csharp
+=
-=
*=
/=
%=
```

and the bitwise operators:

``` csharp
&
|
^
```

Using the required values:

``` csharp
int a = 12; // 1100
int b = 10; // 1010
```

produces:

``` text
12 & 10 = 8
12 | 10 = 14
12 ^ 10 = 6
```

### Part E --- Stack & Heap

`STACK_HEAP.md` visualizes the memory model for:

``` csharp
Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };
Order o2 = o1;
o2.IsPaid = true;
```

The diagrams show that `o1` and `o2` refer to the same `Order` object
and that changing the object through `o2` is therefore visible through
`o1`.

The document also compares this behavior with the `Point` struct from
Part C.

### Part F --- LeetCode 136: Single Number

The assignment applies the XOR operator to solve **Single Number** in
linear time and constant extra space.

Required method:

``` csharp
int FindSingleNumber(int[] nums)
```

The intended solution uses:

``` csharp
^
```

without dictionaries, sorting, or an additional array.

The important XOR properties are:

``` text
x ^ x = 0
x ^ 0 = x
```

Therefore, when every duplicate pair is XORed together, the pairs cancel
out and the number that occurs only once remains.

### Part G --- Short Answers

The final section documents:

1.  The `.csproj` configuration.
2.  Whether `#region` / `#endregion` affect compiled output.
3.  When XML documentation comments (`///`) are appropriate.
4.  Why C# has no true global variables and what the closest equivalent
    is.

## `Order` Model

The `Order` class contains exactly ten concrete-typed fields:

``` text
OrderId
CustomerName
Quantity
UnitPrice
TotalPrice
IsPaid
DiscountPercent
ShippingCity
Priority
ItemCode
```

It also contains two methods:

``` csharp
CalculateTotal()
PrintSummary()
```

`CalculateTotal()` calculates the order total using quantity, unit
price, and discount percentage.

`PrintSummary()` prints the essential order information to the console.

## Running the Project

### Requirements

Install a compatible .NET SDK.

Verify the installation with:

``` bash
dotnet --version
```

### Run

From the project directory:

``` bash
dotnet run
```

### Build

``` bash
dotnet build
```

The compiled output is generated under:

``` text
bin/
```

while intermediate build files are generated under:

``` text
obj/
```

## Learning Objectives

After completing this assignment, the project should demonstrate an
understanding of:

-   How a .NET solution and project are structured
-   How C# represents and converts common data types
-   When implicit and explicit conversions occur
-   How boxing and unboxing work
-   How parsing differs from casting
-   How value-type assignment differs from reference-type assignment
-   How class references relate to shared object identity
-   How scope controls variable visibility
-   How compound and bitwise operators behave
-   How to reason about a simple stack/heap model
-   How XOR can be applied to solve a small algorithmic problem

## Course

**C# Basics --- Module 1-1**\
**Assignment 4: Console Apps, Types & Memory Model**\
SIMULATION · Software House & Academy
