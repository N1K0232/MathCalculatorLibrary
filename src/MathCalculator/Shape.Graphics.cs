using System.Drawing.Drawing2D;

namespace MathCalculator;

public abstract partial class Shape
{
    private float x = 0;
    private float y = 0;

    private Color borderColor;
    private Color shapeColor;

    private PointF location;
    private SmoothingMode? smoothingMode;

    public float X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
            UpdateLocation();
        }
    }
    public float Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
            UpdateLocation();
        }
    }

    public Color BorderColor
    {
        get
        {
            return borderColor;
        }
        set
        {
            if (value == BorderColor || value == Color.Empty)
            {
                return;
            }

            borderColor = value;
            Invalidate();
        }
    }
    public Color ShapeColor
    {
        get
        {
            return shapeColor;
        }
        set
        {
            if (value == ShapeColor || value == Color.Empty)
            {
                return;
            }

            shapeColor = value;
            Invalidate();
        }
    }

    public PointF Location
    {
        get
        {
            return location;
        }
        set
        {
            location = value;
            Invalidate();
        }
    }
    public SmoothingMode? Mode
    {
        get
        {
            return smoothingMode;
        }
        set
        {
            if (value == smoothingMode)
            {
                return;
            }

            smoothingMode = value;
        }
    }


    protected abstract void Draw(Graphics graphics);

    protected void Invalidate()
    {
        ThrowIfDisposed();

        Graphics graphics = CreateGraphics();
        Draw(graphics);
        graphics.Dispose();
    }

    private Graphics CreateGraphics()
    {
        Color color = ShapeColor;
        SmoothingMode mode = Mode ?? SmoothingMode.AntiAlias;

        Graphics graphics = Form.CreateGraphics();
        graphics.Clear(color);
        graphics.SmoothingMode = mode;
        return graphics;
    }

    private void UpdateLocation()
    {
        PointF newLocation = new(x, y);
        Location = newLocation;
    }
}