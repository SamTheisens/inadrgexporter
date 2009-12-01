﻿using inadrgTableAdapter=INADRGExporter.RSKUPANGDataSetTableAdapters.inadrgTableAdapter;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExporterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutINADRGExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportkeExcelWorker = new System.ComponentModel.BackgroundWorker();
            this.cUSTOMERTableAdapter = new INADRGExporter.CustomerDatasetTableAdapters.CUSTOMERTableAdapter();
            this.exportGridKeExcelWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelYangSalahToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.reportIndividualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportRekapitulasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textfileUntukExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
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
            this.Inadrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deskripsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dokter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaRs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.browseFromGrouperButton = new System.Windows.Forms.Button();
            this.fromGrouperBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.browseToExcelButton = new System.Windows.Forms.Button();
            this.toExcelTextBox = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toGrouperTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.untilDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.exporterFormBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalRecords = new System.Windows.Forms.ToolStripStatusLabel();
            this.exportGridKeExcelProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.exporterFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.inadrgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSKUPANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOMERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataset)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exporterFormBindingSource1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exporterFormBindingSource)).BeginInit();
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
            this.exportWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.exportWorker_RunWorkerCompleted);
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
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(5);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(815, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.settingsToolStripMenuItem});
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
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.settingsToolStripMenuItem.Text = "S&ettings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            this.exportkeExcelWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.exportGridKeExcelWorker_RunWorkerCompleted);
            this.exportkeExcelWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.exportWorker_ProgressChanged);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 26);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(815, 484);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::INADRGExporter.Properties.Resources._3M;
            this.pictureBox2.Location = new System.Drawing.Point(102, 115);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(282, 36);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 3);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(6, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(803, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.keExcelToolStripMenuItem,
            this.excelYangSalahToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(62, 22);
            this.toolStripDropDownButton2.Text = "Verifikasi";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Image = global::INADRGExporter.Properties.Resources.kasirrwj;
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.databaseToolStripMenuItem.Text = "&Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // keExcelToolStripMenuItem
            // 
            this.keExcelToolStripMenuItem.Image = global::INADRGExporter.Properties.Resources.excel;
            this.keExcelToolStripMenuItem.Name = "keExcelToolStripMenuItem";
            this.keExcelToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.keExcelToolStripMenuItem.Text = "Excel S&emuah";
            this.keExcelToolStripMenuItem.Click += new System.EventHandler(this.keExcelToolStripMenuItem_Click);
            // 
            // excelYangSalahToolStripMenuItem
            // 
            this.excelYangSalahToolStripMenuItem.Image = global::INADRGExporter.Properties.Resources.excel_salah;
            this.excelYangSalahToolStripMenuItem.Name = "excelYangSalahToolStripMenuItem";
            this.excelYangSalahToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.excelYangSalahToolStripMenuItem.Text = "Excel Yang S&alah";
            this.excelYangSalahToolStripMenuItem.Click += new System.EventHandler(this.excelYangSalahToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportIndividualToolStripMenuItem,
            this.reportRekapitulasiToolStripMenuItem,
            this.textfileUntukExcelToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::INADRGExporter.Properties.Resources.excel;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripDropDownButton1.Text = "Export";
            // 
            // reportIndividualToolStripMenuItem
            // 
            this.reportIndividualToolStripMenuItem.Image = global::INADRGExporter.Properties.Resources.crystal;
            this.reportIndividualToolStripMenuItem.Name = "reportIndividualToolStripMenuItem";
            this.reportIndividualToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.reportIndividualToolStripMenuItem.Text = "Report &Individual";
            this.reportIndividualToolStripMenuItem.Click += new System.EventHandler(this.reportIndividualToolStripMenuItem_Click);
            // 
            // reportRekapitulasiToolStripMenuItem
            // 
            this.reportRekapitulasiToolStripMenuItem.Image = global::INADRGExporter.Properties.Resources.crystal;
            this.reportRekapitulasiToolStripMenuItem.Name = "reportRekapitulasiToolStripMenuItem";
            this.reportRekapitulasiToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.reportRekapitulasiToolStripMenuItem.Text = "Report &Rekapitulasi";
            this.reportRekapitulasiToolStripMenuItem.Click += new System.EventHandler(this.reportRekapitulasiToolStripMenuItem_Click);
            // 
            // textfileUntukExcelToolStripMenuItem
            // 
            this.textfileUntukExcelToolStripMenuItem.Image = global::INADRGExporter.Properties.Resources.excel;
            this.textfileUntukExcelToolStripMenuItem.Name = "textfileUntukExcelToolStripMenuItem";
            this.textfileUntukExcelToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.textfileUntukExcelToolStripMenuItem.Text = "Textfile untuk E&xcel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Masa";
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
            this.p5DataGridViewTextBoxColumn,
            this.Inadrg,
            this.Tarif,
            this.Deskripsi,
            this.ALOS,
            this.Nama,
            this.Dokter,
            this.SKP,
            this.NamaRs});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            this.dataGridView1.DataSource = this.inadrgBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(9, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.ErrorText = "Error";
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(797, 219);
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
            // Inadrg
            // 
            this.Inadrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Inadrg.DataPropertyName = "Inadrg";
            this.Inadrg.HeaderText = "Inadrg";
            this.Inadrg.Name = "Inadrg";
            this.Inadrg.ReadOnly = true;
            this.Inadrg.Width = 62;
            // 
            // Tarif
            // 
            this.Tarif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tarif.DataPropertyName = "Tarif";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.- IRD";
            this.Tarif.DefaultCellStyle = dataGridViewCellStyle3;
            this.Tarif.HeaderText = "Tarif";
            this.Tarif.Name = "Tarif";
            this.Tarif.ReadOnly = true;
            this.Tarif.Width = 53;
            // 
            // Deskripsi
            // 
            this.Deskripsi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Deskripsi.DataPropertyName = "Deskripsi";
            this.Deskripsi.HeaderText = "Deskripsi";
            this.Deskripsi.Name = "Deskripsi";
            this.Deskripsi.ReadOnly = true;
            this.Deskripsi.Width = 75;
            // 
            // ALOS
            // 
            this.ALOS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ALOS.DataPropertyName = "ALOS";
            this.ALOS.HeaderText = "ALOS";
            this.ALOS.Name = "ALOS";
            this.ALOS.ReadOnly = true;
            this.ALOS.Width = 60;
            // 
            // Nama
            // 
            this.Nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 60;
            // 
            // Dokter
            // 
            this.Dokter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dokter.DataPropertyName = "Dokter";
            this.Dokter.HeaderText = "Dokter";
            this.Dokter.Name = "Dokter";
            this.Dokter.ReadOnly = true;
            this.Dokter.Width = 64;
            // 
            // SKP
            // 
            this.SKP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SKP.DataPropertyName = "SKP";
            this.SKP.HeaderText = "SKP";
            this.SKP.Name = "SKP";
            this.SKP.ReadOnly = true;
            this.SKP.Width = 53;
            // 
            // NamaRs
            // 
            this.NamaRs.DataPropertyName = "NamaRs";
            this.NamaRs.HeaderText = "NamaRs";
            this.NamaRs.Name = "NamaRs";
            this.NamaRs.ReadOnly = true;
            // 
            // panel7
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 3);
            this.panel7.Controls.Add(this.bindingNavigator1);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(9, 431);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(797, 24);
            this.panel7.TabIndex = 14;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(797, 25);
            this.bindingNavigator1.TabIndex = 15;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "label6";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.browseFromGrouperButton);
            this.panel2.Controls.Add(this.fromGrouperBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(390, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 36);
            this.panel2.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(290, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Group";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // browseFromGrouperButton
            // 
            this.browseFromGrouperButton.Location = new System.Drawing.Point(209, 0);
            this.browseFromGrouperButton.Name = "browseFromGrouperButton";
            this.browseFromGrouperButton.Size = new System.Drawing.Size(75, 23);
            this.browseFromGrouperButton.TabIndex = 19;
            this.browseFromGrouperButton.Text = "Browse...";
            this.browseFromGrouperButton.UseVisualStyleBackColor = true;
            this.browseFromGrouperButton.Click += new System.EventHandler(this.browseFromGrouperButton_Click);
            // 
            // fromGrouperBox
            // 
            this.fromGrouperBox.Location = new System.Drawing.Point(3, 3);
            this.fromGrouperBox.Name = "fromGrouperBox";
            this.fromGrouperBox.Size = new System.Drawing.Size(200, 20);
            this.fromGrouperBox.TabIndex = 18;
            this.fromGrouperBox.Text = "C:\\darigrouper.txt";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Location = new System.Drawing.Point(102, 157);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(282, 43);
            this.panel4.TabIndex = 15;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::INADRGExporter.Properties.Resources.excel;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(282, 43);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.browseToExcelButton);
            this.panel5.Controls.Add(this.toExcelTextBox);
            this.panel5.Controls.Add(this.importButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(390, 157);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(416, 43);
            this.panel5.TabIndex = 17;
            // 
            // browseToExcelButton
            // 
            this.browseToExcelButton.Location = new System.Drawing.Point(209, 3);
            this.browseToExcelButton.Name = "browseToExcelButton";
            this.browseToExcelButton.Size = new System.Drawing.Size(75, 23);
            this.browseToExcelButton.TabIndex = 1;
            this.browseToExcelButton.Text = "Browse...";
            this.browseToExcelButton.UseVisualStyleBackColor = true;
            this.browseToExcelButton.Click += new System.EventHandler(this.browseInputButton_Click);
            // 
            // toExcelTextBox
            // 
            this.toExcelTextBox.Location = new System.Drawing.Point(3, 2);
            this.toExcelTextBox.Name = "toExcelTextBox";
            this.toExcelTextBox.Size = new System.Drawing.Size(200, 20);
            this.toExcelTextBox.TabIndex = 0;
            this.toExcelTextBox.Text = "C:\\keexcel.txt";
            // 
            // importButton
            // 
            this.importButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.Location = new System.Drawing.Point(290, 2);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(74, 24);
            this.importButton.TabIndex = 17;
            this.importButton.Text = "Export";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.toGrouperTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(390, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 39);
            this.panel1.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(290, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Export";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // toGrouperTextBox
            // 
            this.toGrouperTextBox.Location = new System.Drawing.Point(3, 0);
            this.toGrouperTextBox.Name = "toGrouperTextBox";
            this.toGrouperTextBox.Size = new System.Drawing.Size(200, 20);
            this.toGrouperTextBox.TabIndex = 0;
            this.toGrouperTextBox.Text = "C:\\kegrouper.txt";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::INADRGExporter.Properties.Resources.kasirrwj;
            this.pictureBox1.Location = new System.Drawing.Point(102, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 39);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "2) Ke Grouper";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "1) Dari Database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 16;
            this.label4.Tag = "I";
            this.label4.Text = "3) Ke Excel";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.comboBoxCustomer);
            this.panel3.Controls.Add(this.untilDateTimePicker);
            this.panel3.Location = new System.Drawing.Point(390, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(416, 30);
            this.panel3.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Sampai";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DataSource = this.cUSTOMERBindingSource;
            this.comboBoxCustomer.DisplayMember = "CUSTOMER";
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(290, 3);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCustomer.TabIndex = 8;
            this.comboBoxCustomer.Tag = "";
            this.comboBoxCustomer.ValueMember = "KD_CUSTOMER";
            // 
            // untilDateTimePicker
            // 
            this.untilDateTimePicker.Location = new System.Drawing.Point(51, 3);
            this.untilDateTimePicker.Name = "untilDateTimePicker";
            this.untilDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.untilDateTimePicker.TabIndex = 0;
            this.untilDateTimePicker.ValueChanged += new System.EventHandler(this.untilDateTimePicker_ValueChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.fromDateTimePicker);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(102, 34);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(282, 30);
            this.panel6.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dari";
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.CustomFormat = "";
            this.fromDateTimePicker.Location = new System.Drawing.Point(35, 3);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromDateTimePicker.TabIndex = 1;
            this.fromDateTimePicker.ValueChanged += new System.EventHandler(this.fromDateTimePicker_ValueChanged);
            // 
            // exporterFormBindingSource1
            // 
            this.exporterFormBindingSource1.DataSource = typeof(INADRGExporter.ExporterForm);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.totalRecords,
            this.exportGridKeExcelProgressBar});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(1);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(815, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.TabStop = true;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel.Size = new System.Drawing.Size(205, 13);
            this.toolStripStatusLabel.Text = "Untuk berubah pengaturan, click Settings";
            // 
            // totalRecords
            // 
            this.totalRecords.Name = "totalRecords";
            this.totalRecords.Size = new System.Drawing.Size(0, 0);
            // 
            // exportGridKeExcelProgressBar
            // 
            this.exportGridKeExcelProgressBar.Name = "exportGridKeExcelProgressBar";
            this.exportGridKeExcelProgressBar.Size = new System.Drawing.Size(100, 16);
            this.exportGridKeExcelProgressBar.Visible = false;
            // 
            // exporterFormBindingSource
            // 
            this.exporterFormBindingSource.DataSource = typeof(INADRGExporter.ExporterForm);
            // 
            // ExporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(815, 508);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exporterFormBindingSource1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exporterFormBindingSource)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker untilDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox toGrouperTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutINADRGExporterToolStripMenuItem;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar exportGridKeExcelProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button browseToExcelButton;
        private System.Windows.Forms.TextBox toExcelTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button browseFromGrouperButton;
        private System.Windows.Forms.TextBox fromGrouperBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.BindingSource exporterFormBindingSource;
        private System.Windows.Forms.BindingSource exporterFormBindingSource1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem reportIndividualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportRekapitulasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textfileUntukExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelYangSalahToolStripMenuItem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Inadrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deskripsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dokter;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaRs;
        private System.Windows.Forms.ToolStripStatusLabel totalRecords;
    }
}
