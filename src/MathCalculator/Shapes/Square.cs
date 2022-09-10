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
            return side;
        }
        set
        {
            side = value;
        }
    }

    public override float Area
    {
        get
        {
            return side * side;
        }
    }

    public override float Perimeter
    {
        get
        {
            return side * 4;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && !IsDisposed)
        {
            side = 0;
        }

        base.Dispose(disposing);
    }
}