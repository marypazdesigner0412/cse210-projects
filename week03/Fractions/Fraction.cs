using System;

namespace Fractions
{
    public class Fraction
    {
        // 1. Private Attributes
        private int _top;
        private int _bottom;

        // 2. Constructors

        // Constructor with no parameters (Defaults to 1/1)
        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        // Constructor with one parameter for the top (Defaults bottom to 1)
        public Fraction(int top)
        {
            _top = top;
            _bottom = 1;
        }

        // Constructor with two parameters for both top and bottom
        public Fraction(int top, int bottom)
        {
            _top = top;
            // Basic guardrail: avoid division by zero
            _bottom = bottom == 0 ? 1 : bottom;
        }

        // 3. Getters and Setters
        public int GetTop()
        {
            return _top;
        }

        public void SetTop(int top)
        {
            _top = top;
        }

        public int GetBottom()
        {
            return _bottom;
        }

        public void SetBottom(int bottom)
        {
            if (bottom != 0)
            {
                _bottom = bottom;
            }
            else
            {
                Console.WriteLine("Warning: Denominator cannot be zero. Value not changed.");
            }
        }

        // 4. Representation Methods

        // Returns the fraction format
        public string GetFractionString()
        {
            return $"{_top}/{_bottom}";
        }

        // Returns the decimal representation
        public double GetDecimalValue()
        {
            return (double)_top / _bottom;
        }
    }
}