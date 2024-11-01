namespace BTLON_NHOM6
{
    partial class FrmRanking
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
            this.DGVranking = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLeagueId = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVranking)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVranking
            // 
            this.DGVranking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVranking.Location = new System.Drawing.Point(12, 161);
            this.DGVranking.Name = "DGVranking";
            this.DGVranking.RowHeadersWidth = 51;
            this.DGVranking.RowTemplate.Height = 24;
            this.DGVranking.Size = new System.Drawing.Size(776, 150);
            this.DGVranking.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "BẢNG XẾP HẠNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã giải đấu";
            // 
            // cboLeagueId
            // 
            this.cboLeagueId.FormattingEnabled = true;
            this.cboLeagueId.Location = new System.Drawing.Point(182, 103);
            this.cboLeagueId.Name = "cboLeagueId";
            this.cboLeagueId.Size = new System.Drawing.Size(121, 24);
            this.cboLeagueId.TabIndex = 3;
            this.cboLeagueId.SelectedIndexChanged += new System.EventHandler(this.cboLeagueId_SelectedIndexChanged);
            // 
            // FrmRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboLeagueId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVranking);
            this.Name = "FrmRanking";
            this.Text = "FrmRanking";
            this.Load += new System.EventHandler(this.FrmRanking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVranking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVranking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLeagueId;
    }
}