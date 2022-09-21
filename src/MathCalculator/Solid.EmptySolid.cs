namespace MathCalculator;

public abstract partial class Solid
{
    private class EmptySolid : Solid
    {
        public EmptySolid()
        {
            Name = "Empty Solid";
        }

        public override float Area => 0;
        public override float Perimeter => 0;

        public override Solid Clone() => this;

        protected override void Draw(Graphics graphics)
        {
            throw new InvalidOperationException("can't draw an empty solid");
        }
    }
}