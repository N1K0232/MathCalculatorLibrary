using MathCalculator.Common;
using MathCalculator.Shapes;
using Shapes = MathCalculator.Shapes;

namespace MathCalculatorApp;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void Form_Load(object sender, EventArgs e)
    {
        Shape.ShapeCollection shapes = new();

        using var square = new Square();
        square.Name = "Test Square";
        square.Side = 14;
        shapes.Add(square);

        string squareMessage = $"The perimeter of the square is {square.Perimeter} " +
            $"and the area is {square.Area}";

        MessageBox.Show(squareMessage, Text);

        //creates a conflict with the System.Drawing.Rectangle struct
        using var rectangle = new Shapes.Rectangle();
        rectangle.Name = "Test Rectangle";
        rectangle.Width = 8;
        rectangle.Height = 4;
        shapes.Add(rectangle);

        string rectangleMessage = $"The perimeter of the rectangle is {rectangle.Perimeter} " +
            $"and the area is {rectangle.Area}";

        MessageBox.Show(rectangleMessage, Text);

        using var circle = new Circle();
        circle.Name = "Test Circle";
        circle.Radius = 10;
        shapes.Add(circle);

        string circleMessage = $"The perimeter of the circle is {circle.Perimeter} " +
            $"and the area is {circle.Area}";

        MessageBox.Show(circleMessage);

        using var ellipse = new Ellipse();
        ellipse.Name = "Test ellipse";
        ellipse.MajorAxis = 20;
        ellipse.MinorAxis = 10;
        shapes.Add(ellipse);

        string ellipseMessage = $"The perimeter of the ellipse is {ellipse.Perimeter} " +
            $"and the area is {ellipse.Area}";

        MessageBox.Show(ellipseMessage);
    }
}