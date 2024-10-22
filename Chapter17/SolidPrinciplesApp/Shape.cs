namespace SolidPrinciplesApp
{
    // Liskov Substitution Principle (LSP)
    // objects of a superclass should be replace with objects of a subclass without altering the correctness of the program.
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Square : Shape
    {
        public double SideLength { get; set; }

        public override double CalculateArea()
        {
            return SideLength * SideLength;
        }
    }
}
