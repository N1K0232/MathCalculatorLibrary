using MathCalculator.Common;

namespace MathCalculator.Shapes;

public class Rhombus : Shape
{
    private float side;
    private float majorAxis;
    private float minorAxis;

    public Rhombus()
    {
        side = 0;
        majorAxis = 0;
        minorAxis = 0;
    }


    public float Side
    {
        get => side;
        set => side = value;
    }

    public float MajorAxis
    {
        get => majorAxis;
        set => majorAxis = value;
    }

    public float MinorAxis
    {
        get => minorAxis;
        set => minorAxis = value;
    }

    public override float Area => throw new NotImplementedException();

    public override float Perimeter => throw new NotImplementedException();


    protected override void Draw()
    {
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            side = 0;
            majorAxis = 0;
            minorAxis = 0;
        }

        base.Dispose(disposing);
    }
}