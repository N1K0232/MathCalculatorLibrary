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
                ThrowIfDisposed();
                return shapes;
            }
            set
            {
                ThrowIfDisposed();
                shapes = value;
            }
        }

        public virtual Shape this[int index]
        {
            get
            {
                ThrowIfDisposed();
                return shapes[index];
            }
            set
            {
                ThrowIfDisposed();
                shapes[index] = value;
            }
        }

        public virtual int Count => shapes.Count;

        public virtual bool IsReadOnly => false;

        private IEnumerator<Shape> InnerEnumerator => shapes.GetEnumerator();

        public virtual void Add(Shape item)
        {
            ThrowIfDisposed();
            AddInternal(item);
        }

        public virtual void AddRange(IEnumerable<Shape> collection)
        {
            ThrowIfDisposed();

            foreach (Shape item in collection)
            {
                AddInternal(item);
            }
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

        public virtual int IndexOf(Shape item)
        {
            ThrowIfDisposed();
            return GetIndex(item);
        }

        public virtual void Insert(int index, Shape item)
        {
            ThrowIfDisposed();
            InsertInternal(index, item);
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

        public virtual bool RemoveRange(IEnumerable<Shape> collection)
        {
            ThrowIfDisposed();

            foreach (Shape item in collection)
            {
                if (RemoveInternal(item))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public virtual void Update(Shape item)
        {
            ThrowIfDisposed();
            UpdateInternal(item);
        }

        public virtual void UpdateRange(IEnumerable<Shape> collection)
        {
            ThrowIfDisposed();

            foreach (Shape item in collection)
            {
                UpdateInternal(item);
            }
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
            item.ThrowIfDisposed();
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

        private int GetIndex(Shape item)
        {
            item.ThrowIfDisposed();

            Shape itemToCheck = item ?? InnerEnumerator.Current;
            return shapes.IndexOf(itemToCheck);
        }

        private void InsertInternal(int index, Shape item)
        {
            item.ThrowIfDisposed();
            shapes.Insert(index, item);
        }

        private void UpdateInternal(Shape item)
        {
            item.ThrowIfDisposed();

            Shape oldItem = shapes.FirstOrDefault(shape => shape.Name.Equals(item.Name));
            int index = GetIndex(oldItem);
            RemoveInternal(oldItem);
            InsertInternal(index, item);
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