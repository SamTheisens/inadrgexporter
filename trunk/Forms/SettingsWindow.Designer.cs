namespace InadrgExporter.Forms
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.settingsPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.rSKUPANGDataSet = new InadrgExporter.RSKUPANGDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.rSKUPANGDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsPropertyGrid
            // 
            this.settingsPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.settingsPropertyGrid.Name = "settingsPropertyGrid";
            this.settingsPropertyGrid.Size = new System.Drawing.Size(612, 296);
            this.settingsPropertyGrid.TabIndex = 0;
            // 
            // rSKUPANGDataSet
            // 
            this.rSKUPANGDataSet.DataSetName = "RSKUPANGDataSet";
            this.rSKUPANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 296);
            this.Controls.Add(this.settingsPropertyGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rSKUPANGDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RSKUPANGDataSet rSKUPANGDataSet;
        private System.Windows.Forms.PropertyGrid settingsPropertyGrid;
    }
}