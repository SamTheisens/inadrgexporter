using inadrgTableAdapter=INADRGExporter.RSKUPANGDataSetTableAdapters.inadrgTableAdapter;

namespace INADRGExporter
{
    partial class ExporterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExporterForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.inadrgBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rSKUPANGDataSet = new INADRGExporter.RSKUPANGDataSet();
            this.cUSTOMERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerDataset = new INADRGExporter.CustomerDataset();
            this.exportWorker = new System.ComponentModel.BackgroundWorker();
            this.inadrgTableAdapter = new INADRGExporter.RSKUPANGDataSetTableAdapters.inadrgTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutINADRGExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportkeExcelWorker = new System.ComponentModel.BackgroundWorker();
            this.cUSTOMERTableAdapter = new INADRGExporter.CustomerDatasetTableAdapters.CUSTOMERTableAdapter();
            this.exportGridKeExcelWorker = new System.ComponentModel.BackgroundWorker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.untilDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.fromGrouperTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kdrsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klsrsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.normDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klsrawatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.biayaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jnsrawatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglmskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglklrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.losDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgllhrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.umurThnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.umurHariDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caraPlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beratDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dutamaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.exportGridKeExcelProgressBar = new System.Windows.Forms.ProgressBar();
            this.exportGridKeExcelButton = new System.Windows.Forms.Button();
            this.selanjutnyaButton = new System.Windows.Forms.Button();
            this.sebelumnyaButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.inadrgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSKUPANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOMERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataset)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // inadrgBindingSource
            // 
            this.inadrgBindingSource.DataMember = "inadrg";
            this.inadrgBindingSource.DataSource = this.rSKUPANGDataSet;
            // 
            // rSKUPANGDataSet
            // 
            this.rSKUPANGDataSet.DataSetName = "RSKUPANGDataSet";
            this.rSKUPANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cUSTOMERBindingSource
            // 
            this.cUSTOMERBindingSource.DataMember = "CUSTOMER";
            this.cUSTOMERBindingSource.DataSource = this.customerDataset;
            // 
            // customerDataset
            // 
            this.customerDataset.DataSetName = "CustomerDataset";
            this.customerDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // exportWorker
            // 
            this.exportWorker.WorkerReportsProgress = true;
            this.exportWorker.WorkerSupportsCancellation = true;
            this.exportWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.exportWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.exportWorker_ProgressChanged);
            // 
            // inadrgTableAdapter
            // 
            this.inadrgTableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(58, 20);
            this.toolStripMenuItemEdit.Text = "S&ettings";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem2.Text = "Ganti &database";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItemChangeConnectionstring_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutINADRGExporterToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutINADRGExporterToolStripMenuItem
            // 
            this.aboutINADRGExporterToolStripMenuItem.Name = "aboutINADRGExporterToolStripMenuItem";
            this.aboutINADRGExporterToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.aboutINADRGExporterToolStripMenuItem.Text = "&About INADRG Exporter";
            this.aboutINADRGExporterToolStripMenuItem.Click += new System.EventHandler(this.aboutINADRGExporterToolStripMenuItem_Click);
            // 
            // exportkeExcelWorker
            // 
            this.exportkeExcelWorker.WorkerReportsProgress = true;
            this.exportkeExcelWorker.WorkerSupportsCancellation = true;
            this.exportkeExcelWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.exportkeExcel_DoWork);
            // 
            // cUSTOMERTableAdapter
            // 
            this.cUSTOMERTableAdapter.ClearBeforeFill = true;
            // 
            // exportGridKeExcelWorker
            // 
            this.exportGridKeExcelWorker.WorkerReportsProgress = true;
            this.exportGridKeExcelWorker.WorkerSupportsCancellation = true;
            this.exportGridKeExcelWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.exportGridKeExcelWorker_DoWork);
            this.exportGridKeExcelWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.exportGridKeExcelWorker_RunWorkerCompleted);
            this.exportGridKeExcelWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.exportGridKeExcelWorker_ProgressChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(748, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ke Grouper";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Controls.Add(this.fromDateTimePicker, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.untilDateTimePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button7, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(736, 428);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.CustomFormat = "";
            this.fromDateTimePicker.Location = new System.Drawing.Point(51, 3);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromDateTimePicker.TabIndex = 1;
            this.fromDateTimePicker.ValueChanged += new System.EventHandler(this.fromDateTimePicker_ValueChanged);
            // 
            // untilDateTimePicker
            // 
            this.untilDateTimePicker.Location = new System.Drawing.Point(51, 39);
            this.untilDateTimePicker.Name = "untilDateTimePicker";
            this.untilDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.untilDateTimePicker.TabIndex = 0;
            this.untilDateTimePicker.ValueChanged += new System.EventHandler(this.untilDateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sampai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dari";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.fromGrouperTextBox);
            this.panel1.Location = new System.Drawing.Point(51, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 34);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse..";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // fromGrouperTextBox
            // 
            this.fromGrouperTextBox.AcceptsTab = true;
            this.fromGrouperTextBox.Location = new System.Drawing.Point(0, 3);
            this.fromGrouperTextBox.Name = "fromGrouperTextBox";
            this.fromGrouperTextBox.Size = new System.Drawing.Size(200, 20);
            this.fromGrouperTextBox.TabIndex = 0;
            this.fromGrouperTextBox.Text = "C:\\togrouper.txt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kdrsDataGridViewTextBoxColumn,
            this.klsrsDataGridViewTextBoxColumn,
            this.normDataGridViewTextBoxColumn,
            this.klsrawatDataGridViewTextBoxColumn,
            this.biayaDataGridViewTextBoxColumn,
            this.recidDataGridViewTextBoxColumn,
            this.jnsrawatDataGridViewTextBoxColumn,
            this.tglmskDataGridViewTextBoxColumn,
            this.tglklrDataGridViewTextBoxColumn,
            this.losDataGridViewTextBoxColumn,
            this.tgllhrDataGridViewTextBoxColumn,
            this.umurThnDataGridViewTextBoxColumn,
            this.umurHariDataGridViewTextBoxColumn,
            this.jKDataGridViewTextBoxColumn,
            this.caraPlgDataGridViewTextBoxColumn,
            this.beratDataGridViewTextBoxColumn,
            this.dutamaDataGridViewTextBoxColumn,
            this.d1DataGridViewTextBoxColumn,
            this.d2DataGridViewTextBoxColumn,
            this.d3DataGridViewTextBoxColumn,
            this.d4DataGridViewTextBoxColumn,
            this.p1DataGridViewTextBoxColumn,
            this.p2DataGridViewTextBoxColumn,
            this.p3DataGridViewTextBoxColumn,
            this.p4DataGridViewTextBoxColumn,
            this.p5DataGridViewTextBoxColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            this.dataGridView1.DataSource = this.inadrgBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(3, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(733, 289);
            this.dataGridView1.TabIndex = 8;
            // 
            // kdrsDataGridViewTextBoxColumn
            // 
            this.kdrsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kdrsDataGridViewTextBoxColumn.DataPropertyName = "Kdrs";
            this.kdrsDataGridViewTextBoxColumn.HeaderText = "Kdrs";
            this.kdrsDataGridViewTextBoxColumn.Name = "kdrsDataGridViewTextBoxColumn";
            this.kdrsDataGridViewTextBoxColumn.ReadOnly = true;
            this.kdrsDataGridViewTextBoxColumn.Width = 53;
            // 
            // klsrsDataGridViewTextBoxColumn
            // 
            this.klsrsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.klsrsDataGridViewTextBoxColumn.DataPropertyName = "Klsrs";
            this.klsrsDataGridViewTextBoxColumn.HeaderText = "Klsrs";
            this.klsrsDataGridViewTextBoxColumn.Name = "klsrsDataGridViewTextBoxColumn";
            this.klsrsDataGridViewTextBoxColumn.ReadOnly = true;
            this.klsrsDataGridViewTextBoxColumn.Width = 54;
            // 
            // normDataGridViewTextBoxColumn
            // 
            this.normDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.normDataGridViewTextBoxColumn.DataPropertyName = "Norm";
            this.normDataGridViewTextBoxColumn.HeaderText = "Norm";
            this.normDataGridViewTextBoxColumn.Name = "normDataGridViewTextBoxColumn";
            this.normDataGridViewTextBoxColumn.ReadOnly = true;
            this.normDataGridViewTextBoxColumn.Width = 57;
            // 
            // klsrawatDataGridViewTextBoxColumn
            // 
            this.klsrawatDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.klsrawatDataGridViewTextBoxColumn.DataPropertyName = "Klsrawat";
            this.klsrawatDataGridViewTextBoxColumn.HeaderText = "Klsrawat";
            this.klsrawatDataGridViewTextBoxColumn.Name = "klsrawatDataGridViewTextBoxColumn";
            this.klsrawatDataGridViewTextBoxColumn.ReadOnly = true;
            this.klsrawatDataGridViewTextBoxColumn.Width = 72;
            // 
            // biayaDataGridViewTextBoxColumn
            // 
            this.biayaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.biayaDataGridViewTextBoxColumn.DataPropertyName = "Biaya";
            this.biayaDataGridViewTextBoxColumn.HeaderText = "Biaya";
            this.biayaDataGridViewTextBoxColumn.Name = "biayaDataGridViewTextBoxColumn";
            this.biayaDataGridViewTextBoxColumn.ReadOnly = true;
            this.biayaDataGridViewTextBoxColumn.Width = 58;
            // 
            // recidDataGridViewTextBoxColumn
            // 
            this.recidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.recidDataGridViewTextBoxColumn.DataPropertyName = "Recid";
            this.recidDataGridViewTextBoxColumn.HeaderText = "Recid";
            this.recidDataGridViewTextBoxColumn.Name = "recidDataGridViewTextBoxColumn";
            this.recidDataGridViewTextBoxColumn.ReadOnly = true;
            this.recidDataGridViewTextBoxColumn.Width = 60;
            // 
            // jnsrawatDataGridViewTextBoxColumn
            // 
            this.jnsrawatDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.jnsrawatDataGridViewTextBoxColumn.DataPropertyName = "Jnsrawat";
            this.jnsrawatDataGridViewTextBoxColumn.HeaderText = "Jnsrawat";
            this.jnsrawatDataGridViewTextBoxColumn.Name = "jnsrawatDataGridViewTextBoxColumn";
            this.jnsrawatDataGridViewTextBoxColumn.ReadOnly = true;
            this.jnsrawatDataGridViewTextBoxColumn.Width = 74;
            // 
            // tglmskDataGridViewTextBoxColumn
            // 
            this.tglmskDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tglmskDataGridViewTextBoxColumn.DataPropertyName = "Tglmsk";
            this.tglmskDataGridViewTextBoxColumn.HeaderText = "Tglmsk";
            this.tglmskDataGridViewTextBoxColumn.Name = "tglmskDataGridViewTextBoxColumn";
            this.tglmskDataGridViewTextBoxColumn.ReadOnly = true;
            this.tglmskDataGridViewTextBoxColumn.Width = 66;
            // 
            // tglklrDataGridViewTextBoxColumn
            // 
            this.tglklrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tglklrDataGridViewTextBoxColumn.DataPropertyName = "Tglklr";
            this.tglklrDataGridViewTextBoxColumn.HeaderText = "Tglklr";
            this.tglklrDataGridViewTextBoxColumn.Name = "tglklrDataGridViewTextBoxColumn";
            this.tglklrDataGridViewTextBoxColumn.ReadOnly = true;
            this.tglklrDataGridViewTextBoxColumn.Width = 58;
            // 
            // losDataGridViewTextBoxColumn
            // 
            this.losDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.losDataGridViewTextBoxColumn.DataPropertyName = "Los";
            this.losDataGridViewTextBoxColumn.HeaderText = "Los";
            this.losDataGridViewTextBoxColumn.Name = "losDataGridViewTextBoxColumn";
            this.losDataGridViewTextBoxColumn.ReadOnly = true;
            this.losDataGridViewTextBoxColumn.Width = 49;
            // 
            // tgllhrDataGridViewTextBoxColumn
            // 
            this.tgllhrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tgllhrDataGridViewTextBoxColumn.DataPropertyName = "Tgllhr";
            this.tgllhrDataGridViewTextBoxColumn.HeaderText = "Tgllhr";
            this.tgllhrDataGridViewTextBoxColumn.Name = "tgllhrDataGridViewTextBoxColumn";
            this.tgllhrDataGridViewTextBoxColumn.ReadOnly = true;
            this.tgllhrDataGridViewTextBoxColumn.Width = 58;
            // 
            // umurThnDataGridViewTextBoxColumn
            // 
            this.umurThnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.umurThnDataGridViewTextBoxColumn.DataPropertyName = "UmurThn";
            this.umurThnDataGridViewTextBoxColumn.HeaderText = "UmurThn";
            this.umurThnDataGridViewTextBoxColumn.Name = "umurThnDataGridViewTextBoxColumn";
            this.umurThnDataGridViewTextBoxColumn.ReadOnly = true;
            this.umurThnDataGridViewTextBoxColumn.Width = 76;
            // 
            // umurHariDataGridViewTextBoxColumn
            // 
            this.umurHariDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.umurHariDataGridViewTextBoxColumn.DataPropertyName = "UmurHari";
            this.umurHariDataGridViewTextBoxColumn.HeaderText = "UmurHari";
            this.umurHariDataGridViewTextBoxColumn.Name = "umurHariDataGridViewTextBoxColumn";
            this.umurHariDataGridViewTextBoxColumn.ReadOnly = true;
            this.umurHariDataGridViewTextBoxColumn.Width = 76;
            // 
            // jKDataGridViewTextBoxColumn
            // 
            this.jKDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.jKDataGridViewTextBoxColumn.DataPropertyName = "JK";
            this.jKDataGridViewTextBoxColumn.HeaderText = "JK";
            this.jKDataGridViewTextBoxColumn.Name = "jKDataGridViewTextBoxColumn";
            this.jKDataGridViewTextBoxColumn.ReadOnly = true;
            this.jKDataGridViewTextBoxColumn.Width = 44;
            // 
            // caraPlgDataGridViewTextBoxColumn
            // 
            this.caraPlgDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.caraPlgDataGridViewTextBoxColumn.DataPropertyName = "CaraPlg";
            this.caraPlgDataGridViewTextBoxColumn.HeaderText = "CaraPlg";
            this.caraPlgDataGridViewTextBoxColumn.Name = "caraPlgDataGridViewTextBoxColumn";
            this.caraPlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.caraPlgDataGridViewTextBoxColumn.Width = 69;
            // 
            // beratDataGridViewTextBoxColumn
            // 
            this.beratDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.beratDataGridViewTextBoxColumn.DataPropertyName = "Berat";
            this.beratDataGridViewTextBoxColumn.HeaderText = "Berat";
            this.beratDataGridViewTextBoxColumn.Name = "beratDataGridViewTextBoxColumn";
            this.beratDataGridViewTextBoxColumn.ReadOnly = true;
            this.beratDataGridViewTextBoxColumn.Width = 57;
            // 
            // dutamaDataGridViewTextBoxColumn
            // 
            this.dutamaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dutamaDataGridViewTextBoxColumn.DataPropertyName = "Dutama";
            this.dutamaDataGridViewTextBoxColumn.HeaderText = "Dutama";
            this.dutamaDataGridViewTextBoxColumn.Name = "dutamaDataGridViewTextBoxColumn";
            this.dutamaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dutamaDataGridViewTextBoxColumn.Width = 69;
            // 
            // d1DataGridViewTextBoxColumn
            // 
            this.d1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.d1DataGridViewTextBoxColumn.DataPropertyName = "D1";
            this.d1DataGridViewTextBoxColumn.HeaderText = "D1";
            this.d1DataGridViewTextBoxColumn.Name = "d1DataGridViewTextBoxColumn";
            this.d1DataGridViewTextBoxColumn.ReadOnly = true;
            this.d1DataGridViewTextBoxColumn.Width = 46;
            // 
            // d2DataGridViewTextBoxColumn
            // 
            this.d2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.d2DataGridViewTextBoxColumn.DataPropertyName = "D2";
            this.d2DataGridViewTextBoxColumn.HeaderText = "D2";
            this.d2DataGridViewTextBoxColumn.Name = "d2DataGridViewTextBoxColumn";
            this.d2DataGridViewTextBoxColumn.ReadOnly = true;
            this.d2DataGridViewTextBoxColumn.Width = 46;
            // 
            // d3DataGridViewTextBoxColumn
            // 
            this.d3DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.d3DataGridViewTextBoxColumn.DataPropertyName = "D3";
            this.d3DataGridViewTextBoxColumn.HeaderText = "D3";
            this.d3DataGridViewTextBoxColumn.Name = "d3DataGridViewTextBoxColumn";
            this.d3DataGridViewTextBoxColumn.ReadOnly = true;
            this.d3DataGridViewTextBoxColumn.Width = 46;
            // 
            // d4DataGridViewTextBoxColumn
            // 
            this.d4DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.d4DataGridViewTextBoxColumn.DataPropertyName = "D4";
            this.d4DataGridViewTextBoxColumn.HeaderText = "D4";
            this.d4DataGridViewTextBoxColumn.Name = "d4DataGridViewTextBoxColumn";
            this.d4DataGridViewTextBoxColumn.ReadOnly = true;
            this.d4DataGridViewTextBoxColumn.Width = 46;
            // 
            // p1DataGridViewTextBoxColumn
            // 
            this.p1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.p1DataGridViewTextBoxColumn.DataPropertyName = "P1";
            this.p1DataGridViewTextBoxColumn.HeaderText = "P1";
            this.p1DataGridViewTextBoxColumn.Name = "p1DataGridViewTextBoxColumn";
            this.p1DataGridViewTextBoxColumn.ReadOnly = true;
            this.p1DataGridViewTextBoxColumn.Width = 45;
            // 
            // p2DataGridViewTextBoxColumn
            // 
            this.p2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.p2DataGridViewTextBoxColumn.DataPropertyName = "P2";
            this.p2DataGridViewTextBoxColumn.HeaderText = "P2";
            this.p2DataGridViewTextBoxColumn.Name = "p2DataGridViewTextBoxColumn";
            this.p2DataGridViewTextBoxColumn.ReadOnly = true;
            this.p2DataGridViewTextBoxColumn.Width = 45;
            // 
            // p3DataGridViewTextBoxColumn
            // 
            this.p3DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.p3DataGridViewTextBoxColumn.DataPropertyName = "P3";
            this.p3DataGridViewTextBoxColumn.HeaderText = "P3";
            this.p3DataGridViewTextBoxColumn.Name = "p3DataGridViewTextBoxColumn";
            this.p3DataGridViewTextBoxColumn.ReadOnly = true;
            this.p3DataGridViewTextBoxColumn.Width = 45;
            // 
            // p4DataGridViewTextBoxColumn
            // 
            this.p4DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.p4DataGridViewTextBoxColumn.DataPropertyName = "P4";
            this.p4DataGridViewTextBoxColumn.HeaderText = "P4";
            this.p4DataGridViewTextBoxColumn.Name = "p4DataGridViewTextBoxColumn";
            this.p4DataGridViewTextBoxColumn.ReadOnly = true;
            this.p4DataGridViewTextBoxColumn.Width = 45;
            // 
            // p5DataGridViewTextBoxColumn
            // 
            this.p5DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.p5DataGridViewTextBoxColumn.DataPropertyName = "P5";
            this.p5DataGridViewTextBoxColumn.HeaderText = "P5";
            this.p5DataGridViewTextBoxColumn.Name = "p5DataGridViewTextBoxColumn";
            this.p5DataGridViewTextBoxColumn.ReadOnly = true;
            this.p5DataGridViewTextBoxColumn.Width = 45;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressLabel);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(339, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 34);
            this.panel2.TabIndex = 9;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(75, 10);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(128, 13);
            this.progressLabel.TabIndex = 0;
            this.progressLabel.Text = "Mohon pilih jarak tanggal.";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(-1, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Export";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.comboBoxCustomer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(339, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 30);
            this.panel3.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(130, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Preview";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DataSource = this.cUSTOMERBindingSource;
            this.comboBoxCustomer.DisplayMember = "CUSTOMER";
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(3, 3);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCustomer.TabIndex = 8;
            this.comboBoxCustomer.Tag = "";
            this.comboBoxCustomer.ValueMember = "KD_CUSTOMER";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(742, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(37, 23);
            this.button7.TabIndex = 12;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 3);
            this.panel7.Controls.Add(this.exportGridKeExcelProgressBar);
            this.panel7.Controls.Add(this.exportGridKeExcelButton);
            this.panel7.Controls.Add(this.selanjutnyaButton);
            this.panel7.Controls.Add(this.sebelumnyaButton);
            this.panel7.Location = new System.Drawing.Point(3, 400);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(733, 25);
            this.panel7.TabIndex = 14;
            // 
            // exportGridKeExcelProgressBar
            // 
            this.exportGridKeExcelProgressBar.Enabled = false;
            this.exportGridKeExcelProgressBar.Location = new System.Drawing.Point(404, 0);
            this.exportGridKeExcelProgressBar.Name = "exportGridKeExcelProgressBar";
            this.exportGridKeExcelProgressBar.Size = new System.Drawing.Size(220, 23);
            this.exportGridKeExcelProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.exportGridKeExcelProgressBar.TabIndex = 15;
            this.exportGridKeExcelProgressBar.Visible = false;
            // 
            // exportGridKeExcelButton
            // 
            this.exportGridKeExcelButton.Enabled = false;
            this.exportGridKeExcelButton.Location = new System.Drawing.Point(296, 1);
            this.exportGridKeExcelButton.Name = "exportGridKeExcelButton";
            this.exportGridKeExcelButton.Size = new System.Drawing.Size(102, 24);
            this.exportGridKeExcelButton.TabIndex = 14;
            this.exportGridKeExcelButton.Text = "Export ke Excel";
            this.exportGridKeExcelButton.UseVisualStyleBackColor = true;
            this.exportGridKeExcelButton.Click += new System.EventHandler(this.exportGridKeExcelButton_Click);
            // 
            // selanjutnyaButton
            // 
            this.selanjutnyaButton.Location = new System.Drawing.Point(630, 3);
            this.selanjutnyaButton.Name = "selanjutnyaButton";
            this.selanjutnyaButton.Size = new System.Drawing.Size(100, 23);
            this.selanjutnyaButton.TabIndex = 11;
            this.selanjutnyaButton.Text = "10 selanjutnya ->";
            this.selanjutnyaButton.UseVisualStyleBackColor = true;
            this.selanjutnyaButton.Click += new System.EventHandler(this.selanjutnyaButton_Click);
            // 
            // sebelumnyaButton
            // 
            this.sebelumnyaButton.Enabled = false;
            this.sebelumnyaButton.Location = new System.Drawing.Point(3, 3);
            this.sebelumnyaButton.Name = "sebelumnyaButton";
            this.sebelumnyaButton.Size = new System.Drawing.Size(102, 23);
            this.sebelumnyaButton.TabIndex = 13;
            this.sebelumnyaButton.Text = "<- 10 sebelumnya";
            this.sebelumnyaButton.UseVisualStyleBackColor = true;
            this.sebelumnyaButton.Click += new System.EventHandler(this.sebelumnyaButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(756, 466);
            this.tabControl1.TabIndex = 3;
            // 
            // ExporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 505);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ExporterForm";
            this.Text = "INADRG Exporter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExporterForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.inadrgBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSKUPANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOMERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataset)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource inadrgBindingSource;
        private RSKUPANGDataSet rSKUPANGDataSet;
        private inadrgTableAdapter inadrgTableAdapter;
        public System.ComponentModel.BackgroundWorker exportWorker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.ComponentModel.BackgroundWorker exportkeExcelWorker;
        private CustomerDataset customerDataset;
        private System.Windows.Forms.BindingSource cUSTOMERBindingSource;
        private INADRGExporter.CustomerDatasetTableAdapters.CUSTOMERTableAdapter cUSTOMERTableAdapter;
        public System.ComponentModel.BackgroundWorker exportGridKeExcelWorker;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker untilDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox fromGrouperTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdrsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn klsrsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn normDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn klsrawatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn biayaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jnsrawatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglmskDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglklrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn losDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgllhrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn umurThnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn umurHariDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caraPlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beratDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dutamaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn d1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn d2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn d3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn d4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn p1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn p3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn p4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn p5DataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ProgressBar exportGridKeExcelProgressBar;
        private System.Windows.Forms.Button exportGridKeExcelButton;
        private System.Windows.Forms.Button selanjutnyaButton;
        private System.Windows.Forms.Button sebelumnyaButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutINADRGExporterToolStripMenuItem;
    }
}

