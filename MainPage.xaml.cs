//using GameController;

namespace SimpleCalculatorMk2
{
    public partial class MainPage : ContentPage
    {
        //Starting vairables
        public double btnHeight = 60;
        public double btnWidth = 60;
        public int btnRadius = 30;
        public int btnFontSize = 30;

        //This should have been done with methods and properties but I ran out of time
        public string[] operators = ["+", "-", "x", "/" ];
        //public string[] disText = ["0", "+", "-", "x", "÷"];

        public string lastBtn = "new";

        public MainPage()
        {
            InitializeComponent();

            //I know there's a better way to do this but I didn't know it when I started and I don't have time to improve it
            this.Display.FontSize = btnFontSize; this.Display.HeightRequest = btnFontSize * 2;
            this.Clear.HeightRequest = btnHeight; this.Clear.WidthRequest = btnWidth; this.Clear.CornerRadius = btnRadius; this.Clear.FontSize = btnFontSize;
            this.PlusMinus.HeightRequest = btnHeight; this.PlusMinus.WidthRequest = btnWidth; this.PlusMinus.CornerRadius = btnRadius; this.PlusMinus.FontSize = btnFontSize;
            this.Percent.HeightRequest = btnHeight; this.Percent.WidthRequest = btnWidth; this.Percent.CornerRadius = btnRadius; this.Percent.FontSize = btnFontSize;
            this.Divide.HeightRequest = btnHeight; this.Divide.WidthRequest = btnWidth; this.Divide.CornerRadius = btnRadius; this.Divide.FontSize = btnFontSize;
            this.Multiply.HeightRequest = btnHeight; this.Multiply.WidthRequest = btnWidth; this.Multiply.CornerRadius = btnRadius; this.Multiply.FontSize = btnFontSize;
            this.Subtract.HeightRequest = btnHeight; this.Subtract.WidthRequest = btnWidth; this.Subtract.CornerRadius = btnRadius; this.Subtract.FontSize = btnFontSize;
            this.Add.HeightRequest = btnHeight; this.Add.WidthRequest = btnWidth; this.Add.CornerRadius = btnRadius; this.Add.FontSize = btnFontSize;
            this.Decimal.HeightRequest = btnHeight; this.Decimal.WidthRequest = btnWidth; this.Decimal.CornerRadius = btnRadius; this.Decimal.FontSize = btnFontSize;
            this.Equals.HeightRequest = btnHeight; this.Equals.WidthRequest = btnWidth; this.Equals.CornerRadius = btnRadius; this.Equals.FontSize = btnFontSize;
            this.btn9.HeightRequest = btnHeight; this.btn9.WidthRequest = btnWidth; this.btn9.CornerRadius = btnRadius; this.btn9.FontSize = btnFontSize;
            this.btn8.HeightRequest = btnHeight; this.btn8.WidthRequest = btnWidth; this.btn8.CornerRadius = btnRadius; this.btn8.FontSize = btnFontSize;
            this.btn7.HeightRequest = btnHeight; this.btn7.WidthRequest = btnWidth; this.btn7.CornerRadius = btnRadius; this.btn7.FontSize = btnFontSize;
            this.btn6.HeightRequest = btnHeight; this.btn6.WidthRequest = btnWidth; this.btn6.CornerRadius = btnRadius; this.btn6.FontSize = btnFontSize;
            this.btn5.HeightRequest = btnHeight; this.btn5.WidthRequest = btnWidth; this.btn5.CornerRadius = btnRadius; this.btn5.FontSize = btnFontSize;
            this.btn4.HeightRequest = btnHeight; this.btn4.WidthRequest = btnWidth; this.btn4.CornerRadius = btnRadius; this.btn4.FontSize = btnFontSize;
            this.btn3.HeightRequest = btnHeight; this.btn3.WidthRequest = btnWidth; this.btn3.CornerRadius = btnRadius; this.btn3.FontSize = btnFontSize;
            this.btn2.HeightRequest = btnHeight; this.btn2.WidthRequest = btnWidth; this.btn2.CornerRadius = btnRadius; this.btn2.FontSize = btnFontSize;
            this.btn1.HeightRequest = btnHeight; this.btn1.WidthRequest = btnWidth; this.btn1.CornerRadius = btnRadius; this.btn1.FontSize = btnFontSize;
            this.btn0.HeightRequest = btnHeight; this.btn0.WidthRequest = 2.47 * btnWidth; this.btn0.CornerRadius = btnRadius; this.btn0.FontSize = btnFontSize;

            //Reset on startup
            OPS.Num1 = null;
            OPS.Num2 = null;
            OPS.Operator = null;
        }

        //Instantiate OPS object
        OPS OPS = new OPS();

        private void Clear_Clicked(object sender, EventArgs e)
        {
            //RTZ for Display.Text, numbers, operators and Polarity = True
            OPS.Num1 = null;
            OPS.Num2 = null;
            OPS.Operator = null;
            lastBtn = "new";
            Display.Text = "0";
        }
        private void PlusMinus_Clicked(object sender, EventArgs e)
        {
            //don't run unless there is a number displayed
            //parse current number multiply by -1
            //update display
            bool noOperator = Display.Text.All(c => !operators.Contains(c.ToString()));
            if (noOperator)
            {
                OPS.TempNum = OPS.StringToDouble(Display.Text) * -1;
                Display.Text = $"{OPS.TempNum}";
            }
        }

        private void Percent_Clicked(object sender, EventArgs e)
        //basically just a shortcut for /100; haven't found a calculator that does anything other than that
        {
            //selects appropriate num and divides by 100
            //update display
            if (OPS.StringToDouble(Display.Text) != double.NaN)
            {
                OPS.TempNum = OPS.StringToDouble(Display.Text) / 100;
                Display.Text = $"{OPS.TempNum}";
            }
        }

        private void Divide_Clicked(object sender, EventArgs e)
        {
            //Divide, multiply, subtract and add will all be: do not run is lastBtn = "operator"
            //if everything is null, store display as Num1 and set operator to "+"
            //if Num1 is stored and there is an operator, run NumCrunch and set operator to "+"
            //update display
            if (lastBtn != "operator")
            {
                if (OPS.Num1 == null && OPS.Operator == null && OPS.Num2 == null)
                {
                    OPS.Num1 = OPS.StringToDouble(Display.Text);
                    OPS.Operator = "/";
                    Display.Text = "÷";
                }

                else if (OPS.Num1 != null && OPS.Operator != null && OPS.Num2 == null)
                {
                    OPS.Num2 = OPS.StringToDouble(Display.Text);
                    OPS.NumCrunch();
                    OPS.Operator = "/";
                    Display.Text = $"{OPS.Num1}";
                }
            }
            lastBtn = "operator";
        }

        private void Multiply_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "operator")
            {
                if (OPS.Num1 == null && OPS.Operator == null && OPS.Num2 == null)
                {
                    OPS.Num1 = OPS.StringToDouble(Display.Text);
                    OPS.Operator = "x";
                    Display.Text = "x";
                }

                else if (OPS.Num1 != null && OPS.Operator != null && OPS.Num2 == null)
                {
                    OPS.Num2 = OPS.StringToDouble(Display.Text);
                    OPS.NumCrunch();
                    OPS.Operator = "x";
                    Display.Text = $"{OPS.Num1}";
                }
            }
            lastBtn = "operator";
        }

        private void Subtract_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "operator")

            {
                if (OPS.Num1 == null && OPS.Operator == null && OPS.Num2 == null)
                {
                    OPS.Num1 = OPS.StringToDouble(Display.Text);
                    OPS.Operator = "-";
                    Display.Text = "-";
                }

                else if (OPS.Num1 != null && OPS.Operator != null && OPS.Num2 == null)
                {
                    OPS.Num2 = OPS.StringToDouble(Display.Text);
                    OPS.NumCrunch();
                    OPS.Operator = "-";
                    Display.Text = $"{OPS.Num1}";
                }
            }
            lastBtn = "operator";
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "operator")
            {
                if (OPS.Num1 == null && OPS.Operator == null && OPS.Num2 == null)
                {
                    OPS.Num1 = OPS.StringToDouble(Display.Text);
                    OPS.Operator = "+";
                    Display.Text = "+";
                }

                else if (OPS.Num1 != null && OPS.Operator != null && OPS.Num2 == null)
                {
                    OPS.Num2 = OPS.StringToDouble(Display.Text);
                    OPS.NumCrunch();
                    OPS.Operator = "+";
                    Display.Text = $"{OPS.Num1}";
                }
            }
            lastBtn = "operator";
        }

        private void Decimal_Clicked(object sender, EventArgs e)
        {
            //going to need an ignore statement somewhere for 1234.
            //if displayText != "0", doesn't already contain "." or an operator, displayText += "."
            bool noOperator = Display.Text.All(c => !operators.Contains(c.ToString()));
            bool noDeci = Display.Text.All(c => !".".Contains(c.ToString()));
            if (OPS.StringToDouble(Display.Text) != double.NaN && noDeci && noOperator)
            {
                Display.Text += ".";
                lastBtn = "digit";

            }

        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
            //don't run if equals or an operator was already pressed
            //if Num1 is stored and there's an operator, run EqualsCrunch and update display

            if (lastBtn != "equals" && lastBtn != "operator")
            {
                if (OPS.Num1 != null && OPS.Operator != null && OPS.Num2 == null)
                {
                    OPS.Num2 = OPS.StringToDouble(Display.Text);
                    OPS.EqualsCrunch();
                    Display.Text = $"{OPS.Num1}";
                    OPS.Num1 = null;
                }
            }
            lastBtn = "equals";
        }
        private void btn0_Clicked(object sender, EventArgs e)
        {
            //0-9 are going to be if lastBtn isn't "digit (or Display.Text != "0" for 1-9), Display.Text = number
            //else Display.Text = Display.Text + "number"
            if (lastBtn != "digit") { Display.Text = "0"; }
            else if (lastBtn == "digit") { Display.Text = Display.Text + "0"; }
            lastBtn = "digit";
        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "digit" || Display.Text == "0") { Display.Text = "1"; }
            else if (lastBtn == "digit") { Display.Text += "1"; }
            lastBtn = "digit";
        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "digit" || Display.Text == "0") { Display.Text = "2"; }
            else if (lastBtn == "digit") { Display.Text += "2"; }
            lastBtn = "digit";
        }

        private void btn3_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "digit" || Display.Text == "0") { Display.Text = "3"; }
            else if (lastBtn == "digit") { Display.Text += "3"; }
            lastBtn = "digit";
        }

        private void btn4_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "digit" || Display.Text == "0") { Display.Text = "4"; }
            else if (lastBtn == "digit") { Display.Text += "4"; }
            lastBtn = "digit";
        }

        private void btn5_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "digit" || Display.Text == "0") { Display.Text = "5"; }
            else if (lastBtn == "digit") { Display.Text += "5"; }
            lastBtn = "digit";
        }

        private void btn6_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "digit" || Display.Text == "0") { Display.Text = "6"; }
            else if (lastBtn == "digit") { Display.Text += "6"; }
            lastBtn = "digit";
        }
        private void btn7_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "digit" || Display.Text == "0") { Display.Text = "7"; }
            else if (lastBtn == "digit") { Display.Text += "7"; }
            lastBtn = "digit";
        }

        private void btn8_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "digit" || Display.Text == "0") { Display.Text = "8"; }
            else if (lastBtn == "digit") { Display.Text += "8"; }
            lastBtn = "digit";
        }

        private void btn9_Clicked(object sender, EventArgs e)
        {
            if (lastBtn != "digit" || Display.Text == "0") { Display.Text = "9"; }
            else if (lastBtn == "digit") { Display.Text += "9"; }
            lastBtn = "digit";
        }
    }
}