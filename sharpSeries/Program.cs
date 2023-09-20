using System;
public class Series
{
    protected double firstElement;
    protected double commonDifference;
    protected double commonRatio;

    public Series(double firstElement, double commonDifference, double commonRatio)
    {
        this.firstElement = firstElement;
        this.commonDifference = commonDifference;
        this.commonRatio = commonRatio;
    }

    public virtual double GetElement(int j)
    {
        return 0;
    }

    public virtual double GetSum(int n)
    {
        return 0;
    }
}

public class Linear : Series
{
    public Linear(double firstElement, double commonDifference) : base(firstElement, commonDifference, 0)
    {
    }

    public override double GetElement(int j)
    {
        return firstElement + (j - 1) * commonDifference;
    }

    public override double GetSum(int n)
    {
        return (n / 2.0) * (2 * firstElement + (n - 1) * commonDifference);
    }
}

public class Exponential : Series
{
    public Exponential(double firstElement, double commonRatio) : base(firstElement, 0, commonRatio)
    {
    }

    public override double GetElement(int j)
    {
        return firstElement * Math.Pow(commonRatio, j - 1);
    }

    public override double GetSum(int n)
    {
        return firstElement * (Math.Pow(commonRatio, n) - 1) / (commonRatio - 1);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the Series class
        Series series = new Series(1, 2, 3);

        // Call the GetElement and GetSum methods on the Series instance
        Console.WriteLine("Series:");
        Console.WriteLine("Element 3: " + series.GetElement(3));
        Console.WriteLine("Sum of first 5 elements: " + series.GetSum(5));

        // Create an instance of the Linear class
        Linear linear = new Linear(1, 2);

        // Call the GetElement and GetSum methods on the Linear instance
        Console.WriteLine("Linear:");
        Console.WriteLine("Element 3: " + linear.GetElement(3));
        Console.WriteLine("Sum of first 5 elements: " + linear.GetSum(5));

        // Create an instance of the Exponential class
        Exponential exponential = new Exponential(1, 2);

        // Call the GetElement and GetSum methods on the Exponential instance
        Console.WriteLine("Exponential:");
        Console.WriteLine("Element 3: " + exponential.GetElement(3));
        Console.WriteLine("Sum of first 5 elements: " + exponential.GetSum(5));

        Console.ReadLine();
    }
}