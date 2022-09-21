using MathCalculator.Common;

namespace MathCalculator.Shapes;

public class Circle : Shape
{
    private float radius;

    public Circle()
    {
        radius = 0;
    }

    public float Radius
    {
        get
        {
            ThrowIfDisposed();
            return radius;
        }
        set
        {
            ThrowIfDisposed();

            radius = value;
            Invalidate();
        }
    }

    public override float Area
    {
        get
        {
            ThrowIfDisposed();

            float pi = Convert.ToSingle(Math.PI);
            return radius * radius * pi;
        }
    }

    public override float Perimeter
    {
        get
        {
            ThrowIfDisposed();

            float pi = Convert.ToSingle(Math.PI);
            return radius * 2 * pi;
        }
    }

    protected override void Draw(Graphics graphics)
    {
        Color borderColor = BorderColor;
        Color shapeColor = ShapeColor;
        PointF location = Location;

        float radius = Radius * 10;

        Pen borderPen = new(borderColor);
        SolidBrush shapeBrush = new(shapeColor);

        graphics.DrawEllipse(borderPen, location.X, location.Y, radius, radius);
        graphics.FillEllipse(shapeBrush, location.X, location.Y, radius, radius);

        borderPen.Dispose();
        shapeBrush.Dispose();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            radius = 0;
        }

        base.Dispose(disposing);
    }
}