namespace APPInterfaceSAD.Forms
{
    partial class FormInspeções
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
            this.labelInspMenu = new System.Windows.Forms.Label();
            this.labelInspVeiculos = new System.Windows.Forms.Label();
            this.labelInspMat = new System.Windows.Forms.Label();
            this.labeInspData = new System.Windows.Forms.Label();
            this.buttonRegInsp = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxInspVehi = new System.Windows.Forms.ComboBox();
            this.comboBoxInspMat = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInspMenu
            // 
            this.labelInspMenu.AutoSize = true;
            this.labelInspMenu.Location = new System.Drawing.Point(189, 56);
            this.labelInspMenu.Name = "labelInspMenu";
            this.labelInspMenu.Size = new System.Drawing.Size(70, 16);
            this.labelInspMenu.TabIndex = 0;
            this.labelInspMenu.Text = "Inspeções";
            // 
            // labelInspVeiculos
            // 
            this.labelInspVeiculos.AutoSize = true;
            this.labelInspVeiculos.Location = new System.Drawing.Point(126, 136);
            this.labelInspVeiculos.Name = "labelInspVeiculos";
            this.labelInspVeiculos.Size = new System.Drawing.Size(52, 16);
            this.labelInspVeiculos.TabIndex = 1;
            this.labelInspVeiculos.Text = "Veiculo";
            // 
            // labelInspMat
            // 
            this.labelInspMat.AutoSize = true;
            this.labelInspMat.Location = new System.Drawing.Point(129, 184);
            this.labelInspMat.Name = "labelInspMat";
            this.labelInspMat.Size = new System.Drawing.Size(55, 16);
            this.labelInspMat.TabIndex = 2;
            this.labelInspMat.Text = "Material";
            // 
            // labeInspData
            // 
            this.labeInspData.AutoSize = true;
            this.labeInspData.Location = new System.Drawing.Point(129, 276);
            this.labeInspData.Name = "labeInspData";
            this.labeInspData.Size = new System.Drawing.Size(36, 16);
            this.labeInspData.TabIndex = 4;
            this.labeInspData.Text = "Data";
            // 
            // buttonRegInsp
            // 
            this.buttonRegInsp.Location = new System.Drawing.Point(162, 341);
            this.buttonRegInsp.Name = "buttonRegInsp";
            this.buttonRegInsp.Size = new System.Drawing.Size(182, 23);
            this.buttonRegInsp.TabIndex = 5;
            this.buttonRegInsp.Text = "Registar Inspeção";
            this.buttonRegInsp.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 465);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(986, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // comboBoxInspVehi
            // 
            this.comboBoxInspVehi.FormattingEnabled = true;
            this.comboBoxInspVehi.Location = new System.Drawing.Point(256, 136);
            this.comboBoxInspVehi.Name = "comboBoxInspVehi";
            this.comboBoxInspVehi.Size = new System.Drawing.Size(121, 24);
            this.comboBoxInspVehi.TabIndex = 7;
            // 
            // comboBoxInspMat
            // 
            this.comboBoxInspMat.FormattingEnabled = true;
            this.comboBoxInspMat.Location = new System.Drawing.Point(256, 184);
            this.comboBoxInspMat.Name = "comboBoxInspMat";
            this.comboBoxInspMat.Size = new System.Drawing.Size(121, 24);
            this.comboBoxInspMat.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(256, 276);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // FormInspeções
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 731);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxInspMat);
            this.Controls.Add(this.comboBoxInspVehi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonRegInsp);
            this.Controls.Add(this.labeInspData);
            this.Controls.Add(this.labelInspMat);
            this.Controls.Add(this.labelInspVeiculos);
            this.Controls.Add(this.labelInspMenu);
            this.Name = "FormInspeções";
            this.Text = "FormInspeções";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInspMenu;
        private System.Windows.Forms.Label labelInspVeiculos;
        private System.Windows.Forms.Label labelInspMat;
        private System.Windows.Forms.Label labeInspData;
        private System.Windows.Forms.Button buttonRegInsp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxInspVehi;
        private System.Windows.Forms.ComboBox comboBoxInspMat;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}