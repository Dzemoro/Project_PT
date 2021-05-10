using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void koteczek_Click(object sender, EventArgs e)
        {
            koteczek.Text = "Siemka";

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private double GetValue(System.Windows.Forms.Control textBox)
        {
            var match = Regex.Match(textBox.Text, @"^[0-9]*\.?[0-9]+$");

            if (match.Success && match.Value.Length == textBox.Text.Length)
            {
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                return Convert.ToDouble(textBox.Text, provider);
            }
            else
            {
                textBox.Text = "Wrong value!";
                throw new Exception("Wrong value");
            }
        }

        private void CountButton_Click(object sender, EventArgs e)
        {
            //MHz
            try
            {
                double fsl = (20 * Math.Log10(GetValue(DistanceTextBox) / 1000)) + (20 * Math.Log10(GetValue(FrequencyComboBox))) + 32.44;
                double rpl = GetValue(PowerTextBoxT) - GetValue(AttenuationWireTextBoxT) * GetValue(LengthTextBoxT) - GetValue(AttenuationConnectorTextBoxT) + GetValue(GainTextBoxT) - fsl + GetValue(GainTextBoxR) - GetValue(AttenuationWireTextBoxR) * GetValue(LengthTextBoxR) - GetValue(AttenuationConnectorTextBoxR);
                rpl = Math.Round(rpl, 4);
                ResultTextBox.Text = rpl.ToString();
            }
            catch (Exception ex) { }
        }
    }
}
//todo: change FrequencyComboBox (take channelbox too idk)