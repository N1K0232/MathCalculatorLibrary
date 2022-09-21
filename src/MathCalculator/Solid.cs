namespace MathCalculator;

public abstract partial class Solid : Shape
{
    protected Solid()
    {
    }

    protected override void Draw(Graphics graphics)
    {
        throw new NotImplementedException();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}