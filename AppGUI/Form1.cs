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
        ObstacleAmountManager omm;
        WireManager wm;
        WireAttenuationManager wam;

        // 0 if English, 1 if Polish
        private bool guiLanguage = false;

        NumberFormatInfo nfi = new NumberFormatInfo();

        bool isInit = true;
        bool isSavedSuccessfully = false;
        bool isCleanedSuccessfully = false;

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
            this.omm = new ObstacleAmountManager(this.context);
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
                if (value.name != "custom")
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
                var name = value.GetType().GetProperties().SingleOrDefault(x => x.Name == "name").GetValue(value, null);
                if (!name.Equals("custom"))
                    comboBox.Items.Add(name);
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
                        obstaclesAttenuation += GetValue(row.Cells["ObstacleAttenuationtColumn"]) * GetValue(row.Cells["ObstacleAmountColumn"]);
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
            if (!isCustom(WireComboBoxT.Text))
                AttenuationWireTextBoxT.Text = "";
            if (!isCustom(WireComboBoxR.Text))
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
                row.Cells["ObstacleAmountColumn"].Value = "1";

                if (cell.Value.ToString() != CUSTOM_EN && cell.Value.ToString() != CUSTOM_PL) {
                    if (BandComboBox.Text == "") {
                        row.Cells["ObstacleAttenuationtColumn"].Value = "";
                    } else {
                        var obstacle = this.om.GetObstacleByName(cell.Value.ToString());
                        if (BandComboBox.Text == "2.4")
                            row.Cells["ObstacleAttenuationtColumn"].Value = obstacle.attenuation_24.ToString(nfi);
                        else row.Cells["ObstacleAttenuationtColumn"].Value = obstacle.attenuation_5.ToString(nfi);
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

        private bool isCustom(string text) {
            return (text == CUSTOM_EN || text == CUSTOM_PL);
        }

        // 0 - saved
        // 1 - empty/used name
        // 2 - empty fields
        private int SaveMeasurement(string name) {
            Measurement m = new Measurement();
            try {
                m.name = name;
                m.distance = float.Parse(DistanceTextBox.Text, nfi);
                m.wireLenghtT = float.Parse(LengthTextBoxT.Text, nfi);
                m.wireLenghtR = float.Parse(LengthTextBoxR.Text, nfi);

                m.transmitter_id = (isCustom(TransmitterComboBox.Text) ? this.dm.AddCustomDevice(new Device() { name = "custom", gain = (float)GetValue(GainTextBoxT), power = (float)GetValue(PowerTextBoxT) }).id : this.dm.GetDeviceByName(TransmitterComboBox.Text).id);
                m.receiver_id = (isCustom(ReceiverComboBox.Text) ? this.dm.AddCustomDevice(new Device() { name = "custom", gain = (float)GetValue(GainTextBoxR), power = 0 }).id : this.dm.GetDeviceByName(ReceiverComboBox.Text).id);

                m.wireT_id = (isCustom(WireComboBoxT.Text) ? this.wm.AddCustomWire(new Wire() { name = "custom" }, new WireAttenuation() { frequency = (float)GetValue(FrequencyTextBox), value = (float)GetValue(AttenuationWireTextBoxT) }).id : this.wm.GetWireByName(WireComboBoxT.Text).id);
                m.wireR_id = (isCustom(WireComboBoxR.Text) ? this.wm.AddCustomWire(new Wire() { name = "custom" }, new WireAttenuation() { frequency = (float)GetValue(FrequencyTextBox), value = (float)GetValue(AttenuationWireTextBoxR) }).id : this.wm.GetWireByName(WireComboBoxR.Text).id);

                m.connectorT_id = (isCustom(ConnectorComboBoxT.Text) ? this.cm.AddCustomConnector(new Connector() { name = "custom", attenuation = (float)GetValue(AttenuationConnectorTextBoxT) }).id : this.cm.GetConnectorByName(ConnectorComboBoxT.Text).id);
                m.connectorR_id = (isCustom(ConnectorComboBoxR.Text) ? this.cm.AddCustomConnector(new Connector() { name = "custom", attenuation = (float)GetValue(AttenuationConnectorTextBoxR) }).id : this.cm.GetConnectorByName(ConnectorComboBoxR.Text).id);

                m.channel_id = this.chm.GetChannelByFrequency(Int32.Parse(FrequencyTextBox.Text, nfi)).id;

            } catch (NullReferenceException ex) { // custom

            } catch (FormatException ex) { // empty or wrong value
                koteczek.Text = "puste cos chyba";
                return 2;
            } catch (Exception ex) { //wrong value

            }
            if (this.mm.AddMeasurement(m)) {
                foreach (DataGridViewRow row in ObstaclesDataGridView.Rows) {
                    if (row.Cells["ObstacleColumn"].Value != null) {
                        ObstacleAmount om = new ObstacleAmount();
                        om.amount = (int)GetValue(row.Cells["ObstacleAmountColumn"]);
                        if (isCustom(row.Cells["ObstacleColumn"].Value.ToString())) {
                            om.obstacles_id = this.om.AddCustomObstacle(new Obstacle() { name = "custom", attenuation_24 = (BandComboBox.Text == "2.4" ? float.Parse(row.Cells["ObstacleAttenuationtColumn"].Value.ToString()) : 0), attenuation_5 = (BandComboBox.Text == "5.0" ? float.Parse(row.Cells["ObstacleAttenuationtColumn"].Value.ToString()) : 0) }).id;
                        } else
                            om.obstacles_id = this.om.GetObstacleByName(row.Cells["ObstacleColumn"].Value.ToString()).id;
                        om.measurements_id = m.id;

                        this.omm.AddObstacleAmount(om);
                    }
                }

                return 0;
            } else return 1;
        }

        private bool WantToSave(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Do you want to save your measurement?", "New", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes) {
                SaveButton_Click(sender, e);
                if (isSavedSuccessfully)
                    return true;
                else return false;

            } else if (dialogResult == DialogResult.No) {
                return true;
            } else return false;
        }

        private void NewButton_Click(object sender, EventArgs e) {
            if (WantToSave(sender, e)) {
                Form1 NewForm = new Form1();
                NewForm.Show();
                this.Dispose(false);
                isCleanedSuccessfully = true;
            } else isCleanedSuccessfully = false;
        }

        private void OpenButton_Click(object sender, EventArgs e) {
            /*
            NewButton_Click(sender, e);
            if (isCleanedSuccessfully)
                ShowOpenDialog();
            */
            if (WantToSave(sender, e)) {
                Form1 NewForm = new Form1();
                NewForm.Show();
                this.Dispose(false);
                NewForm.ShowOpenDialog();
            }
        }

        // 0 - saved
        // 1 - empty/used name
        // 2 - empty fields
        // 3 - cancel
        private void SaveButton_Click(object sender, EventArgs e) {
            int result = ShowSaveDialog();
            string msg = "";
            switch (result) {
                case 0:
                    msg = "Saved successfully";
                    break;
                case 1:
                    msg = "Given name is wrong or already in use";
                    break;
                case 2:
                    msg = "You cannot leave empty fields";
                    break;
                case 3:
                    return;
            }
            DialogResult dialogResult = MessageBox.Show(msg, "Save", MessageBoxButtons.OK);
            if (result == 0) isSavedSuccessfully = true;
            else isSavedSuccessfully = false;
        }

        // 0 - saved
        // 1 - empty/used name
        // 2 - empty fields
        // 3 - cancel
        private int ShowSaveDialog() {
            Form prompt = new Form() {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Save",
                StartPosition = FormStartPosition.CenterScreen,
                CausesValidation = true,
            };
            Label textLabel = new Label() { Left = 25, Top = 20, Text = "Enter measurement name:" };
            TextBox textBox = new TextBox() { Left = 25, Top = 50, Width = 250 };
            Button confirmation = new Button() { Text = "Save", Left = 100, Width = 100, Top = 80, DialogResult = DialogResult.OK, CausesValidation = true };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            var dialogResult = prompt.ShowDialog();

            if (dialogResult == DialogResult.Cancel) {
                prompt.Dispose();
                return 3;
            } else if (dialogResult == DialogResult.OK) {
                if (textBox.Text == "")
                    return 1;
                else
                    return this.SaveMeasurement(textBox.Text);
            }
            return 2;
        }

        private void ShowOpenDialog() {
            Form prompt = new Form() {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Open",
                StartPosition = FormStartPosition.CenterScreen,
                CausesValidation = true,
            };
            ComboBox comboBox = new ComboBox() { Left = 50, Width = 200, Top = 20 };
            Button confirmation = new Button() { Text = "Open", Left = 100, Width = 100, Top = 50, DialogResult = DialogResult.OK, CausesValidation = true };
            var measurementList = this.mm.GetMeasurements();
            foreach (var measurement in measurementList)
                comboBox.Items.Add(measurement.name);
            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            var dialogResult = prompt.ShowDialog();

            if (dialogResult == DialogResult.Cancel) {
                prompt.Dispose();
                return;
            } else if (dialogResult == DialogResult.OK) {
                FillMeasurement(comboBox.Text);
            }
        }

        private void FillMeasurement(string name) {
            koteczek.Text = name;

            var m = this.mm.GetMeasurementByName(name);

            DistanceTextBox.Text = m.distance.ToString(nfi);
            LengthTextBoxT.Text = m.wireLenghtT.ToString(nfi);
            LengthTextBoxR.Text = m.wireLenghtR.ToString(nfi);

            var channel = this.chm.GetChannel(m.channel_id);
            BandComboBox.Text = ((float)channel.band / 10).ToString(nfi);
            ChannelComboBox.Text = channel.number.ToString(nfi);

            var transmitter = this.dm.GetDevice(m.transmitter_id);
            if (transmitter.name == "custom") {
                TransmitterComboBox.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
                PowerTextBoxT.Text = "123";
                PowerTextBoxT.Text = transmitter.power.ToString();
                GainTextBoxT.Text = transmitter.gain.ToString();
            } else {
                TransmitterComboBox.Text = transmitter.name;
            }

            var receiver = this.dm.GetDevice(m.receiver_id);
            if (receiver.name == "custom") {
                ReceiverComboBox.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
                GainTextBoxR.Text = receiver.gain.ToString(nfi);
            } else {
                ReceiverComboBox.Text = receiver.name;
            }

            var wireT = this.wm.GetWire(m.wireT_id);
            if (wireT.name == "custom") {
                WireComboBoxT.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
                AttenuationWireTextBoxT.Text = (this.wm.GetWireAttenuationByIdFrequency(wireT.id, Convert.ToInt32(FrequencyTextBox.Text)).value).ToString(nfi);
            } else {
                WireComboBoxT.Text = wireT.name;
            }

            var wireR = this.wm.GetWire(m.wireR_id);
            if (wireR.name == "custom") {
                WireComboBoxR.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
                AttenuationWireTextBoxR.Text = (this.wm.GetWireAttenuationByIdFrequency(wireR.id, Convert.ToInt32(FrequencyTextBox.Text)).value).ToString(nfi);
            } else {
                WireComboBoxR.Text = wireR.name;
            }

            var connT = this.cm.GetConnector(m.connectorT_id);
            if (connT.name == "custom") {
                ConnectorComboBoxT.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
                AttenuationConnectorTextBoxT.Text = connT.attenuation.ToString(nfi);
            } else {
                ConnectorComboBoxT.Text = connT.name;
            }

            var connR = this.cm.GetConnector(m.connectorR_id);
            if (connR.name == "custom") {
                ConnectorComboBoxR.Text = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
                AttenuationConnectorTextBoxR.Text = connR.attenuation.ToString(nfi);
            } else {
                ConnectorComboBoxR.Text = connR.name;
            }

            var obstacles = this.omm.GetObstaleAmountsByMID(m.id);

            int i = 0;
            foreach (var obstacle in obstacles) {
                ObstaclesDataGridView.Rows.Add();
                var row = ObstaclesDataGridView.Rows[i];
                var ob = this.om.GetObstacle(obstacle.obstacles_id);
                if (ob.name == "custom") {
                    row.Cells["ObstacleColumn"].Value = (guiLanguage ? CUSTOM_PL : CUSTOM_EN);
                    if (BandComboBox.Text == "2.4")
                        row.Cells["ObstacleAttenuationtColumn"].Value = ob.attenuation_24.ToString(nfi);
                    else row.Cells["ObstacleAttenuationtColumn"].Value = ob.attenuation_5.ToString(nfi);
                    row.Cells["ObstacleAmountColumn"].Value = obstacle.amount.ToString(nfi);
                } else {
                    row.Cells["ObstacleColumn"].Value = ob.name;
                }
                i++;
            }

        }
    }
}