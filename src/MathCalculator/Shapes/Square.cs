using MathCalculator.Common;

namespace MathCalculator.Shapes;

public class Square : Shape
{
    private float side;

    public Square()
    {
        side = 0;
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
        }
    }

    public override float Area
    {
        get
        {
            ThrowIfDisposed();
            return side * side;
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

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            side = 0;
        }

        base.Dispose(disposing);
    }
}