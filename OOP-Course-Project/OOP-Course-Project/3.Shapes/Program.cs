using System;

namespace _3.Shapes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var firstShape = new RightIsoscelesTriangle();
            firstShape.SideLenghts.AddRange(new double[] {3, 4, 5}); //perimeter should be 12

            var secondShape = new Square();
            secondShape.SideLenghts.AddRange(new double[] {4, 4, 4, 4}); //perimeter should be 16

            Console.WriteLine(
                $"First shape is {firstShape.GetShapeType()} with perimeter of {firstShape.GetPerimeter()}");
            Console.WriteLine(
                $"First shape is {secondShape.GetShapeType()} with perimeter of {secondShape.GetPerimeter()}");
        }
    }
}