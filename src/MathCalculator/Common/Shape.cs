namespace MathCalculator.Common;

public abstract partial class Shape : ICloneable, IDisposable
{
    private string name = string.Empty;
    private bool disposed = false;

    protected Shape()
    {
    }

    ~Shape()
    {
        Dispose(disposing: false);
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

    internal bool IsDisposed => disposed;

    public virtual Shape? Clone()
    {
        ICloneable cloneable = this;
        object? clone = cloneable.Clone();
        return clone as Shape;
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
        if (!disposed)
        {
            disposed = true;
        }
    }
    internal void ThrowIfDisposed()
    {
        if (disposed)
        {
            Type currentType = GetType();
            throw new ObjectDisposedException(currentType.FullName);
        }
    }
}