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

    protected override void Draw()
    {
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