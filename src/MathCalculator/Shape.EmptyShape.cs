namespace MathCalculator;

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

        public override Shape Clone() => this;

        protected override void Draw(Graphics graphics)
        {
            throw new InvalidOperationException("can't draw an empty shape");
        }
    }
}