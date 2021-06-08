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

        NumberFormatInfo nfi = new NumberFormatInfo();

        bool isSavedSuccessfully = false;

        const string CUSTOM_PL = "<własne>";
        const string WRONG_PL = "Błędne dane!";

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

            this.nfi.NumberDecimalSeparator = ".";

            Init();
        }

        private void ClearAll() {
            TransmitterComboBox.Text = "";
            ReceiverComboBox.Text = "";
            GainTextBoxT.Text = "";
            GainTextBoxR.Text = "";
            PowerTextBoxT.Text = "";
            WireComboBoxT.Text = "";
            WireComboBoxR.Text = "";
            AttenuationWireTextBoxT.Text = "";
            AttenuationWireTextBoxR.Text = "";
            LengthTextBoxT.Text = "";
            LengthTextBoxR.Text = "";
            ConnectorComboBoxT.Text = "";
            ConnectorComboBoxR.Text = "";
            AttenuationConnectorTextBoxT.Text = "";
            AttenuationConnectorTextBoxR.Text = "";
            DistanceTextBox.Text = "";
            BandComboBox.Text = "";
            ChannelComboBox.Text = "";
            FrequencyTextBox.Text = "";
            ResultTextBox.Text = "";
            ChannelComboBox.Items.Clear();
            ObstaclesDataGridView.Rows.Clear();
            ObstaclesDataGridView.Refresh();
            Init();
        }

        private void Init() {
            List<Connector> connectorList = this.cm.GetConnectors();
            var deviceList = this.dm.GetDevices();
            var obstacleList = this.om.GetObstacles();
            var wireList = this.wm.GetWires();

            FillCombobox(ConnectorComboBoxT, connectorList);
            FillCombobox(ConnectorComboBoxR, connectorList);
            FillCombobox(TransmitterComboBox, deviceList);
            FillCombobox(ReceiverComboBox, deviceList);
            FillCombobox(WireComboBoxT, wireList);
            FillCombobox(WireComboBoxR, wireList);

            //var utf8 = Encoding.GetEncoding("UTF-8");

            ObstacleColumn.Items.Clear();
            ObstacleColumn.Items.Add(GetCustom());
            foreach (var value in obstacleList) {
                if (value.name != "custom") {
                    //ObstacleColumn.Items.Add(Encoding.UTF8.GetString(Encoding.Convert(utf8, Encoding.UTF8, Encoding.Default.GetBytes(value.name))));
                    ObstacleColumn.Items.Add(value.name);
                }
            }

            BandComboBox.Items.Clear();
            BandComboBox.Items.Add("2.4");
            BandComboBox.Items.Add("5.0");
        }


        private void FillCombobox<T>(ComboBox comboBox, List<T> values) {
            comboBox.Items.Clear();
            comboBox.Items.Add(GetCustom());
            foreach (var value in values) {
                var name = value.GetType().GetProperties().SingleOrDefault(x => x.Name == "name").GetValue(value, null);
                if (!name.Equals("custom"))
                    comboBox.Items.Add(name);
            }
        }

        private double GetValue(Control textBox) {
            var match = Regex.Match(textBox.Text, @"^[0-9]*\.?[0-9]+$");
            if (match.Success && match.Value.Length == textBox.Text.Length) {
                return Convert.ToDouble(textBox.Text, nfi);
            } else {
                textBox.Text = WRONG_PL;
                throw new Exception("Wrong value");
            }
        }
        
        private double GetValue(DataGridViewCell cell) {
            var match = Regex.Match(cell.Value.ToString(), @"^[0-9]*\.?[0-9]+$");
            if (match.Success && match.Value.Length == cell.Value.ToString().Length) {
                return Convert.ToDouble(cell.Value.ToString(), nfi);
            } else {
                cell.Value = WRONG_PL;
                throw new Exception("Wrong value");
            }
        }

        private bool IsCustom(string text) {
            return (text == CUSTOM_PL);
        }
        
        private string GetCustom() {
            return CUSTOM_PL;
        }
        
        private void InfoButton_Click(object sender, EventArgs e) {
                string info = @"Budżet łącza obliczany jest zgodnie ze wzorem:
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

            MessageBox.Show(info, "Info");
        }

        private void TransmitterComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (!IsCustom(TransmitterComboBox.Text)) {
                var transmitter = this.dm.GetDeviceByName(TransmitterComboBox.Text);
                PowerTextBoxT.Text = transmitter.power.ToString(nfi);
                GainTextBoxT.Text = transmitter.gain.ToString(nfi);
                PowerTextBoxT.Enabled = false;
                GainTextBoxT.Enabled = false;
            } else {
                PowerTextBoxT.Enabled = true;
                GainTextBoxT.Enabled = true;
            }
        }

        private void ReceiverComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (!IsCustom(ReceiverComboBox.Text)) {
                var receiver = this.dm.GetDeviceByName(ReceiverComboBox.Text);
                GainTextBoxR.Text = receiver.gain.ToString(nfi);
                GainTextBoxR.Enabled = false;
            } else {
                GainTextBoxR.Enabled = true;
            }
        }

        private void WireComboBoxT_SelectedIndexChanged(object sender, EventArgs e) {
            if (!IsCustom(WireComboBoxT.Text)) {
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
                } else if (!IsCustom(ConnectorComboBoxT.Text)) {
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
            if (!IsCustom(WireComboBoxR.Text)) {
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
                } else if (!IsCustom(ConnectorComboBoxR.Text)) {
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
            if (!IsCustom(ConnectorComboBoxT.Text)) {
                AttenuationConnectorTextBoxT.Text = this.cm.GetConnectorByName(ConnectorComboBoxT.Text).attenuation.ToString(nfi);
                AttenuationConnectorTextBoxT.Enabled = false;
            } else {
                AttenuationConnectorTextBoxT.Enabled = true;
            }
        }

        private void ConnectorComboBoxR_SelectedIndexChanged(object sender, EventArgs e) {
            if (!IsCustom(ConnectorComboBoxR.Text)) {
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
            if (!IsCustom(WireComboBoxT.Text))
                AttenuationWireTextBoxT.Text = "";
            if (!IsCustom(WireComboBoxR.Text))
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
                        if (!IsCustom(row.Cells["ObstacleColumn"].Value.ToString())) {
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

            if (WireComboBoxT.Text != "" && !IsCustom(WireComboBoxT.Text)) {
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

            if (WireComboBoxR.Text != "" && !IsCustom(WireComboBoxR.Text)) {
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
            TransmitterComboBox.Text = GetCustom();
        }

        private void GainTextBoxT_Click(object sender, EventArgs e) {
            TransmitterComboBox.Text = GetCustom();
        }

        private void AttenuationWireTextBoxT_Click(object sender, EventArgs e) {
            WireComboBoxT.Text = GetCustom();
        }

        private void AttenuationConnectorTextBoxT_Click(object sender, EventArgs e) {
            ConnectorComboBoxT.Text = GetCustom();
        }

        private void GainTextBoxR_Click(object sender, EventArgs e) {
            ReceiverComboBox.Text = GetCustom();
        }

        private void AttenuationWireTextBoxR_Click(object sender, EventArgs e) {
            WireComboBoxR.Text = GetCustom();
        }

        private void AttenuationConnectorTextBoxR_Click(object sender, EventArgs e) {
            ConnectorComboBoxR.Text = GetCustom();
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

                if (!IsCustom(cell.Value.ToString())) {
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
                    row.Cells["ObstacleColumn"].Value = GetCustom();
            }
        }

        private void Count() {
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

        private void CountButton_Click(object sender, EventArgs e) {
            Count();
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

                m.transmitter_id = (IsCustom(TransmitterComboBox.Text) ? this.dm.AddCustomDevice(new Device() { name = "custom", gain = (float)GetValue(GainTextBoxT), power = (float)GetValue(PowerTextBoxT) }).id : this.dm.GetDeviceByName(TransmitterComboBox.Text).id);
                m.receiver_id = (IsCustom(ReceiverComboBox.Text) ? this.dm.AddCustomDevice(new Device() { name = "custom", gain = (float)GetValue(GainTextBoxR), power = 0 }).id : this.dm.GetDeviceByName(ReceiverComboBox.Text).id);

                m.wireT_id = (IsCustom(WireComboBoxT.Text) ? this.wm.AddCustomWire(new Wire() { name = "custom" }, new WireAttenuation() { frequency = (float)GetValue(FrequencyTextBox), value = (float)GetValue(AttenuationWireTextBoxT) }).id : this.wm.GetWireByName(WireComboBoxT.Text).id);
                m.wireR_id = (IsCustom(WireComboBoxR.Text) ? this.wm.AddCustomWire(new Wire() { name = "custom" }, new WireAttenuation() { frequency = (float)GetValue(FrequencyTextBox), value = (float)GetValue(AttenuationWireTextBoxR) }).id : this.wm.GetWireByName(WireComboBoxR.Text).id);

                m.connectorT_id = (IsCustom(ConnectorComboBoxT.Text) ? this.cm.AddCustomConnector(new Connector() { name = "custom", attenuation = (float)GetValue(AttenuationConnectorTextBoxT) }).id : this.cm.GetConnectorByName(ConnectorComboBoxT.Text).id);
                m.connectorR_id = (IsCustom(ConnectorComboBoxR.Text) ? this.cm.AddCustomConnector(new Connector() { name = "custom", attenuation = (float)GetValue(AttenuationConnectorTextBoxR) }).id : this.cm.GetConnectorByName(ConnectorComboBoxR.Text).id);

                m.channel_id = this.chm.GetChannelByFrequency(Int32.Parse(FrequencyTextBox.Text, nfi)).id;

            } catch (NullReferenceException ex) { // custom

            } catch (FormatException ex) { // empty or wrong value
                return 2;
            } catch (Exception ex) { //wrong value

            }
            if (this.mm.AddMeasurement(m)) {
                foreach (DataGridViewRow row in ObstaclesDataGridView.Rows) {
                    if (row.Cells["ObstacleColumn"].Value != null) {
                        ObstacleAmount om = new ObstacleAmount();
                        om.amount = (int)GetValue(row.Cells["ObstacleAmountColumn"]);
                        if (IsCustom(row.Cells["ObstacleColumn"].Value.ToString())) {
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
            DialogResult dialogResult = MessageBox.Show("Czy chcesz zapisać pomiar?", "Nowy", MessageBoxButtons.YesNoCancel);
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
                ClearAll();
            }
        }

        private void OpenButton_Click(object sender, EventArgs e) {
            if (WantToSave(sender, e)) {
                ClearAll();
                ShowOpenDialog();
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
                    msg = "Zapisano pomyslnie";
                    break;
                case 1:
                    msg = "Podana nazwa jest nieprawidłowa lub już istnieje pomiar o takiej nazwie";
                    break;
                case 2:
                    msg = "Pozostawiono puste wymagane pola";
                    break;
                case 3:
                    return;
            }
            DialogResult dialogResult = MessageBox.Show(msg, "Zapisz", MessageBoxButtons.OK);
            if (result == 0) isSavedSuccessfully = true;
            else isSavedSuccessfully = false;
        }

        // 0 - saved
        // 1 - empty/used name
        // 2 - empty fields
        // 3 - cancel
        private int ShowSaveDialog() {
            string text = "Zapisz";
            Form prompt = new Form() {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = text,
                StartPosition = FormStartPosition.CenterScreen,
                CausesValidation = true,
            };
            Label textLabel = new Label() { Left = 25, Top = 20, Text = "Podaj nazwę pomiaru:"};
            TextBox textBox = new TextBox() { Left = 25, Top = 50, Width = 250 };
            Button confirmation = new Button() { Text = text, Left = 100, Width = 100, Top = 80, DialogResult = DialogResult.OK, CausesValidation = true };
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
            string text = "Otwórz";
            Form prompt = new Form() {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = text,
                StartPosition = FormStartPosition.CenterScreen,
                CausesValidation = true,
            };
            ComboBox comboBox = new ComboBox() { Left = 50, Width = 200, Top = 20 };
            Button confirmation = new Button() { Text = text, Left = 100, Width = 100, Top = 50, DialogResult = DialogResult.OK, CausesValidation = true };
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
                Count();
            }
        }

        private void FillMeasurement(string name) {
            var m = this.mm.GetMeasurementByName(name);

            DistanceTextBox.Text = m.distance.ToString(nfi);
            LengthTextBoxT.Text = m.wireLenghtT.ToString(nfi);
            LengthTextBoxR.Text = m.wireLenghtR.ToString(nfi);

            var channel = this.chm.GetChannel(m.channel_id);
            BandComboBox.Text = (channel.band < 50) ? "2.4" : "5.0";
            ChannelComboBox.Text = channel.number.ToString(nfi);

            var transmitter = this.dm.GetDevice(m.transmitter_id);
            if (transmitter.name == "custom") {
                TransmitterComboBox.Text = GetCustom();
                PowerTextBoxT.Text = transmitter.power.ToString();
                GainTextBoxT.Text = transmitter.gain.ToString();
            } else {
                TransmitterComboBox.Text = transmitter.name;
            }

            var receiver = this.dm.GetDevice(m.receiver_id);
            if (receiver.name == "custom") {
                ReceiverComboBox.Text = GetCustom();
                GainTextBoxR.Text = receiver.gain.ToString(nfi);
            } else {
                ReceiverComboBox.Text = receiver.name;
            }

            var wireT = this.wm.GetWire(m.wireT_id);
            if (wireT.name == "custom") {
                WireComboBoxT.Text = GetCustom();
                AttenuationWireTextBoxT.Text = (this.wm.GetWireAttenuationByIdFrequency(wireT.id, Convert.ToInt32(FrequencyTextBox.Text)).value).ToString(nfi);
            } else {
                WireComboBoxT.Text = wireT.name;
            }

            var wireR = this.wm.GetWire(m.wireR_id);
            if (wireR.name == "custom") {
                WireComboBoxR.Text = GetCustom();
                AttenuationWireTextBoxR.Text = (this.wm.GetWireAttenuationByIdFrequency(wireR.id, Convert.ToInt32(FrequencyTextBox.Text)).value).ToString(nfi);
            } else {
                WireComboBoxR.Text = wireR.name;
            }

            var connT = this.cm.GetConnector(m.connectorT_id);
            if (connT.name == "custom") {
                ConnectorComboBoxT.Text = GetCustom();
                AttenuationConnectorTextBoxT.Text = connT.attenuation.ToString(nfi);
            } else {
                ConnectorComboBoxT.Text = connT.name;
            }

            var connR = this.cm.GetConnector(m.connectorR_id);
            if (connR.name == "custom") {
                ConnectorComboBoxR.Text = GetCustom();
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
                    row.Cells["ObstacleColumn"].Value = GetCustom();
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

        private void ObstaclesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e) { }
    }
}