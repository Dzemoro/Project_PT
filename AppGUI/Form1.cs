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

namespace AppGUI {
    public partial class Form1 : Form {
        AppDatabaseContext context;
        ChannelManager chm;
        ConnectorManager cm;
        ConnectorToWireManager ctwm;
        DeviceManager dm;
        MeasurementManager mm;
        ObstacleManager om;
        WireManager wm;
        WireAttenuationManager wam;

        // 0 if English, 1 if Polish
        private bool guiLanguage = false;

        NumberFormatInfo nfi = new NumberFormatInfo();

        bool isInit = true;

        const string CUSTOM_PL = "<własne>";
        const string CUSTOM_EN = "<custom>";
        const string WRONG_PL = "Błędne dane!";
        const string WRONG_EN = "Wrong value!";

        public Form1() {
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
            this.mm = new MeasurementManager(this.context);
            this.om = new ObstacleManager(this.context);
            this.wm = new WireManager(this.context);
            this.wam = new WireAttenuationManager(this.context);
            List<Connector> connectorList = this.cm.GetConnectors();
            var deviceList = this.dm.GetDevices();
            var obstacleList = this.om.GetObstacles();
            var wireList = this.wm.GetWires();
            var obstaclesList = this.om.GetObstacles();

            FillCombobox(ConnectorComboBoxT, connectorList);
            FillCombobox(ConnectorComboBoxR, connectorList);
            FillCombobox(TransmitterComboBox, deviceList);
            FillCombobox(ReceiverComboBox, deviceList);
            FillCombobox(WireComboBoxT, wireList);
            FillCombobox(WireComboBoxR, wireList);

            ObstacleColumn.Items.Clear();
            ObstacleColumn.Items.Add(guiLanguage ? CUSTOM_PL : CUSTOM_EN);
            foreach (var value in obstacleList) {
                ObstacleColumn.Items.Add(value.name);
            }

            BandComboBox.Items.Add("2.4");
            BandComboBox.Items.Add("5.0");

            this.nfi.NumberDecimalSeparator = ".";
        }

        private void koteczek_Click(object sender, EventArgs e) {
            koteczek.Text = "Siemka";

        }

        private void FillCombobox<T>(ComboBox comboBox, List<T> values) {
            comboBox.Items.Clear();
            comboBox.Items.Add(guiLanguage ? CUSTOM_PL : CUSTOM_EN);
            foreach (var value in values) {
                comboBox.Items.Add(value.GetType().GetProperties().SingleOrDefault(x => x.Name == "name").GetValue(value, null));
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private double GetValue(Control textBox) {
            var match = Regex.Match(textBox.Text, @"^[0-9]*\.?[0-9]+$");

            if (match.Success && match.Value.Length == textBox.Text.Length) {
                return Convert.ToDouble(textBox.Text, nfi);
            } else {
                textBox.Text = guiLanguage ? WRONG_PL : WRONG_EN;
                throw new Exception("Wrong value");
            }
        }
        private double GetValue(DataGridViewCell cell) {
            var match = Regex.Match(cell.Value.ToString(), @"^[0-9]*\.?[0-9]+$");

            if (match.Success && match.Value.Length == cell.Value.ToString().Length) {
                return Convert.ToDouble(cell.Value.ToString(), nfi);
            } else {
                cell.Value = guiLanguage ? WRONG_PL : WRONG_EN;
                throw new Exception("Wrong value");
            }
        }

        private void CountButton_Click(object sender, EventArgs e) {
            try {
                double obstaclesAttenuation = 0;
                foreach (DataGridViewRow row in ObstaclesDataGridView.Rows) {
                    if (row.Cells["ObstacleColumn"].Value != null) {
                        var obstacle = this.om.GetObstacleByName(row.Cells["ObstacleColumn"].Value.ToString());
                        //if (BandComboBox.Text == "2.4")
                        obstaclesAttenuation += GetValue(row.Cells["ObstacleAttenuationColumn"]) * GetValue(row.Cells["ObstacleAmountColumn"]);
                        //else
                        //obstaclesAttenuation += obstacle.attenuation_5 * Int32.Parse(row.Cells["ObstacleAmountColumn"].Value);
                    }
                }
                double fsl = (20 * Math.Log10(GetValue(DistanceTextBox) / 1000)) + (20 * Math.Log10(GetValue(FrequencyTextBox))) + 32.44;
                double rpl = GetValue(PowerTextBoxT) - GetValue(AttenuationWireTextBoxT) * GetValue(LengthTextBoxT) - GetValue(AttenuationConnectorTextBoxT) + GetValue(GainTextBoxT) - fsl + GetValue(GainTextBoxR) - GetValue(AttenuationWireTextBoxR) * GetValue(LengthTextBoxR) - GetValue(AttenuationConnectorTextBoxR) - obstaclesAttenuation;
                rpl = Math.Round(rpl, 4);
                ResultTextBox.Text = rpl.ToString();
            } catch (Exception ex) { }
        }

        private void LanguageButton_Click(object sender, EventArgs e) {
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
                BandLabel.Text = "Band [GHz]";
                ChannelLabel.Text = "Channel";
                FrequencyLabel.Text = "Frequency [MHz]";
                ObstaclesLabel.Text = "Obstacles";
                ResultLabel.Text = "RESULT [dB]";
                CountButton.Text = "Count";

                TransmitterComboBox.Items[0] = CUSTOM_EN;
                ReceiverComboBox.Items[0] = CUSTOM_EN;
                WireComboBoxT.Items[0] = CUSTOM_EN;
                WireComboBoxR.Items[0] = CUSTOM_EN;
                ConnectorComboBoxT.Items[0] = CUSTOM_EN;
                ConnectorComboBoxR.Items[0] = CUSTOM_EN;

                this.guiLanguage = false;
            } else // switch to Polish
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
                BandLabel.Text = "Pasmo [GHz]";
                ChannelLabel.Text = "Kanał";
                FrequencyLabel.Text = "Częstotliwość [MHz]";
                ObstaclesLabel.Text = "Przeszkody";
                ResultLabel.Text = "WYNIK [dB]";
                CountButton.Text = "Oblicz";

                TransmitterComboBox.Items[0] = CUSTOM_PL;
                ReceiverComboBox.Items[0] = CUSTOM_PL;
                WireComboBoxT.Items[0] = CUSTOM_PL;
                WireComboBoxR.Items[0] = CUSTOM_PL;
                ConnectorComboBoxT.Items[0] = CUSTOM_PL;
                ConnectorComboBoxR.Items[0] = CUSTOM_PL;

                this.guiLanguage = true;
            }
        }
        private void InfoButton_Click(object sender, EventArgs e) {
            string info;
            if (this.guiLanguage) {
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
            } else {
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

        private void TransmitterComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (TransmitterComboBox.Text != CUSTOM_EN && TransmitterComboBox.Text != CUSTOM_PL) {
                var transmitter = this.dm.GetDeviceByName(TransmitterComboBox.Text);
                PowerTextBoxT.Text = transmitter.power.ToString();
                GainTextBoxT.Text = transmitter.gain.ToString();
                PowerTextBoxT.Enabled = false;
                GainTextBoxT.Enabled = false;
            } else {
                PowerTextBoxT.Enabled = true;
                GainTextBoxT.Enabled = true;
            }
        }

        private void ReceiverComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (ReceiverComboBox.Text != CUSTOM_EN && ReceiverComboBox.Text != CUSTOM_PL) {
                var receiver = this.dm.GetDeviceByName(ReceiverComboBox.Text);
                GainTextBoxR.Text = receiver.gain.ToString();
                GainTextBoxR.Enabled = false;
            } else {
                GainTextBoxR.Enabled = true;
            }
        }

        private void WireComboBoxT_SelectedIndexChanged(object sender, EventArgs e) {
            if (WireComboBoxT.Text != CUSTOM_EN && WireComboBoxT.Text != CUSTOM_PL) {
                var wire = this.wm.GetWireByName(WireComboBoxT.Text);

                if (FrequencyTextBox.Text == "") {
                    AttenuationWireTextBoxT.Text = "";
                } else {
                    var attenuation = this.wm.GetWireAttenuationByNameFrequency(WireComboBoxT.Text, Convert.ToInt32(FrequencyTextBox.Text));
                    AttenuationWireTextBoxT.Text = (attenuation.value / 100).ToString(nfi);
                }

                var connectors = this.ctwm.GetConnectorsByWire(wire.id);
                FillCombobox(ConnectorComboBoxT, connectors);
                if (!ConnectorComboBoxT.Items.Contains(ConnectorComboBoxT.Text)) {
                    ConnectorComboBoxT.Text = "";
                    AttenuationConnectorTextBoxT.Text = "";
                } else {
                    AttenuationConnectorTextBoxT.Text = this.cm.GetConnectorByName(ConnectorComboBoxT.Text).attenuation.ToString(nfi);
                }

                AttenuationWireTextBoxT.Enabled = false;

            } else {
                AttenuationWireTextBoxT.Enabled = true;
                var connectors = this.cm.GetConnectors();
                FillCombobox(ConnectorComboBoxT, connectors);
            }
        }

        private void WireComboBoxR_SelectedIndexChanged(object sender, EventArgs e) {
            if (WireComboBoxR.Text != CUSTOM_EN && WireComboBoxR.Text != CUSTOM_PL) {
                var wire = this.wm.GetWireByName(WireComboBoxR.Text);

                if (FrequencyTextBox.Text == "") {
                    AttenuationWireTextBoxR.Text = "";
                } else {
                    var attenuation = this.wm.GetWireAttenuationByNameFrequency(WireComboBoxR.Text, Convert.ToInt32(FrequencyTextBox.Text));
                    AttenuationWireTextBoxR.Text = (attenuation.value / 100).ToString(nfi);
                }

                var connectors = this.ctwm.GetConnectorsByWire(wire.id);
                FillCombobox(ConnectorComboBoxR, connectors);

                if (!ConnectorComboBoxR.Items.Contains(ConnectorComboBoxR.Text)) {
                    ConnectorComboBoxR.Text = "";
                    AttenuationConnectorTextBoxR.Text = "";
                } else {
                    AttenuationConnectorTextBoxR.Text = this.cm.GetConnectorByName(ConnectorComboBoxR.Text).attenuation.ToString(nfi);
                }

                AttenuationWireTextBoxR.Enabled = false;

            } else {
                AttenuationWireTextBoxR.Enabled = true;
                var connectors = this.cm.GetConnectors();
                FillCombobox(ConnectorComboBoxR, connectors);
            }
        }

        private void ConnectorComboBoxT_SelectedIndexChanged(object sender, EventArgs e) {
            if (ConnectorComboBoxT.Text != CUSTOM_EN && ConnectorComboBoxT.Text != CUSTOM_PL) {
                AttenuationConnectorTextBoxT.Text = this.cm.GetConnectorByName(ConnectorComboBoxT.Text).attenuation.ToString(nfi);
                AttenuationConnectorTextBoxT.Enabled = false;
            } else {
                AttenuationConnectorTextBoxT.Enabled = true;
            }
        }

        private void ConnectorComboBoxR_SelectedIndexChanged(object sender, EventArgs e) {
            if (ConnectorComboBoxR.Text != CUSTOM_EN && ConnectorComboBoxR.Text != CUSTOM_PL) {
                AttenuationConnectorTextBoxR.Text = this.cm.GetConnectorByName(ConnectorComboBoxR.Text).attenuation.ToString(nfi);
                AttenuationConnectorTextBoxR.Enabled = false;
            } else {
                AttenuationConnectorTextBoxR.Enabled = true;
            }
        }

        private void BandComboBox_SelectedIndexChanged(object sender, EventArgs e) {
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
                ChannelComboBox.Items.Add(channel.number);

            if (ObstaclesDataGridView.Columns[0].Name != "") {
                foreach (DataGridViewRow row in ObstaclesDataGridView.Rows) {
                    if (row.Cells["ObstacleColumn"].Value != null) {
                        if (row.Cells["ObstacleColumn"].Value.ToString() != CUSTOM_EN && row.Cells["ObstacleColumn"].Value.ToString() != CUSTOM_PL) {
                            var obstacle = this.om.GetObstacleByName(row.Cells["ObstacleColumn"].Value.ToString());
                            if (BandComboBox.Text == "2.4")
                                row.Cells["ObstacleAttenuationtColumn"].Value = obstacle.attenuation_24;
                            else row.Cells["ObstacleAttenuationtColumn"].Value = obstacle.attenuation_5;
                        }
                    }
                }
            }
        }

        private void ChannelComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int band = 0;
            if (BandComboBox.Text == "2.4")
                band = 24;
            else if (BandComboBox.Text == "5.0")
                band = 50;
            var channel = this.chm.GetChannelByBandFrequency(band, Convert.ToInt32(ChannelComboBox.Text));
            FrequencyTextBox.Text = channel.frequency.ToString();

            if (WireComboBoxT.Text != "" && WireComboBoxT.Text != CUSTOM_EN && WireComboBoxT.Text != CUSTOM_PL) {
                var wireAttenuation = this.wm.GetWireAttenuationByNameFrequency(WireComboBoxT.Text, channel.frequency);

                var wires = this.wm.GetWiresByFrequency(channel.frequency);
                FillCombobox(WireComboBoxT, wires);

                if (wireAttenuation == null) {
                    WireComboBoxT.Text = "";
                    AttenuationWireTextBoxT.Text = "";
                    AttenuationConnectorTextBoxT.Text = "";

                    var connectors = this.cm.GetConnectors();
                    FillCombobox(ConnectorComboBoxT, connectors);
                } else {
                    AttenuationWireTextBoxT.Text = (wireAttenuation.value / 100).ToString(nfi);
                }
            } else {
                var wirelist = this.wm.GetWiresByFrequency(channel.frequency);
                FillCombobox(WireComboBoxT, wirelist);
            }

            if (WireComboBoxR.Text != "" && WireComboBoxR.Text != CUSTOM_EN && WireComboBoxR.Text != CUSTOM_PL) {
                var wireAttenuation = this.wm.GetWireAttenuationByNameFrequency(WireComboBoxR.Text, channel.frequency);

                var wires = this.wm.GetWiresByFrequency(channel.frequency);
                FillCombobox(WireComboBoxR, wires);

                if (wireAttenuation == null) {
                    WireComboBoxR.Text = "";
                    AttenuationWireTextBoxR.Text = "";
                    AttenuationConnectorTextBoxR.Text = "";

                    var connectors = this.cm.GetConnectors();
                    FillCombobox(ConnectorComboBoxR, connectors);
                } else {

                    AttenuationWireTextBoxR.Text = (wireAttenuation.value / 100).ToString(nfi);
                }
            } else {
                var wirelist = this.wm.GetWiresByFrequency(channel.frequency);
                FillCombobox(WireComboBoxR, wirelist);
            }
        }

        private void PowerTextBoxT_Click(object sender, EventArgs e) {
            TransmitterComboBox.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
        }

        private void GainTextBoxT_Click(object sender, EventArgs e) {
            TransmitterComboBox.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
        }

        private void AttenuationWireTextBoxT_Click(object sender, EventArgs e) {
            WireComboBoxT.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
        }

        private void AttenuationConnectorTextBoxT_Click(object sender, EventArgs e) {
            ConnectorComboBoxT.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
        }

        private void GainTextBoxR_Click(object sender, EventArgs e) {
            ReceiverComboBox.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
        }

        private void AttenuationWireTextBoxR_Click(object sender, EventArgs e) {
            WireComboBoxR.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
        }

        private void AttenuationConnectorTextBoxR_Click(object sender, EventArgs e) {
            ConnectorComboBoxR.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
        }

        private void ObstaclesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1 && !ObstaclesDataGridView.Rows[e.RowIndex].IsNewRow)
                if (ObstaclesDataGridView.Rows.Count > 1)
                    ObstaclesDataGridView.Rows.RemoveAt(e.RowIndex);
                else
                    foreach (DataGridViewCell cell in ObstaclesDataGridView.Rows[0].Cells)
                        cell.Value = "";
        }

        private void ObstaclesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (ObstaclesDataGridView.Columns[0].Name == "") return;
            if (e.RowIndex < 0) return;
            var rowNum = e.ColumnIndex;
            var row = ObstaclesDataGridView.Rows[e.RowIndex];
            var cell = row.Cells[rowNum];
            if (rowNum == 0) {        // Name
                if (cell.Value.ToString() != CUSTOM_EN && cell.Value.ToString() != CUSTOM_PL) {
                    if (BandComboBox.Text == "") {
                        row.Cells["ObstacleAttenuationtColumn"].Value = "";
                    } else {
                        var obstacle = this.om.GetObstacleByName(cell.Value.ToString());
                        if (BandComboBox.Text == "2.4")
                            row.Cells["ObstacleAttenuationtColumn"].Value = obstacle.attenuation_24;
                        else row.Cells["ObstacleAttenuationtColumn"].Value = obstacle.attenuation_5;
                    }
                    row.Cells["ObstacleAttenuationtColumn"].ReadOnly = true;
                } else {
                    row.Cells["ObstacleAttenuationtColumn"].ReadOnly = false;
                }
            } else if (rowNum == 2) { // Attenuation
                if (row.Cells["ObstacleColumn"].Value == null)
                    row.Cells["ObstacleColumn"].Value = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
            }
        }

        private void NewButton_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes) {
                // save to DB
                Measurement m = new Measurement();
                m.name = "Test2";
                m.distance = float.Parse(DistanceTextBox.Text, nfi);
                m.wireLenghtT = float.Parse(LengthTextBoxT.Text, nfi);
                m.wireLenghtR = float.Parse(LengthTextBoxR.Text, nfi);
                m.transmitter_id = this.dm.GetDeviceByName(TransmitterComboBox.Text).id;
                m.receiver_id = this.dm.GetDeviceByName(ReceiverComboBox.Text).id;
                m.wireT_id = this.wm.GetWireByName(WireComboBoxT.Text).id;
                m.wireR_id = this.wm.GetWireByName(WireComboBoxR.Text).id;
                m.connectorT_id = this.cm.GetConnectorByName(ConnectorComboBoxT.Text).id;
                m.connectorR_id = this.cm.GetConnectorByName(ConnectorComboBoxR.Text).id;
                m.channel_id = Int32.Parse(DistanceTextBox.Text, nfi);

                this.mm.AddMeasurement(m);
                var list = this.mm.GetMeasurements();

                // clear form
                Form1 NewForm = new Form1();
                NewForm.Show();
                this.Dispose(false);

            } else if (dialogResult == DialogResult.No) {
                Form1 NewForm = new Form1();
                NewForm.Show();
                this.Dispose(false);
            }
        }
    }
}

// todo: