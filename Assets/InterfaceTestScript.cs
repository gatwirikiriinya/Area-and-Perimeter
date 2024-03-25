using UnityEngine;

public class InterfaceTestScript : MonoBehaviour
{
    void Start()
    {
        // Create objects of each shape's class
        Nonagon one = new Nonagon(9, 5.4f);
        Circle two = new Circle(9);
        Trapezium three = new Trapezium(10, 15, 8);

        // Call methods for each shape and log the results
        Debug.Log("Area of Nonagon: " + one.CalculateArea());
        Debug.Log("Perimeter of Nonagon: " + one.CalculatePerimeter());

        Debug.Log("Area of Circle: " + two.CalculateArea());
        Debug.Log("Perimeter of Circle: " + two.CalculatePerimeter());

        Debug.Log("Area of Trapezium: " + three.CalculateArea());
        Debug.Log("Perimeter of Trapezium: " + three.CalculatePerimeter());
    }

    // Define the IShape interface
    public interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
    }

    // Define the Nonagon class implementing the IShape interface
    public class Nonagon : IShape
    {
        private int numberOfSides;
        private float lengthOfSides;

        public Nonagon(int numberOfSides, float lengthOfSides)
        {
            this.numberOfSides = numberOfSides;
            this.lengthOfSides = lengthOfSides;
        }

        public double CalculateArea()
        {
            double apothem = lengthOfSides / (2 * Mathf.Tan(Mathf.PI / numberOfSides));
            return (numberOfSides * lengthOfSides * apothem) / 2;
        }

        public double CalculatePerimeter()
        {
            return numberOfSides * lengthOfSides;
        }
    }

    // Define the Circle class implementing the IShape interface
    public class Circle : IShape
    {
        private float radius;

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public double CalculateArea()
        {
            return Mathf.PI * Mathf.Pow(radius, 2);
        }

        public double CalculatePerimeter()
        {
            return 2 * Mathf.PI * radius;
        }
    }

    // Define the Trapezium class implementing the IShape interface
    public class Trapezium : IShape
    {
        private double upBase;
        private double downBase;
        private double height;

        public Trapezium(double upBase, double downBase, double height)
        {
            this.upBase = upBase;
            this.downBase = downBase;
            this.height = height;
        }

        public double CalculateArea()
        {
            return 0.5 * height * (downBase + upBase);
        }

        public double CalculatePerimeter()
        {
            // Assuming legs are equal and given the number of sides
            double legLength = (upBase - downBase) / 2;
            return upBase + downBase + 2 * Mathf.Sqrt((float)(height * height + legLength * legLength));
        }
    }
}
