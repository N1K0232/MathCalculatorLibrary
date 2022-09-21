namespace MathCalculator;

public abstract partial class Solid : Shape
{
    public static new readonly Solid Empty = new EmptySolid();

    protected Solid()
    {
    }


    public new virtual Solid Clone()
    {
        Shape shape = base.Clone();
        if (shape is Solid solid)
        {
            return solid;
        }

        return null!;
    }

    protected override void Draw(Graphics graphics)
    {
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}