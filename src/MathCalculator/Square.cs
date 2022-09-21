namespace MathCalculator;

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

    protected override void Draw(Graphics graphics)
    {
        Color borderColor = BorderColor;
        Color shapeColor = ShapeColor;
        PointF location = Location;
        float side = Side * 10;
        RectangleF rectangle = new(location.X, location.Y, side, side);

        SolidBrush shapeBrush = new(shapeColor);
        Pen borderPen = new(borderColor);

        graphics.DrawRectangle(borderPen, location.X, location.Y, side, side);
        graphics.FillRectangle(shapeBrush, rectangle);

        borderPen.Dispose();
        shapeBrush.Dispose();
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