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
        public ShapeCollection(IEnumerable<Shape> collection)
        {
            Shapes = new List<Shape>();
            AddRangeInternal(collection);
        }

        ~ShapeCollection()
        {
            Dispose(disposing: false);
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

        private IEnumerator<Shape> InnerEnumerator => shapes.GetEnumerator();

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

        public virtual void Clear()
        {
            ThrowIfDisposed();
            ClearInternal();
        }

        public virtual bool Contains(Shape item)
        {
            ThrowIfDisposed();

            Shape itemToCheck = item ?? InnerEnumerator.Current;
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
            return InnerEnumerator;
        }

        public virtual int IndexOf(Shape item)
        {
            ThrowIfDisposed();

            Shape itemToCheck = item ?? InnerEnumerator.Current;
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

        public virtual bool RemoveAt(int index)
        {
            ThrowIfDisposed();

            Shape item = this[index];
            return RemoveInternal(item);
        }

        #region private helpers
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

        private bool RemoveInternal(Shape item)
        {
            Shape removableItem = item ?? InnerEnumerator.Current;
            return shapes.Remove(removableItem);
        }

        private void ClearInternal()
        {
            shapes.Clear();
        }
        #endregion

        #region IDisposable pattern
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
        #endregion
    }
}

#nullable enable