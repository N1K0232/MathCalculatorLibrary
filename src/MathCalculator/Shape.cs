namespace MathCalculator;

public abstract partial class Shape : ICloneable, IDisposable
{
    private static readonly Form defaultForm = new();
    public static readonly Shape Empty = new EmptyShape();

    private string name = string.Empty;
    private ShapeCollection? shapes;
    private Form? form;

    private bool disposed = false;

    protected Shape()
    {
        Shapes = new ShapeCollection();
        Shapes.Add(this);

        defaultForm.Visible = true;
        defaultForm.Enabled = true;
        defaultForm.Text = "Shape form";
        defaultForm.Name = "ShapeForm";
        defaultForm.Size = new Size(800, 450);
    }

    ~Shape()
    {
        Dispose(disposing: false);
    }

    public Form Form
    {
        get
        {
            ThrowIfDisposed();
            return GetForm();
        }
        set
        {
            ThrowIfDisposed();
            SetForm(value);
        }
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

    private Form GetForm()
    {
        Form control = form ?? defaultForm;
        return control;
    }
    private void SetForm(Form value)
    {
        if (value.IsDisposed)
        {
            Type type = value.GetType();
            ThrowIfDisposed(type);
        }

        form = value;
        form.Owner = value;
        form.Visible = true;
        form.Enabled = true;
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
            DisposeContainer();
            Shapes.Dispose();

            name = string.Empty;
            disposed = true;
        }
    }

    private void DisposeContainer()
    {
        bool canDispose = form?.IsDisposed ?? false;
        if (canDispose)
        {
            form?.Dispose();
        }
    }

    protected void ThrowIfDisposed(Type? type = null)
    {
        if (disposed)
        {
            Type currentType = type ?? GetType();
            throw new ObjectDisposedException(currentType.FullName);
        }
    }
}