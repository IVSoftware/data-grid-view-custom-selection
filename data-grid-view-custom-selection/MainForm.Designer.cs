namespace data_grid_view_custom_selection
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDaten = new DataGridViewEx();
            this.buttonDbUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaten)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDaten
            // 
            this.dgvDaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDaten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaten.Location = new System.Drawing.Point(13, 8);
            this.dgvDaten.Name = "dgvDaten";
            this.dgvDaten.RowHeadersWidth = 62;
            this.dgvDaten.RowTemplate.Height = 33;
            this.dgvDaten.Size = new System.Drawing.Size(543, 296);
            this.dgvDaten.TabIndex = 0;
            // 
            // buttonDbUpdate
            // 
            this.buttonDbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDbUpdate.Location = new System.Drawing.Point(444, 309);
            this.buttonDbUpdate.Name = "buttonDbUpdate";
            this.buttonDbUpdate.Size = new System.Drawing.Size(112, 34);
            this.buttonDbUpdate.TabIndex = 1;
            this.buttonDbUpdate.Text = "Db Update";
            this.buttonDbUpdate.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 344);
            this.Controls.Add(this.buttonDbUpdate);
            this.Controls.Add(this.dgvDaten);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaten)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewEx dgvDaten;
        private System.Windows.Forms.Button buttonDbUpdate;
    }
}
