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
        using var square = new Square();
        square.Name = "Test Square";
        square.Side = 14;

        string squareMessage = $"The perimeter of the square is {square.Perimeter} " +
            $"and the area is {square.Area}";

        MessageBox.Show(squareMessage, Text);

        //creates a conflict with the System.Drawing.Rectangle struct
        using var rectangle = new Shapes.Rectangle();
        rectangle.Name = "Test Rectangle";
        rectangle.Width = 8;
        rectangle.Height = 4;

        string rectangleMessage = $"The perimeter of the rectangle is {rectangle.Perimeter} " +
            $"and the area is {rectangle.Area}";

        MessageBox.Show(rectangleMessage, Text);
    }
}