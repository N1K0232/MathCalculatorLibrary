namespace MathCalculator.Common;

public abstract partial class Shape : ICloneable, IDisposable
{
    public static readonly Shape Empty = new EmptyShape();

    private string name = string.Empty;
    private ShapeCollection? shapes;

    private bool disposed = false;

    protected Shape()
    {
        Shapes.Add(this);
    }

    ~Shape()
    {
        Dispose(disposing: false);
    }


    public ShapeCollection Shapes
    {
        get
        {
            ThrowIfDisposed();
            return shapes ?? new ShapeCollection();
        }
        set
        {
            ThrowIfDisposed();
            shapes = value;
        }
    }

    public abstract float Area { get; }

    public abstract float Perimeter { get; }

    public string Name
    {
        get
        {
            ThrowIfDisposed();
            return name;
        }
        set
        {
            ThrowIfDisposed();
            name = value;
        }
    }


    public virtual Shape Clone()
    {
        ThrowIfDisposed();

        ICloneable cloneable = this;
        object clone = cloneable.Clone();
        return (Shape)clone!;
    }

    object ICloneable.Clone()
    {
        return this;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !disposed)
        {
            name = string.Empty;
            Shapes.Dispose();

            disposed = true;
        }
    }

    protected void ThrowIfDisposed()
    {
        if (disposed)
        {
            Type currentType = GetType();
            throw new ObjectDisposedException(currentType.FullName);
        }
    }
}