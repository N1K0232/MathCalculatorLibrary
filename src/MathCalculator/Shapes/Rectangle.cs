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