namespace MathCalculator.Common;

#nullable disable

public abstract partial class Shape
{
    public class ShapeCollection : IDisposable
    {
        private List<Shape> shapes;
        private bool disposed = false;

        public ShapeCollection()
        {
            Shapes = new List<Shape>();
            ClearInternal();
        }
        public ShapeCollection(List<Shape> shapes)
        {
            Shapes = shapes;
        }

        public virtual List<Shape> Shapes
        {
            get
            {
                return shapes;
            }
            set
            {
                shapes = value;
            }
        }

        public virtual Shape this[int index]
        {
            get => shapes[index];
            set => shapes[index] = value;
        }

        public virtual int Count => shapes.Count;

        public virtual bool IsReadOnly => false;


        public virtual void Add(Shape item)
        {
            ThrowIfDisposed();
            AddInternal(item);
        }

        public virtual void AddRange(IEnumerable<Shape> shapes)
        {
            ThrowIfDisposed();
            AddRangeInternal(shapes);
        }

        public virtual void AddRange(Shape[] shapes)
        {
            ThrowIfDisposed();
            AddRangeInternal(shapes);
        }

        private void AddRangeInternal(IEnumerable<Shape> collection)
        {
            foreach (Shape item in collection)
            {
                AddInternal(item);
            }
        }

        private void AddInternal(Shape item)
        {
            shapes.Add(item);
        }

        public virtual void Clear()
        {
            ThrowIfDisposed();
            ClearInternal();
        }

        public virtual bool Contains(Shape item)
        {
            ThrowIfDisposed();

            Shape itemToCheck = item;

            if (itemToCheck is null)
            {
                IEnumerator<Shape> enumerator = GetEnumeratorInternal();
                itemToCheck = enumerator.Current;
            }

            return shapes.Contains(itemToCheck);
        }

        public virtual void CopyTo(Shape[] array, int arrayIndex)
        {
            ThrowIfDisposed();
            shapes.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<Shape> GetEnumerator()
        {
            ThrowIfDisposed();
            return GetEnumeratorInternal();
        }

        public virtual int IndexOf(Shape item)
        {
            ThrowIfDisposed();

            Shape itemToCheck = item;

            if (itemToCheck is null)
            {
                IEnumerator<Shape> enumerator = GetEnumeratorInternal();
                itemToCheck = enumerator.Current;
            }

            return shapes.IndexOf(itemToCheck);
        }

        public virtual void Insert(int index, Shape item)
        {
            ThrowIfDisposed();
            shapes.Insert(index, item);
        }

        public virtual bool Remove(Shape item)
        {
            ThrowIfDisposed();
            return RemoveInternal(item);
        }

        public virtual void RemoveAt(int index)
        {
            ThrowIfDisposed();
            RemoveInternal(this[index]);
        }

        private bool RemoveInternal(Shape item)
        {
            Shape itemToRemove = item;

            if (itemToRemove is null)
            {
                IEnumerator<Shape> enumerator = GetEnumeratorInternal();
                itemToRemove = enumerator.Current;
            }

            return shapes.Remove(itemToRemove);
        }

        private IEnumerator<Shape> GetEnumeratorInternal()
        {
            return shapes.GetEnumerator();
        }

        private void ClearInternal()
        {
            shapes.Clear();
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
                ClearInternal();
                disposed = true;
            }
        }
        private void ThrowIfDisposed()
        {
            if (disposed)
            {
                Type currentType = typeof(ShapeCollection);
                throw new ObjectDisposedException(currentType.FullName);
            }
        }
    }
}

#nullable enable