using System.Collections.Generic;
using System.Linq;

namespace _3.Shapes
{
    public class Polygon
    {
        public Polygon()
        {
            this.SideLenghts = new List<double>();
        }

        public List<double> SideLenghts { get; set; }

        public double GetPerimeter()
        {
            return this.SideLenghts.Sum();
        }

        public virtual string GetShapeType()
        {
            return "Polygon";
        }
    }
}