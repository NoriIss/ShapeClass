namespace ShapeApplication.Shape
{
    public abstract class AbstractShape
    {
        public abstract double SurfaceArea { get; }

        public abstract double Perimeter { get; }

        public abstract string ShapeName { get; }
        
        public static string GetName(AbstractShape shape) => shape.ShapeName;

        public static double GetSurfaceArea(AbstractShape shape) => shape.SurfaceArea;

        public static double GetPerimeter(AbstractShape shape) => shape.Perimeter;

    }
}
