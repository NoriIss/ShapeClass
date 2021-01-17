using System;

namespace ShapeApplication.Shape
{
    public class Triangle : AbstractShape
    {
         /// <summary>
        /// Height
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Bottom
        /// </summary>
        public double Bottom { get; }

        /// <summary>
        /// EdgeA
        /// </summary>
        public double EdgeA { get; }

        /// <summary>
        /// EdgeB
        /// </summary>
        public double EdgeB { get; }

        /// <summary>
        /// EdgeC
        /// </summary>
        public double EdgeC { get; }

     
        /// <summary>
        /// Instance
        /// </summary>
        /// <param name="edgea">edgea</param>
        /// <param name="edgeb">edgeb</param>
        /// <param name="edgec">edgec</param>
        public Triangle(double edgea,double edgeb, double edgec)
        {
            EdgeA = edgea;
            EdgeB = edgeb;
            EdgeC = edgec;
        }

        /// <summary>
        /// Instance(Serialize)
        /// </summary>
        public Triangle() { }

        /// <summary>
        /// Area of Triangle
        /// </summary>
        public override double SurfaceArea=> this.calcSurfaceArea();

        /// <summary>
        /// Perimeter of Triangle
        /// </summary>
        public override double Perimeter => EdgeA + EdgeB + EdgeC;

        /// <summary>
        /// Name
        /// </summary>
        public override string ShapeName => this.GetName();

        /// <summary>
        /// Calc area
        /// </summary>
        private double calcSurfaceArea()
        {
            //s=(a+b+c)/2
            //S=√s(s-a)(s-b)(s-c)

            double s1 = (EdgeA + EdgeB + EdgeC) / 2.0d;
            double s2 = s1 * (s1 - EdgeA) * (s1 - EdgeB) * (s1 - EdgeC);

            return Math.Sqrt(s2);
        }

        /// <summary>
        /// GetTriangleTypeName
        /// </summary>
        /// <returns></returns>
        private string GetName()
        {
            if(EdgeA == EdgeB && EdgeB == EdgeC)
            {
                //all 3 sides are the same length
                return "Equilateral";
            }
            else if(EdgeA == EdgeB || EdgeB == EdgeC || EdgeA == EdgeC)
            {
                //only 2 sides are the same length
                return "Isosceles";
            }
            else
            {
                //no 2 sides are the same
                return "Scalene";
            }
        }

    }
}
