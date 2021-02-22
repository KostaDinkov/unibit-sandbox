using System;

namespace sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Circle s = new Circle();
            Rect r = new Rect();
            Ball b = new Ball();


            IPrintArea [] printables = new IPrintArea[] {s, r, b};

            

            
        }
    }

    public abstract class Shape
    {
        

        public void PrintPerimeter()
        {

            Console.WriteLine("Perimeter ...");
        }
    }

    public class Rect : Shape, IPrintArea
    {
        public void PrintRect()
        {

        }

        public void PrintArea()
        {
            
        }

    }

    public class Circle : Shape, IPrintArea
    {
        public void PrintCirc()
        {

        }

        public void PrintArea()
        {
            
        }
    }


    public class Ball : IPrintArea
    {

        public void PrintArea()
        {

        }
    }

    interface IPrintArea
    {

        public void PrintArea();


    }



}
