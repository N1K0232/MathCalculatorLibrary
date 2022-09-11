namespace MathCalculator.Common;
public abstract partial class Shape
{
    protected abstract void Draw();

    protected void Invalidate()
    {
        //I call the ThrowIfDisposed method in case the object was disposed
        ThrowIfDisposed();
        Draw();
    }
}