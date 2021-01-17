namespace ShapeApplication.Shape
{
    public class Square : AbstractShape
    {
        /// <summary>
        /// Width
        /// </summary>
        public double Width { get; }

        /// <summary>
        /// Length
        /// </summary>
        public double Length { get; }

        /// <summary>
        /// Instance
        /// </summary>
        /// <param name="width">width</param>
        /// <param name="length">length</param>
        public Square(double width, double length)
        {
            Width = width;
            Length = length;
        }

        /// <summary>
        /// Instance(Serialize)
        /// </summary>
        public Square() { }

        /// <summary>
        /// Area of Square
        /// </summary>
        public override double SurfaceArea => Width * Length;

        /// <summary>
        /// Perimeter (circumference) of Square
        /// </summary>
        public override double Perimeter => (Width + Length) * 2;

        /// <summary>
        /// Name
        /// </summary>
        public override string ShapeName => this.GetName();

        /// <summary>
        /// GetSquareTypeName
        /// </summary>
        /// <returns></returns>
        private string GetName()
        {
            if (Width == Length)
            {
                //all sides are the same length
                return "Square";
            }           
            else
            {
                //etc
                return "Rectangle ";
            }
        }

    }
}
