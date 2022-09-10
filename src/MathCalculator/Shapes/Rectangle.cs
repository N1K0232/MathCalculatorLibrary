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
            return width;
        }
        set
        {
            width = value;
        }
    }

    public float Height
    {
        get
        {
            return height;
        }
        set
        {
            height = value;
        }
    }

    public override float Area
    {
        get
        {
            return width * height;
        }
    }

    public override float Perimeter
    {
        get
        {
            return (width + height) * 2;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && !IsDisposed)
        {
            width = 0;
            height = 0;
        }

        base.Dispose(disposing);
    }
}