using MathCalculator.Common;

namespace MathCalculator.Shapes;

public class Rhombus : Shape
{
    private float side;
    private float majorAxis;
    private float minorAxis;

    public Rhombus()
    {
        side = 0;
        majorAxis = 0;
        minorAxis = 0;
    }


    public float Side
    {
        get
        {
            ThrowIfDisposed();
            return side;
        }
        set
        {
            ThrowIfDisposed();

            side = value;
            Invalidate();
        }
    }

    public float MajorAxis
    {
        get
        {
            ThrowIfDisposed();
            return majorAxis;
        }
        set
        {
            ThrowIfDisposed();

            majorAxis = value;
            Invalidate();
        }
    }

    public float MinorAxis
    {
        get
        {
            ThrowIfDisposed();
            return minorAxis;
        }
        set
        {
            ThrowIfDisposed();

            minorAxis = value;
            Invalidate();
        }
    }

    public override float Area
    {
        get
        {
            ThrowIfDisposed();

            float doubleArea = MajorAxis * MinorAxis;
            return doubleArea / 2;
        }
    }

    public override float Perimeter
    {
        get
        {
            ThrowIfDisposed();
            return side * 4;
        }
    }


    protected override void Draw()
    {
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            side = 0;
            majorAxis = 0;
            minorAxis = 0;
        }

        base.Dispose(disposing);
    }
}