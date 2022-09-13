namespace MathCalculator.Common;

public abstract partial class Solid : Shape
{
	protected Solid()
	{
	}

	protected override void Draw()
	{
		throw new NotImplementedException();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}
}