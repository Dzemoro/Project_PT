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
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using AppFunctionsLibrary.Models;

namespace AppGUI
{
    public partial class Form1 : Form
    {
        AppDatabaseContext context;
        ChannelManager chm;
        ConnectorManager cm;
        ConnectorToWireManager ctwm;
        DeviceManager dm;
        ObstacleManager om;
        WireManager wm;
        WireAttenuationManager wam;

        // 0 if English, 1 if Polish
        private bool guiLanguage = false;

        NumberFormatInfo nfi = new NumberFormatInfo();

        public Form1()
        {
            InitializeComponent();

            var opBuilder = new DbContextOptionsBuilder<AppDatabaseContext>();
            var conStringBuilder = new SqliteConnectionStringBuilder();
            conStringBuilder.DataSource = @"..\..\..\AppDB.db";
            opBuilder.UseSqlite(conStringBuilder.ConnectionString);
            this.context = new AppDatabaseContext(opBuilder.Options);
            this.chm = new ChannelManager(this.context);
            this.cm = new ConnectorManager(this.context);
            this.ctwm = new ConnectorToWireManager(this.context);
            this.dm = new DeviceManager(this.context);
            this.om = new ObstacleManager(this.context);
            this.wm = new WireManager(this.context);
            this.wam = new WireAttenuationManager(this.context);
            var connectorList = this.cm.GetConnectors();
            var deviceList = this.dm.GetDevices();
            var obstacleList = this.om.GetObstacles();
            var wireList = this.wm.GetWires();

            foreach (var connector in connectorList)
            {
                ConnectorComboBoxT.Items.Add(connector.name);
                ConnectorComboBoxR.Items.Add(connector.name);
            }
            foreach (var device in deviceList)
            {
                TransmitterComboBox.Items.Add(device.name);
                ReceiverComboBox.Items.Add(device.name);
            }
            /*foreach (var obstacle in obstacleList)
            {
                ObstacleComboBox.Items.Add(obstacle.name);
            }*/
            foreach (var wire in wireList)
            {
                WireComboBoxT.Items.Add(wire.name);
                WireComboBoxR.Items.Add(wire.name);
            }
            BandComboBox.Items.Add("2.4");
            BandComboBox.Items.Add("5.0");

            this.nfi.NumberDecimalSeparator = ".";
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
                return Convert.ToDouble(textBox.Text, nfi);
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
                double fsl = (20 * Math.Log10(GetValue(DistanceTextBox) / 1000)) + (20 * Math.Log10(GetValue(FrequencyTextBox))) + 32.44;
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
                BandLabel.Text = "Frequency [MHz]";
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
                BandLabel.Text = "Częstotliwość [MHz]";
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

        private void TransmitterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var transmitter = this.dm.GetDeviceByName(TransmitterComboBox.Text);
            PowerTextBoxT.Text = transmitter.power.ToString();
            GainTextBoxT.Text = transmitter.gain.ToString();
        }

        private void ReceiverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var receiver = this.dm.GetDeviceByName(ReceiverComboBox.Text);
            GainTextBoxR.Text = receiver.gain.ToString();
        }

        private void WireComboBoxT_SelectedIndexChanged(object sender, EventArgs e)
        {
            var wire = this.wm.GetWireByName(WireComboBoxT.Text);

            if (FrequencyTextBox.Text == "")
            {
                AttenuationWireTextBoxT.Text = "";
            } else
            {
                var attenuation = this.wm.GetWireAttenuationByNameFrequency(WireComboBoxT.Text, Convert.ToInt32(FrequencyTextBox.Text));
                AttenuationWireTextBoxT.Text = (attenuation.value/100).ToString(nfi);
            }

            var connectors = this.ctwm.GetConnectorsByWire(wire.id);
            ConnectorComboBoxT.Items.Clear();
            foreach (var connector in connectors)
            {
                ConnectorComboBoxT.Items.Add(connector.name);
            }
            if (!ConnectorComboBoxT.Items.Contains(ConnectorComboBoxT.Text))
            {
                ConnectorComboBoxT.Text = "";
                AttenuationConnectorTextBoxT.Text = "";
            }
            else
            {
                AttenuationConnectorTextBoxT.Text = this.cm.GetConnectorByName(ConnectorComboBoxT.Text).attenuation.ToString(nfi);
            }
        }

        private void WireComboBoxR_SelectedIndexChanged(object sender, EventArgs e)
        {
            var wire = this.wm.GetWireByName(WireComboBoxR.Text);

            if (FrequencyTextBox.Text == "")
            {
                AttenuationWireTextBoxR.Text = "";
            }
            else
            {
                var attenuation = this.wm.GetWireAttenuationByNameFrequency(WireComboBoxR.Text, Convert.ToInt32(FrequencyTextBox.Text));
                AttenuationWireTextBoxR.Text = (attenuation.value / 100).ToString(nfi);
            }

            var connectors = this.ctwm.GetConnectorsByWire(wire.id);
            ConnectorComboBoxR.Items.Clear();
            foreach (var connector in connectors)
            {
                ConnectorComboBoxR.Items.Add(connector.name);
            }
            if (!ConnectorComboBoxR.Items.Contains(ConnectorComboBoxR.Text))
            {
                ConnectorComboBoxR.Text = "";
                AttenuationConnectorTextBoxR.Text = "";
            }
            else
            {
                AttenuationConnectorTextBoxR.Text = this.cm.GetConnectorByName(ConnectorComboBoxR.Text).attenuation.ToString(nfi);
            }
        }

        private void ConnectorComboBoxT_SelectedIndexChanged(object sender, EventArgs e)
        {
            AttenuationConnectorTextBoxT.Text = this.cm.GetConnectorByName(ConnectorComboBoxT.Text).attenuation.ToString(nfi);
        }

        private void ConnectorComboBoxR_SelectedIndexChanged(object sender, EventArgs e)
        {
            AttenuationConnectorTextBoxR.Text = this.cm.GetConnectorByName(ConnectorComboBoxR.Text).attenuation.ToString(nfi);
        }

        private void BandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrequencyTextBox.Text = "";
            ChannelComboBox.Text = "";
            ChannelComboBox.Items.Clear();
            AttenuationWireTextBoxT.Text = "";
            AttenuationWireTextBoxR.Text = "";
            List<Channel> channels = new List<Channel>();
            if (BandComboBox.Text == "2.4")
                channels = this.chm.GetChannelsByBand(24);
            else if (BandComboBox.Text == "5.0")
                channels = this.chm.GetChannelsByBand(50);
            foreach (var channel in channels)
            {
                ChannelComboBox.Items.Add(channel.number);
            }
        }

        private void ChannelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int band = 0;
            if (BandComboBox.Text == "2.4")
                band = 24;
            else if (BandComboBox.Text == "5.0")
                band = 50;
            var channel = this.chm.GetChannelByBandFrequency(band, Convert.ToInt32(ChannelComboBox.Text));
            FrequencyTextBox.Text = channel.frequency.ToString();
            
            if (WireComboBoxT.Text != "") {
                var wireAttenuation = this.wm.GetWireAttenuationByNameFrequency(WireComboBoxT.Text, channel.frequency);

                WireComboBoxT.Items.Clear();
                var wires = this.wm.GetWiresByFrequency(channel.frequency);
                foreach (var wire in wires) {
                    WireComboBoxT.Items.Add(wire.name);
                }

                if (wireAttenuation == null) {
                    WireComboBoxT.Text = "";
                    AttenuationWireTextBoxT.Text = "";
                    AttenuationConnectorTextBoxT.Text = "";

                    ConnectorComboBoxT.Items.Clear();
                    var connectors = this.cm.GetConnectors();
                    foreach (var connector in connectors)
                        ConnectorComboBoxT.Items.Add(connector.name);
                }
                else {
                    AttenuationWireTextBoxT.Text = (wireAttenuation.value / 100).ToString(nfi);
                }
            } else {
                WireComboBoxT.Items.Clear();
                var wirelist = this.wm.GetWiresByFrequency(channel.frequency);
                foreach (var wire in wirelist) {
                    WireComboBoxT.Items.Add(wire.name);
                }
            }

            if (WireComboBoxR.Text != "")
            {
                var wireAttenuation = this.wm.GetWireAttenuationByNameFrequency(WireComboBoxR.Text, channel.frequency);

                WireComboBoxR.Items.Clear();
                var wires = this.wm.GetWiresByFrequency(channel.frequency);
                foreach (var wire in wires)
                {
                    WireComboBoxR.Items.Add(wire.name);
                }

                if (wireAttenuation == null)
                {
                    WireComboBoxR.Text = "";
                    AttenuationWireTextBoxR.Text = "";
                    AttenuationConnectorTextBoxR.Text = "";

                    ConnectorComboBoxR.Items.Clear();
                    var connectors = this.cm.GetConnectors();
                    foreach (var connector in connectors)
                        ConnectorComboBoxR.Items.Add(connector.name);
                }
                else
                {

                    AttenuationWireTextBoxR.Text = (wireAttenuation.value / 100).ToString(nfi);
                }
            }
            else
            {
                WireComboBoxR.Items.Clear();
                var wirelist = this.wm.GetWiresByFrequency(channel.frequency);
                foreach (var wire in wirelist)
                {
                    WireComboBoxR.Items.Add(wire.name);
                }
            }
        }


    }
}

// todo:
// "wrong value" traktować jak ""
// custom parametry