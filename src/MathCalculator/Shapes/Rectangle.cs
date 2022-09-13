using MathCalculator.Common;

namespace MathCalculator.Shapes;

public class Rectangle : Shape
{
    private float width;
    private float height;

    public Rectangle()
    {
        width = 0;
        height = 0;
    }

    public float Width
    {
        get
        {
            ThrowIfDisposed();
            return width;
        }
        set
        {
            ThrowIfDisposed();

            width = value;
            Invalidate();
        }
    }

    public float Height
    {
        get
        {
            ThrowIfDisposed();
            return height;
        }
        set
        {
            ThrowIfDisposed();

            height = value;
            Invalidate();
        }
    }

    public override float Area
    {
        get
        {
            ThrowIfDisposed();
            return width * height;
        }
    }

    public override float Perimeter
    {
        get
        {
            ThrowIfDisposed();
            return (width + height) * 2;
        }
    }

    public float Diagonal
    {
        get
        {
            ThrowIfDisposed();

            float width = Width * 2;
            float height = Height * 2;

            return Convert.ToSingle(Math.Sqrt(width + height));
        }
    }

    protected override void Draw()
    {
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            width = 0;
            height = 0;
        }

        base.Dispose(disposing);
    }
}