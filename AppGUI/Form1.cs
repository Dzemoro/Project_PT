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
using Microsoft.SqlServer;
using Microsoft.Data.Sqlite;
using Microsoft.SqlServer;
using AppFunctionsLibrary.Models;

namespace AppGUI
{
    public partial class Form1 : Form
    {
        AppDatabaseContext context;
        DeviceManager um;

        // 0 if English, 1 if Polish
        private bool guiLanguage = false;

        public Form1()
        {

            var opBuilder = new SqliteConnectionStringBuilder<AppDatabaseContext>();
            var conStringBuilder = new SqliteConnectionStringBuilder();
            conStringBuilder.DataSource = @"..\..\..\AppDB.db";
            opBuilder.UseSqlite(conStringBuilder.ConnectionString);
            this.context = new AppDatabaseContext(opBuilder.Options);


            var opBuilder = new DbContextOptionsBuilder<AppDatabaseContext>();
            var conStringBuilder = new SqliteConnectionStringBuilder();
            conStringBuilder.DataSource = @"..\..\..\AppDB.db";
            opBuilder.UseSqlite(conStringBuilder.ConnectionString);
            this.context = new AppDatabaseContext(opBuilder.Options);
            this.um = new DeviceManager(this.context);

            InitializeComponent();

            

        }

        private void koteczek_Click(object sender, EventArgs e)
        {
            koteczek.Text = "Siemka";

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private double GetValue(Control textBox)
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
            try
            {
                double fsl = (20 * Math.Log10(GetValue(DistanceTextBox) / 1000)) + (20 * Math.Log10(GetValue(FrequencyComboBox))) + 32.44;
                double rpl = GetValue(PowerTextBoxT) - GetValue(AttenuationWireTextBoxT) * GetValue(LengthTextBoxT) - GetValue(AttenuationConnectorTextBoxT) + GetValue(GainTextBoxT) - fsl + GetValue(GainTextBoxR) - GetValue(AttenuationWireTextBoxR) * GetValue(LengthTextBoxR) - GetValue(AttenuationConnectorTextBoxR);
                rpl = Math.Round(rpl, 4);
                ResultTextBox.Text = rpl.ToString();
            }
            catch (Exception ex) { }
        }

        private void LanguageButton_Click(object sender, EventArgs e)
        {
            if (this.guiLanguage) // switch to English
            {
                NewButton.Text = "New";
                OpenButton.Text = "Open";
                SaveButton.Text = "Save";
                TransmitterLabelT.Text = "Transmitter";
                ReceiverLabel.Text = "Receiver";
                PowerLabelT.Text = "Power [dBm]";
                GainLabelT.Text = GainLabelR.Text = "Gain [dBi]";
                WireLabelT.Text = WireLabelR.Text = "Wire";
                AttenuationWireLabelT.Text = AttenuationWireLabelR.Text = "Attenuation [dB]";
                LengthLabelT.Text = LengthLabelR.Text = "Length [m]";
                ConnectorLabelT.Text = ConnectorLabelR.Text = "Connector";
                AttenuationConnectorLabelT.Text = AttenuationConnectorLabelR.Text = "Attenuation [dB]";
                DistanceLabel.Text = "Distance [m]";
                FrequencyLabel.Text = "Frequency [MHz]";
                ChannelLabel.Text = "Channel";
                ObstaclesLabel.Text = "Obstacles";
                ResultLabel.Text = "RESULT [dB]";
                CountButton.Text = "Count";

                this.guiLanguage = false;
            }
            else // switch to Polish
            {
                NewButton.Text = "Nowy";
                OpenButton.Text = "Otwórz";
                SaveButton.Text = "Zapisz";
                TransmitterLabelT.Text = "Nadajnik";
                ReceiverLabel.Text = "Odbiornik";
                PowerLabelT.Text = "Moc [dBm]";
                GainLabelT.Text = GainLabelR.Text = "Zysk [dBi]";
                WireLabelT.Text = WireLabelR.Text = "Przewód";
                AttenuationWireLabelT.Text = AttenuationWireLabelR.Text = "Tłumienie [dB]";
                LengthLabelT.Text = LengthLabelR.Text = "Długość [m]";
                ConnectorLabelT.Text = ConnectorLabelR.Text = "Złącze";
                AttenuationConnectorLabelT.Text = AttenuationConnectorLabelR.Text = "Tłumienie [db]";
                DistanceLabel.Text = "Dystans [m]";
                FrequencyLabel.Text = "Częstotliwość [MHz]";
                ChannelLabel.Text = "Kanał";
                ObstaclesLabel.Text = "Przeszkody";
                ResultLabel.Text = "WYNIK [dB]";
                CountButton.Text = "Oblicz";

                this.guiLanguage = true;
            }
        }
        private void InfoButton_Click(object sender, EventArgs e)
        {
            string info;
            if (this.guiLanguage)
            {
                info = @"Budżet łącza obliczany jest zgodnie ze wzorem:
            RSL=TSL-CLT+GT-FSL+GR-CLR-CLO
gdzie:
    RSL – poziom sygnału na wejściu odbiornika [dB]
    TSL – poziom sygnału na zaciskach nadajnika (moc nadajnika) [dBm]
    CLT – tłumienność w przewodzie i w złączu po stronie nadajnika [dB]
    GT – zysk anteny nadawczej [dBi]
    FSL – poziom strat sygnału w wolnej przestrzeni [dB]
    GR – zysk anteny odbiorczej [dBi]
    CLR – tłumienność w przewodzie i w złączu po stronie odbiornika [dB]
    CLO – tłumienność przeszkód

FSL wyliczany jest ze wzoru:
            FSL=20log(d*1000)+20log(f)+32,44
gdzie:
    d - odległość między antenami [m]
    f - częstotliwość fali [MHz]";
            }
            else
            {
                info = @"Link budget is calculated using following equation:
            RSL=TSL-CLT+GT-FSL+GR-CLR-CLO
where:
    RSL – received power [dB]
    TSL – transmitter power [dBm]
    CLT – transmitter wire and connector loss [dB]
    GT – transmitter antenna gain [dBi]
    FSL – free space loss [dB]
    GR – receiver antenna gain [dBi]
    CLR – receiver wire and connector loss [dB]
    CLO – obstacles attenuation

FSL is calculated with:
            FSL=20log(d*1000)+20log(f)+32,44
where:
    d - distance between antennas [m]
    f - wave frequency [MHz]";

            }
            MessageBox.Show(info, "Info");
        }
    }
}
