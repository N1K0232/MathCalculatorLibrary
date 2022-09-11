using System.ComponentModel;

namespace MathCalculatorApp;

public partial class MainForm : Form
{
    private IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        DisposeMe(disposing);
        base.Dispose(disposing);
    }

    private void DisposeMe(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
    }

    private void InitializeComponent()
    {
        components = new Container();
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Text = "Math Calculator Sample Application";
        Load += new EventHandler(Form_Load);
    }
}