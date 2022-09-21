namespace MathCalculator;

#nullable disable
public abstract partial class Solid
{
    public class SolidCollection : ShapeCollection, IDisposable
    {
        private List<Solid> solids;

        public SolidCollection()
        {
        }
        public SolidCollection(List<Solid> solids)
        {
            Solids = solids;
        }

        public virtual List<Solid> Solids
        {
            get
            {
                ThrowIfDisposed();
                return solids;
            }
            set
            {
                ThrowIfDisposed();
                solids = value;
            }
        }
        public override List<Shape> Shapes
        {
            get => base.Shapes;
            set => base.Shapes = value;
        }
        public new virtual Solid this[int index]
        {
            get
            {
                return GetSolidByIndex(index);
            }
            set
            {
                solids[index] = value;
                base[index] = value;
            }
        }

        public override int Count => solids.Count;

        public override bool IsReadOnly => false;

        public new virtual IEnumerator<Solid> Enumerator
        {
            get
            {
                return InnerEnumerator;
            }
        }

        private Solid Current
        {
            get
            {
                IEnumerator<Solid> current = solids.GetEnumerator();
                return current.Current;
            }
        }

        private IEnumerator<Solid> InnerEnumerator
        {
            get
            {
                return solids.GetEnumerator();
            }
        }

        public override void Add(Shape item)
        {
            solids.Add(item as Solid);
            base.Add(item);
        }

        public override void AddRange(IEnumerable<Shape> collection)
        {
            IEnumerable<Solid> solidCollection = collection.Cast<Solid>();

            foreach (Solid item in solidCollection)
            {
                solids.Add(item);
            }

            base.AddRange(collection);
        }

        public override void Clear()
        {
            solids.Clear();
            base.Clear();
        }

        public override bool Contains(Shape item)
        {
            if (item is Solid solidItem)
            {
                return base.Contains(solidItem);
            }

            return false;
        }

        public override void CopyTo(Shape[] array, int arrayIndex)
        {
            Solid[] solidArray = array.Cast<Solid>().ToArray();
            base.CopyTo(solidArray, arrayIndex);
        }

        public override int IndexOf(Shape item)
        {
            if (item is Solid solidItem)
            {
                return base.IndexOf(solidItem);
            }

            return -1;
        }

        public override void Insert(int index, Shape item)
        {
            if (item is Solid solidItem)
            {
                base.Insert(index, solidItem);
            }
        }

        public override bool Remove(Shape item)
        {
            if (item is Solid solidItem)
            {
                return base.Remove(solidItem);
            }

            return false;
        }

        public override bool RemoveAt(int index)
        {
            return base.RemoveAt(index);
        }

        public override bool RemoveRange(IEnumerable<Shape> collection)
        {
            IEnumerable<Solid> solidCollection = collection.Cast<Solid>();
            return base.RemoveRange(solidCollection);
        }

        public override void Update(Shape item)
        {
            if (item is Solid solidItem)
            {
                base.Update(solidItem);
            }
        }

        public override void UpdateRange(IEnumerable<Shape> collection)
        {
            IEnumerable<Solid> solidCollection = collection.Cast<Solid>();
            base.UpdateRange(solidCollection);
        }

        private Solid GetSolidByIndex(int index)
        {
            Shape item = GetShapeByIndex(index);

            if (item is Solid solidItem)
            {
                return solidItem;
            }

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            DisposeMe(disposing);
            base.Dispose(disposing);
        }

        private void DisposeMe(bool disposing)
        {
            if (disposing)
            {
                solids.Clear();
            }
        }
    }
}
#nullable enable