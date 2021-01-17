using System;

namespace ShapeApplication.Shape
{
    public class Circle : AbstractShape
    {
        /// <summary>
        /// Radius
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Instance
        /// </summary>
        /// <param name="radius">radius</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Instance(Serialize)
        /// </summary>
        public Circle(){}

        /// <summary>
        /// Area of circle
        /// </summary>
        public override double SurfaceArea => Math.PI * Math.Pow(Radius, 2);

        /// <summary>
        /// Perimeter (circumference) of circle
        /// </summary>
        public override double Perimeter => 2 * Math.PI * Radius;

        /// <summary>
        /// Name
        /// </summary>
        public override string ShapeName => "Circle";
         
    }
}
