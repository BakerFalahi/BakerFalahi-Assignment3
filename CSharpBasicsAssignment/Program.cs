using CSharpBasicsAssignment.Classes;
using System.Drawing;

namespace CSharpBasicsAssignment;

// csproj: (this is the Project configuration file) each project has this file to determine everything about the project, including the platform version, enabel/disable features, version of packages and some other settings.
// Program.cs: this file contains the main entry point for the application
// bin/: this folder contains the compiled(Build) output of the project, including the executable and any dependencies.
// obj/: this folder contains the intermediate files generated during the build process, including the compiled assemblies and other build artifacts. contains the cashed files that are used to speed up the build process.
// Sln: is widlely supported. I use slnx its more organized.
internal class Program
{
    private static void Main(string[] args)
    {
        //RunTypesDemo();

        // reference types are stored in the heap memory, while value types are stored in the stack memory. This can lead to different performance characteristics and memory usage patterns.
        Order o1 = new Order
        {
            OrderId = 1,
            CustomerName = "Baker",
            Quantity = 3,
            UnitPrice = 30.00m,
            TotalPrice = 0m,
            IsPaid = false,
            DiscountPercent = 10.0,
            ShippingCity = "Vienna",
            Priority = 'H',
            ItemCode = 100001L
        };

        o1.CalculateTotal();
        o1.PrintSummary();

        // When we assign o1 to o2, we are copying the reference to the same object in memory. Therefore, both o1 and o2 point to the same Order object. When we modify the IsPaid property of o2, it also affects the IsPaid property of o1 because they refer to the same object.
        Order o2 = o1;

        o2.IsPaid = true;

        Console.WriteLine($"o1.IsPaid: {o1.IsPaid}");
        Console.WriteLine($"o2.IsPaid: {o2.IsPaid}");

        // boxing reference type to object type.
        object boxedOrder = o1;
        int number = 42;
        object boxedNumber = number;
        Order o3 = (Order)boxedOrder;
        Console.WriteLine($"Same instance: {object.ReferenceEquals(o1, o3)}");

        o2.PrintSummary();

        RunScopeAndOperatorsDemo();

    }

    static void RunTypesDemo()
    {
        #region Variable Declaration and Initialization
        int age = 38;
        long population = 9_000_000_000L;
        double height = 187.5;
        decimal accountBalance = 1520.75m;
        bool isStudent = true;
        char grade = 'A';
        string name = "Baker";
        var score = 95;

        Console.WriteLine($"age: {age}, Type: {age.GetType()}");
        Console.WriteLine($"population: {population}, Type: {population.GetType()}");
        Console.WriteLine($"height: {height}, Type: {height.GetType()}");
        Console.WriteLine($"accountBalance: {accountBalance}, Type: {accountBalance.GetType()}");
        Console.WriteLine($"isStudent: {isStudent}, Type: {isStudent.GetType()}");
        Console.WriteLine($"grade: {grade}, Type: {grade.GetType()}");
        Console.WriteLine($"name: {name}, Type: {name.GetType()}");
        Console.WriteLine($"score: {score}, Type: {score.GetType()}");

        #endregion

        #region Type Conversion and Casting 
        // Implicit conversion from int to long and char to int because long can hold larger values than int, and int can hold larger values than char. Therefore, the conversion is safe and does not result in data loss.
        int smallNumber = 100;
        long bigNumber = smallNumber;

        char letter = 'A';
        int characterCode = letter;
        Console.WriteLine($"int → long: {bigNumber}");
        Console.WriteLine($"char → int: {characterCode}");

        // truncation occurs when converting from a floating-point type (double) to an integral type (int). The fractional part of the number is discarded, and only the whole number part is retained. This can lead to loss of precision and unexpected results if not handled carefully.
        // rounding occurs when using Convert.ToInt32, which rounds the number to the nearest integer. If the fractional part is 0.5 or greater, it rounds up; otherwise, it rounds down. This can lead to different results compared to truncation, especially for numbers with a fractional part of exactly 0.5.
        double number = 5.8;

        int castResult = (int)number;
        int convertResult = Convert.ToInt32(number);

        Console.WriteLine($"Explicit cast: {castResult}");
        Console.WriteLine($"Convert.ToInt32: {convertResult}");

        // Integer division and double division. Integer division discards the fractional part, while double division retains it. This can lead to different results when dividing numbers, especially when the result is not a whole number.
        int intDivision = 5 / 2;
        double doubleDivision = 5.0 / 2;

        Console.WriteLine($"Integer division: {intDivision}");
        Console.WriteLine($"Double division: {doubleDivision}");

        // Boxing and unboxing. Boxing is the process of converting a value type (like int) to a reference type (like object), while unboxing is the reverse process. This can lead to performance overhead due to the additional memory allocation and garbage collection involved in boxing, especially in performance-critical applications.
        int originalNumber = 42;

        object boxedNumber = originalNumber;

        int unboxedNumber = (int)boxedNumber;

        Console.WriteLine($"Boxed value: {boxedNumber}");
        Console.WriteLine($"Unboxed value: {unboxedNumber}");

        // Parsing and TryParse. Parsing converts a string representation of a number to its numeric type, while TryParse attempts to do the same but returns a boolean indicating success or failure. This can lead to exceptions if parsing fails, while TryParse provides a safer way to handle potential errors without throwing exceptions.
        string numberText = "42";

        int parsedNumber = int.Parse(numberText);

        Console.WriteLine($"Parsed number: {parsedNumber}");
        Console.WriteLine(parsedNumber + 8);

        string badText = "abc";

        bool success = int.TryParse(badText, out int result);

        Console.WriteLine($"TryParse succeeded: {success}");
        Console.WriteLine($"Result: {result}");

        // float cannot be implicitly converted to decimal because the two types use different representations and the conversion may affect precision. for that the conversion must be explicit.
        float floatNumber = 10.5f;

        // decimal decimalNumber = floatNumber; // Does not compile

        decimal decimalNumber = (decimal)floatNumber;

        Console.WriteLine($"Float: {floatNumber}");
        Console.WriteLine($"Decimal: {decimalNumber}");

        #endregion

    }
    static void RunValueVsReferenceDemo()
    {
        #region Value vs Reference Types 
        // Value types are stored in the stack memory, while reference types are stored in the heap memory. This can lead to different performance characteristics and memory usage patterns, especially in scenarios involving large data structures or frequent object creation and destruction.
        Point p1 = new Point
        {
            X = 1,
            Y = 2
        };

        Point p2 = p1;

        p2.X = 99;
        // Point is a value type, so assigning p1 to p2 copies the complete value. Changing p2 therefore does not modify p1.
        Console.WriteLine($"p1.X: {p1.X}");
        Console.WriteLine($"p2.X: {p2.X}");
        #endregion
    }

    #region Scope & Operators
    private static int sharedNumber = 50;


    public static void RunScopeAndOperatorsDemo()
    {
        Console.WriteLine("=== PART D: Scope & Operators ===");

        Console.WriteLine("\n--- D1: Scope ---");

        ReadFieldFromFirstMethod();
        ReadFieldFromSecondMethod();

        MethodScopeDemo();
        BlockScopeDemo();


        Console.WriteLine("\n--- D2: Composite (Compound Assignment) Operators ---");

        CompoundAssignmentDemo();


        Console.WriteLine("\n--- D3: Bitwise Operators ---");

        BitwiseOperatorsDemo();
    }

    static void ReadFieldFromFirstMethod()
    {
        Console.WriteLine(
            $"First method reads sharedNumber: {sharedNumber}"
        );
    }


    static void ReadFieldFromSecondMethod()
    {
        Console.WriteLine(
            $"Second method reads sharedNumber: {sharedNumber}"
        );
    }


    static void MethodScopeDemo()
    {
        int localNumber = 20;

        Console.WriteLine(
            $"Local variable inside MethodScopeDemo: {localNumber}"
        );

        // localNumber only exists inside this method.
    }


    static void BlockScopeDemo()
    {
        for (int i = 0; i < 3; i++)
        {
            int insideLoop = i * 10;

            Console.WriteLine(
                $"i = {i}, insideLoop = {insideLoop}"
            );
        }
    }

    static void CompoundAssignmentDemo()
    {
        int total = 100;

        Console.WriteLine($"Starting total: {total}");

        total += 20;
        Console.WriteLine($"After += 20: {total}");

        // Long form:
        // total = total + 20;
        // This is equivalent to:
        // total += 20;

        total -= 10;
        Console.WriteLine($"After -= 10: {total}");

        total *= 2;
        Console.WriteLine($"After *= 2: {total}");

        total /= 5;
        Console.WriteLine($"After /= 5: {total}");

        total %= 7;
        Console.WriteLine($"After %= 7: {total}");
    }

    static void BitwiseOperatorsDemo()
    {
        int a = 12;
        int b = 10;

        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");

        // Decimal:
        // a = 12
        // b = 10

        // Binary:
        // a = 1100
        // b = 1010


        // Bitwise AND (&)
        //
        //   1100
        // & 1010
        // ------
        //   1000
        //
        // 1000 binary = 8 decimal

        int andResult = a & b;

        Console.WriteLine($"a & b = {andResult}");


        // Bitwise OR (|)
        //
        //   1100
        // | 1010
        // ------
        //   1110
        //
        // 1110 binary = 14 decimal

        int orResult = a | b;

        Console.WriteLine($"a | b = {orResult}");


        // Bitwise XOR (^)
        //
        //   1100
        // ^ 1010
        // ------
        //   0110
        //
        // 0110 binary = 6 decimal

        int xorResult = a ^ b;

        Console.WriteLine($"a ^ b = {xorResult}");


        // Practical difference:
        // && is a logical operator that short-circuits:
        // if the left operand is false, the right operand is not evaluated.
        //
        // & evaluates both operands even when the left operand is false.
    }

    #endregion



}

