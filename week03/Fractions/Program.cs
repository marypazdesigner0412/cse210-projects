using System;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Testing Constructors and Representations ---");

            // Test 1: No parameter constructor (1/1)
            Fraction f1 = new Fraction();
            Console.WriteLine(f1.GetFractionString());
            Console.WriteLine(f1.GetDecimalValue());

            // Test 2: One parameter constructor (5/1)
            Fraction f2 = new Fraction(5);
            Console.WriteLine(f2.GetFractionString());
            Console.WriteLine(f2.GetDecimalValue());

            // Test 3: Two parameter constructor (3/4)
            Fraction f3 = new Fraction(3, 4);
            Console.WriteLine(f3.GetFractionString());
            Console.WriteLine(f3.GetDecimalValue());

            // Test 4: Two parameter constructor (1/3)
            Fraction f4 = new Fraction(1, 3);
            Console.WriteLine(f4.GetFractionString());
            Console.WriteLine(f4.GetDecimalValue());


            Console.WriteLine("\n--- Testing Getters and Setters ---");

            // Create a temporary fraction to test mutability
            Fraction testFraction = new Fraction(6, 7);
            Console.WriteLine($"Original: {testFraction.GetFractionString()}");

            // Use setters to change the values
            testFraction.SetTop(2);
            testFraction.SetBottom(5);

            // Use getters to retrieve and verify the changes
            Console.WriteLine($"Updated Top via Getter: {testFraction.GetTop()}");
            Console.WriteLine($"Updated Bottom via Getter: {testFraction.GetBottom()}");
            Console.WriteLine($"New Fraction String: {testFraction.GetFractionString()}");
            Console.WriteLine($"New Decimal Value: {testFraction.GetDecimalValue()}");
        }
    }
}