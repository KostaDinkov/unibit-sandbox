using System;

namespace _3.Shapes
{
    internal class RightIsoscelesTriangle : Triangle, IRightTriangle, IIsosceles
    {
        public double GetHypotenuseLength()
        {
            throw new NotImplementedException();
        }

        public override string GetShapeType()
        {
            return "Right Isosceles Triangle";
        }
    }
}