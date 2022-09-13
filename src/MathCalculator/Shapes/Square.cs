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
            Invalidate();
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

    public float Diagonal
    {
        get
        {
            ThrowIfDisposed();

            return Convert.ToSingle(2 * Math.Sqrt(side));
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
        }

        base.Dispose(disposing);
    }
}