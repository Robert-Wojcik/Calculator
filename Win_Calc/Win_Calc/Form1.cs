using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Calc
{
    public partial class Calculator : Form
    {
        Double value = 0;
        String operation = "";
        bool operation_pressed = false;

        public Calculator()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button_Enter_Value(object sender, EventArgs e)
        {
            if ((textResult.Text == "0") || (operation_pressed))
                textResult.Clear();

            operation_pressed = false;
            Button button = (Button)sender;
            textResult.Text = textResult.Text + button.Text;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textResult.Text = "0";
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            value = Double.Parse(textResult.Text);
            operation_pressed = true;
            equation.Text = null;
            equation.Text = value + " " + operation;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            
            equation.Text = "";
            switch(operation)
            {
                case "+":
                    textResult.Text = (value + Double.Parse(textResult.Text)).ToString();
                    break;
                case "-":
                    textResult.Text = (value - Double.Parse(textResult.Text)).ToString();
                    break;
                case "*":
                    textResult.Text = (value * Double.Parse(textResult.Text)).ToString();
                    break;
                case "/":
                    textResult.Text = (value / Double.Parse(textResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textResult.Text = "0";
            value = 0;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void button_Enter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(230, 230, 230);

        }

        private void button_Leave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Transparent;
        }

        private void button_Equal_Enter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(182, 182, 255);
        }

        private void button_Equal_Leave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Transparent;
        }






        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  
            _start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
    }
}
