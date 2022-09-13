using MathCalculator.Common;

namespace MathCalculator.Shapes;

public class Parallelogram : Shape
{
    private float longSide;
    private float shortSide;

    public Parallelogram()
    {
    }

    public override float Area => throw new NotImplementedException();

    public override float Perimeter => throw new NotImplementedException();

    protected override void Draw()
    {
        throw new NotImplementedException();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}