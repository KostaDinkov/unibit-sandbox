using System;

namespace _3.Shapes
{
    public class RightTriangle : Triangle, IRightTriangle
    {
        public double GetHypotenuseLength()
        {
            throw new NotImplementedException();
        }

        public override string GetShapeType()
        {
            return "Right Triangle";
        }
    }
}