namespace AppGUI
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LanguageButton = new System.Windows.Forms.Button();
            this.InfoButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.TransmitterComboBox = new System.Windows.Forms.ComboBox();
            this.PowerTextBoxT = new System.Windows.Forms.TextBox();
            this.GainTextBoxT = new System.Windows.Forms.TextBox();
            this.AttenuationConnectorTextBoxT = new System.Windows.Forms.TextBox();
            this.AttenuationWireTextBoxT = new System.Windows.Forms.TextBox();
            this.LengthTextBoxT = new System.Windows.Forms.TextBox();
            this.ConnectorComboBoxT = new System.Windows.Forms.ComboBox();
            this.WireComboBoxT = new System.Windows.Forms.ComboBox();
            this.DistanceTextBox = new System.Windows.Forms.TextBox();
            this.ChannelComboBox = new System.Windows.Forms.ComboBox();
            this.FrequencyComboBox = new System.Windows.Forms.ComboBox();
            this.koteczek = new System.Windows.Forms.Label();
            this.WireLabel = new System.Windows.Forms.TableLayoutPanel();
            this.AttenuationConnectorLabelT = new System.Windows.Forms.Label();
            this.ConnectorLabelT = new System.Windows.Forms.Label();
            this.LengthLabelT = new System.Windows.Forms.Label();
            this.AttenuationWireLabelT = new System.Windows.Forms.Label();
            this.WireLabelT = new System.Windows.Forms.Label();
            this.GainLabelT = new System.Windows.Forms.Label();
            this.PowerLabelT = new System.Windows.Forms.Label();
            this.TransmitterLabelT = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AttenuationConnectorLabelR = new System.Windows.Forms.Label();
            this.ReceiverComboBox = new System.Windows.Forms.ComboBox();
            this.ReceiverLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.GainLabelR = new System.Windows.Forms.Label();
            this.WireLabelR = new System.Windows.Forms.Label();
            this.AttenuationWireLabelR = new System.Windows.Forms.Label();
            this.LengthLabelR = new System.Windows.Forms.Label();
            this.ConnectorLabelR = new System.Windows.Forms.Label();
            this.GainComboBoxR = new System.Windows.Forms.TextBox();
            this.AttenuationConnectorTextBoxR = new System.Windows.Forms.TextBox();
            this.ConnectorComboBoxR = new System.Windows.Forms.ComboBox();
            this.LengthTextBoxR = new System.Windows.Forms.TextBox();
            this.AttenuationWireTextBoxR = new System.Windows.Forms.TextBox();
            this.WireComboBoxR = new System.Windows.Forms.ComboBox();
            this.CountButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ChannelLabel = new System.Windows.Forms.Label();
            this.DistanceLabel = new System.Windows.Forms.Label();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.ObstaclesDataGridView = new System.Windows.Forms.DataGridView();
            this.ObstacleColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ObstacleAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount2Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.WireLabel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObstaclesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LanguageButton);
            this.groupBox1.Controls.Add(this.InfoButton);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.OpenButton);
            this.groupBox1.Controls.Add(this.NewButton);
            this.groupBox1.Location = new System.Drawing.Point(50, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1019, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // LanguageButton
            // 
            this.LanguageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LanguageButton.Location = new System.Drawing.Point(791, 39);
            this.LanguageButton.Name = "LanguageButton";
            this.LanguageButton.Size = new System.Drawing.Size(75, 23);
            this.LanguageButton.TabIndex = 27;
            this.LanguageButton.Text = "PL/EN";
            this.LanguageButton.UseVisualStyleBackColor = true;
            // 
            // InfoButton
            // 
            this.InfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InfoButton.Location = new System.Drawing.Point(886, 39);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(75, 23);
            this.InfoButton.TabIndex = 26;
            this.InfoButton.Text = "Info";
            this.InfoButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveButton.Location = new System.Drawing.Point(295, 44);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 25;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // OpenButton
            // 
            this.OpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OpenButton.Location = new System.Drawing.Point(174, 44);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 24;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            // 
            // NewButton
            // 
            this.NewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NewButton.Location = new System.Drawing.Point(60, 44);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 23;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            // 
            // TransmitterComboBox
            // 
            this.TransmitterComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TransmitterComboBox.FormattingEnabled = true;
            this.TransmitterComboBox.Location = new System.Drawing.Point(135, 13);
            this.TransmitterComboBox.Name = "TransmitterComboBox";
            this.TransmitterComboBox.Size = new System.Drawing.Size(86, 21);
            this.TransmitterComboBox.TabIndex = 3;
            // 
            // PowerTextBoxT
            // 
            this.PowerTextBoxT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PowerTextBoxT.Location = new System.Drawing.Point(135, 60);
            this.PowerTextBoxT.Name = "PowerTextBoxT";
            this.PowerTextBoxT.Size = new System.Drawing.Size(86, 20);
            this.PowerTextBoxT.TabIndex = 4;
            // 
            // GainTextBoxT
            // 
            this.GainTextBoxT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.GainTextBoxT.Location = new System.Drawing.Point(135, 107);
            this.GainTextBoxT.Name = "GainTextBoxT";
            this.GainTextBoxT.Size = new System.Drawing.Size(86, 20);
            this.GainTextBoxT.TabIndex = 5;
            // 
            // AttenuationConnectorTextBoxT
            // 
            this.AttenuationConnectorTextBoxT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AttenuationConnectorTextBoxT.Location = new System.Drawing.Point(135, 343);
            this.AttenuationConnectorTextBoxT.Name = "AttenuationConnectorTextBoxT";
            this.AttenuationConnectorTextBoxT.Size = new System.Drawing.Size(86, 20);
            this.AttenuationConnectorTextBoxT.TabIndex = 6;
            // 
            // AttenuationWireTextBoxT
            // 
            this.AttenuationWireTextBoxT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AttenuationWireTextBoxT.Location = new System.Drawing.Point(135, 201);
            this.AttenuationWireTextBoxT.Name = "AttenuationWireTextBoxT";
            this.AttenuationWireTextBoxT.Size = new System.Drawing.Size(86, 20);
            this.AttenuationWireTextBoxT.TabIndex = 7;
            // 
            // LengthTextBoxT
            // 
            this.LengthTextBoxT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LengthTextBoxT.Location = new System.Drawing.Point(135, 248);
            this.LengthTextBoxT.Name = "LengthTextBoxT";
            this.LengthTextBoxT.Size = new System.Drawing.Size(86, 20);
            this.LengthTextBoxT.TabIndex = 8;
            // 
            // ConnectorComboBoxT
            // 
            this.ConnectorComboBoxT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ConnectorComboBoxT.FormattingEnabled = true;
            this.ConnectorComboBoxT.Location = new System.Drawing.Point(135, 295);
            this.ConnectorComboBoxT.Name = "ConnectorComboBoxT";
            this.ConnectorComboBoxT.Size = new System.Drawing.Size(86, 21);
            this.ConnectorComboBoxT.TabIndex = 9;
            // 
            // WireComboBoxT
            // 
            this.WireComboBoxT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.WireComboBoxT.FormattingEnabled = true;
            this.WireComboBoxT.Location = new System.Drawing.Point(135, 154);
            this.WireComboBoxT.Name = "WireComboBoxT";
            this.WireComboBoxT.Size = new System.Drawing.Size(86, 21);
            this.WireComboBoxT.TabIndex = 10;
            // 
            // DistanceTextBox
            // 
            this.DistanceTextBox.Location = new System.Drawing.Point(185, 530);
            this.DistanceTextBox.Name = "DistanceTextBox";
            this.DistanceTextBox.Size = new System.Drawing.Size(86, 20);
            this.DistanceTextBox.TabIndex = 17;
            // 
            // ChannelComboBox
            // 
            this.ChannelComboBox.FormattingEnabled = true;
            this.ChannelComboBox.Location = new System.Drawing.Point(185, 587);
            this.ChannelComboBox.Name = "ChannelComboBox";
            this.ChannelComboBox.Size = new System.Drawing.Size(86, 21);
            this.ChannelComboBox.TabIndex = 18;
            // 
            // FrequencyComboBox
            // 
            this.FrequencyComboBox.FormattingEnabled = true;
            this.FrequencyComboBox.Location = new System.Drawing.Point(185, 560);
            this.FrequencyComboBox.Name = "FrequencyComboBox";
            this.FrequencyComboBox.Size = new System.Drawing.Size(86, 21);
            this.FrequencyComboBox.TabIndex = 19;
            // 
            // koteczek
            // 
            this.koteczek.AutoSize = true;
            this.koteczek.Location = new System.Drawing.Point(1108, 606);
            this.koteczek.Name = "koteczek";
            this.koteczek.Size = new System.Drawing.Size(51, 13);
            this.koteczek.TabIndex = 21;
            this.koteczek.Text = "koteczek";
            this.koteczek.Click += new System.EventHandler(this.koteczek_Click);
            // 
            // WireLabel
            // 
            this.WireLabel.ColumnCount = 2;
            this.WireLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.48214F));
            this.WireLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.51786F));
            this.WireLabel.Controls.Add(this.AttenuationConnectorLabelT, 0, 7);
            this.WireLabel.Controls.Add(this.ConnectorLabelT, 0, 6);
            this.WireLabel.Controls.Add(this.LengthLabelT, 0, 5);
            this.WireLabel.Controls.Add(this.AttenuationWireLabelT, 0, 4);
            this.WireLabel.Controls.Add(this.WireLabelT, 0, 3);
            this.WireLabel.Controls.Add(this.GainLabelT, 0, 2);
            this.WireLabel.Controls.Add(this.PowerLabelT, 0, 1);
            this.WireLabel.Controls.Add(this.GainTextBoxT, 1, 2);
            this.WireLabel.Controls.Add(this.AttenuationWireTextBoxT, 1, 4);
            this.WireLabel.Controls.Add(this.PowerTextBoxT, 1, 1);
            this.WireLabel.Controls.Add(this.WireComboBoxT, 1, 3);
            this.WireLabel.Controls.Add(this.ConnectorComboBoxT, 1, 6);
            this.WireLabel.Controls.Add(this.LengthTextBoxT, 1, 5);
            this.WireLabel.Controls.Add(this.AttenuationConnectorTextBoxT, 1, 7);
            this.WireLabel.Controls.Add(this.TransmitterComboBox, 1, 0);
            this.WireLabel.Controls.Add(this.TransmitterLabelT, 0, 0);
            this.WireLabel.Location = new System.Drawing.Point(50, 129);
            this.WireLabel.Name = "WireLabel";
            this.WireLabel.RowCount = 8;
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.WireLabel.Size = new System.Drawing.Size(224, 377);
            this.WireLabel.TabIndex = 22;
            this.WireLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // AttenuationConnectorLabelT
            // 
            this.AttenuationConnectorLabelT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AttenuationConnectorLabelT.AutoSize = true;
            this.AttenuationConnectorLabelT.Location = new System.Drawing.Point(3, 346);
            this.AttenuationConnectorLabelT.Name = "AttenuationConnectorLabelT";
            this.AttenuationConnectorLabelT.Size = new System.Drawing.Size(61, 13);
            this.AttenuationConnectorLabelT.TabIndex = 18;
            this.AttenuationConnectorLabelT.Text = "Attenuation";
            // 
            // ConnectorLabelT
            // 
            this.ConnectorLabelT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConnectorLabelT.AutoSize = true;
            this.ConnectorLabelT.Location = new System.Drawing.Point(3, 299);
            this.ConnectorLabelT.Name = "ConnectorLabelT";
            this.ConnectorLabelT.Size = new System.Drawing.Size(56, 13);
            this.ConnectorLabelT.TabIndex = 17;
            this.ConnectorLabelT.Text = "Connector";
            this.ConnectorLabelT.Click += new System.EventHandler(this.ConnectorLabelT_Click);
            // 
            // LengthLabelT
            // 
            this.LengthLabelT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LengthLabelT.AutoSize = true;
            this.LengthLabelT.Location = new System.Drawing.Point(3, 252);
            this.LengthLabelT.Name = "LengthLabelT";
            this.LengthLabelT.Size = new System.Drawing.Size(40, 13);
            this.LengthLabelT.TabIndex = 16;
            this.LengthLabelT.Text = "Length";
            this.LengthLabelT.Click += new System.EventHandler(this.LengthLabelT_Click);
            // 
            // AttenuationWireLabelT
            // 
            this.AttenuationWireLabelT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AttenuationWireLabelT.AutoSize = true;
            this.AttenuationWireLabelT.Location = new System.Drawing.Point(3, 205);
            this.AttenuationWireLabelT.Name = "AttenuationWireLabelT";
            this.AttenuationWireLabelT.Size = new System.Drawing.Size(61, 13);
            this.AttenuationWireLabelT.TabIndex = 15;
            this.AttenuationWireLabelT.Text = "Attenuation";
            this.AttenuationWireLabelT.Click += new System.EventHandler(this.AttenuationWireLabelT_Click);
            // 
            // WireLabelT
            // 
            this.WireLabelT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.WireLabelT.AutoSize = true;
            this.WireLabelT.Location = new System.Drawing.Point(3, 158);
            this.WireLabelT.Name = "WireLabelT";
            this.WireLabelT.Size = new System.Drawing.Size(29, 13);
            this.WireLabelT.TabIndex = 14;
            this.WireLabelT.Text = "Wire";
            this.WireLabelT.Click += new System.EventHandler(this.WireLabelT_Click);
            // 
            // GainLabelT
            // 
            this.GainLabelT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GainLabelT.AutoSize = true;
            this.GainLabelT.Location = new System.Drawing.Point(3, 111);
            this.GainLabelT.Name = "GainLabelT";
            this.GainLabelT.Size = new System.Drawing.Size(29, 13);
            this.GainLabelT.TabIndex = 13;
            this.GainLabelT.Text = "Gain";
            this.GainLabelT.Click += new System.EventHandler(this.GainLabelT_Click);
            // 
            // PowerLabelT
            // 
            this.PowerLabelT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PowerLabelT.AutoSize = true;
            this.PowerLabelT.Location = new System.Drawing.Point(3, 64);
            this.PowerLabelT.Name = "PowerLabelT";
            this.PowerLabelT.Size = new System.Drawing.Size(37, 13);
            this.PowerLabelT.TabIndex = 12;
            this.PowerLabelT.Text = "Power";
            this.PowerLabelT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PowerLabelT.Click += new System.EventHandler(this.PowerLabelT_Click);
            // 
            // TransmitterLabelT
            // 
            this.TransmitterLabelT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TransmitterLabelT.AutoSize = true;
            this.TransmitterLabelT.Location = new System.Drawing.Point(3, 17);
            this.TransmitterLabelT.Name = "TransmitterLabelT";
            this.TransmitterLabelT.Size = new System.Drawing.Size(59, 13);
            this.TransmitterLabelT.TabIndex = 11;
            this.TransmitterLabelT.Text = "Transmitter";
            this.TransmitterLabelT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TransmitterLabelT.Click += new System.EventHandler(this.TransmitterLabelT_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.AttenuationConnectorLabelR, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.ReceiverComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ReceiverLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.GainLabelR, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.WireLabelR, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.AttenuationWireLabelR, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.LengthLabelR, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.ConnectorLabelR, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.GainComboBoxR, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.AttenuationConnectorTextBoxR, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.ConnectorComboBoxR, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.LengthTextBoxR, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.AttenuationWireTextBoxR, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.WireComboBoxR, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(397, 129);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(278, 377);
            this.tableLayoutPanel2.TabIndex = 23;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // AttenuationConnectorLabelR
            // 
            this.AttenuationConnectorLabelR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AttenuationConnectorLabelR.AutoSize = true;
            this.AttenuationConnectorLabelR.Location = new System.Drawing.Point(3, 346);
            this.AttenuationConnectorLabelR.Name = "AttenuationConnectorLabelR";
            this.AttenuationConnectorLabelR.Size = new System.Drawing.Size(61, 13);
            this.AttenuationConnectorLabelR.TabIndex = 19;
            this.AttenuationConnectorLabelR.Text = "Attenuation";
            // 
            // ReceiverComboBox
            // 
            this.ReceiverComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ReceiverComboBox.FormattingEnabled = true;
            this.ReceiverComboBox.Location = new System.Drawing.Point(189, 13);
            this.ReceiverComboBox.Name = "ReceiverComboBox";
            this.ReceiverComboBox.Size = new System.Drawing.Size(86, 21);
            this.ReceiverComboBox.TabIndex = 3;
            // 
            // ReceiverLabel
            // 
            this.ReceiverLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ReceiverLabel.AutoSize = true;
            this.ReceiverLabel.Location = new System.Drawing.Point(3, 17);
            this.ReceiverLabel.Name = "ReceiverLabel";
            this.ReceiverLabel.Size = new System.Drawing.Size(50, 13);
            this.ReceiverLabel.TabIndex = 12;
            this.ReceiverLabel.Text = "Receiver";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 13;
            // 
            // GainLabelR
            // 
            this.GainLabelR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GainLabelR.AutoSize = true;
            this.GainLabelR.Location = new System.Drawing.Point(3, 111);
            this.GainLabelR.Name = "GainLabelR";
            this.GainLabelR.Size = new System.Drawing.Size(29, 13);
            this.GainLabelR.TabIndex = 14;
            this.GainLabelR.Text = "Gain";
            // 
            // WireLabelR
            // 
            this.WireLabelR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.WireLabelR.AutoSize = true;
            this.WireLabelR.Location = new System.Drawing.Point(3, 158);
            this.WireLabelR.Name = "WireLabelR";
            this.WireLabelR.Size = new System.Drawing.Size(29, 13);
            this.WireLabelR.TabIndex = 15;
            this.WireLabelR.Text = "Wire";
            // 
            // AttenuationWireLabelR
            // 
            this.AttenuationWireLabelR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AttenuationWireLabelR.AutoSize = true;
            this.AttenuationWireLabelR.Location = new System.Drawing.Point(3, 205);
            this.AttenuationWireLabelR.Name = "AttenuationWireLabelR";
            this.AttenuationWireLabelR.Size = new System.Drawing.Size(61, 13);
            this.AttenuationWireLabelR.TabIndex = 16;
            this.AttenuationWireLabelR.Text = "Attenuation";
            // 
            // LengthLabelR
            // 
            this.LengthLabelR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LengthLabelR.AutoSize = true;
            this.LengthLabelR.Location = new System.Drawing.Point(3, 252);
            this.LengthLabelR.Name = "LengthLabelR";
            this.LengthLabelR.Size = new System.Drawing.Size(40, 13);
            this.LengthLabelR.TabIndex = 17;
            this.LengthLabelR.Text = "Length";
            // 
            // ConnectorLabelR
            // 
            this.ConnectorLabelR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConnectorLabelR.AutoSize = true;
            this.ConnectorLabelR.Location = new System.Drawing.Point(3, 299);
            this.ConnectorLabelR.Name = "ConnectorLabelR";
            this.ConnectorLabelR.Size = new System.Drawing.Size(56, 13);
            this.ConnectorLabelR.TabIndex = 18;
            this.ConnectorLabelR.Text = "Connector";
            // 
            // GainComboBoxR
            // 
            this.GainComboBoxR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.GainComboBoxR.Location = new System.Drawing.Point(189, 107);
            this.GainComboBoxR.Name = "GainComboBoxR";
            this.GainComboBoxR.Size = new System.Drawing.Size(86, 20);
            this.GainComboBoxR.TabIndex = 4;
            // 
            // AttenuationConnectorTextBoxR
            // 
            this.AttenuationConnectorTextBoxR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AttenuationConnectorTextBoxR.Location = new System.Drawing.Point(189, 343);
            this.AttenuationConnectorTextBoxR.Name = "AttenuationConnectorTextBoxR";
            this.AttenuationConnectorTextBoxR.Size = new System.Drawing.Size(86, 20);
            this.AttenuationConnectorTextBoxR.TabIndex = 6;
            // 
            // ConnectorComboBoxR
            // 
            this.ConnectorComboBoxR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ConnectorComboBoxR.FormattingEnabled = true;
            this.ConnectorComboBoxR.Location = new System.Drawing.Point(189, 295);
            this.ConnectorComboBoxR.Name = "ConnectorComboBoxR";
            this.ConnectorComboBoxR.Size = new System.Drawing.Size(86, 21);
            this.ConnectorComboBoxR.TabIndex = 10;
            // 
            // LengthTextBoxR
            // 
            this.LengthTextBoxR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LengthTextBoxR.Location = new System.Drawing.Point(189, 248);
            this.LengthTextBoxR.Name = "LengthTextBoxR";
            this.LengthTextBoxR.Size = new System.Drawing.Size(86, 20);
            this.LengthTextBoxR.TabIndex = 7;
            this.LengthTextBoxR.TextChanged += new System.EventHandler(this.LengthTextBoxR_TextChanged);
            // 
            // AttenuationWireTextBoxR
            // 
            this.AttenuationWireTextBoxR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AttenuationWireTextBoxR.Location = new System.Drawing.Point(189, 201);
            this.AttenuationWireTextBoxR.Name = "AttenuationWireTextBoxR";
            this.AttenuationWireTextBoxR.Size = new System.Drawing.Size(86, 20);
            this.AttenuationWireTextBoxR.TabIndex = 8;
            // 
            // WireComboBoxR
            // 
            this.WireComboBoxR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.WireComboBoxR.FormattingEnabled = true;
            this.WireComboBoxR.Location = new System.Drawing.Point(189, 154);
            this.WireComboBoxR.Name = "WireComboBoxR";
            this.WireComboBoxR.Size = new System.Drawing.Size(86, 21);
            this.WireComboBoxR.TabIndex = 9;
            // 
            // CountButton
            // 
            this.CountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CountButton.Location = new System.Drawing.Point(757, 565);
            this.CountButton.Name = "CountButton";
            this.CountButton.Size = new System.Drawing.Size(75, 23);
            this.CountButton.TabIndex = 27;
            this.CountButton.Text = "Count";
            this.CountButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDown1, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(757, 129);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(270, 60);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Obstacles";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(138, 3);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 36;
            // 
            // ChannelLabel
            // 
            this.ChannelLabel.AutoSize = true;
            this.ChannelLabel.Location = new System.Drawing.Point(47, 587);
            this.ChannelLabel.Name = "ChannelLabel";
            this.ChannelLabel.Size = new System.Drawing.Size(46, 13);
            this.ChannelLabel.TabIndex = 30;
            this.ChannelLabel.Text = "Channel";
            // 
            // DistanceLabel
            // 
            this.DistanceLabel.AutoSize = true;
            this.DistanceLabel.Location = new System.Drawing.Point(47, 530);
            this.DistanceLabel.Name = "DistanceLabel";
            this.DistanceLabel.Size = new System.Drawing.Size(49, 13);
            this.DistanceLabel.TabIndex = 31;
            this.DistanceLabel.Text = "Distance";
            this.DistanceLabel.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Location = new System.Drawing.Point(47, 560);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(57, 13);
            this.FrequencyLabel.TabIndex = 32;
            this.FrequencyLabel.Text = "Frequency";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(860, 534);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(50, 13);
            this.ResultLabel.TabIndex = 33;
            this.ResultLabel.Text = "RESULT";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ResultTextBox.Location = new System.Drawing.Point(863, 565);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(86, 20);
            this.ResultTextBox.TabIndex = 34;
            // 
            // ObstaclesDataGridView
            // 
            this.ObstaclesDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ObstaclesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ObstaclesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObstacleColumn,
            this.ObstacleAmountColumn,
            this.Amount2Column,
            this.DeleteColumn});
            this.ObstaclesDataGridView.Location = new System.Drawing.Point(702, 200);
            this.ObstaclesDataGridView.Name = "ObstaclesDataGridView";
            this.ObstaclesDataGridView.Size = new System.Drawing.Size(457, 197);
            this.ObstaclesDataGridView.TabIndex = 36;
            this.ObstaclesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // ObstacleColumn
            // 
            this.ObstacleColumn.HeaderText = "ObstacleColumn";
            this.ObstacleColumn.Items.AddRange(new object[] {
            "Wood wall",
            "Stone wall"});
            this.ObstacleColumn.Name = "ObstacleColumn";
            // 
            // ObstacleAmountColumn
            // 
            this.ObstacleAmountColumn.HeaderText = "Amount";
            this.ObstacleAmountColumn.Name = "ObstacleAmountColumn";
            this.ObstacleAmountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ObstacleAmountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Amount2Column
            // 
            this.Amount2Column.HeaderText = "Amount2";
            this.Amount2Column.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.Amount2Column.Name = "Amount2Column";
            this.Amount2Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Amount2Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.HeaderText = "Delete";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.Text = "Delete";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1160, 628);
            this.Controls.Add(this.ObstaclesDataGridView);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.FrequencyLabel);
            this.Controls.Add(this.DistanceLabel);
            this.Controls.Add(this.ChannelLabel);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.CountButton);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.WireLabel);
            this.Controls.Add(this.koteczek);
            this.Controls.Add(this.FrequencyComboBox);
            this.Controls.Add(this.ChannelComboBox);
            this.Controls.Add(this.DistanceTextBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.WireLabel.ResumeLayout(false);
            this.WireLabel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObstaclesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox TransmitterComboBox;
        private System.Windows.Forms.TextBox PowerTextBoxT;
        private System.Windows.Forms.TextBox GainTextBoxT;
        private System.Windows.Forms.TextBox AttenuationConnectorTextBoxT;
        private System.Windows.Forms.TextBox AttenuationWireTextBoxT;
        private System.Windows.Forms.TextBox LengthTextBoxT;
        private System.Windows.Forms.ComboBox ConnectorComboBoxT;
        private System.Windows.Forms.ComboBox WireComboBoxT;
        private System.Windows.Forms.TextBox DistanceTextBox;
        private System.Windows.Forms.ComboBox ChannelComboBox;
        private System.Windows.Forms.ComboBox FrequencyComboBox;
        private System.Windows.Forms.Label koteczek;
        private System.Windows.Forms.TableLayoutPanel WireLabel;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button InfoButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label AttenuationConnectorLabelT;
        private System.Windows.Forms.Label ConnectorLabelT;
        private System.Windows.Forms.Label LengthLabelT;
        private System.Windows.Forms.Label AttenuationWireLabelT;
        private System.Windows.Forms.Label WireLabelT;
        private System.Windows.Forms.Label GainLabelT;
        private System.Windows.Forms.Label PowerLabelT;
        private System.Windows.Forms.Label TransmitterLabelT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox LengthTextBoxR;
        private System.Windows.Forms.TextBox GainComboBoxR;
        private System.Windows.Forms.ComboBox ReceiverComboBox;
        private System.Windows.Forms.ComboBox ConnectorComboBoxR;
        private System.Windows.Forms.TextBox AttenuationWireTextBoxR;
        private System.Windows.Forms.ComboBox WireComboBoxR;
        private System.Windows.Forms.TextBox AttenuationConnectorTextBoxR;
        private System.Windows.Forms.Button CountButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label ReceiverLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label GainLabelR;
        private System.Windows.Forms.Label WireLabelR;
        private System.Windows.Forms.Label AttenuationWireLabelR;
        private System.Windows.Forms.Label LengthLabelR;
        private System.Windows.Forms.Label ConnectorLabelR;
        private System.Windows.Forms.Label AttenuationConnectorLabelR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ChannelLabel;
        private System.Windows.Forms.Label DistanceLabel;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button LanguageButton;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.DataGridView ObstaclesDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn ObstacleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObstacleAmountColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Amount2Column;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteColumn;
    }
}

