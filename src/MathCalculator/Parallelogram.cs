namespace MathCalculator;

public class Parallelogram : Shape
{
    private float longSide;
    private float shortSide;
    private float height;
    private float radius;

    public Parallelogram()
    {
        longSide = 0;
        shortSide = 0;
        height = 0;
        radius = 0;
    }


    public float LongSide
    {
        get
        {
            ThrowIfDisposed();
            return longSide;
        }
        set
        {
            ThrowIfDisposed();

            longSide = value;
            Invalidate();
        }
    }
    public float ShortSide
    {
        get
        {
            ThrowIfDisposed();
            return shortSide;
        }
        set
        {
            ThrowIfDisposed();

            shortSide = value;
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
    public float Radius
    {
        get
        {
            return radius;
        }
        set
        {
            ThrowIfDisposed();

            radius = 0;
            Invalidate();
        }
    }

    public override float Area
    {
        get
        {
            ThrowIfDisposed();

            return LongSide * Height;
        }
    }

    public override float Perimeter
    {
        get
        {
            ThrowIfDisposed();

            return (2 * LongSide) + (2 * ShortSide);
        }
    }

    public float FirstDiagonal
    {
        get
        {
            ThrowIfDisposed();

            float longSide = LongSide * LongSide;
            float shortSide = ShortSide * ShortSide;
            float height = Height * Height;
            float thirdSide = Convert.ToSingle(2 * ShortSide * Math.Sqrt(longSide - height));

            return Convert.ToSingle(Math.Sqrt(longSide + shortSide - thirdSide));
        }
    }

    public float SecondDiagonal
    {
        get
        {
            ThrowIfDisposed();

            float longSide = LongSide * LongSide;
            float shortSide = ShortSide * ShortSide;
            float height = Height * Height;
            float thirdSide = Convert.ToSingle(2 * ShortSide * Math.Sqrt(longSide - height));

            return Convert.ToSingle(Math.Sqrt(longSide + shortSide + thirdSide));
        }
    }

    protected override void Draw(Graphics graphics)
    {
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            longSide = 0;
            shortSide = 0;
            height = 0;
            radius = 0;
        }

        base.Dispose(disposing);
    }
}