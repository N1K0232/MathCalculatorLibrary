using MathCalculator.Common;

namespace MathCalculator.Shapes;

public class Ellipse : Shape
{
	private float majorAxis;
	private float minorAxis;

	public Ellipse()
	{
		majorAxis = 0;
		minorAxis = 0;
	}


	public float MajorAxis
	{
		get
		{
			ThrowIfDisposed();
			return majorAxis;
		}
		set
		{
			ThrowIfDisposed();

			majorAxis = value;
			Invalidate();
		}
	}

	public float MinorAxis
	{
		get
		{
			ThrowIfDisposed();
			return minorAxis;
		}
		set
		{
			ThrowIfDisposed();

			minorAxis = value;
			Invalidate();
		}
	}

	public override float Area
	{
		get
		{
			ThrowIfDisposed();

			float pi = Convert.ToSingle(Math.PI);
			return SemiMajorAxis * SemiMinorAxis * pi;
		}
	}

	public override float Perimeter
	{
		get
		{
			ThrowIfDisposed();

			float pi = Convert.ToSingle(Math.PI);
			float majorAxis = SemiMajorAxis * SemiMajorAxis;
			float minorAxis = SemiMinorAxis * SemiMinorAxis;
			return Convert.ToSingle(2 * pi * Math.Sqrt((majorAxis + minorAxis) / 2));
		}
	}

	private float SemiMajorAxis => MajorAxis / 2;
	private float SemiMinorAxis => MinorAxis / 2;

	protected override void Draw(Graphics graphics)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			majorAxis = 0;
			minorAxis = 0;
		}

		base.Dispose(disposing);
	}
}