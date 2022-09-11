namespace MathCalculator.Common;

public abstract partial class Shape
{
    private sealed class EmptyShape : Shape
    {
        internal EmptyShape()
        {
            Name = "Empty Shape";
        }

        public override float Area => 0;
        public override float Perimeter => 0;
    }
}